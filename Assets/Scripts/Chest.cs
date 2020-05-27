using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	private void OnDestroy()
	{
		for (int i = 0; i < 27; i++)
		{
			slots[i].Drop(true, transform.position);
		}
	}
}
