using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Recipes
{
	private static Dictionary<Recipe, Slot> recipes = new Dictionary<Recipe, Slot>();

	[RuntimeInitializeOnLoadMethod]
	private static void Initialize()
	{
		Item[,] oakPlanksRecipe = new Item[3, 3]
		{
			{ null , null ,		     null},
			{ null , Item.OakLog ,	 null},
			{ null , null ,         null},
		};
		Item[,] sprucePlanksRecipe = new Item[3, 3]
		{
			{ null , null ,          null},
			{ null , Item.SpruceLog ,   null},
			{ null , null ,         null},
		};
		Item[,] birchPlanksRecipe = new Item[3, 3]
		{
			{ null , null ,          null},
			{ null , Item.BirchLog ,   null},
			{ null , null ,         null},
		};
		Item[,] doorRecipe = new Item[3, 3]
		{
			{ Item.OakPlanks,   Item.OakPlanks,       null},
			{ Item.OakPlanks ,   Item.OakPlanks,       null},
			{ Item.OakPlanks ,   Item.OakPlanks,     null},
		};
		Item[,] stickRecipe = new Item[3, 3]
		{
			{ null,   null,       null},
			{ null,   Item.OakPlanks,       null},
			{ null,   Item.OakPlanks,     null},
		};
		Item[,] diamondPickRecipe = new Item[3, 3]
		{
			{Item.Diamond ,   Item.Diamond,    Item.Diamond},
			{null ,   Item.Stick,       null},
			{null ,   Item.Stick,     null},
		};
		Item[,] ironPickRecipe = new Item[3, 3]
		{
			{Item.Iron ,   Item.Iron,    Item.Iron},
			{null ,   Item.Stick,       null},
			{null ,   Item.Stick,     null},
		};
		Item[,] goldPickRecipe = new Item[3, 3]
		{
			{Item.Gold ,   Item.Gold,    Item.Gold},
			{null ,   Item.Stick,       null},
			{null ,   Item.Stick,     null},
		};
		Item[,] stonePickRecipe = new Item[3, 3]
		{
			{Item.Cobblestone ,   Item.Cobblestone,    Item.Cobblestone},
			{null ,   Item.Stick,       null},
			{null ,   Item.Stick,     null},
		};
		Item[,] woodenPickRecipe = new Item[3, 3]
		{
			{Item.OakPlanks ,   Item.OakPlanks,    Item.OakPlanks},
			{null ,   Item.Stick,       null},
			{null ,   Item.Stick,     null},
		};
		Item[,] woodenSwordRecipe = new Item[3, 3]
		{
			{null,   Item.OakPlanks,       null},
			{null ,   Item.OakPlanks,       null},
			{null ,   Item.Stick,     null},
		};
		Item[,] stoneSwordRecipe = new Item[3, 3]
		{
			{null,   Item.Cobblestone,       null},
			{null ,   Item.Cobblestone,       null},
			{null ,   Item.Stick,     null},
		};
		Item[,] diamondSwordRecipe = new Item[3, 3]
		{
			{null,   Item.Diamond,       null},
			{null ,   Item.Diamond,       null},
			{null ,   Item.Stick,     null},
		};
		Item[,] goldSwordRecipe = new Item[3, 3]
		{
			{null,   Item.Gold,       null},
			{null ,   Item.Gold,       null},
			{null ,   Item.Stick,     null},
		};
		Item[,] ironSwordRecipe = new Item[3, 3]
		{
			{null,   Item.Iron,       null},
			{null ,   Item.Iron,       null},
			{null ,   Item.Stick,     null},
		};
		Item[,] ironAxeRecipe = new Item[3, 3]
		{
			{null,   Item.Iron,       Item.Iron},
			{null ,   Item.Stick,       Item.Iron},
			{null ,   Item.Stick,     null},
		};
		Item[,] diamondAxeRecipe = new Item[3, 3]
		{
			{null,   Item.Diamond,       Item.Diamond},
			{null ,   Item.Stick,       Item.Diamond},
			{null ,   Item.Stick,     null},
		};
		Item[,] goldAxeRecipe = new Item[3, 3]
		{
			{null,   Item.Gold,       Item.Gold},
			{null ,   Item.Stick,       Item.Gold},
			{null ,   Item.Stick,     null},
		};
		Item[,] stoneAxeRecipe = new Item[3, 3]
		{
			{null,   Item.Cobblestone,       Item.Cobblestone},
			{null ,   Item.Stick,       Item.Cobblestone},
			{null ,   Item.Stick,     null},
		};
		Item[,] woodenAxeRecipe = new Item[3, 3]
		{
			{null,   Item.OakPlanks,       Item.OakPlanks},
			{null ,   Item.Stick,       Item.OakPlanks},
			{null ,   Item.Stick,     null},
		};
		Item[,] woodenShovelRecipe = new Item[3, 3]
		{
			{null,   Item.OakPlanks,       null},
			{null ,   Item.Stick,       null},
			{null ,   Item.Stick,     null},
		};
		Item[,] stoneShovelRecipe = new Item[3, 3]
		{
			{null,   Item.Cobblestone,       null},
			{null ,   Item.Stick,       null},
			{null ,   Item.Stick,     null},
		};
		Item[,] ironShovelRecipe = new Item[3, 3]
		{
			{null,   Item.Iron,       null},
			{null ,   Item.Stick,       null},
			{null ,   Item.Stick,     null},
		};
		Item[,] goldShovelRecipe = new Item[3, 3]
		{
			{null,   Item.Gold,       null},
			{null ,   Item.Stick,       null},
			{null ,   Item.Stick,     null},
		};
		Item[,] diamondShovelRecipe = new Item[3, 3]
		{
			{null,   Item.Diamond,       null},
			{null ,   Item.Stick,       null},
			{null ,   Item.Stick,     null},
		};
		Item[,] craftingTableRecipe = new Item[3, 3]
		{
			{ null,   null,       null},
			{ null,   Item.OakPlanks,       Item.OakPlanks},
			{ null,   Item.OakPlanks,     Item.OakPlanks},
		};
		Item[,] chestRecipe = new Item[3, 3]
		{
			{ Item.OakPlanks,   Item.OakPlanks,       Item.OakPlanks},
			{ Item.OakPlanks,   null,       Item.OakPlanks},
			{ Item.OakPlanks,   Item.OakPlanks,     Item.OakPlanks},
		};
		Item[,] breadRecipe = new Item[3, 3]
		{
			{ null,  null,  null},
			{ Item.Wheat,  Item.Wheat,  Item.Wheat},
			{ null,  null,  null},
		};
		Item[,] tntRecipe = new Item[3, 3]
		{
			{ Item.Gunpowder, Item.Sand, Item.Gunpowder},
			{ Item.Sand, Item.Gunpowder, Item.Sand},
			{ Item.Gunpowder, Item.Sand, Item.Gunpowder},
		};
		recipes.Add(new Recipe(tntRecipe), new Slot(Item.TNT, 1));
		recipes.Add(new Recipe(breadRecipe), new Slot(Item.Bread, 1));
		recipes.Add(new Recipe(chestRecipe), new Slot(Item.Chest, 1));
		recipes.Add(new Recipe(woodenShovelRecipe), new Slot(Item.WoodenShovel, 1));
		recipes.Add(new Recipe(stoneShovelRecipe), new Slot(Item.StoneShovel, 1));
		recipes.Add(new Recipe(ironShovelRecipe), new Slot(Item.IronShovel, 1));
		recipes.Add(new Recipe(goldShovelRecipe), new Slot(Item.GoldShovel, 1));
		recipes.Add(new Recipe(diamondShovelRecipe), new Slot(Item.DiamondShovel, 1));
		recipes.Add(new Recipe(ironAxeRecipe), new Slot(Item.IronAxe, 1));
		recipes.Add(new Recipe(diamondAxeRecipe), new Slot(Item.DiamondAxe, 1));
		recipes.Add(new Recipe(goldAxeRecipe), new Slot(Item.GoldenAxe, 1));
		recipes.Add(new Recipe(stoneAxeRecipe), new Slot(Item.StoneAxe, 1));
		recipes.Add(new Recipe(woodenAxeRecipe), new Slot(Item.WoodenAxe, 1));
		recipes.Add(new Recipe(diamondPickRecipe), new Slot(Item.DiamondPickaxe, 1));
		recipes.Add(new Recipe(goldPickRecipe), new Slot(Item.GoldPickaxe, 1));
		recipes.Add(new Recipe(ironPickRecipe), new Slot(Item.IronPickaxe, 1));
		recipes.Add(new Recipe(stonePickRecipe), new Slot(Item.StonePickaxe, 1));
		recipes.Add(new Recipe(woodenPickRecipe), new Slot(Item.WoodenPickaxe, 1));
		recipes.Add(new Recipe(diamondSwordRecipe), new Slot(Item.DiamondSword, 1));
		recipes.Add(new Recipe(stoneSwordRecipe), new Slot(Item.StoneSword, 1));
		recipes.Add(new Recipe(woodenSwordRecipe), new Slot(Item.WoodenSword, 1));
		recipes.Add(new Recipe(goldSwordRecipe), new Slot(Item.GoldSword, 1));
		recipes.Add(new Recipe(ironSwordRecipe), new Slot(Item.IronSword, 1));
		recipes.Add(new Recipe(craftingTableRecipe), new Slot(Item.CraftingTable, 1));
		recipes.Add(new Recipe(oakPlanksRecipe), new Slot(Item.OakPlanks, 4));
		recipes.Add(new Recipe(sprucePlanksRecipe), new Slot(Item.SprucePlanks, 4));
		recipes.Add(new Recipe(birchPlanksRecipe), new Slot(Item.BirchPlanks, 4));
		recipes.Add(new Recipe(doorRecipe), new Slot(Item.Door, 3));
		recipes.Add(new Recipe(stickRecipe), new Slot(Item.Stick, 4));
	}

	public static Slot TryCraft(Item[,] layout)
	{
		Dictionary<Item, int> ingredients = Recipe.GetIngredients(layout);

		foreach(var recipe in recipes.Keys)
		{
			if (recipe.ingredients.Count == ingredients.Count)
			{
				bool sameIngredients = true;
				foreach(var ingredient in recipe.ingredients.Keys)
				{
					if (ingredients.ContainsKey(ingredient))
					{
						if (recipe.ingredients[ingredient] != ingredients[ingredient])
						{
							sameIngredients = false;
							break;
						}
					}
					else
					{
						sameIngredients = false;
						break;
					}
				}
				if(sameIngredients)
				{
					Item[,] newLayout;
					for (int i = -1; i <= 1; i++)
					{
						for(int j = -1; j <= 1; j++)
						{
							if(recipe.CanMove(j, i))
							{
								newLayout = Recipe.Move(recipe.layout, j, i);
								if (Recipe.CompareLayouts(layout, newLayout))
								{
									return recipes[recipe];
								}
							}
						}
					}
					newLayout = Recipe.Flip(recipe.layout);
					if (Recipe.CompareLayouts(layout, newLayout))
					{
						return recipes[recipe];
					}
				}
			}
		}
		return null;
	}
}
