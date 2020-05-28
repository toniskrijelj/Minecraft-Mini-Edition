using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item : Enumeration
{
	public static readonly Item OakLog = new BlockItem("Oak_Log", () => ItemData.icons.oakLog, BlockType.OakLog);
	public static readonly Item SpruceLog = new BlockItem("Spruce_Log", () => ItemData.icons.spruceLog, BlockType.SpruceLog); 
	public static readonly Item BirchLog = new BlockItem("Birch_Log", () => ItemData.icons.birchLog, BlockType.BirchLog);
	public static readonly Item OakPlanks = new BlockItem("Oak_Planks", () => ItemData.icons.oakPlanks, BlockType.OakPlanks);
	public static readonly Item BirchPlanks = new BlockItem("Birch_Planks", () => ItemData.icons.birchPlanks, BlockType.BirchPlanks);
	public static readonly Item SprucePlanks = new BlockItem("Spruce_Planks", () => ItemData.icons.sprucePlanks, BlockType.SprucePlanks);
	public static readonly Item oakLeaves = new BlockItem("Oak_Leaves", () => ItemData.icons.acaciaLeaves, BlockType.OakLeaves);
	public static readonly Item SpruceLeaves = new BlockItem("Spruce_Leaves", () => ItemData.icons.spruceLeaves, BlockType.SpruceLeaves);
	public static readonly Item Dirt = new BlockItem("Dirt", () => ItemData.icons.Dirt, BlockType.Dirt);
	public static readonly Item Sand = new BlockItem("Sand", () => ItemData.icons.Sand, BlockType.Sand);
	public static readonly Item CraftingTable = new BlockItem("Crafting_Table", () => ItemData.icons.craftingTable, BlockType.CraftingTable);
	public static readonly Item Chest = new BlockItem("Chest", () => ItemData.icons.Chest, BlockType.Chest);
	public static readonly Item CoalOre = new BlockItem("Coal_Ore", () => ItemData.icons.CoalOre, BlockType.CoalOre);
	public static readonly Item Coal = new Item("Coal_Ore", () => ItemData.icons.coal, true);
	public static readonly Item Cobblestone = new BlockItem("Cobblestone", () => ItemData.icons.Cobblestone, BlockType.Cobblestone);
	public static readonly Item Door = new BlockItem("Door", () => ItemData.icons.oakDoor, BlockType.Door);
	public static readonly Item GrassBlock = new BlockItem("Grass_Block", () => ItemData.icons.grassBlock, BlockType.GrassBlock);
	public static readonly Item IronOre = new BlockItem("Iron_Ore", () => ItemData.icons.ironOre, BlockType.IronOre);
	public static readonly Item StoneBlock = new BlockItem("Stone", () => ItemData.icons.Stone, BlockType.Stone);
	public static readonly Item DiamondOre = new BlockItem("Diamond_Ore", () => ItemData.icons.DiamondOre, BlockType.DiamondOre);
	public static readonly Item Diamond = new Item("Diamond", () => ItemData.icons.Diamond, true);
	public static readonly Item Iron = new Item("Iron", () => ItemData.icons.IronIngot, true);
	public static readonly Item Gold = new Item("Gold", () => ItemData.icons.Gold, true);
	public static readonly Item Stick = new Item("Stick", () => ItemData.icons.Stick, true);
	public static readonly Item Wheat = new Item("Wheat", () => ItemData.icons.Wheat, true);
	public static readonly Item Gunpowder = new Item("Gunpowder", () => ItemData.icons.Gunpowder, true);
	public static readonly Item Emerald = new Item("Emerald", () => ItemData.icons.Emerald, true);
	public static readonly Item furnace = new BlockItem("Furnace", () => ItemData.icons.furnace, BlockType.Furnace);
	public static readonly Item GoldOre = new BlockItem("Gold_Ore", () => ItemData.icons.GoldOre, BlockType.GoldOre);
	public static readonly Item TNT = new BlockItem("TNT", () => ItemData.icons.TNT, BlockType.TNT);
	public static readonly Item DiamondBlock = new BlockItem("Block_of_Diamond", () => ItemData.icons.DiamonBlock, BlockType.DiamondBlock);
	public static readonly Item IronBlock = new BlockItem("Block_of_Iron", () => ItemData.icons.IronBlock, BlockType.IronBlock);
	public static readonly Item EmeraldBlock = new BlockItem("Block_of_Emerald", () => ItemData.icons.EmeraldBlock, BlockType.EmeraldBlock);
	public static readonly Item CoalBlock = new BlockItem("Block_of_Coal", () => ItemData.icons.CoalBlock, BlockType.CoalBlock);
	public static readonly Item GoldBlock = new BlockItem("Block_of_Gold", () => ItemData.icons.GoldBlock, BlockType.GoldBlock);
	public static readonly Item Diorite = new BlockItem("Diorite", () => ItemData.icons.Diorite, BlockType.Diorite);
	public static readonly Item SmoothStone = new BlockItem("SmoothStone", () => ItemData.icons.SmoothStone, BlockType.SmoothStone);
	public static readonly Item Sandstone = new BlockItem("Sandstone", () => ItemData.icons.Sandstone, BlockType.Sandstone);
	public static readonly Item StoneBrick = new BlockItem("Stone_Bricks", () => ItemData.icons.StoneBrick, BlockType.StoneBrick);
	

	// Tools
	public static readonly Item DiamondSword = new SwordItem("Diamond_Sword", () => ItemData.icons.DiamondSword, 4);
	public static readonly Item WoodenSword = new SwordItem("Wooden_Sword", () => ItemData.icons.WoodenSword, 1);
	public static readonly Item StoneSword = new SwordItem("Stone_Sword", () => ItemData.icons.StoneSword, 2);
	public static readonly Item IronSword = new SwordItem("Iron_Sword", () => ItemData.icons.IronSword, 3);
	public static readonly Item GoldSword = new SwordItem("Gold_Sword", () => ItemData.icons.GoldSword, 1);
	public static readonly Item WoodenPickaxe = new ToolItem("Wooden_Pickaxe", () => ItemData.icons.WoodenPickaxe, ToolType.Pickaxe, ToolMaterial.Wood);
	public static readonly Item StonePickaxe = new ToolItem("Stone_Pickaxe", () => ItemData.icons.StonePickaxe, ToolType.Pickaxe, ToolMaterial.Stone);
	public static readonly Item IronPickaxe = new ToolItem("Iron_Pickaxe", () => ItemData.icons.IronPickaxe, ToolType.Pickaxe, ToolMaterial.Iron);
	public static readonly Item GoldPickaxe = new ToolItem("Gold_Pickaxe", () => ItemData.icons.GoldPickaxe, ToolType.Pickaxe, ToolMaterial.Gold);
	public static readonly Item DiamondPickaxe = new ToolItem("Diamond_Pickaxe", () => ItemData.icons.DiamondPickaxe, ToolType.Pickaxe, ToolMaterial.Diamond);
	public static readonly Item WoodenAxe = new ToolItem("Wooden_Axe", () => ItemData.icons.WoodenAxeTexture, ToolType.Axe, ToolMaterial.Wood);
	public static readonly Item StoneAxe = new ToolItem("Stone_Axe", () => ItemData.icons.StoneAxeTexture, ToolType.Axe, ToolMaterial.Stone);
	public static readonly Item IronAxe = new ToolItem("Iron_Axe", () => ItemData.icons.IronAxeTexture, ToolType.Axe, ToolMaterial.Iron);
	public static readonly Item GoldenAxe = new ToolItem("Gold_Axe", () => ItemData.icons.GoldAxeTexture, ToolType.Axe, ToolMaterial.Gold);
	public static readonly Item DiamondAxe = new ToolItem("Diamond_Axe", () => ItemData.icons.DiamondAxeTexture, ToolType.Axe, ToolMaterial.Diamond);
	public static readonly Item WoodenShovel = new ToolItem("Wooden_Shovel", () => ItemData.icons.WoodenShovel, ToolType.Shovel, ToolMaterial.Wood);
	public static readonly Item StoneShovel = new ToolItem("Stone_Shovel", () => ItemData.icons.StoneShovel, ToolType.Shovel, ToolMaterial.Stone);
	public static readonly Item IronShovel = new ToolItem("Iron_Shovel", () => ItemData.icons.IronShovel, ToolType.Shovel, ToolMaterial.Iron);
	public static readonly Item GoldShovel = new ToolItem("Gold_Shovel", () => ItemData.icons.GoldShovel, ToolType.Shovel, ToolMaterial.Gold);
	public static readonly Item DiamondShovel = new ToolItem("Diamond_Shovel", () => ItemData.icons.DiamondShovel, ToolType.Shovel, ToolMaterial.Diamond);
	//Food
	public static readonly Item Apple = new FoodItem("Apple", () => ItemData.icons.Apple, 4);
	public static readonly Item BakedPotato = new FoodItem("Baked_Potato", () => ItemData.icons.CookedPotato, 5);
	public static readonly Item Potato = new FoodItem("Potato", () => ItemData.icons.Potato, 2);
	public static readonly Item CookedChicken = new FoodItem("Cooked_Chicken", () => ItemData.icons.CookedChicken, 6);
	public static readonly Item RawChicken = new FoodItem("Raw_Chicken", () => ItemData.icons.RawChicken, 2);
	public static readonly Item CookedBeef = new FoodItem("Steak", () => ItemData.icons.CookedBeef, 8);
	public static readonly Item RawBeef = new FoodItem("Raw_Beef", () => ItemData.icons.RawBeef, 3);
	public static readonly Item CookedPork = new FoodItem("Cooked_Porkchop", () => ItemData.icons.CookedPork, 8);
	public static readonly Item RawPork = new FoodItem("Raw_Porkchop", () => ItemData.icons.RawPork, 3);
	public static readonly Item Bread = new FoodItem("Bread", () => ItemData.icons.Bread, 5);
	public static readonly Item Carrot = new FoodItem("Carrot", () => ItemData.icons.Carrot, 3);
	//Stairs
	public static readonly Item CobblestoneStairs = new BlockItem("Cobblestone_Stairs", () => ItemData.icons.CobbleStairs, BlockType.CobblestoneStairs);
	public static readonly Item StoneStairs = new BlockItem("Stone_Stairs", () => ItemData.icons.StoneStairs, BlockType.StoneStairs);
	public static readonly Item OakStairs = new BlockItem("Oak_Stairs", () => ItemData.icons.OakStairs, BlockType.OakStairs);
	public static readonly Item BirchStairs = new BlockItem("Birch_Stairs", () => ItemData.icons.BirchStairs, BlockType.BirchStairs);
	public static readonly Item SpruceStairs = new BlockItem("Spruce_Stairs", () => ItemData.icons.SpruceStairs, BlockType.SpruceStairs);
	public static readonly Item StoneBrickStairs = new BlockItem("Stone_Brick_Stairs", () => ItemData.icons.StoneBrickStairs, BlockType.StoneBrickStairs);


	//Slabs
	public static readonly Item CobblestoneSlab = new BlockItem("Cobblestone_Slab", () => ItemData.icons.CobblestoneSlab, BlockType.CobblestoneSlab);
	public static readonly Item DioriteSlab = new BlockItem("Diorite_Slab", () => ItemData.icons.DioriteSlab, BlockType.DioriteSlab);
	public static readonly Item OakSlab = new BlockItem("Oak_Slab", () => ItemData.icons.OakSlab, BlockType.OakSlab);
	public static readonly Item SandstoneSlab = new BlockItem("Sandstone_Slab", () => ItemData.icons.SandStoneSlab, BlockType.SandstoneSlab);
	public static readonly Item SpruceSlab = new BlockItem("Spruce_Slab", () => ItemData.icons.SpruceSlab, BlockType.SpruceSlab);
	public static readonly Item StoneBrickSlab = new BlockItem("Stone_Brick_Slab", () => ItemData.icons.StoneBrickSlab, BlockType.StoneBrickSlab);


	

	private Action putInHand = null;
	private Action removeFromHand = null;

	private Action onMouseRightClickDown = null;
	private Func<bool> specialAction = null;
	private Action onMouseRightClickUp = null;

	public readonly bool stackable;

	public Func<Sprite> GetIcon { get; }

	protected Item(string displayName, Func<Sprite> iconFunc, bool stackable) : base(displayName)
	{
		GetIcon = iconFunc;
		this.stackable = stackable;
	}

	public void PutInHand()
	{
		putInHand?.Invoke();
	}

	public void RemoveFromHand()
	{
		removeFromHand?.Invoke();
	}

	public void OnRightClickDown()
	{
		onMouseRightClickDown?.Invoke();
	}

	public void OnRightClickUp()
	{
		onMouseRightClickUp?.Invoke();
	}

	public bool SpecialAction()
	{
		if(specialAction == null)
		{
			return false;
		}
		return specialAction.Invoke();
	}

	private class FoodItem : Item
	{
		int hungerPointsRestored;
		float startEatTime;

		public FoodItem(string displayName, Func<Sprite> iconFunc, int hungerPointsRestored) : base(displayName, iconFunc, true)
		{
			this.hungerPointsRestored = hungerPointsRestored;
			onMouseRightClickDown = () =>
			{
				startEatTime = Time.time;
			};
			specialAction = () =>
			{
				if (!Player.Instance.hungerSytem.IsFull())
				{
					if (startEatTime + 2 < Time.time)
					{
						startEatTime = Time.time;
						Player.Instance.hungerSytem.Increase(hungerPointsRestored);
						return true;
					}
				}
				else
				{
					startEatTime = Time.time;
				}
				return false;
			};
		}
	}

	public class SwordItem : Item
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
