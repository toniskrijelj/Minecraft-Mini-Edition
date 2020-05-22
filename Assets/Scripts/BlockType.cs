using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlockType : Enumeration
{
	public static readonly BlockType OakPlanks = new BlockType(2, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.oakPlanksTexture);

	public float Hardness { get; }
	public ToolType ToolType { get; }
	public ToolMaterial ToolMaterial { get; }
	public Func<Sprite> Texture { get; }

	protected BlockType(float hardness, ToolType toolType, ToolMaterial toolMaterial, Func<Sprite> texture)
	{
		Hardness = hardness;
		ToolType = toolType;
		ToolMaterial = toolMaterial;
		Texture = texture;
	}

	public void TryPlace()
	{
		Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if ((mouseWorldPosition - Player.Instance.transform.position).sqrMagnitude <= 4 * 4)
		{
			Vector2Int mouseGridPosition = BlockGrid.Instance.GetXY(mouseWorldPosition);
			Vector3 worldPosition = BlockGrid.Instance.GetWorldPosition(mouseGridPosition);
			if (
			BlockGrid.Instance.CheckXY(mouseGridPosition) &&
			!Physics2D.BoxCast(worldPosition, new Vector2(.8f, .8f), 0, Vector2.zero, 0, 1 << 10) && (
			BlockGrid.Instance.GetBlock(mouseGridPosition.x - 1, mouseGridPosition.y) != null ||
			BlockGrid.Instance.GetBlock(mouseGridPosition.x + 1, mouseGridPosition.y) != null ||
			BlockGrid.Instance.GetBlock(mouseGridPosition.x, mouseGridPosition.y + 1) != null ||
			BlockGrid.Instance.GetBlock(mouseGridPosition.x, mouseGridPosition.y - 1) != null))
			{
				Block block = new Block(Hardness, ToolType, ToolMaterial, UnityEngine.Object.Instantiate(BlockData.blockData.blockPrefab, worldPosition, Quaternion.identity), "nigg", Texture());
				BlockGrid.Instance.SetBlock(mouseGridPosition, block);
			}
		}
	}
}
