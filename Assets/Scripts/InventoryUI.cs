using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUI : MonoBehaviour
{
	[SerializeField] Inventory inventory = null;

	Canvas canvas;
	private readonly InventorySlotUI[] slots = new InventorySlotUI[Inventory.SLOTS];

	private void Awake()
	{
		canvas = GetComponent<Canvas>();
		for(int i = 0; i < Inventory.SLOTS; i++)
		{
			slots[i] = transform.Find("slot (" + i + ")").GetComponent<InventorySlotUI>();
		}
	}

	private void Start()
	{
		SetInventory(inventory);
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.E))
		{
			canvas.enabled = !canvas.enabled;
			Player.Instance.enabled = !Player.Instance.enabled;
		}
		if(Input.GetKeyDown(KeyCode.Q))
		{
			if(SlotUI.mouseOverSlot != null)
			{
				SlotUI.mouseOverSlot.Drop(Input.GetKey(KeyCode.LeftControl));
			}
		}
		if(Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftShift))
		{
			if(SlotUI.mouseOverSlot != null)
			{
				Item item = SlotUI.mouseOverSlot.Slot.Item;
				int amount = SlotUI.mouseOverSlot.Slot.Amount;
				if (item != null && amount > 0)
				{
					SlotUI.mouseOverSlot.Slot.SetAmount(0);
					inventory.Add(item, amount);
				}
			}
		}
		if (SlotUI.mouseOverSlot != null)
		{
			for (int i = 0; i < 8; i++)
			{
				if (Input.GetKeyDown(KeyCode.Alpha1 + i))
				{
					if (SlotUI.mouseOverSlot.Slot.Item != null && slots[i].Slot.TrySetItem(SlotUI.mouseOverSlot.Slot.Item))
					{
						int amount = slots[i].Slot.AddAmount(SlotUI.mouseOverSlot.Slot.Amount);
						SlotUI.mouseOverSlot.Slot.Consume(amount);
					}
					else
					{
						Item tempItem = slots[i].Slot.Item;
						int tempAmount = slots[i].Slot.Amount;
						slots[i].SetSlotValues(SlotUI.mouseOverSlot.Slot);
						SlotUI.mouseOverSlot.SetSlotValues(tempItem, tempAmount);
					}
					break;
				}
			}
		}
	}

	public void SetInventory(Inventory inventory)
	{
		this.inventory = inventory;
		for(int i = 0; i < Inventory.SLOTS; i++)
		{
			slots[i].SetSlot(inventory.slots[i]);
		}
	}
}
