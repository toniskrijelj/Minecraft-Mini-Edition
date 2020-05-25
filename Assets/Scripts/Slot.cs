using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

	public Item Item { get; private set; }
	public int Amount { get; private set; }
	public int Index { get; private set; }

	public int AddAmount(int amount)
	{
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
		return Mathf.Min(maxAdd, amount);
	}
	
	public int Consume(int amount)
	{
		int consumed = Mathf.Min(Amount, amount);
		Amount -= consumed;
		if(Amount <= 0)
		{
			Item = null;
			Amount = 0;
		}
		OnSlotChanged?.Invoke(Index);
		return consumed;
	}

	public bool TrySetItem(Item item)
	{
		if(Item == null || Item == item)
		{
			if (Item == null)
			{
				Item = item;
				OnSlotChanged?.Invoke(Index);
			}
			return true;
		}
		return false;
	}

	public void SetItem(Item item)
	{
		Item = item;
		OnSlotChanged?.Invoke(Index);
	}

	public void SetAmount(int amount)
	{
		Amount = Mathf.Max(amount, 0);
		if(Amount == 0)
		{
			Item = null;
		}
		Amount = amount;
		OnSlotChanged?.Invoke(Index);
	}
	
	public void SetItemAmount(Item item, int amount)
	{
		Item = item;
		Amount = amount;
		OnSlotChanged?.Invoke(Index);
	}

	public void Drop(bool all = false)
	{
		if (Item != null)
		{
			ItemEntity.Spawn(Player.Instance.transform.position, Item, all ? Amount : 1);
			Consume(all ? Amount : 1);
		}
	}
}
