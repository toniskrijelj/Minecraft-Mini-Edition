using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MouseSlotUI : SlotUI
{
	public static MouseSlotUI Instance { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		Instance = this;
		SetSlot(new Slot());
	}

	void Update()
    {
		transform.position = Input.mousePosition;
    }
}
