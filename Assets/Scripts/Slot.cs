using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SlotData
{
	public string itemName;
	public int amount;
	public int index;

	public SlotData(Slot slot)
	{
		if (slot.Item == null)
		{
			itemName = "";
		}
		else
		{
			itemName = slot.Item.DisplayName.ToLower();
		}
		amount = slot.Amount;
		index = slot.Index;
	}

	public Slot GetSlot()
	{
		return new Slot(Item.GetItem(itemName), amount, index);
	}
}

public class Slot
{
	public Slot() { }
	public Slot(Item item, int amount, int index = -1)
	{
		Item = item;
		Amount = amount;
		Index = index;
	}

	public event Action<int> OnSlotChanged;
	/// <summary>
	/// arg1 = index, arg2 = old item
	/// </summary>
	public event Action<int, Item> OnSlotItemChanged;
	/// <summary>
	/// arg1 = index, arg2 = old amount
	/// </summary>
	public event Action<int, int> OnSlotAmountChanged;

	public Item Item { get; private set; }
	public int Amount { get; private set; }
	public int Index { get; private set; }

	/// <summary>
	/// Returns int that represents amount of items that could be added
	/// </summary>
	public int MaxAddAmount(Item item, int amount)
	{
		if(Item == null)
		{
			if(item.stackable)
			{
				return Mathf.Min(64, amount);
			}
			return Mathf.Min(1, amount);
		}
		if(Item == item && item.stackable)
		{
			return Mathf.Min(64 - Amount, amount);
		}
		else if (Amount <= 0)
		{
			return 1;
		}
		return 0;
	}

	public int AddAmount(int amount)
	{
		int oldAmount = Amount;
		int maxAdd = 0;
		if (Item.stackable)
		{
			maxAdd = 64 - Amount;
			Amount += Mathf.Min(maxAdd, amount);
		}
		else if(Amount <= 0)
		{
			Amount = 1;
			maxAdd = 1;
		}
		OnSlotChanged?.Invoke(Index);
		OnSlotAmountChanged?.Invoke(Index, oldAmount);
		return Mathf.Min(maxAdd, amount);
	}
	
	public int Consume(int amount)
	{
		if(Amount <= 0)
		{
			Amount = 0;
			return 0;
		}
		Item oldItem = Item;
		int oldAmount = Amount;
		int consumed = Mathf.Min(Amount, amount);
		Amount -= consumed;
		if(Amount <= 0)
		{
			Item = null;
			if (oldItem != null)
			{
				OnSlotItemChanged?.Invoke(Index, oldItem);
			}
			Amount = 0;
		}
		OnSlotAmountChanged?.Invoke(Index, oldAmount);
		OnSlotChanged?.Invoke(Index);
		return consumed;
	}

	public bool CanSetItem(Item item)
	{
		return Item == null || Item == item;
	}

	public bool TrySetItem(Item item)
	{
		Item oldItem = Item;
		if(CanSetItem(item))
		{
			if (Item == null)
			{
				Item = item;
				OnSlotChanged?.Invoke(Index);
				OnSlotItemChanged?.Invoke(Index, oldItem);
			}
			return true;
		}
		return false;
	}

	public void SetItem(Item item)
	{
		Item oldItem = Item;
		Item = item;
		OnSlotChanged?.Invoke(Index);
		OnSlotItemChanged?.Invoke(Index, oldItem);
	}

	public void SetAmount(int amount)
	{
		Item oldItem = Item;
		int oldAmount = Amount;
		Amount = Mathf.Max(amount, 0);
		if(Amount == 0)
		{
			Item = null;
			OnSlotItemChanged?.Invoke(Index, oldItem);
		}
		Amount = amount;
		OnSlotChanged?.Invoke(Index);
		OnSlotAmountChanged?.Invoke(Index, oldAmount);
	}
	
	public void SetItemAmount(Item item, int amount)
	{
		Item oldItem = Item;
		int oldAmount = Amount;
		Item = item;
		Amount = amount;
		OnSlotChanged?.Invoke(Index);
		OnSlotItemChanged?.Invoke(Index, oldItem);
		OnSlotAmountChanged?.Invoke(Index, oldAmount);
	}

	public void Drop(bool all = false, Vector3? position = null)
	{
		if(position == null)
		{
			position = Player.Instance.transform.position;
		}
		if (Item != null)
		{
			ItemEntity.Spawn((Vector3)position, Item, all ? Amount : 1);
			Consume(all ? Amount : 1);
		}
	}
}
