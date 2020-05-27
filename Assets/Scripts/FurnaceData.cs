using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FurnaceData
{
	private static Furnace prefab;
	public static Furnace Prefab
	{
		get
		{
			if (prefab == null)
			{
				prefab = Resources.Load<Furnace>("FurnacePrefab");
			}
			return prefab;
		}
	}

	private static Dictionary<Item, Item> productDictionary;
	private static Dictionary<Item, float> burnDictionary;


	[RuntimeInitializeOnLoadMethod]
	private static void Initialize()
	{
		productDictionary = new Dictionary<Item, Item>();
		burnDictionary = new Dictionary<Item, float>();
		productDictionary.Add(Item.IronOre, Item.Iron);
		burnDictionary.Add(Item.Coal, 80);
		burnDictionary.Add(Item.OakPlanks, 15);
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
