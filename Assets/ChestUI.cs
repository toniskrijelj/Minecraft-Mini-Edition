using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestUI : MonoBehaviour
{
	public static ChestUI Instance { get; private set; }

	Chest chest;

	private Canvas canvas;

	public readonly InventorySlotUI[] slots = new InventorySlotUI[27];

	private void Awake()
	{
		Instance = this;
		canvas = GetComponent<Canvas>();
		for(int i = 0; i < 27; i++)
		{
			slots[i] = transform.Find("slot (" + i + ")").GetComponent<InventorySlotUI>();
		}
	}

	private void Start()
	{
		InventoryUI.Instance.OnInventoryClosed += InventoryUI_OnInventoryClosed;
	}

	private void InventoryUI_OnInventoryClosed()
	{
		canvas.enabled = false;
	}

	public void SetChest(Chest chest)
	{
		this.chest = chest;
		InventoryUI.Instance.Open();
		canvas.enabled = true;
		for(int i = 0; i < 27; i++)
		{
			slots[i].SetSlot(chest.slots[i]);
		}
	}
}
