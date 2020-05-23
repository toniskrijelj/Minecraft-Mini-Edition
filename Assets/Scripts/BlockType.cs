using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlockType : Enumeration
{
	public static readonly BlockType OakPlanks = new BlockType(1, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.oakPlanksTexture, () => Item.OakPlanks);

	public float Hardness { get; }
	public ToolType ToolType { get; }
	public ToolMaterial ToolMaterial { get; }
	public Func<Sprite> Texture { get; }
	public Func<Item> GetItem { get; }

	protected BlockType(float hardness, ToolType toolType, ToolMaterial toolMaterial, Func<Sprite> texture, Func<Item> itemDrop)
	{
		Hardness = hardness;
		ToolType = toolType;
		ToolMaterial = toolMaterial;
		Texture = texture;
		GetItem = itemDrop;
	}

	public bool TryPlace()
	{
		Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouseWorldPosition.z = 0;
		if ((mouseWorldPosition - Player.Instance.transform.position).sqrMagnitude <= 4 * 4)
		{
			Vector2Int mouseGridPosition = BlockGrid.Instance.GetXY(mouseWorldPosition);
			Vector3 worldPosition = BlockGrid.Instance.GetWorldPosition(mouseGridPosition);
			if (BlockGrid.Instance.CanPlace(mouseGridPosition))
			{
				Block block = Block.Place(worldPosition, Hardness, ToolType, ToolMaterial, Texture(), GetItem(), Input.GetKey(KeyCode.LeftAlt));
				BlockGrid.Instance.SetBlock(mouseGridPosition, block);
				return true;
			}
		}
		return false;
	}
}
