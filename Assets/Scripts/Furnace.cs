using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FurnaceSaveData
{
	public int x, y, z;
	public SlotData smeltingSlot;
	public SlotData fuelSlot;
	public SlotData outputSlot;
	public float cookTime;
	public float burnTimeTotal;
	public float burnTime;

	public FurnaceSaveData(Furnace furnace)
	{
		smeltingSlot = new SlotData(furnace.smeltingslot);
		fuelSlot = new SlotData(furnace.fuelSlot);
		outputSlot = new SlotData(furnace.outputSlot);
		cookTime = furnace.cookTime;
		burnTimeTotal = furnace.burnTimeTotal;
		burnTime = furnace.burnTime;
	}
}


public class Furnace : Block
{
	public Slot smeltingslot { get; private set; }
	public Slot fuelSlot { get; private set; } = new Slot();
	public Slot outputSlot { get; private set; } = new Slot();

	public float cookTimeTotal { get; private set; } = 10;
	public float cookTime { get; private set; } = 0;
	public float burnTimeTotal { get; private set; } = 0;
	public float burnTime { get; private set; } = 0;

	private void Awake()
	{
		specialAction = () => FurnaceUI.Instance.SetFurnace(this);
		SetSmeltingSlot(new Slot());
	}

	private void SetSmeltingSlot(Slot slot)
	{
		if(smeltingslot != null)
		{
			smeltingslot.OnSlotItemChanged -= Smeltingslot_OnSlotItemChanged;
		}
		smeltingslot = slot;
		slot.OnSlotItemChanged += Smeltingslot_OnSlotItemChanged;
	}

	private void Smeltingslot_OnSlotItemChanged(int arg1, Item arg2)
	{
		cookTime = 0;
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
					spriteRenderer.sprite = BlockData.blockData.furnaceUnlit;
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

	protected override void OnDestroyed()
	{
		smeltingslot.Drop(true, transform.position);
		fuelSlot.Drop(true, transform.position);
		outputSlot.Drop(true, transform.position);
	}

	public FurnaceSaveData Save(int x, int y, int z)
	{
		return new FurnaceSaveData(this) { x = x, y = y, z = z };
	}

	public void Load(FurnaceSaveData saveData)
	{
		SetSmeltingSlot(saveData.smeltingSlot.GetSlot());
		fuelSlot = saveData.fuelSlot.GetSlot();
		outputSlot = saveData.outputSlot.GetSlot();

		burnTime = saveData.burnTime;
		burnTimeTotal = saveData.burnTimeTotal;
		cookTime = saveData.cookTime;
	}
}
