using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnaceUI : MonoBehaviour
{
	public static FurnaceUI Instance { get; private set; }

	bool furnaceSet;
	Furnace furnace;
	

	private Canvas canvas;
	private Image arrow;
	private Image fire;

	public InventorySlotUI smeltingSlot { get; private set; }
	public InventorySlotUI fuelSlot { get; private set; }
	public FurnaceOutputSlotUI outputSlot { get; private set; }

	private void Awake()
	{
		Instance = this;
		fire = transform.Find("fire").GetComponent<Image>();
		arrow = transform.Find("arrow").GetComponent<Image>();
		smeltingSlot = transform.Find("smeltingSlot").GetComponent<InventorySlotUI>();
		fuelSlot = transform.Find("fuelSlot").GetComponent<InventorySlotUI>();
		outputSlot = transform.Find("output").GetComponent<FurnaceOutputSlotUI>();
		canvas = GetComponent<Canvas>();
	}

	private void Start()
	{
		InventoryUI.Instance.OnInventoryClosed += InventoryUI_OnInventoryClosed;
	}

	private void Update()
	{
		if(furnaceSet)
		{
			if (furnace.burnTimeTotal != 0)
			{
				fire.fillAmount = furnace.burnTime / furnace.burnTimeTotal;
			}
			else
			{
				fire.fillAmount = 0;
			}
			arrow.fillAmount = furnace.cookTime / furnace.cookTimeTotal;
		}
	}

	private void InventoryUI_OnInventoryClosed()
	{
		canvas.enabled = false;
		furnaceSet = false;
		furnace = null;
	}

	public void SetFurnace(Furnace furnace)
	{
		furnaceSet = true;
		this.furnace = furnace;
		InventoryUI.Instance.Open();
		canvas.enabled = true;
		smeltingSlot.SetSlot(furnace.smeltingslot);
		fuelSlot.SetSlot(furnace.fuelSlot);
		outputSlot.SetSlot(furnace.outputSlot);
	}
}
