using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOutline : MonoBehaviour
{
	[SerializeField] SpriteRenderer breakOutline = null;
	[SerializeField] SpriteRenderer placeOutline = null;

	/*
	void Update()
	{
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var hit = Physics2D.Raycast(Player.Instance.transform.position, (mousePosition - Player.Instance.transform.position).normalized, 4, 1 << 8);
		if (hit)
		{
			Vector2 placeWorldPosition = hit.point + hit.normal * 0.1f;
			Vector2 breakWorldPosition = hit.point - hit.normal * 0.1f;
			Vector2Int placeGridPosition = BlockGrid.Instance.GetXY(placeWorldPosition);
			Vector2Int breakGridPosition = BlockGrid.Instance.GetXY(breakWorldPosition);
			breakOutline.enabled = true;
			breakOutline.transform.position = BlockGrid.Instance.GetWorldPosition(breakGridPosition.x, breakGridPosition.y);
			if (Player.Instance.HoldingBlock() && BlockGrid.Instance.CheckXY(placeGridPosition) && !Physics2D.BoxCast(placeWorldPosition, new Vector2(.8f, .8f), 0, Vector2.zero, 0, 1 << 10))
			{
				placeWorldPosition = BlockGrid.Instance.GetWorldPosition(placeGridPosition.x, placeGridPosition.y);
				placeOutline.transform.position = placeWorldPosition;
				placeOutline.enabled = true;
			}
			else
			{
				placeOutline.enabled = false;
			}
		}
		else
		{
			placeOutline.enabled = false;
			breakOutline.enabled = false;
		}
	}
	*/
}
