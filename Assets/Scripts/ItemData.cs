using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
	private static ItemData _i;

	public static ItemData icons
	{
		get
		{
			if (_i == null)
			{
				_i = Resources.Load<ItemData>("ItemData");
			}
			return _i;
		}
	}

	public Sprite oakPlanks;
	public Sprite diamondSword;
	public Sprite woodenSword;
	public Sprite woodenPickaxe;
}
