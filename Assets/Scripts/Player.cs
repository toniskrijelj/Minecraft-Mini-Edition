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
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var hit = Physics2D.Raycast(transform.position, (mousePosition - transform.position).normalized, 4, 1 << 8);
		if (hit)
		{
			Vector2 placeWorldPosition = hit.point + hit.normal * 0.1f;
			Vector2 breakWorldPosition = hit.point - hit.normal * 0.1f;

			Vector2Int placeGridPosition = BlockGrid.Instance.GetXY(placeWorldPosition);
			Vector2Int breakGridPosition = BlockGrid.Instance.GetXY(breakWorldPosition);

			Block newBlock = BlockGrid.Instance.GetBlock(breakGridPosition.x, breakGridPosition.y);
			if(newBlock != currentBlock)
			{
				currentBlock?.Repair();
			}
			currentBlock = newBlock;
			if (Input.GetMouseButtonDown(0))
			{

			}
			if(Input.GetMouseButton(0))
			{
				breakObject.SetActive(true);
				breakObject.transform.position = BlockGrid.Instance.GetWorldPosition(breakGridPosition.x, breakGridPosition.y);
				if(currentBlock.Damage(activeTool, toolMaterial))
				{
					BlockGrid.Instance.SetBlock(breakGridPosition.x, breakGridPosition.y, null);
					breakObject.SetActive(false);
				}
				fillBar.transform.localScale = new Vector3(currentBlock.Percentage(), fillBar.transform.localScale.y);
			}
			else
			{
				breakObject.SetActive(false);
			}
			if(Input.GetMouseButtonUp(0))
			{
				currentBlock?.Repair();
			}

			if (HoldingBlock())
			{
				if (Input.GetMouseButton(1))
				{
					inHand.SpecialAction();
				}
			}
			else
			{
				if(Input.GetMouseButtonDown(1))
				{
					inHand.SpecialAction();
				}
			}
		}
		else
		{
			currentBlock?.Repair();
			currentBlock = null;
			breakObject.SetActive(false);
		}
	}

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

	public bool HoldingBlock()
	{
		return inHand is Item.BlockItem;
	}
}
