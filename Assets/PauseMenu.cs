using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	Canvas canvas;

	private void Awake()
	{
		canvas = GetComponent<Canvas>();
	}

	void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(!InventoryUI.Instance.open)
			{
				Toggle();
			}
		}
    }

	public void Toggle()
	{
		canvas.enabled = !canvas.enabled;
		Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
	}
}
