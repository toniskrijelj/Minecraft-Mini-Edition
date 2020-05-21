using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public static Player Instance { get; private set; }

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

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
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


			if (Input.GetMouseButtonDown(0))
			{
				BlockGrid.Instance.SetBlock(breakGridPosition.x, breakGridPosition.y, null);
			}

			if (inHand is Item.BlockItem)
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
}
