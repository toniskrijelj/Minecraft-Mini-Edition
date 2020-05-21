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
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var hit = Physics2D.Raycast(Player.Instance.transform.position, (mousePosition - Player.Instance.transform.position).normalized, 4, 1 << 8);
		if (hit)
		{
			Vector2 placeWorldPosition = hit.point + hit.normal * 0.1f;
			Vector2Int placeGridPosition = BlockGrid.Instance.GetXY(placeWorldPosition);
			placeWorldPosition = BlockGrid.Instance.GetWorldPosition(placeGridPosition.x, placeGridPosition.y);
			if (!BlockGrid.Instance.CheckXY(placeGridPosition) || Physics2D.BoxCast(placeWorldPosition, new Vector2(.8f, .8f), 0, Vector2.zero, 0, 1 << 10))
			{
				return;
			}
			Block block = new Block(Hardness, ToolType, ToolMaterial, UnityEngine.Object.Instantiate(BlockData.blockData.blockPrefab, placeWorldPosition, Quaternion.identity), "nigg", Texture());
			BlockGrid.Instance.SetBlock(placeGridPosition.x, placeGridPosition.y, block);
		}
	}
}
