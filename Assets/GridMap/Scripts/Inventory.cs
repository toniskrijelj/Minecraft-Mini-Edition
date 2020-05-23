using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	private const int SLOTS = 36;

	Slot[] slots = new Slot[SLOTS];
	Player player;

	private void Awake()
	{
		player = GetComponent<Player>();
	}

	public void SetActiveSlot(int index)
	{
		index = Mathf.Clamp(index, 0, 8);
		player.ChangeHandSlot(slots[index]);
	}

	public int Add(Item item, int amount)
	{
		int amountAdded = 0;
		for(int i = 0; i < SLOTS; i++)
		{
			if(slots[i].SetItem(item))
			{
				amountAdded += slots[i].AddAmount(amount - amountAdded);
				if(amountAdded == amount)
				{
					break;
				}
			}
		}
		return amountAdded;
	}

	public void Remove(int index, int amount)
	{
		slots[index].Consume(amount);
	}

	public void Drop(int index, bool all = false)
	{
		int dropped = slots[index].Consume(all ? slots[index].amount : 1);
		// ItemEntity spawn amount = dropped
	}
}
