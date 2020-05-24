using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOutline : MonoBehaviour
{
	SpriteRenderer blockOutline;

	private void Awake()
	{
		blockOutline = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		Vector3 mouseWorldPosition = Utilities.GetMouseWorldPosition();
		if ((mouseWorldPosition - Player.Instance.transform.position).sqrMagnitude <= Player.range * Player.range)
		{
			Vector2Int mouseGridPosition = BlockGrid.Instance.GetXY(mouseWorldPosition);
			Block block = BlockGrid.Instance.GetBlock(mouseGridPosition);
			if (block != null)
			{
				transform.position = BlockGrid.Instance.GetWorldPosition(mouseGridPosition);
				blockOutline.enabled = true;
			}
			else if(Player.Instance.HoldingBlock())
			{
				if (BlockGrid.Instance.CanPlace(mouseGridPosition))
				{
					transform.position = BlockGrid.Instance.GetWorldPosition(mouseGridPosition);
					blockOutline.enabled = true;
				}
				else
				{
					blockOutline.enabled = false;
					blockOutline.enabled = false;
				}
			}
			else
			{
				blockOutline.enabled = false;
				blockOutline.enabled = false;
			}
		}
		else
		{
			blockOutline.enabled = false;
			blockOutline.enabled = false;
		}
	}
}
