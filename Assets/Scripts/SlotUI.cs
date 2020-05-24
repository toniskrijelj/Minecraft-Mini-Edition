using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public static SlotUI mouseOverSlot { get; private set; }
	public Slot Slot { get; protected set; }
	protected Image icon;
	protected TextMeshProUGUI number;

	protected virtual void Awake()
	{
		icon = GetComponent<Image>();
		number = transform.Find("number").GetComponent<TextMeshProUGUI>();
	}

	public void SetSlot(Slot slot)
	{
		UnsetSlot();
		Slot = slot;
		slot.OnSlotChanged += Slot_OnSlotChanged;
		Refresh();
	}

	public virtual void Drop(bool all = false)
	{
		Slot.Drop(all);
	}

	private void OnEnable()
	{
		if(Slot != null)
		{
			Slot.OnSlotChanged += Slot_OnSlotChanged;
		}
	}
	private void OnDisable()
	{
		UnsetSlot();
	}

	private void UnsetSlot()
	{
		if (Slot != null)
		{
			Slot.OnSlotChanged -= Slot_OnSlotChanged;
			Slot = null;
		}
	}

	private void Slot_OnSlotChanged(int i)
	{
		Refresh();
	}

	public void SetSlotValues(Slot slot)
	{
		Slot.SetItemAmount(slot.Item, slot.Amount);
	}
	public void SetSlotValues(Item item, int amount)
	{
		Slot.SetItemAmount(item, amount);
	}

	public void Refresh()
	{
		icon.sprite = Slot.Item?.GetIcon();
		if (icon.sprite == null)
		{
			icon.color = Color.clear;
		}
		else
		{
			icon.color = Color.white;
		}
		number.text = Slot.Amount <= 1 ? "" : Slot.Amount.ToString();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		mouseOverSlot = this;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		mouseOverSlot = null;
	}
}
