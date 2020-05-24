using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
	public const int SLOTS = 36;
	public event Action<int> OnSlotChanged;
	public event Action<int> OnActiveSlotChanged;
	public readonly Slot[] slots = new Slot[SLOTS];
	Player player;

	private void Awake()
	{
		player = GetComponent<Player>();
		for(int i = 0; i < SLOTS; i++)
		{
			slots[i] = new Slot(null, 0, i);
		}
		player.ChangeHandSlot(slots[0]);
	}

	private void OnEnable()
	{
		for (int i = 0; i < SLOTS; i++)
		{
			slots[i].OnSlotChanged += OnSlotChanged;
		}
	}
	private void OnDisable()
	{
		for (int i = 0; i < SLOTS; i++)
		{
			slots[i].OnSlotChanged -= OnSlotChanged;
		}
	}

	private void Update()
	{
		if (!player.enabled) return;


		float mouseScroll = Input.GetAxisRaw("Mouse ScrollWheel");
		if(mouseScroll < 0)
		{
			int index = player.HandSlot.Index;
			index -= 1;
			if(index <= -1)
			{
				index = 8;
			}
			SetActiveSlot(index);
		}
		else if(mouseScroll > 0)
		{
			int index = player.HandSlot.Index;
			index = (index + 1) % 9;
			SetActiveSlot(index);
		}
		for (int i = 0; i < 9; i++)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1 + i))
			{
				SetActiveSlot(i);
				break;
			}
		}
		if(Input.GetKeyDown(KeyCode.Q))
		{
			if (player.HandSlot != null)
			{
				Drop(player.HandSlot.Index, Input.GetKey(KeyCode.LeftControl));
			}
		}
		if(Input.GetKeyDown(KeyCode.P))
		{
			Add(Item.OakPlanks, 16);
		}
	}

	public void SetActiveSlot(int index)
	{
		index = Mathf.Clamp(index, 0, 8);
		player.ChangeHandSlot(slots[index]);
		OnActiveSlotChanged?.Invoke(index);
	}

	public int Add(Item item, int amount)
	{
		int amountAdded = 0;
		for(int i = 0; i < SLOTS; i++)
		{
			if(slots[i].TrySetItem(item))
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
		slots[index].Drop(all);
	}
}
