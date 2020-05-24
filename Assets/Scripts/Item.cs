using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item : Enumeration
{
	public static readonly Item DiamondSword = new SwordItem("Diamond Sword", () => ItemData.icons.DiamondSword, 4);
	public static readonly Item WoodenSword = new SwordItem("Wooden Sword", () => ItemData.icons.WoodenSword, 1);
	public static readonly Item OakPlanks = new BlockItem("Oak Planks", () => ItemData.icons.oakPlanks, BlockType.OakPlanks);
	public static readonly Item WoodenPickaxe = new ToolItem("Wooden Pickaxe", () => ItemData.icons.WoodenPickaxe, ToolType.Pickaxe, ToolMaterial.Wood);

	private Action putInHand = null;
	private Action removeFromHand = null;
	private Func<bool> specialAction = null;

	public readonly bool stackable;

	public Func<Sprite> GetIcon { get; }

	protected Item(string displayName, Func<Sprite> iconFunc, bool stackable) : base(displayName)
	{
		GetIcon = iconFunc;
		this.stackable = stackable;
	}

	protected Item(int value, string displayName, Action putInHand, Action removeFromHand, Func<bool> specialAction) : base(displayName)
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

	public bool SpecialAction()
	{
		if(specialAction == null)
		{
			return false;
		}
		return specialAction.Invoke();
	}

	private class SwordItem : Item
	{
		public SwordItem(string displayName, Func<Sprite> icon, int damageIncrease) : base(displayName, icon, false)
		{
			putInHand = () => Player.Instance.ChangeBonusDamage(damageIncrease);
			removeFromHand = () => Player.Instance.ChangeBonusDamage(-damageIncrease);
		}
	}
	public class BlockItem : Item
	{
		public BlockItem(string displayName, Func<Sprite> icon, BlockType blockType) : base(displayName, icon, true)
		{
			specialAction = blockType.TryPlace;
		}
	}
	private class ToolItem : Item
	{
		public ToolItem(string displayName, Func<Sprite> icon, ToolType type, ToolMaterial material) : base(displayName, icon, false)
		{
			putInHand = () => Player.Instance.ChangeTool(type, material);
			removeFromHand = () => Player.Instance.ChangeTool(ToolType.None, ToolMaterial.All);
		}
	}
}
