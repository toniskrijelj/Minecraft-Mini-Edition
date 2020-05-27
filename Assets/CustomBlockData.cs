using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBlockData : MonoBehaviour
{
	private static Furnace furnace;
	public static Furnace Furnace
	{
		get
		{
			if (furnace == null)
			{
				furnace = Resources.Load<Furnace>("FurnacePrefab");
			}
			return furnace;
		}
	}

	private static Chest chest;
	public static Chest Chest
	{
		get
		{
			if (chest == null)
			{
				chest = Resources.Load<Chest>("ChestPrefab");
			}
			return chest;
		}
	}
}
