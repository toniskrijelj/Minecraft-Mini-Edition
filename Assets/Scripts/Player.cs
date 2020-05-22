using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public static Player Instance { get; private set; }

	[SerializeField] GameObject breakObject;
	[SerializeField] Transform fillBar;
	private Item inHand = Item.OakPlanks;
	private ToolType activeTool = ToolType.None;
	private ToolMaterial toolMaterial = ToolMaterial.All;
	private float bonusDamage = 0;

	private void Awake()
	{
		Instance = this;
	}

	public void ChangeItem(Item item)
	{
		inHand?.RemoveFromHand();
		inHand = item;
		inHand?.PutInHand();
	}

	public void ChangeTool(ToolType tool, ToolMaterial material)
	{
		activeTool = tool;
		toolMaterial = material;
	}

	public void ChangeBonusDamage(float difference)
	{
		bonusDamage += difference;
	}

	Block currentBlock = null;

    void Update()
    {
		Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouseWorldPosition.z = 0;
		if ((mouseWorldPosition - transform.position).sqrMagnitude <= 4 * 4)
		{
			Vector2Int mouseGridPosition = BlockGrid.Instance.GetXY(mouseWorldPosition);
			Block block = BlockGrid.Instance.GetBlock(mouseGridPosition);
			if (block != null)
			{
				if (block != currentBlock)
				{
					currentBlock?.Repair();
				}
				currentBlock = block;
				if (Input.GetMouseButtonDown(0))
				{

				}
				if (Input.GetMouseButton(0))
				{
					breakObject.SetActive(true);
					breakObject.transform.position = BlockGrid.Instance.GetWorldPosition(mouseGridPosition);
					if (currentBlock.Damage(activeTool, toolMaterial))
					{
						breakObject.SetActive(false);
						currentBlock = null;
						block = null;
						BlockGrid.Instance.SetBlock(mouseGridPosition, null);
					}
					else
					{
						fillBar.transform.localScale = new Vector3(currentBlock.Percentage(), fillBar.transform.localScale.y);
					}
				}
				else
				{
					breakObject.SetActive(false);
				}
				if (Input.GetMouseButtonUp(0))
				{
					currentBlock?.Repair();
				}
			}
			else
			{
				currentBlock?.Repair();
				currentBlock = null;
				breakObject.SetActive(false);
			}
		}
		else
		{
			currentBlock?.Repair();
			currentBlock = null;
			breakObject.SetActive(false);
		}
		if (Input.GetMouseButtonDown(1))
		{
			inHand.SpecialAction();
		}
	}
	/*
	private void OnDrawGizmos()
	{
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var hit = Physics2D.Raycast(transform.position, (mousePosition - transform.position).normalized, 4, 1 << 8);
		Gizmos.DrawRay(transform.position, (mousePosition - transform.position).normalized * 4);

		Vector2 placeWorldPosition = hit.point + hit.normal * 0.1f;
		Vector2 breakWorldPosition = hit.point - hit.normal * 0.1f;

		Gizmos.DrawSphere(placeWorldPosition, .05f);
		Gizmos.DrawSphere(breakWorldPosition, .05f);
	}
	*/
	public bool HoldingBlock()
	{
		return inHand is Item.BlockItem;
	}
}
