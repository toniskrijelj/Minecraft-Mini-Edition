using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FurnaceData
{
	private static Dictionary<Item, Item> productDictionary;
	private static Dictionary<Item, float> burnDictionary;


	[RuntimeInitializeOnLoadMethod]
	private static void Initialize()
	{
		productDictionary = new Dictionary<Item, Item>();
		burnDictionary = new Dictionary<Item, float>();
		productDictionary.Add(Item.IronOre, Item.Iron);
		productDictionary.Add(Item.BirchLog, Item.Coal);
		productDictionary.Add(Item.OakLog, Item.Coal);
		productDictionary.Add(Item.DiamondOre, Item.Diamond);
		productDictionary.Add(Item.CoalOre, Item.Coal);
		productDictionary.Add(Item.RawBeef, Item.CookedBeef);
		productDictionary.Add(Item.RawChicken, Item.CookedChicken);
		productDictionary.Add(Item.RawPork, Item.CookedPork);
		productDictionary.Add(Item.Potato, Item.BakedPotato);

		burnDictionary.Add(Item.Coal, 80);
		burnDictionary.Add(Item.OakPlanks, 15);
		burnDictionary.Add(Item.OakLog, 15);
		burnDictionary.Add(Item.BirchLog, 15);
		burnDictionary.Add(Item.BirchPlanks, 15);
		burnDictionary.Add(Item.SpruceLog, 15);
		burnDictionary.Add(Item.SpruceLeaves, 15);
		burnDictionary.Add(Item.Stick, 5);
		burnDictionary.Add(Item.Chest, 15);
		burnDictionary.Add(Item.CraftingTable, 15);
		burnDictionary.Add(Item.Door, 10);
		burnDictionary.Add(Item.WoodenAxe, 10);
		burnDictionary.Add(Item.WoodenPickaxe, 10);
		burnDictionary.Add(Item.WoodenShovel, 10);
		burnDictionary.Add(Item.WoodenSword, 10);
	}


	public static Item GetProductItem(Item item)
	{
		if (item == null) return null;
		return productDictionary.ContainsKey(item) ? productDictionary[item] : null;
	}

	public static float GetBurnTime(Item item)
	{
		if (item == null) return 0;
		return burnDictionary.ContainsKey(item) ? burnDictionary[item] : 0;
	}
}
