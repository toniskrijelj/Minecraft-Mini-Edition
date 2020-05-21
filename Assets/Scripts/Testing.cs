using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
	public void Awake()
	{
		new BlockGrid(16, 9, 1, new Vector3(-9, -5));
		for (int i = 0; i < 10; i++)
		{
			SpriteRenderer spriteRenderer = Object.Instantiate(BlockData.blockData.blockPrefab, BlockGrid.Instance.GetWorldPosition(i, 0), Quaternion.identity);
			BlockGrid.Instance.SetBlock(i, 0, new Block(1, ToolType.None, ToolMaterial.All, spriteRenderer, "BLOCK NIGGA " + i, BlockData.blockData.oakPlanksTexture));
		}
	}

}
