using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlockType : Enumeration
{
	public static readonly BlockType OakPlanks = new BlockType(1, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.oakPlanksTexture, () => Item.OakPlanks);
	public static readonly BlockType OakLeaves = new BlockType(0.2f, ToolType.None, ToolMaterial.All, () => BlockData.blockData.oakLeavesTexture, () => Item.oakLeaves);
	public static readonly BlockType Dirt = new BlockType(0.6f, ToolType.Shovel, ToolMaterial.All, () => BlockData.blockData.dirtBlockTexture, () => Item.Dirt);
	public static readonly BlockType Sand = new BlockType(0.5f, ToolType.Shovel, ToolMaterial.All, () => BlockData.blockData.sandTexture, () => Item.Sand);
	public static readonly BlockType CraftingTable = new BlockType(2.5f, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.CraftingTableTexture, () => Item.CraftingTable);
	public static readonly BlockType BirchLog = new BlockType(2, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.birchLogTexture, () => Item.BirchLog);
	public static readonly BlockType Chest = new BlockType(2.5f, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.chestTexture, () => Item.Chest);
	public static readonly BlockType BirchPlanks = new BlockType(2, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.birchPlanksTexture, () => Item.BirchPlanks);
	public static readonly BlockType SprucePlanks = new BlockType(2, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.sprucePlanksTexture, () => Item.SprucePlanks);
	public static readonly BlockType CoalOre = new BlockType(3, ToolType.Pickaxe, ToolMaterial.All, () => BlockData.blockData.coalOreTexture, () => Item.Coal);
	public static readonly BlockType Cobblestone = new BlockType(2, ToolType.Pickaxe, ToolMaterial.All, () => BlockData.blockData.cobblestoneTexture, () => Item.Cobblestone);
	public static readonly BlockType SpruceLeaves = new BlockType(0.2f, ToolType.None, ToolMaterial.All, () => BlockData.blockData.spruceLeavesTexture, () => Item.SpruceLeaves);
	public static readonly BlockType Door = new BlockType(3, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.doorTexture, () => Item.Door);
	public static readonly BlockType GrassBlock = new BlockType(0.6f, ToolType.Shovel , ToolMaterial.All, () => BlockData.blockData.grassBlockTexture, () => Item.GrassBlock);
	public static readonly BlockType IronOre = new BlockType(3, ToolType.Pickaxe , ToolMaterial.Stone, () => BlockData.blockData.ironOreTexture, () => Item.IronOre);
	public static readonly BlockType OakLog = new BlockType(2, ToolType.Axe , ToolMaterial.All, () => BlockData.blockData.oakLogTexture, () => Item.OakLog);
	public static readonly BlockType SpruceLog = new BlockType(2, ToolType.Axe , ToolMaterial.All, () => BlockData.blockData.spruceLogTexture, () => Item.SpruceLog);
	public static readonly BlockType Stone = new BlockType(1.5f, ToolType.Pickaxe , ToolMaterial.All, () => BlockData.blockData.stoneBlockTexture, () => Item.StoneBlock);
	public static readonly BlockType DiamondOre = new BlockType(3f, ToolType.Pickaxe , ToolMaterial.Iron, () => BlockData.blockData.diamondOreTexture, () => Item.Diamond);










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
		Vector3 mouseWorldPosition = Utilities.GetMouseWorldPosition();
		if ((mouseWorldPosition - Player.Instance.transform.position).sqrMagnitude <= Player.range * Player.range)
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
