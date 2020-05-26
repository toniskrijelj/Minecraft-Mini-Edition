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
		Item[,] diamondPickRecipe = new Item[3, 3]
		{
			{Item.Diamond ,   Item.Diamond,    Item.Diamond},
			{null ,   Item.OakPlanks,       null},
			{null ,   Item.OakPlanks,     null},
		};
		Item[,] diamondSwordRecipe = new Item[3, 3]
		{
			{null,   Item.Diamond,       null},
			{null ,   Item.Diamond,       null},
			{null ,   Item.OakPlanks,     null},
		};
		Item[,] doorRecipe = new Item[3, 3]
		{
			{ Item.OakPlanks,   Item.OakPlanks,       null},
			{ Item.OakPlanks ,   Item.OakPlanks,       null},
			{ Item.OakPlanks ,   Item.OakPlanks,     null},
		};
		recipes.Add(new Recipe(diamondPickRecipe), new Slot(Item.DiamondPickaxe, 1));
		recipes.Add(new Recipe(oakPlanksRecipe), new Slot(Item.OakPlanks, 4));
		recipes.Add(new Recipe(diamondSwordRecipe), new Slot(Item.DiamondSword, 1));
		recipes.Add(new Recipe(doorRecipe), new Slot(Item.Door, 3));
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
					Debug.Log("ima same ingredients");
					Item[,] newLayout;
					for (int i = -1; i <= 1; i++)
					{
						for(int j = -1; j <= 1; j++)
						{
							if(recipe.CanMove(j, i))
							{
								if(i == 0 && j == 0)
								{
									Debug.Log("testiram 0, 0");
									newLayout = Recipe.Move(recipe.layout, j, i);
									Recipe.Print(newLayout);
									Debug.Log("kurcina ");
									Recipe.Print(recipe.layout);
								}
								newLayout = Recipe.Move(recipe.layout, j, i);
								if (Recipe.CompareLayouts(layout, newLayout))
								{
									Debug.Log("pronadjen");
									return recipes[recipe];
								}
							}
						}
					}
					newLayout = Recipe.Flip(recipe.layout);
					if (Recipe.CompareLayouts(layout, newLayout))
					{
						Debug.Log("pronadjen");
						return recipes[recipe];
					}
				}
			}
		}
		return null;
	}
}
