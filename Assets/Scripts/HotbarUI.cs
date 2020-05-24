using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HotbarUI : MonoBehaviour
{
	[SerializeField] private Inventory inventory = null;
	private readonly SlotUI[] slots = new SlotUI[9];

    private RectTransform selected;

    void Awake()
    {
        selected = (RectTransform)transform.Find("Selected");
        for(int i = 0; i<9; i++)
        {
            slots[i] = transform.Find("Slot" + (i+1)).GetComponent<SlotUI>();
        }
    }
	private void Start()
	{
		for (int i = 0; i < 9; i++)
		{
			slots[i].SetSlot(inventory.slots[i]);
		}
	}

	private void OnEnable()
	{
		inventory.OnActiveSlotChanged += Inventory_OnActiveSlotChanged;
	}

	private void OnDisable()
	{
		inventory.OnActiveSlotChanged -= Inventory_OnActiveSlotChanged;
	}

	private void Inventory_OnActiveSlotChanged(int i)
	{
		selected.anchoredPosition = ((RectTransform)slots[i].transform).anchoredPosition;
	}
}
