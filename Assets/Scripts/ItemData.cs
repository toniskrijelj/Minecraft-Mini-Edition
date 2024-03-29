using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
	private static ItemData _i;

	public static ItemData icons
	{
		get
		{
			if (_i == null)
			{
				_i = Resources.Load<ItemData>("ItemData");
			}
			return _i;
		}
	}

	public Sprite oakPlanks;
	public Sprite acaciaLeaves;
	public Sprite birchLog;
	public Sprite birchPlanks;
	public Sprite Chest;
	public Sprite Cobblestone;
	public Sprite craftingTable;
	public Sprite Dirt;
	public Sprite grassBlock;
	public Sprite ironOre;
	public Sprite oakDoor;
	public Sprite oakLog;
	public Sprite Sand;
	public Sprite spruceLeaves;
	public Sprite spruceLog;
	public Sprite sprucePlanks;
	public Sprite coal;
	public Sprite ironIngot;
	public Sprite DiamondAxeTexture;
	public Sprite GoldAxeTexture;
	public Sprite IronAxeTexture;
	public Sprite StoneAxeTexture;
	public Sprite WoodenAxeTexture;
	public Sprite ArrowTexture;
	public Sprite BowTexture;
	public Sprite DiamondPickaxe;
	public Sprite GoldPickaxe;
	public Sprite IronPickaxe;
	public Sprite StonePickaxe;
	public Sprite WoodenPickaxe;
	public Sprite DiamondShovel;
	public Sprite GoldShovel;
	public Sprite IronShovel;
	public Sprite StoneShovel;
	public Sprite WoodenShovel;
	public Sprite DiamondSword;
	public Sprite GoldSword;
	public Sprite IronSword;
	public Sprite StoneSword;
	public Sprite WoodenSword;
	public Sprite CoalOre;
	public Sprite Stone;
	public Sprite Diamond;
	public Sprite DiamondOre;
	public Sprite Stick;
	public Sprite IronIngot;
	public Sprite Gold;
	public Sprite furnace;
	public Sprite RawChicken;
	public Sprite CookedChicken;
	public Sprite RawBeef;
	public Sprite CookedBeef;
	public Sprite RawPork;
	public Sprite CookedPork;
	public Sprite Potato;
	public Sprite CookedPotato;
	public Sprite Carrot;
	public Sprite Bread;
	public Sprite Apple;
	public Sprite Wheat;
	public Sprite GoldOre;
	public Sprite Gunpowder;
	public Sprite TNT;
	public Sprite DiamonBlock;
	public Sprite IronBlock;
	public Sprite Emerald;
	public Sprite EmeraldBlock;
	public Sprite GoldBlock;
	public Sprite CoalBlock;
	public Sprite OakStairs;
	public Sprite SpruceStairs;
	public Sprite BirchStairs;
	public Sprite CobbleStairs;
	public Sprite StoneStairs;
	public Sprite CobblestoneSlab;
	public Sprite Andesite;
	public Sprite AndesiteSlab;
	public Sprite BirchSlab;
	public Sprite Diorite;
	public Sprite DioriteSlab;
	public Sprite SmoothStone;
	public Sprite OakSlab;
	public Sprite Sandstone;
	public Sprite SandStoneSlab;
	public Sprite SmoothStoneSlab;
	public Sprite SpruceSlab;
	public Sprite StoneBrick;
	public Sprite StoneBrickStairs;
	public Sprite StoneBrickSlab;

	
}
