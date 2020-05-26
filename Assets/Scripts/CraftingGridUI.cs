using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class CraftingGridUI : MonoBehaviour
{
	protected abstract int Size { get; }

	protected InventorySlotUI[] craftingSlots;
	private CraftingOutputSlotUI outputSlot;

	private readonly Item[,] layout = new Item[3, 3];

	protected virtual void Awake()
	{
		craftingSlots = new InventorySlotUI[Size * Size];
		for (int i = 0; i < craftingSlots.Length; i++)
		{
			craftingSlots[i] = transform.Find("slot (" + i + ")").GetComponent<InventorySlotUI>();

		}
		outputSlot = transform.Find("output").GetComponent<CraftingOutputSlotUI>();
	}

	private void Start()
	{
		for (int i = 0; i < craftingSlots.Length; i++)
		{
			craftingSlots[i].SetSlot(new Slot(null, 0, i));
			craftingSlots[i].Slot.OnSlotItemChanged += CraftingSlot_OnSlotItemChanged;
		}
		outputSlot.SetSlot(new Slot(null, 0));
		outputSlot.OnItemTaken += OutputSlot_OnItemTaken;
		InventoryUI.Instance.OnInventoryClosed += InventoryUI_OnInventoryClosed;
	}

	protected virtual void InventoryUI_OnInventoryClosed()
	{
		for(int i = 0; i < craftingSlots.Length; i++)
		{
			craftingSlots[i].Drop(true);
		}
	}

	private void OutputSlot_OnItemTaken()
	{
		for (int i = 0; i < craftingSlots.Length; i++)
		{
			craftingSlots[i].Slot.Consume(1);
		}
	}

	private void CraftingSlot_OnSlotItemChanged(int index, Item oldItem)
	{
		layout[index / Size, index % Size] = craftingSlots[index].Slot.Item;
		outputSlot.SetSlotValues(Recipes.TryCraft(layout));
	}
}
