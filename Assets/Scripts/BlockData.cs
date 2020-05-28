using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockData : MonoBehaviour
{
	private static BlockData _i;

	public static BlockData blockData
	{
		get
		{
			if (_i == null)
			{
				_i = Resources.Load<BlockData>("BlockData");
			}
			return _i;
		}
	}

	public Sprite dirtBlockTexture;
	public Sprite sandTexture;
	public Sprite birchLogTexture;
	public Sprite chestTexture;
	public Sprite birchPlanksTexture;
	public Sprite sprucePlanksTexture;
	public Sprite chestBackTexture;
	public Sprite coalOreTexture;
	public Sprite cobblestoneTexture;
	public Sprite spruceLeavesTexture;
	public Sprite diamondOreTexture;
	public Sprite doorTexture;
	public Sprite goldOreTexture;
	public Sprite grassBlockTexture;
	public Sprite ironOreTexture;
	public Sprite oakLeavesTexture;
	public Sprite oakLogTexture;
	public Sprite openDoorTexture;
	public Sprite oakPlanksTexture;
	public Sprite spruceLogTexture;
	public Sprite stoneBlockTexture;
	public Sprite CraftingTableTexture;
	public Sprite furnaceUnlit;
	public Sprite furnaceLit;
	public Sprite TNT;
	public Sprite DiamondBlock;
	public Sprite IronBlock;
	public Sprite EmeraldBlock;
	public Sprite GoldBlock;
	public Sprite CoalBlock;
	public Sprite doorTextureOpen;
	public Sprite doorTextureClosed;
	public Sprite cobbleStoneStairs;
	public Sprite cobblestoneSlab;
}
