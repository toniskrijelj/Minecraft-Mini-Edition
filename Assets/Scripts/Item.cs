using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item : Enumeration
{
	public static readonly Item OakLog = new BlockItem("Oak Log", () => ItemData.icons.oakLog, BlockType.OakLog);
	public static readonly Item SpruceLog = new BlockItem("Spruce Log", () => ItemData.icons.spruceLog, BlockType.SpruceLog); 
	public static readonly Item BirchLog = new BlockItem("Birch Log", () => ItemData.icons.birchLog, BlockType.BirchLog);
	public static readonly Item OakPlanks = new BlockItem("Oak Planks", () => ItemData.icons.oakPlanks, BlockType.OakPlanks);
	public static readonly Item BirchPlanks = new BlockItem("Birch Planks", () => ItemData.icons.birchPlanks, BlockType.BirchPlanks);
	public static readonly Item SprucePlanks = new BlockItem("Spruce Planks", () => ItemData.icons.sprucePlanks, BlockType.SprucePlanks);
	public static readonly Item oakLeaves = new BlockItem("Oak Leaves", () => ItemData.icons.acaciaLeaves, BlockType.OakLeaves);
	public static readonly Item SpruceLeaves = new BlockItem("Spruce Leaves", () => ItemData.icons.spruceLeaves, BlockType.SpruceLeaves);
	public static readonly Item Dirt = new BlockItem("Dirt", () => ItemData.icons.Dirt, BlockType.Dirt);
	public static readonly Item Sand = new BlockItem("Sand", () => ItemData.icons.Sand, BlockType.Sand);
	public static readonly Item CraftingTable = new BlockItem("Crafting Table", () => ItemData.icons.craftingTable, BlockType.CraftingTable);
	public static readonly Item Chest = new BlockItem("Chest", () => ItemData.icons.Chest, BlockType.Chest);
	public static readonly Item CoalOre = new BlockItem("Coal Ore", () => ItemData.icons.CoalOre, BlockType.CoalOre);
	public static readonly Item Coal = new Item("Coal Ore", () => ItemData.icons.coal, true);
	public static readonly Item Cobblestone = new BlockItem("Cobblestone", () => ItemData.icons.Cobblestone, BlockType.Cobblestone);
	public static readonly Item Door = new BlockItem("Door", () => ItemData.icons.oakDoor, BlockType.Door);
	public static readonly Item GrassBlock = new BlockItem("Grass Block", () => ItemData.icons.grassBlock, BlockType.GrassBlock);
	public static readonly Item IronOre = new BlockItem("Iron Ore", () => ItemData.icons.ironOre, BlockType.IronOre);
	public static readonly Item StoneBlock = new BlockItem("Stone", () => ItemData.icons.Stone, BlockType.Stone);
	public static readonly Item DiamondOre = new BlockItem("Diamond Ore", () => ItemData.icons.DiamondOre, BlockType.DiamondOre);
	public static readonly Item Diamond = new Item("Diamond", () => ItemData.icons.Diamond, true);
	public static readonly Item Iron = new Item("Iron", () => ItemData.icons.IronIngot, true);
	public static readonly Item Gold = new Item("Gold", () => ItemData.icons.Gold, true);
	public static readonly Item Stick = new Item("Stick", () => ItemData.icons.Stick, true);
	public static readonly Item Wheat = new Item("Wheat", () => ItemData.icons.Wheat, true);
	public static readonly Item Gunpowder = new Item("Gunpowder", () => ItemData.icons.Gunpowder, true);
	public static readonly Item Emerald = new Item("Emerald", () => ItemData.icons.Emerald, true);
	public static readonly Item furnace = new BlockItem("Furnace", () => ItemData.icons.furnace, BlockType.Furnace);
	public static readonly Item GoldOre = new BlockItem("Gold Ore", () => ItemData.icons.GoldOre, BlockType.GoldOre);
	public static readonly Item TNT = new BlockItem("TNT", () => ItemData.icons.TNT, BlockType.TNT);
	public static readonly Item DiamondBlock = new BlockItem("Block of diamond", () => ItemData.icons.DiamonBlock, BlockType.DiamondBlock);
	public static readonly Item IronBlock = new BlockItem("Block of Iron", () => ItemData.icons.IronBlock, BlockType.IronBlock);
	public static readonly Item EmeraldBlock = new BlockItem("Block of Emerald", () => ItemData.icons.EmeraldBlock, BlockType.EmeraldBlock);
	public static readonly Item CoalBlock = new BlockItem("Block of Coal", () => ItemData.icons.CoalBlock, BlockType.CoalBlock);
	public static readonly Item GoldBlock = new BlockItem("Block of Gold", () => ItemData.icons.GoldBlock, BlockType.GoldBlock);

	// Tools
	public static readonly Item DiamondSword = new SwordItem("Diamond Sword", () => ItemData.icons.DiamondSword, 4);
	public static readonly Item WoodenSword = new SwordItem("Wooden Sword", () => ItemData.icons.WoodenSword, 1);
	public static readonly Item StoneSword = new SwordItem("Stone Sword", () => ItemData.icons.StoneSword, 2);
	public static readonly Item IronSword = new SwordItem("Iron Sword", () => ItemData.icons.IronSword, 3);
	public static readonly Item GoldSword = new SwordItem("Gold Sword", () => ItemData.icons.GoldSword, 1);
	public static readonly Item WoodenPickaxe = new ToolItem("Wooden Pickaxe", () => ItemData.icons.WoodenPickaxe, ToolType.Pickaxe, ToolMaterial.Wood);
	public static readonly Item StonePickaxe = new ToolItem("Stone Pickaxe", () => ItemData.icons.StonePickaxe, ToolType.Pickaxe, ToolMaterial.Stone);
	public static readonly Item IronPickaxe = new ToolItem("Iron Pickaxe", () => ItemData.icons.IronPickaxe, ToolType.Pickaxe, ToolMaterial.Iron);
	public static readonly Item GoldPickaxe = new ToolItem("Gold Pickaxe", () => ItemData.icons.GoldPickaxe, ToolType.Pickaxe, ToolMaterial.Gold);
	public static readonly Item DiamondPickaxe = new ToolItem("Diamond Pickaxe", () => ItemData.icons.DiamondPickaxe, ToolType.Pickaxe, ToolMaterial.Diamond);
	public static readonly Item WoodenAxe = new ToolItem("Wooden Axe", () => ItemData.icons.WoodenAxeTexture, ToolType.Axe, ToolMaterial.Wood);
	public static readonly Item StoneAxe = new ToolItem("Stone Axe", () => ItemData.icons.StoneAxeTexture, ToolType.Axe, ToolMaterial.Stone);
	public static readonly Item IronAxe = new ToolItem("Iron Axe", () => ItemData.icons.IronAxeTexture, ToolType.Axe, ToolMaterial.Iron);
	public static readonly Item GoldenAxe = new ToolItem("Gold Axe", () => ItemData.icons.GoldAxeTexture, ToolType.Axe, ToolMaterial.Gold);
	public static readonly Item DiamondAxe = new ToolItem("Diamond Axe", () => ItemData.icons.DiamondAxeTexture, ToolType.Axe, ToolMaterial.Diamond);
	public static readonly Item WoodenShovel = new ToolItem("Wooden Shovel", () => ItemData.icons.WoodenShovel, ToolType.Shovel, ToolMaterial.Wood);
	public static readonly Item StoneShovel = new ToolItem("Stone Shovel", () => ItemData.icons.StoneShovel, ToolType.Shovel, ToolMaterial.Stone);
	public static readonly Item IronShovel = new ToolItem("Iron Shovel", () => ItemData.icons.IronShovel, ToolType.Shovel, ToolMaterial.Iron);
	public static readonly Item GoldShovel = new ToolItem("Gold Shovel", () => ItemData.icons.GoldShovel, ToolType.Shovel, ToolMaterial.Gold);
	public static readonly Item DiamondShovel = new ToolItem("Diamond Shovel", () => ItemData.icons.DiamondShovel, ToolType.Shovel, ToolMaterial.Diamond);
	//Food
	public static readonly Item Apple = new FoodItem("Apple", () => ItemData.icons.Apple, 4);
	public static readonly Item BakedPotato = new FoodItem("Baked Potato", () => ItemData.icons.CookedPotato, 5);
	public static readonly Item Potato = new FoodItem("Potato", () => ItemData.icons.Potato, 2);
	public static readonly Item CookedChicken = new FoodItem("Cooked Chicken", () => ItemData.icons.CookedChicken, 6);
	public static readonly Item RawChicken = new FoodItem("Raw Chicken", () => ItemData.icons.RawChicken, 2);
	public static readonly Item CookedBeef = new FoodItem("Steak", () => ItemData.icons.CookedBeef, 8);
	public static readonly Item RawBeef = new FoodItem("Raw Beef", () => ItemData.icons.RawBeef, 3);
	public static readonly Item CookedPork = new FoodItem("Cooked Porkchop", () => ItemData.icons.CookedPork, 8);
	public static readonly Item RawPork = new FoodItem("Raw Porkchop", () => ItemData.icons.RawPork, 3);
	public static readonly Item Bread = new FoodItem("Bread", () => ItemData.icons.Bread, 5);
	public static readonly Item Carrot = new FoodItem("Carrot", () => ItemData.icons.Carrot, 3);





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
