using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : Block
{
	public Slot smeltingslot { get; private set; } = new Slot();
	public Slot fuelSlot { get; private set; } = new Slot();
	public Slot outputSlot { get; private set; } = new Slot();

	public float cookTimeTotal { get; private set; } = 10;
	public float cookTime { get; private set; } = 0;
	public float burnTimeTotal { get; private set; } = 0;
	public float burnTime { get; private set; } = 0;

	private void Awake()
	{
		specialAction = () => FurnaceUI.Instance.SetFurnace(this);
	}

	private void Update()
	{
		Item product = FurnaceData.GetProductItem(smeltingslot.Item);
		if (product != null && outputSlot.MaxAddAmount(product, 1) >= 1)
		{
			if (burnTime <= 0)
			{
				burnTimeTotal = FurnaceData.GetBurnTime(fuelSlot.Item);
				if(burnTimeTotal == 0)
				{
					burnTime = 0;
					cookTime = 0;
					return;
				}
				else
				{
					burnTime = burnTimeTotal;
					fuelSlot.Consume(1);
				}
			}
			burnTime -= Time.deltaTime;
			cookTime += Time.deltaTime;
			if(cookTime >= cookTimeTotal)
			{
				outputSlot.SetItemAmount(product, outputSlot.Amount + 1);
				smeltingslot.Consume(1);
				cookTime -= cookTimeTotal;
			}
			spriteRenderer.sprite = BlockData.blockData.furnaceLit;
		}
		else
		{
			burnTime -= Time.deltaTime;
			cookTime = 0;
			spriteRenderer.sprite = BlockData.blockData.furnaceUnlit;
		}
	}
}
