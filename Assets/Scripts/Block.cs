using System;
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

	[SerializeField] protected SpriteRenderer spriteRenderer = null;
	[SerializeField] protected Collider2D blockCollider = null;

	public Action specialAction = null;

	protected float hardness;
	protected ToolType toolType;
	protected ToolMaterial toolMaterial;
	protected Item item;

	protected float totalDamage;
	protected float currentDamage;

	protected virtual void OnDestroyed() { }

	public static Block Place(Block prefab, Vector3 worldPosition, float hardness, ToolType toolType, ToolMaterial toolMaterial, Sprite texture, Item item, Action specialAction = null,  bool background = false)
	{
		Block block = Instantiate(prefab, worldPosition, Quaternion.identity);
		block.hardness = hardness;
		block.toolMaterial = toolMaterial;
		block.toolType = toolType;
		block.spriteRenderer.sprite = texture;
		block.totalDamage = hardness;
		if (specialAction != null)
		{
			block.specialAction = specialAction;
		}
		block.item = item;
		if(background)
		{
			block.spriteRenderer.color = new Color(1, 1, 1, 0.7f);
			block.spriteRenderer.sortingOrder = -1;
		}
		else
		{
			block.blockCollider.enabled = true;
		}
		return block;
	}

	public float Percentage()
	{
		if (totalDamage == 0) return 0;
		return currentDamage / totalDamage;
	}

	public void Repair()
	{
		currentDamage = 0;
	}

	bool destroyed = false;

	public bool Damage(ToolType toolType, ToolMaterial toolMaterial)
	{
		if(toolType.CanHarvest(this.toolType) && toolMaterial.StrongEnough(this.toolMaterial))
		{
			float multiplier = toolType.RightTool(this.toolType) ? toolMaterial.Multiplier : 1;
			currentDamage += Time.deltaTime * multiplier * 0.666666f;
			if(currentDamage >= totalDamage)
			{
				if (destroyed) return true;
				destroyed = true;
				ItemEntity.Spawn(transform.position, item, 1);
			}
		}
		else
		{
			currentDamage += Time.deltaTime * 0.2f;
		}
		if(currentDamage >= totalDamage)
		{
			destroyed = true;
			OnDestroyed();
			Destroy(gameObject);
			return true;
		}
		return false;
	}
}
