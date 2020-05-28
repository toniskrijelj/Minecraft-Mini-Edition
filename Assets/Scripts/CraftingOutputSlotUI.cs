using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class CraftingOutputSlotUI : SlotUI, IPointerDownHandler
{
	[SerializeField] Inventory inventory = null;

	public event Action OnItemTaken;

	public void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right || eventData.button == PointerEventData.InputButton.Left)
		{
			if (Slot.Item != null)
			{
				if (!Input.GetKey(KeyCode.LeftShift))
				{
					if (MouseSlotUI.Instance.Slot.MaxAddAmount(Slot.Item, Slot.Amount) >= Slot.Amount)
					{
						MouseSlotUI.Instance.Slot.SetItemAmount(Slot.Item, MouseSlotUI.Instance.Slot.Amount + Slot.Amount);
						OnItemTaken?.Invoke();
					}
				}
				else
				{
					while(Slot.Item != null)
					{
						if(inventory.MaxAdd(Slot.Item, Slot.Amount) >= Slot.Amount)
						{
							inventory.Add(Slot.Item, Slot.Amount);
							OnItemTaken?.Invoke();
						}
						else
						{
							break;
						}
					}
				}
			}
		}
	}

	public override void QuickTake(SlotUI toSlot)
	{
		if(toSlot.Slot.MaxAddAmount(Slot.Item, Slot.Amount) >= Slot.Amount)
		{
			toSlot.Slot.SetItemAmount(Slot.Item, Slot.Amount + toSlot.Slot.Amount);
			OnItemTaken?.Invoke();
		}
	}

	public override void Drop(bool all = false)
	{
		if (Slot.Item != null)
		{
			if (!all)
			{
				ItemEntity.Spawn(Player.Instance.transform.position, Slot.Item, Slot.Amount);
				OnItemTaken?.Invoke();
			}
			else
			{
				while (Slot.Item != null)
				{
					ItemEntity.Spawn(Player.Instance.transform.position, Slot.Item, Slot.Amount);
					OnItemTaken?.Invoke();
				}
			}
		}
	}
}
