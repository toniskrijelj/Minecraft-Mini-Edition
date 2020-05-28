using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DeveloperConsole : MonoBehaviour
{
	Dictionary<string, Action<string[]>> Commands;

    string input;
    TextMeshProUGUI text;
    Canvas canvas;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
		Commands = new Dictionary<string, Action<string[]>>();
		Commands.Add("/give", Give);

    }
    private void Update()
    {
        if(InventoryUI.Instance.open)
        {
            return;
        }
        if(canvas.enabled)
        {
            ReceiveFrameInput(Input.inputString);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Player.Instance.enabled = !Player.Instance.enabled;
            InventoryUI.Instance.locked = !canvas.enabled;
            canvas.enabled = !canvas.enabled;
        }
    }
    public void ReceiveFrameInput(string input)
    {
        foreach (char c in input)
        {
            UpdateCurrentInputLine(c);
        }
    }
    private void UpdateCurrentInputLine(char c)
    {
        if (c == '\b')
        {
            if(input.Length > 0)
            {
                input = input.Remove(input.Length - 1, 1);
            }
        }
        else if (c == '\n' || c == '\r')
        {
			CheckCommand();
            input = "";
        }
        else
        {
            input += c;
        }
        text.text = input;
    }

	private void CheckCommand()
	{
		if(input[0] == '/')
		{
			string[] words = input.Split(' ');
			if(Commands.ContainsKey(words[0]))
			{
				string command = words[0];
				List<string> kurcina = new List<string>(words);
				kurcina.RemoveAt(0);
				words = kurcina.ToArray();
				Commands[command](words);
			}
		}
	}

	private void Give(params string[] arguments)
	{
		var fields = typeof(Item).GetFields();
		foreach (var item in fields)
		{
			if (item.FieldType == typeof(Item))
			{
				Item current = (Item)item.GetValue(null);
				if (current.DisplayName == arguments[0])
				{
					Inventory.Instance.Add(current, int.Parse(arguments[1]));
					break;
				}
			}
		}
	}
	
}
