using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FurnaceOutputSlotUI : SlotUI, IPointerDownHandler
{
	[SerializeField] Inventory inventory;

	public void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right || eventData.button == PointerEventData.InputButton.Left)
		{
			if (Slot.Item != null)
			{
				if (!Input.GetKey(KeyCode.LeftShift))
				{
					int maxAdd = MouseSlotUI.Instance.Slot.MaxAddAmount(Slot.Item, Slot.Amount);
					MouseSlotUI.Instance.Slot.SetItemAmount(Slot.Item, MouseSlotUI.Instance.Slot.Amount + maxAdd);
					Slot.Consume(maxAdd);
				}
				else
				{
					int added = inventory.Add(Slot.Item, Slot.Amount);
					Slot.Consume(added);
				}
			}
		}
	}
}
