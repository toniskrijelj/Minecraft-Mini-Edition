using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlockType : Enumeration
{
	public static readonly BlockType OakPlanks = new BlockType("Oak_Planks", 1, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.oakPlanksTexture, () => Item.OakPlanks);
	public static readonly BlockType OakLeaves = new BlockType("Oak_Leaves", 0.2f, ToolType.None, ToolMaterial.All, () => BlockData.blockData.oakLeavesTexture, () => Item.oakLeaves);
	public static readonly BlockType Dirt = new BlockType("Dirt",0.6f, ToolType.Shovel, ToolMaterial.All, () => BlockData.blockData.dirtBlockTexture, () => Item.Dirt);
	public static readonly BlockType Sand = new BlockType("Sand",0.5f, ToolType.Shovel, ToolMaterial.All, () => BlockData.blockData.sandTexture, () => Item.Sand);
	public static readonly BlockType CraftingTable = new BlockType("Crafting_Table",2.5f, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.CraftingTableTexture, () => Item.CraftingTable, () =>CraftingGrid3x3UI.Instance.Open());
	public static readonly BlockType BirchLog = new BlockType("Birch_Log",2, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.birchLogTexture, () => Item.BirchLog);
	public static readonly BlockType Chest = new BlockType("Chest",2.5f, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.chestTexture, () => Item.Chest, null, () => CustomBlockData.Chest);
	public static readonly BlockType BirchPlanks = new BlockType("Birch_Planks", 2, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.birchPlanksTexture, () => Item.BirchPlanks);
	public static readonly BlockType SprucePlanks = new BlockType("Spruce_Planks",2, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.sprucePlanksTexture, () => Item.SprucePlanks);
	public static readonly BlockType CoalOre = new BlockType("Coal_Ore",3, ToolType.Pickaxe, ToolMaterial.All, () => BlockData.blockData.coalOreTexture, () => Item.Coal);
	public static readonly BlockType Cobblestone = new BlockType("Cobblestone",2, ToolType.Pickaxe, ToolMaterial.All, () => BlockData.blockData.cobblestoneTexture, () => Item.Cobblestone);
	public static readonly BlockType SpruceLeaves = new BlockType("SpruceLeaves",0.2f, ToolType.None, ToolMaterial.All, () => BlockData.blockData.spruceLeavesTexture, () => Item.SpruceLeaves);
	public static readonly BlockType Door = new DoorType("Door",3, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.doorTexture, () => Item.Door, null, () => CustomBlockData.Door);
	public static readonly BlockType GrassBlock = new BlockType("Grass_Block",0.6f, ToolType.Shovel , ToolMaterial.All, () => BlockData.blockData.grassBlockTexture, () => Item.Dirt);
	public static readonly BlockType IronOre = new BlockType("Iron_Ore",3, ToolType.Pickaxe , ToolMaterial.Stone, () => BlockData.blockData.ironOreTexture, () => Item.IronOre);
	public static readonly BlockType OakLog = new BlockType("Oak_Log",2, ToolType.Axe , ToolMaterial.All, () => BlockData.blockData.oakLogTexture, () => Item.OakLog);
	public static readonly BlockType SpruceLog = new BlockType("Spruce_Log",2, ToolType.Axe , ToolMaterial.All, () => BlockData.blockData.spruceLogTexture, () => Item.SpruceLog);
	public static readonly BlockType Stone = new BlockType("Stone",1.5f, ToolType.Pickaxe , ToolMaterial.All, () => BlockData.blockData.stoneBlockTexture, () => Item.Cobblestone);
	public static readonly BlockType DiamondOre = new BlockType("Diamond_Ore",3, ToolType.Pickaxe , ToolMaterial.Iron, () => BlockData.blockData.diamondOreTexture, () => Item.Diamond);
	public static readonly BlockType Furnace = new BlockType("Furnace",3.5f, ToolType.Pickaxe, ToolMaterial.Wood, () => BlockData.blockData.furnaceUnlit, () => Item.furnace, null, () => CustomBlockData.Furnace);
	public static readonly BlockType GoldOre = new BlockType("Gold_Ore",3, ToolType.Pickaxe, ToolMaterial.Iron, () => BlockData.blockData.goldOreTexture, () => Item.GoldOre); 
	public static readonly BlockType TNT = new BlockType("TNT",0, ToolType.None, ToolMaterial.All, () => BlockData.blockData.TNT, () => Item.TNT); 
	public static readonly BlockType DiamondBlock = new BlockType("Diamond_Block",5, ToolType.Pickaxe, ToolMaterial.Iron, () => BlockData.blockData.DiamondBlock, () => Item.DiamondBlock); 
	public static readonly BlockType IronBlock = new BlockType("Iron_Block",5, ToolType.Pickaxe, ToolMaterial.Stone, () => BlockData.blockData.IronBlock, () => Item.IronBlock); 
	public static readonly BlockType EmeraldBlock = new BlockType("Emerald_Block",5, ToolType.Pickaxe, ToolMaterial.Iron, () => BlockData.blockData.EmeraldBlock, () => Item.EmeraldBlock); 
	public static readonly BlockType CoalBlock = new BlockType("Coal_Block",5, ToolType.Pickaxe, ToolMaterial.Stone, () => BlockData.blockData.CoalBlock, () => Item.CoalBlock); 
	public static readonly BlockType GoldBlock = new BlockType("Gold_Block",5, ToolType.Pickaxe, ToolMaterial.Iron, () => BlockData.blockData.GoldBlock, () => Item.GoldBlock);
	public static readonly BlockType Diorite = new BlockType("Diorite",1.5f, ToolType.Pickaxe, ToolMaterial.Wood, () => BlockData.blockData.Diorite, () => Item.Diorite);
	public static readonly BlockType SmoothStone = new BlockType("Smooth_Stone",1.5f, ToolType.Pickaxe, ToolMaterial.Wood, () => BlockData.blockData.SmoothStone, () => Item.SmoothStone);
	public static readonly BlockType Sandstone = new BlockType("Sandstone",0.8f, ToolType.Pickaxe, ToolMaterial.Wood, () => BlockData.blockData.Sandstone, () => Item.Sandstone);
	public static readonly BlockType StoneBrick = new BlockType("Stone_Brick",1.5f, ToolType.Pickaxe, ToolMaterial.Wood, () => BlockData.blockData.StoneBrick, () => Item.StoneBrick);
	//Stairs
	public static readonly BlockType CobblestoneStairs = new BlockType("Cobblestone_Stairs",2, ToolType.Pickaxe, ToolMaterial.Wood, () => BlockData.blockData.cobbleStoneStairs, () => Item.CobblestoneStairs, null, ()=>CustomBlockData.Stairs);
	public static readonly BlockType StoneStairs = new BlockType("Stone_Stairs",2, ToolType.Pickaxe, ToolMaterial.Wood, () => BlockData.blockData.StoneStairs, () => Item.StoneStairs, null, ()=>CustomBlockData.Stairs);
	public static readonly BlockType OakStairs = new BlockType("Oak_Stairs",2, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.OakStairs, () => Item.OakStairs, null, () => CustomBlockData.Stairs);
	public static readonly BlockType BirchStairs = new BlockType("Birch_Stairs",2, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.BirchStairs, () => Item.BirchStairs, null, ()=>CustomBlockData.Stairs);
	public static readonly BlockType SpruceStairs = new BlockType("Spruce_Stairs",2, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.SpruceStairs, () => Item.SpruceStairs, null, ()=>CustomBlockData.Stairs);
	public static readonly BlockType StoneBrickStairs = new BlockType("Stone_Brick_Stairs",1.5f, ToolType.Pickaxe, ToolMaterial.Wood, () => BlockData.blockData.StoneBrickStairs, () => Item.StoneBrickStairs, null, ()=>CustomBlockData.Stairs);
	
	//Slab
	public static readonly BlockType CobblestoneSlab = new BlockType("Cobblestone_Slab",2, ToolType.Pickaxe, ToolMaterial.Wood, () => BlockData.blockData.cobblestoneSlab, () => Item.CobblestoneSlab, null, ()=>CustomBlockData.Slab);
	public static readonly BlockType DioriteSlab = new BlockType("Diorite_Slab",1.5f, ToolType.Pickaxe, ToolMaterial.Wood, () => BlockData.blockData.DioriteSlab, () => Item.DioriteSlab, null, ()=>CustomBlockData.Slab);
	public static readonly BlockType OakSlab = new BlockType("Oak_Slab",2, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.OakSlab, () => Item.OakSlab, null, ()=>CustomBlockData.Slab);
	public static readonly BlockType SandstoneSlab = new BlockType("Sandstone_Slab",0.8f, ToolType.Pickaxe, ToolMaterial.Wood, () => BlockData.blockData.SandstoneSlab, () => Item.SandstoneSlab, null, ()=>CustomBlockData.Slab);
	public static readonly BlockType SpruceSlab = new BlockType("Spruce_Slab",2, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.SpruceSlab, () => Item.SpruceSlab, null, ()=>CustomBlockData.Slab);
	public static readonly BlockType StoneBrickSlab = new BlockType("Stone_Brick_Slab",1.5f, ToolType.Pickaxe, ToolMaterial.Wood, () => BlockData.blockData.StoneBrickSlab, () => Item.StoneBrickSlab, null, ()=>CustomBlockData.Slab);
	public static readonly BlockType BirchSlab = new BlockType("Birch_Slab",1.5f, ToolType.Axe, ToolMaterial.All, () => BlockData.blockData.BirchSlab, () => Item.BirchSlab, null, ()=>CustomBlockData.Slab);


	public static BlockType GetBlockType(string blockName)
	{
		blockName = blockName.ToLower();
		var fields = typeof(BlockType).GetFields();
		foreach (var item in fields)
		{
			if (item.FieldType == typeof(BlockType))
			{
				BlockType current = (BlockType)item.GetValue(null);
				if (current.DisplayName.ToLower() == blockName)
				{
					return current;
				}
			}
		}
		return null;
	}


	public string Name { get; }
	public float Hardness { get; }
	public ToolType ToolType { get; }
	public ToolMaterial ToolMaterial { get; }
	public Func<Sprite> Texture { get; }
	public Func<Item> GetItem { get; }
	public Action SpecialAction { get; }

	protected Func<Block> prefab;

	protected BlockType(string name, float hardness, ToolType toolType, ToolMaterial toolMaterial, Func<Sprite> texture, Func<Item> itemDrop, Action specialAction = null, Func<Block> blockPrefab = null) : base(name)
	{
		Name = name;
		Hardness = hardness;
		ToolType = toolType;
		ToolMaterial = toolMaterial;
		Texture = texture;
		GetItem = itemDrop;
		SpecialAction = specialAction;
		if (blockPrefab == null)
		{
			prefab = () => Block.Prefab;
		}
		else
		{
			prefab = blockPrefab;
		}
	}

	public virtual bool TryPlace()
	{
		Layer layer = Input.GetKey(KeyCode.LeftAlt) ? Layer.Background : Layer.Ground;
		Vector3 mouseWorldPosition = Utilities.GetMouseWorldPosition();
		if ((mouseWorldPosition - Player.Instance.transform.position).sqrMagnitude <= Player.range * Player.range)
		{
			Vector2Int mouseGridPosition = BlockGrid.Instance.GetXY(mouseWorldPosition);
			Vector3 worldPosition = BlockGrid.Instance.GetWorldPosition(mouseGridPosition);
			if (BlockGrid.Instance.CanPlace(mouseGridPosition, layer))
			{
				Block block = Block.Place(prefab(), worldPosition, DisplayName, Hardness, ToolType, ToolMaterial, Texture(), GetItem(), SpecialAction, Input.GetKey(KeyCode.LeftAlt));
				BlockGrid.Instance.SetBlock(mouseGridPosition, layer, block);
				return true;
			}
		}
		return false;
	}

	public Block Place(Vector3 worldPosition, Layer layer)
	{
		Block block = Block.Place(prefab(), worldPosition, Name, Hardness, ToolType, ToolMaterial, Texture(), GetItem(), SpecialAction, layer == Layer.Background ? true : false);
		BlockGrid.Instance.SetBlock(worldPosition, layer, block);
		return block;
	}

	public class DoorType : BlockType
	{
		public DoorType(string name, float hardness, ToolType toolType, ToolMaterial toolMaterial, Func<Sprite> texture, Func<Item> itemDrop, Action specialAction = null, Func<Block> blockPrefab = null) : base(name, hardness, toolType, toolMaterial, texture, itemDrop, specialAction, blockPrefab)
		{
		}

		public override bool TryPlace()
		{
			Layer layer = Input.GetKey(KeyCode.LeftAlt) ? Layer.Background : Layer.Ground;
			Vector3 mouseWorldPosition = Utilities.GetMouseWorldPosition();
			if ((mouseWorldPosition - Player.Instance.transform.position).sqrMagnitude <= Player.range * Player.range)
			{
				Vector2Int mouseGridPosition = BlockGrid.Instance.GetXY(mouseWorldPosition);
				Vector3 worldPosition = BlockGrid.Instance.GetWorldPosition(mouseGridPosition);
				if (BlockGrid.Instance.CanPlace(mouseGridPosition, layer) && BlockGrid.Instance.CanPlace(mouseGridPosition + Vector2Int.up, layer, false))
				{
					Block block = Block.Place(prefab(), worldPosition, DisplayName, Hardness, ToolType, ToolMaterial, Texture(), GetItem(), SpecialAction, Input.GetKey(KeyCode.LeftAlt));
					BlockGrid.Instance.SetBlock(mouseGridPosition, layer, block);
					BlockGrid.Instance.SetBlock(mouseGridPosition + Vector2Int.up, layer, block);
					return true;
				}
			}
			return false;
		}
	}
}
