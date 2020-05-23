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

	public Sprite oakPlanksTexture;
}
