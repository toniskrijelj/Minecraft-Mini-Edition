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
	bool harvested = false;

	float totalDamage;
	float currentDamage;

	public Block(float hardness, ToolType toolType, ToolMaterial toolMaterial, SpriteRenderer spriteRenderer, string name = "", Sprite texture = null)
	{
		Name = name;
		GameObject = spriteRenderer.gameObject;
		Hardness = hardness;
		ToolMaterial = toolMaterial;
		ToolType = toolType;
		spriteRenderer.sprite = texture;
		totalDamage = hardness;
	}

	~Block()
	{
		if(GameObject != null)
		{
			Object.Destroy(GameObject);
		}
	}

	public float Percentage()
	{
		return currentDamage / totalDamage;
	}

	public void Repair()
	{
		currentDamage = 0;
	}

	public bool Damage(ToolType toolType, ToolMaterial toolMaterial)
	{
		if(toolType.CanHarvest(ToolType))
		{
			float multiplier = toolType.RightTool(ToolType) ? toolMaterial.Multiplier : 1;
			currentDamage += Time.deltaTime * multiplier * 0.666666f;
			if(currentDamage >= totalDamage)
			{
				harvested = true;
			}
		}
		else
		{
			currentDamage += Time.deltaTime * 0.2f;
		}
		return currentDamage >= totalDamage;
	}
}
