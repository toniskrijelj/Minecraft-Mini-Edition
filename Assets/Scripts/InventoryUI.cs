using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryUI : MonoBehaviour
{
    RectTransform[] slots = new RectTransform[9];

    RectTransform selected;
    void Awake()
    {
        selected = (RectTransform)transform.Find("Selected");
        for(int i = 0; i<9; i++)
        {
            slots[i] = (RectTransform)transform.Find("Slot" + (i+1));
            if(slots[i] == null)
            {
                Debug.Log("Pa lol");
            }
        }
    }
    void Update()
    {
        for(int i = 0; i<9; i++)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1+i))
            {
                selected.anchoredPosition = slots[i].anchoredPosition;
                break;
            }
        }
    }
}
