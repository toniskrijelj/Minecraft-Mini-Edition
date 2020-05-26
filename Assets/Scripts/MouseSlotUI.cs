using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MouseSlotUI : SlotUI
{
	public static MouseSlotUI Instance { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		Instance = this;
		SetSlot(new Slot());
	}

	private void Start()
	{
		InventoryUI.Instance.OnInventoryClosed += InventoryUI_OnInventoryClosed;
	}

	private void InventoryUI_OnInventoryClosed()
	{
		Drop(true);
	}

	void Update()
    {
		transform.position = Input.mousePosition;
    }
}
