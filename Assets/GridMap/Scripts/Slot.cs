using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot
{
	public Item item { get; private set; }
	public int amount { get; private set; }

	public int AddAmount(int amount)
	{
		int maxAdd = 0;
		if (item.stackable)
		{
			maxAdd = 64 - this.amount;
			this.amount += Mathf.Min(maxAdd, amount);
		}
		return Mathf.Min(maxAdd, amount);
	}
	
	public int Consume(int amount)
	{
		int consumed = Mathf.Min(this.amount, amount);
		this.amount -= consumed;
		if(this.amount <= 0)
		{
			item = null;
			this.amount = 0;
		}
		return consumed;
	}

	public bool SetItem(Item item)
	{
		if(this.item == null || this.item == item)
		{
			this.item = item;
			return true;
		}
		return false;
	}
}
