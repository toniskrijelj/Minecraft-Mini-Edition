using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
	public static Player Instance { get; private set; }
	public const float range = 4;
	[SerializeField] private GameObject breakObject = null;
	[SerializeField] private Transform fillBar = null;

	private HandBlock handVisualItem;
	public Slot HandSlot { get; private set; }
	private Item handItem;
	private ToolType activeTool = ToolType.None;
	private ToolMaterial toolMaterial = ToolMaterial.All;
	private float bonusDamage = 0;

	HungerSytem hungerSytem;
	HealthSystem healthSystem;

	private void Awake()
	{
		Instance = this;
		handVisualItem = GetComponent<HandBlock>();
		healthSystem = GetComponent<HealthSystem>();
		hungerSytem = GetComponent<HungerSytem>();
		healthSystem.OnResourceEmpty += HealthSystem_OnResourceEmpty;
	}

	private void HealthSystem_OnResourceEmpty(object sender, System.EventArgs e)
	{
		DeathScreen.Instance.SetActive(true);
		enabled = false;
	}

	public void ChangeHandSlot(Slot slot)
	{
		if(HandSlot != null)
		{
			HandSlot.OnSlotChanged -= HandSlot_OnSlotChanged;
		}
		handItem?.RemoveFromHand();
		HandSlot = slot;
		HandSlot?.Item?.PutInHand();
		handItem = slot?.Item;
		handVisualItem.SetItem(handItem, activeTool);
		if(HandSlot != null)
		{
			HandSlot.OnSlotChanged += HandSlot_OnSlotChanged;
		}
	}

	private void HandSlot_OnSlotChanged(int i)
	{
		if (handItem != HandSlot.Item)
		{
			handItem?.RemoveFromHand();
			handItem = HandSlot.Item;
			handItem?.PutInHand();
			handVisualItem.SetItem(handItem, activeTool);
		}
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
		//Debug.Log(activeTool);
		//Debug.Log(toolMaterial);
		Vector3 mouseWorldPosition = Utilities.GetMouseWorldPosition();
		if ((mouseWorldPosition - transform.position).sqrMagnitude <= range * range)
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
					currentBlock.Damage(activeTool, toolMaterial);
					fillBar.transform.localScale = new Vector3(currentBlock.Percentage(), fillBar.transform.localScale.y);
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
		if (Input.GetMouseButton(1))
		{
			if (HandSlot != null && HandSlot.Item != null)
			{
				if (HandSlot.Item.SpecialAction())
				{
					HandSlot.Consume(1);
				}
			}
		}
	}
	public bool HoldingBlock()
	{
		if (HandSlot == null) return false;
		return HandSlot.Item is Item.BlockItem;
	}
}
