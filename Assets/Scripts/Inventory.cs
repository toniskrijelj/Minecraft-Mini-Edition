using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
	public const int SLOTS = 36;
	public event Action<int> OnSlotChanged;
	public event Action<int> OnActiveSlotChanged;
	public readonly Slot[] slots = new Slot[SLOTS];
	Player player;

	private void Awake()
	{
		player = GetComponent<Player>();
		for(int i = 0; i < SLOTS; i++)
		{
			slots[i] = new Slot(null, 0, i);
		}
		slots[0].SetItemAmount(Item.WoodenPickaxe, 1);
		slots[1].SetItemAmount(Item.StonePickaxe, 1);
		slots[2].SetItemAmount(Item.IronPickaxe, 1);
		slots[3].SetItemAmount(Item.GoldPickaxe, 1);
		slots[4].SetItemAmount(Item.DiamondPickaxe, 1);
		slots[5].SetItemAmount(Item.WoodenAxe, 1);
		slots[6].SetItemAmount(Item.StoneAxe, 1);
		slots[7].SetItemAmount(Item.IronAxe, 1);
		slots[8].SetItemAmount(Item.GoldenAxe, 1);
		slots[9].SetItemAmount(Item.DiamondAxe, 1);
		slots[10].SetItemAmount(Item.CoalOre, 64);
		slots[11].SetItemAmount(Item.IronOre, 64);
		slots[12].SetItemAmount(Item.DiamondOre, 64);
		slots[13].SetItemAmount(Item.CraftingTable, 64);
		slots[14].SetItemAmount(Item.OakLog, 64);
		slots[15].SetItemAmount(Item.Sand, 64);
		player.ChangeHandSlot(slots[0]);
	}

	private void OnEnable()
	{
		for (int i = 0; i < SLOTS; i++)
		{
			slots[i].OnSlotChanged += OnSlotChanged;
		}
	}
	private void OnDisable()
	{
		for (int i = 0; i < SLOTS; i++)
		{
			slots[i].OnSlotChanged -= OnSlotChanged;
		}
	}

	private void Update()
	{
		if (!player.enabled) return;


		float mouseScroll = Input.GetAxisRaw("Mouse ScrollWheel");
		if(mouseScroll < 0)
		{
			int index = player.HandSlot.Index;
			index = (index + 1) % 9;
			SetActiveSlot(index);
		}
		else if(mouseScroll > 0)
		{
			int index = player.HandSlot.Index;
			index -= 1;
			if (index <= -1)
			{
				index = 8;
			}
			SetActiveSlot(index);
		}
		for (int i = 0; i < 9; i++)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1 + i))
			{
				SetActiveSlot(i);
				break;
			}
		}
		if(Input.GetKeyDown(KeyCode.Q))
		{
			if (player.HandSlot != null)
			{
				Drop(player.HandSlot.Index, Input.GetKey(KeyCode.LeftControl));
			}
		}
		if(Input.GetKeyDown(KeyCode.P))
		{
			Add(Item.OakPlanks, 16);
		}
	}

	public void SetActiveSlot(int index)
	{
		index = Mathf.Clamp(index, 0, 8);
		player.ChangeHandSlot(slots[index]);
		OnActiveSlotChanged?.Invoke(index);
	}

	public int MaxAdd(Item item, int amount)
	{
		int couldBeAdded = 0;
		for (int i = 0; i < SLOTS; i++)
		{
			couldBeAdded += slots[i].MaxAddAmount(item, amount - couldBeAdded);
			if (couldBeAdded == amount)
			{
				break;
			}
		}
		return couldBeAdded;
	}

	public int Add(Item item, int amount)
	{
		int amountAdded = 0;
		for(int i = 0; i < SLOTS; i++)
		{
			if(slots[i].TrySetItem(item))
			{
				amountAdded += slots[i].AddAmount(amount - amountAdded);
				if(amountAdded == amount)
				{
					break;
				}
			}
		}
		return amountAdded;
	}

	public void Remove(int index, int amount)
	{
		slots[index].Consume(amount);
	}

	public void Drop(int index, bool all = false)
	{
		slots[index].Drop(all);
	}
}
