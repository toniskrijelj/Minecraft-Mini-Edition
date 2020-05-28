using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeveloperConsole : MonoBehaviour
{
    string input;
    TextMeshProUGUI text;
    Canvas canvas;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
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
            Debug.Log(input);
            input = "";
        }
        else
        {
            input += c;
        }
        text.text = input;
    }
}
