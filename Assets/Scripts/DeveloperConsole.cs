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
		Commands.Add("/spawn", Spawn);

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
		if (input != null && input.Length > 0)
		{
			if (input[0] == '/')
			{
				string[] words = input.Split(' ');
				if (words != null && words.Length > 0)
				{
					if (Commands.ContainsKey(words[0]))
					{
						string command = words[0];
						List<string> temp = new List<string>(words);
						temp.RemoveAt(0);
						words = temp.ToArray();
						Commands[command](words);
					}
				}
			}
		}
	}

	private void Give(params string[] arguments)
	{
		if (arguments.Length == 2)
		{
			var fields = typeof(Item).GetFields();
			Item current = Item.GetItem(arguments[0].ToLower());
			if (current != null)
			{
				if (int.TryParse(arguments[1], out int number))
				{
					Inventory.Instance.Add(current, number);
				}
			}

		}
	}

	private void Spawn(params string[] arguments)
	{
		if (arguments.Length == 1)
		{
			arguments[0] = arguments[0].ToLower();
			if (arguments[0] == "on")
			{
				MobSwpawn.Instance.SetActive(true);
			}
			else if(arguments[0] == "off")
			{
				MobSwpawn.Instance.SetActive(false);
				foreach(var mob in FindObjectsOfType<Mob>())
				{
					Destroy(mob.gameObject);
				}
			}
		}
	}

	}
