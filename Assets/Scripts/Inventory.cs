using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class InventoryData
{
	public SlotData[] slots;

	public InventoryData(Inventory inventory)
	{
		slots = new SlotData[Inventory.SLOTS];
		for(int i = 0; i < Inventory.SLOTS; i++)
		{
			slots[i] = new SlotData(inventory.slots[i]);
		}
	}
}

public class Inventory : MonoBehaviour
{
	public static Inventory Instance { get; private set; }

	public const int SLOTS = 36;
	public event Action<int> OnSlotChanged;
	public event Action<int> OnActiveSlotChanged;
	public readonly Slot[] slots = new Slot[SLOTS];
	Player player;

	private void Awake()
	{
		Instance = this;
		player = GetComponent<Player>();
		player.OnPlayerRespawn += Player_OnPlayerRespawn;
		GetComponent<HealthSystem>().OnResourceEmpty += Inventory_OnResourceEmpty;
		DeathScreen.OnQuit += Save;
		if (!Load())
		{
			for (int i = 0; i < SLOTS; i++)
			{
				slots[i] = new Slot(null, 0, i);
			}
		}
	}

	private void Player_OnPlayerRespawn()
	{
		enabled = true;
	}

	private void Inventory_OnResourceEmpty(object sender, EventArgs e)
	{
		for (int i = 0; i < SLOTS; i++)
		{
			slots[i].Drop(true);
		}
		enabled = false;
	}

	private void Start()
	{
		player.ChangeHandSlot(slots[0]);
	}

	private void OnEnable()
	{
		for (int i = 0; i < SLOTS; i++)
		{
			slots[i].OnSlotChanged += OnSlotChanged;
		}
	}
	private void OnDisable()
	{
		for (int i = 0; i < SLOTS; i++)
		{
			slots[i].OnSlotChanged -= OnSlotChanged;
		}
	}

	private void Update()
	{
		if (!player.enabled) return;


		float mouseScroll = Input.GetAxisRaw("Mouse ScrollWheel");
		if (mouseScroll < 0)
		{
			int index = player.HandSlot.Index;
			index = (index + 1) % 9;
			SetActiveSlot(index);
		}
		else if (mouseScroll > 0)
		{
			int index = player.HandSlot.Index;
			index -= 1;
			if (index <= -1)
			{
				index = 8;
			}
			SetActiveSlot(index);
		}
		for (int i = 0; i < 9; i++)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1 + i))
			{
				SetActiveSlot(i);
				break;
			}
		}
		if (Input.GetKeyDown(KeyCode.Q))
		{
			if (player.HandSlot != null)
			{
				Drop(player.HandSlot.Index, Input.GetKey(KeyCode.LeftControl));
			}
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			Add(Item.OakPlanks, 16);
		}
	}

	public void SetActiveSlot(int index)
	{
		index = Mathf.Clamp(index, 0, 8);
		player.ChangeHandSlot(slots[index]);
		OnActiveSlotChanged?.Invoke(index);
	}

	public int MaxAdd(Item item, int amount)
	{
		int couldBeAdded = 0;
		for (int i = 0; i < SLOTS; i++)
		{
			couldBeAdded += slots[i].MaxAddAmount(item, amount - couldBeAdded);
			if (couldBeAdded == amount)
			{
				break;
			}
		}
		return couldBeAdded;
	}

	public int Add(Item item, int amount)
	{
		if (!enabled) return 0;
		int amountAdded = 0;
		for (int i = 0; i < SLOTS; i++)
		{
			if (slots[i].TrySetItem(item))
			{
				amountAdded += slots[i].AddAmount(amount - amountAdded);
				if (amountAdded == amount)
				{
					break;
				}
			}
		}
		return amountAdded;
	}

	public void Remove(int index, int amount)
	{
		slots[index].Consume(amount);
	}

	public void Drop(int index, bool all = false)
	{
		slots[index].Drop(all);
	}

	public void Save()
	{
		string json = JsonUtility.ToJson(new InventoryData(this));
		File.WriteAllText(Application.dataPath + "/inventory.txt", json);
	}

	private bool Load()
	{
		if (File.Exists(Application.dataPath + "/inventory.txt"))
		{
			string saveString = File.ReadAllText(Application.dataPath + "/inventory.txt");

			InventoryData data = JsonUtility.FromJson<InventoryData>(saveString);
			for(int i = 0; i < SLOTS; i++)
			{
				slots[i] = data.slots[i].GetSlot();
			}
			return true;
		}
		return false;
	}
}
