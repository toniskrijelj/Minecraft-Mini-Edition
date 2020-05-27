using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class InventoryUI : MonoBehaviour
{
	public static InventoryUI Instance { get; private set; }

	public event Action OnInventoryClosed;

	[SerializeField] Inventory inventory = null;

	Canvas canvas;
	private readonly InventorySlotUI[] slots = new InventorySlotUI[Inventory.SLOTS];

	private void Awake()
	{
		canvas = GetComponent<Canvas>();
		Instance = this;
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
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(canvas.enabled)
			{
				Close();
			}
		}
		if(Input.GetKeyDown(KeyCode.E))
		{
			if(canvas.enabled)
			{
				Close();
			}
			else
			{
				Open();
			}
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
			for (int i = 0; i < 9; i++)
			{
				if (Input.GetKeyDown(KeyCode.Alpha1 + i))
				{
					SlotUI.mouseOverSlot.QuickTake(slots[i]);
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

	public void Open()
	{
		canvas.enabled = true;
		Player.Instance.enabled = false;
	}

	public void Close()
	{
		canvas.enabled = false;
		Player.Instance.enabled = true;
		OnInventoryClosed?.Invoke();
	}
}
