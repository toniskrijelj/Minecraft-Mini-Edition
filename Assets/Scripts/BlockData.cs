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
				_i = (Resources.Load("BlockData") as GameObject).GetComponent<BlockData>();
			}
			return _i;
		}
	}

	private void Awake()
	{
		if(_i == null)
		{
			_i = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public SpriteRenderer blockPrefab;

	public Sprite oakPlanksTexture;
}
