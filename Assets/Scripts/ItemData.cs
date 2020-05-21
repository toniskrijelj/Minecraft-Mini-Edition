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
				GameObject gameObj = Instantiate(Resources.Load("ItemData") as GameObject);
				_i = gameObj.GetComponent<ItemData>();
				_i.name = "ItemData";
			}
			return _i;
		}
	}

	private void Awake()
	{
		if (_i == null)
		{
			_i = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public Sprite oakPlanks;
	public Sprite diamondSword;
	public Sprite woodenSword;
	public Sprite woodenPickaxe;

}
