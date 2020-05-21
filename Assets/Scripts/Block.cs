using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block
{
	public string Name { get; }
	public float Hardness { get; }
	public ToolType ToolType { get; }
	public ToolMaterial ToolMaterial { get; }
	public GameObject GameObject { get; }

	public Block(float hardness, ToolType toolType, ToolMaterial toolMaterial, SpriteRenderer spriteRenderer, string name = "", Sprite texture = null)
	{
		Name = name;
		GameObject = spriteRenderer.gameObject;
		Hardness = hardness;
		ToolMaterial = toolMaterial;
		ToolType = toolType;
		spriteRenderer.sprite = texture;
	}

	~Block()
	{
		if(GameObject != null)
		{
			Object.Destroy(GameObject);
		}
	}
}
