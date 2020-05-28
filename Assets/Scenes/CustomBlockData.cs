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

	private static Door door;
	public static Door Door
	{
		get
		{
			if (door == null)
			{
				door = Resources.Load<Door>("DoorPrefab");
			}
			return door;
		}
	}

	private static Stairs stairs;
	public static Stairs Stairs
	{
		get
		{
			if (stairs == null)
			{
				stairs = Resources.Load<Stairs>("StairsPrefab");
			}
			return stairs;
		}
	}

	private static Slab slab;
	public static Slab Slab
	{
		get
		{
			if (slab == null)
			{
				slab = Resources.Load<Slab>("SlabPrefab");
			}
			return slab;
		}
	}
}
