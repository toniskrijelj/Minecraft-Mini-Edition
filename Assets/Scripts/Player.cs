using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.XR;

[Serializable]
public class PlayerData
{
	public float[] position;
	public int healthMissingPoints;
	public int hungerMissingPoints;

	public PlayerData(Player player)
	{
		Vector3 playerPosition = player.transform.position;
		position = new float[3];
		position[0] = playerPosition.x;
		position[1] = playerPosition.y;
		position[2] = playerPosition.z;
		healthMissingPoints = player.GetComponent<HealthSystem>().GetMissingPoints();
		hungerMissingPoints = player.hungerSytem.GetMissingPoints();
	}
}

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
	private int bonusDamage = 0;

	public event Action OnPlayerRespawn;

	public HungerSytem hungerSytem { get; private set; }

	private void Awake()
	{
		Instance = this;
		handVisualItem = GetComponent<HandBlock>();
		hungerSytem = GetComponent<HungerSytem>();
		GetComponent<HealthSystem>().OnResourceEmpty += HealthSystem_OnResourceEmpty;
		DeathScreen.OnQuit += Save;
	}

	private void Start()
	{
		Load();
	}

	private void HealthSystem_OnResourceEmpty(object sender, System.EventArgs e)
	{
		DeathScreen.Instance.SetActive(true);
		enabled = false;
	}

	public void Respawn()
	{
		if (enabled) return;
		transform.position = new Vector3(0, 1, 0);
		OnPlayerRespawn?.Invoke();
		DeathScreen.Instance.SetActive(false);
		GetComponent<HealthSystem>().Increase(20);
		hungerSytem.Increase(20);
		enabled = true;
	}

	public void ChangeHandSlot(Slot slot)
	{
		if (HandSlot != null)
		{
			HandSlot.OnSlotChanged -= HandSlot_OnSlotChanged;
		}
		handItem?.RemoveFromHand();
		HandSlot = slot;
		HandSlot?.Item?.PutInHand();
		handItem = slot?.Item;
		handVisualItem.SetItem(handItem, activeTool);
		ItemText.Instance.SetItem(slot?.Item);
		if (HandSlot != null)
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

	public void ChangeBonusDamage(int difference)
	{
		bonusDamage += difference;
	}

	Block currentBlock = null;

	void Update()
	{
		bool blockTriggered = false;
		Vector3 mouseWorldPosition = Utilities.GetMouseWorldPosition();
		mouseWorldPosition.z = 0;
		Vector3 pos = transform.position;
		pos.z = 0;
		if(Input.GetMouseButtonDown(0))
		{
			var hits = Physics2D.RaycastAll(pos, (mouseWorldPosition - pos).normalized, 4, 1 << 10);
			for(int i = 0; i < hits.Length; i++)
			{
				if (hits[i].transform == transform) continue;
				hits[i].transform.GetComponent<HealthSystem>().Decrease(1 + bonusDamage);
			}
		}

		if ((mouseWorldPosition - transform.position).sqrMagnitude <= range * range)
		{
			Vector2Int mouseGridPosition = BlockGrid.Instance.GetXY(mouseWorldPosition);
			Block block = BlockGrid.Instance.GetBlock(mouseGridPosition, Layer.Ground);
			if(block == null) block = BlockGrid.Instance.GetBlock(mouseGridPosition, Layer.Background);
			if (block != null)
			{
				if (block != currentBlock)
				{
					currentBlock?.Repair();
				}
				currentBlock = block;
				if (Input.GetMouseButtonDown(1))
				{
					if(block != null && block.specialAction != null)
					{
						blockTriggered = true;
						block.specialAction.Invoke();
					}
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
		if (!blockTriggered)
		{
			if (Input.GetMouseButtonDown(1))
			{
				if (HandSlot != null && HandSlot.Item != null)
				{
					HandSlot.Item.OnRightClickDown();
				}
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
			if (Input.GetMouseButtonUp(1))
			{
				if (HandSlot != null && HandSlot.Item != null)
				{
					HandSlot.Item.OnRightClickUp();
				}
			}
		}
	}
	public bool HoldingBlock()
	{
		if (HandSlot == null) return false;
		return HandSlot.Item is Item.BlockItem;
	}

	private bool Load()
	{
		if (File.Exists(Application.dataPath + "/player.txt"))
		{
			string saveString = File.ReadAllText(Application.dataPath + "/player.txt");

			PlayerData data = JsonUtility.FromJson<PlayerData>(saveString);
			transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
			hungerSytem.Decrease(data.hungerMissingPoints);
			GetComponent<HealthSystem>().Decrease(data.healthMissingPoints);
			return true;
		}
		return false;
	}

	public void Save()
	{
		string json = JsonUtility.ToJson(new PlayerData(this));
		File.WriteAllText(Application.dataPath + "/player.txt", json);
	}
}
