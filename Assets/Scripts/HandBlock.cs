using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBlock : MonoBehaviour
{
    [SerializeField] Transform handTransform = null;
    SpriteRenderer spriteRenderer;
    public void SetItem(Item item, ToolType toolType)
    {
        if(item != null && (toolType == ToolType.Axe || toolType == ToolType.Shovel))
        {
            spriteRenderer.transform.localEulerAngles = new Vector3(-180, 0, 135);
			spriteRenderer.transform.localPosition = new Vector3(-0.003f, 0.002f, 0);
		}
        else if(!(item is Item.SwordItem))
        {
            spriteRenderer.transform.localEulerAngles = new Vector3(-180, 0, 45);
			spriteRenderer.transform.localPosition = new Vector3(-0.003f, 0.002f, 0);
		}
		else
		{
			spriteRenderer.transform.localEulerAngles = new Vector3(-180, 0, 90);
			spriteRenderer.transform.localPosition = new Vector3(-0.003f, -0.002f, 0);
		}
        spriteRenderer.sprite = item?.GetIcon();
    }
    private void Awake()
    {
        spriteRenderer = new GameObject("Hand Item", typeof(SpriteRenderer)).GetComponent<SpriteRenderer>();
        spriteRenderer.transform.parent = handTransform;
        spriteRenderer.transform.localPosition = new Vector3(-0.003f, 0.002f, 0);
        spriteRenderer.transform.localScale *= 1.5f;
    }
}
