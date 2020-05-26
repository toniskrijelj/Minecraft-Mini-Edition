using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Recipe
{
	public readonly Item[,] layout;
	public readonly Dictionary<Item, int> ingredients;

	public Recipe(Item[,] layout)
	{
		/// flip upside-down
		for(int i = 0; i < 3; i++)
		{
			Item temp = layout[0, i];
			layout[0, i] = layout[2, i];
			layout[2, i] = temp;
		}
		this.layout = layout;
		ingredients = GetIngredients(layout);
	}

	public static bool CompareLayouts(Item[,] layout1, Item[,] layout2)
	{
		for (int y = 0; y < 3; y++)
		{
			for (int x = 0; x < 3; x++)
			{
				if (layout1[y, x] != layout2[y, x])
				{
					return false;
				}
			}
		}
		return true;
	}

	public static void Print(Item[,] layout)
	{
		for (int y = 2; y >= 0; y--)
		{
			Debug.Log(((layout[y, 0] == null) ? "0" : layout[y, 0].ToString()) + " " + ((layout[y, 1] == null) ? "0" : layout[y, 1].ToString()) + " " + ((layout[y, 2] == null) ? "0" : layout[y, 2].ToString()));
		}
	}

	public bool CanMove(Vector2Int direction)
	{
		return CanMove(direction.x, direction.y);
	}
	public bool CanMove(int xMove, int yMove)
	{
		for (int y = 0; y < 3; y++)
		{
			for (int x = 0; x < 3; x++)
			{
				if (x + xMove < 0 || x + xMove > 2 || y + yMove < 0 || y + yMove > 2)
				{
					if (layout[y, x] != null)
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	public static Item[,] Move(Item[,] layout, Vector2Int direction)
	{
		return Move(layout, direction.x, direction.y);
	}
	public static Item[,] Move(Item[,] layout, int xMove, int yMove)
	{
		Item[,] newLayout = new Item[3, 3];
		for (int y = 0; y < 3; y++)
		{
			for (int x = 0; x < 3; x++)
			{
				if (layout[y, x] != null)
				{
					newLayout[y + yMove, x + xMove] = layout[y, x];
				}
			}
		}
		return newLayout;
	}

	public static Item[,] Flip(Item[,] layout)
	{
		Item[,] newLayout = new Item[3, 3];
		for(int i = 0; i < 3; i++)
		{
			newLayout[i, 1] = layout[i, 1];
			newLayout[i, 0] = layout[i, 2];
			newLayout[i, 2] = layout[i, 0];
		}
		return newLayout;
	}

	public static Dictionary<Item, int> GetIngredients(Item[,] layout)
	{
		Dictionary<Item, int> ingredients = new Dictionary<Item, int>();
		for (int y = 0; y < 3; y++)
		{
			for (int x = 0; x < 3; x++)
			{
				Item currItem = layout[y, x];
				if (currItem != null)
				{
					if(ingredients.ContainsKey(currItem))
					{
						ingredients[currItem]++;
					}
					else
					{
						ingredients.Add(currItem, 1);
					}
				}
			}
		}
		return ingredients;
	}
}