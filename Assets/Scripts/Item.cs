using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item : Enumeration
{
	public static readonly Item DiamondSword = new SwordItem("Diamond Sword", () => ItemData.icons.diamondSword, 4);
	public static readonly Item WoodenSword = new SwordItem("Wooden Sword", () => ItemData.icons.woodenSword, 1);
	public static readonly Item OakPlanks = new BlockItem("Oak Planks", () => ItemData.icons.oakPlanks, BlockType.OakPlanks);
	public static readonly Item WoodenPickaxe = new ToolItem("Wooden Pickaxe", () => ItemData.icons.woodenPickaxe, ToolType.Pickaxe, ToolMaterial.Wood);

	private Action putInHand = null;
	private Action removeFromHand = null;
	private Action specialAction = null;

	public Func<Sprite> GetIcon { get; }

	protected Item(string displayName, Func<Sprite> iconFunc) : base(displayName) { GetIcon = iconFunc; }

	protected Item(int value, string displayName, Action putInHand, Action removeFromHand, Action specialAction) : base(displayName)
	{
		this.putInHand = putInHand;
		this.removeFromHand = removeFromHand;
		this.specialAction = specialAction;
	}

	public void PutInHand()
	{
		putInHand?.Invoke();
	}

	public void RemoveFromHand()
	{
		removeFromHand?.Invoke();
	}

	public void SpecialAction()
	{
		specialAction?.Invoke();
	}

	private class SwordItem : Item
	{
		public SwordItem(string displayName, Func<Sprite> icon, int damageIncrease) : base(displayName, icon)
		{
			putInHand = () => Player.Instance.ChangeBonusDamage(damageIncrease);
			removeFromHand = () => Player.Instance.ChangeBonusDamage(-damageIncrease);
		}
	}
	public class BlockItem : Item
	{
		public BlockItem(string displayName, Func<Sprite> icon, BlockType blockType) : base(displayName, icon)
		{
			specialAction = blockType.TryPlace;
		}
	}
	private class ToolItem : Item
	{
		public ToolItem(string displayName, Func<Sprite> icon, ToolType type, ToolMaterial material) : base(displayName, icon)
		{
			putInHand = () => Player.Instance.ChangeTool(type, material);
			removeFromHand = () => Player.Instance.ChangeTool(ToolType.None, ToolMaterial.All);
		}
	}
}
