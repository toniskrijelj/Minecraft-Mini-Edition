using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	private static Block prefab;
	public static Block Prefab
	{
		get
		{
			if(prefab == null)
			{
				prefab = Resources.Load<Block>("BlockPrefab");
			}
			return prefab;
		}
	}

	[SerializeField] SpriteRenderer spriteRenderer = null;
	[SerializeField] Collider2D blockCollider = null;

	private float hardness;
	private ToolType toolType;
	private ToolMaterial toolMaterial;
	private Item item;

	float totalDamage;
	float currentDamage;

	public static Block Place(Vector3 worldPosition, float hardness, ToolType toolType, ToolMaterial toolMaterial, Sprite texture, Item item, bool background = false)
	{
		Block block = Instantiate(Prefab, worldPosition, Quaternion.identity);
		block.hardness = hardness;
		block.toolMaterial = toolMaterial;
		block.toolType = toolType;
		block.spriteRenderer.sprite = texture;
		block.totalDamage = hardness;
		block.item = item;
		if(background)
		{
			block.spriteRenderer.color = new Color(1, 1, 1, 0.7f);
		}
		else
		{
			block.blockCollider.enabled = true;
		}
		return block;
	}

	public float Percentage()
	{
		return currentDamage / totalDamage;
	}

	public void Repair()
	{
		currentDamage = 0;
	}

	bool destroyed = false;

	public bool Damage(ToolType toolType, ToolMaterial toolMaterial)
	{
		if(toolType.CanHarvest(toolType) && toolMaterial.StrongEnough(toolMaterial))
		{
			float multiplier = toolType.RightTool(toolType) ? toolMaterial.Multiplier : 1;
			currentDamage += Time.deltaTime * multiplier * 0.666666f;
			if(currentDamage >= totalDamage)
			{
				if (destroyed) return true;
				destroyed = true;
				Instantiate(ItemData.icons.itemEntityPrefab, transform.position, Quaternion.identity).Setup(item);
			}
		}
		else
		{
			currentDamage += Time.deltaTime * 0.2f;
		}
		if(currentDamage >= totalDamage)
		{
			destroyed = true;
			Destroy(gameObject);
			return true;
		}
		return false;
	}
}
