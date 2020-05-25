using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item : Enumeration
{
	public static readonly Item DiamondSword = new SwordItem("Diamond Sword", () => ItemData.icons.DiamondSword, 4);
	public static readonly Item WoodenSword = new SwordItem("Wooden Sword", () => ItemData.icons.WoodenSword, 1);
	public static readonly Item OakPlanks = new BlockItem("Oak Planks", () => ItemData.icons.oakPlanks, BlockType.OakPlanks);
	public static readonly Item WoodenPickaxe = new ToolItem("Wooden Pickaxe", () => ItemData.icons.WoodenPickaxe, ToolType.Pickaxe, ToolMaterial.Wood);
	public static readonly Item oakLeaves = new BlockItem("Oak Leaves", () => ItemData.icons.acaciaLeaves, BlockType.OakLeaves);
	public static readonly Item Dirt = new BlockItem("Dirt", () => ItemData.icons.Dirt, BlockType.Dirt);
	public static readonly Item Sand = new BlockItem("Sand", () => ItemData.icons.Sand, BlockType.Sand);
	public static readonly Item CraftingTable = new BlockItem("Crafting Table", () => ItemData.icons.craftingTable, BlockType.CraftingTable);
	public static readonly Item BirchLog = new BlockItem("Birch Log", () => ItemData.icons.birchLog, BlockType.BirchLog);
	public static readonly Item Chest = new BlockItem("Chest", () => ItemData.icons.Chest, BlockType.Chest);
	public static readonly Item BirchPlanks = new BlockItem("Birch Planks", () => ItemData.icons.birchPlanks, BlockType.BirchPlanks);
	public static readonly Item SprucePlanks = new BlockItem("Spruce Planks", () => ItemData.icons.sprucePlanks, BlockType.SprucePlanks);
	public static readonly Item CoalOre = new BlockItem("Coal Ore", () => ItemData.icons.CoalOre, BlockType.CoalOre);
	public static readonly Item Cobblestone = new BlockItem("Cobblestone", () => ItemData.icons.Cobblestone, BlockType.Cobblestone);
	public static readonly Item SpruceLeaves = new BlockItem("Spruce Leaves", () => ItemData.icons.spruceLeaves, BlockType.SpruceLeaves);
	public static readonly Item Door = new BlockItem("Door", () => ItemData.icons.oakDoor, BlockType.Door);
	public static readonly Item GrassBlock = new BlockItem("Grass Block", () => ItemData.icons.grassBlock, BlockType.GrassBlock);
	public static readonly Item IronOre = new BlockItem("Iron Ore", () => ItemData.icons.ironOre, BlockType.IronOre);
	public static readonly Item OakLog = new BlockItem("Oak Log", () => ItemData.icons.oakLog, BlockType.OakLog);
	public static readonly Item SpruceLog = new BlockItem("Spruce Log", () => ItemData.icons.spruceLog, BlockType.SpruceLog);
	public static readonly Item StoneBlock = new BlockItem("Stone", () => ItemData.icons.Stone, BlockType.Stone);









	

	private Action putInHand = null;
	private Action removeFromHand = null;
	private Func<bool> specialAction = null;

	public readonly bool stackable;

	public Func<Sprite> GetIcon { get; }

	protected Item(string displayName, Func<Sprite> iconFunc, bool stackable) : base(displayName)
	{
		GetIcon = iconFunc;
		this.stackable = stackable;
	}

	protected Item(int value, string displayName, Action putInHand, Action removeFromHand, Func<bool> specialAction) : base(displayName)
	{
		this.putInHand = putInHand;
		this.removeFromHand = removeFromHand;
		this.specialAction = specialAction;
	}

	public void PutInHand()
	{
		putInHand?.Invoke();
	}

	public void RemoveFromHand()
	{
		removeFromHand?.Invoke();
	}

	public bool SpecialAction()
	{
		if(specialAction == null)
		{
			return false;
		}
		return specialAction.Invoke();
	}

	private class SwordItem : Item
	{
		public SwordItem(string displayName, Func<Sprite> icon, int damageIncrease) : base(displayName, icon, false)
		{
			putInHand = () => Player.Instance.ChangeBonusDamage(damageIncrease);
			removeFromHand = () => Player.Instance.ChangeBonusDamage(-damageIncrease);
		}
	}
	public class BlockItem : Item
	{
		public BlockItem(string displayName, Func<Sprite> icon, BlockType blockType) : base(displayName, icon, true)
		{
			specialAction = blockType.TryPlace;
		}
	}
	private class ToolItem : Item
	{
		public ToolItem(string displayName, Func<Sprite> icon, ToolType type, ToolMaterial material) : base(displayName, icon, false)
		{
			putInHand = () => Player.Instance.ChangeTool(type, material);
			removeFromHand = () => Player.Instance.ChangeTool(ToolType.None, ToolMaterial.All);
		}
	}
}
