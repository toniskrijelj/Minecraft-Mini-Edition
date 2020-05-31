using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChestData
{
	public int x, y, z;
	public SlotData[] slots;

	public ChestData(Chest chest)
	{
		slots = new SlotData[27];
		for(int i = 0; i < 27; i++)
		{
			slots[i] = new SlotData(chest.slots[i]);
		}
	}
}

public class Chest : Block
{
	public readonly Slot[] slots = new Slot[27];

	private void Awake()
	{
		specialAction = () => ChestUI.Instance.SetChest(this);
		for(int i = 0; i < 27; i++)
		{
			slots[i] = new Slot(null, 0, i);
		}
	}

	protected override void OnDestroyed()
	{
		for (int i = 0; i < 27; i++)
		{
			slots[i].Drop(true, transform.position);
		}
	}

	public ChestData Save(int x, int y, int z)
	{
		return new ChestData(this) { x = x, y = y, z = z };
	}
	
	public void Load(ChestData chestData)
	{
		for(int i = 0; i < 27; i++)
		{
			slots[i] = chestData.slots[i].GetSlot();
		}
	}
}
