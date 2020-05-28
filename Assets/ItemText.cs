using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemText : MonoBehaviour
{
	public static ItemText Instance { get; private set; }

	private TextMeshProUGUI text;

	private void Awake()
	{
		Instance = this;
		text = GetComponent<TextMeshProUGUI>();
	}

	Color color = new Color(1, 1, 1, 1);
	float lastSetTime = 0;

	private void Update()
	{
		if(Time.time > lastSetTime + 2)
		{
			color.a -= Time.deltaTime;
			text.color = color;
		}
	}

	public void SetItem(Item item)
	{
		color.a = 1;
		text.color = color;
		if(item == null)
		{
			text.text = "";
		}
		else
		{
			text.text = item.DisplayName;
		}
		lastSetTime = Time.time;
	}
}
