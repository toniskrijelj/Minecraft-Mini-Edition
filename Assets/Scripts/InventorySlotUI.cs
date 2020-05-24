using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotUI : SlotUI, IPointerDownHandler
{
	private static Slot lastSlotClicked = null;

	public void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			if(MouseSlotUI.Instance.Slot.Amount <= 0)
			{
				MouseSlotUI.Instance.Slot.SetItemAmount(Slot.Item, Slot.Amount / 2);
				Slot.Consume(Slot.Amount / 2);
			}
			else if(Slot.TrySetItem(MouseSlotUI.Instance.Slot.Item))
			{
				int amount = Slot.AddAmount(1);
				MouseSlotUI.Instance.Slot.Consume(amount);
			}
		}
		else if(eventData.button == PointerEventData.InputButton.Left)
		{
			if(!Input.GetKey(KeyCode.LeftShift))
			{
				if (Slot.Item != null && MouseSlotUI.Instance.Slot.Item == Slot.Item)
				{
					int amount = Slot.AddAmount(MouseSlotUI.Instance.Slot.Amount);
					MouseSlotUI.Instance.Slot.Consume(amount);
				}
				else
				{
					Item tempItem = Slot.Item;
					int tempAmount = Slot.Amount;
					SetSlotValues(MouseSlotUI.Instance.Slot);
					MouseSlotUI.Instance.SetSlotValues(tempItem, tempAmount);
					lastSlotClicked = Slot;
				}
			}
		}
	}
}
