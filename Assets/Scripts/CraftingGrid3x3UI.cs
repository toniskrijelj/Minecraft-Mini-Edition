using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingGrid3x3UI : CraftingGridUI
{
	protected override int Size => 3;

	public static CraftingGrid3x3UI Instance { get; private set; }

	private Canvas canvas;

	protected override void Awake()
	{
		base.Awake();
		canvas = GetComponent<Canvas>();
		Instance = this;
		canvas.enabled = false;
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
			Open();
		}
	}

	protected override void InventoryUI_OnInventoryClosed()
	{
		base.InventoryUI_OnInventoryClosed();
		canvas.enabled = false;
	}

	public void Open()
	{
		canvas.enabled = true;
		InventoryUI.Instance.Open();
	}
}
