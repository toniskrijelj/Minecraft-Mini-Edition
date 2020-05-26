using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEntity : MonoBehaviour
{
	private static ItemEntity prefab = null;
	private static ItemEntity Prefab
	{
		get
		{
			if(prefab == null)
			{
				prefab = Resources.Load<ItemEntity>("ItemEntity");
			}
			return prefab;
		}
	}

	public static ItemEntity Spawn(Vector3 worldPosition, Item item, int amount)
	{
		ItemEntity itemEntity = Instantiate(Prefab, worldPosition, Quaternion.identity);
		itemEntity.item = item;
		for(int i = 0; i < itemEntity.spriteRenderers.Length; i++)
		{
			itemEntity.spriteRenderers[i].sprite = item.GetIcon();
		}
		itemEntity.SetAmount(amount);
		//itemEntity.rb.velocity = new Vector2(-Mathf.Sign(PlayerSprite.Instance.transform.localScale.x) * itemEntity.throwPower, 0);
		return itemEntity;
	}

	[SerializeField] private float bobbingSpeed = 2f;
	[SerializeField] private float throwPower = 3;
	[SerializeField] private Transform offset = null;
	[SerializeField] private Rigidbody2D rb = null;
	[SerializeField] private SpriteRenderer[] spriteRenderers = null;

	private int amount;
	private Item item;
	private float spawnTime;
	private bool picked = false;

	private void Awake()
	{
		spawnTime = Time.time;
	}

	private void Update()
	{
		offset.localPosition = Vector3.up * Mathf.Sin((Time.time - spawnTime) * bobbingSpeed) / 10f;
	}

	private void SetAmount(int amount)
	{
		if(amount <= 0)
		{
			Destroy(gameObject);
			return;
		}
		if (amount >= 21)
		{
			spriteRenderers[0].enabled = true;
			spriteRenderers[1].enabled = true;
			spriteRenderers[2].enabled = true;
			spriteRenderers[3].enabled = true;
		}
		else if (amount >= 6)
		{
			spriteRenderers[0].enabled = true;
			spriteRenderers[1].enabled = true;
			spriteRenderers[2].enabled = true;
			spriteRenderers[3].enabled = false;
		}
		else if (amount >= 2)
		{
			spriteRenderers[0].enabled = true;
			spriteRenderers[1].enabled = true;
			spriteRenderers[2].enabled = false;
			spriteRenderers[3].enabled = false;
		}
		else
		{
			spriteRenderers[0].enabled = true;
			spriteRenderers[1].enabled = false;
			spriteRenderers[2].enabled = false;
			spriteRenderers[3].enabled = false;
		}
		this.amount = amount;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (picked) return;
		if(collision.CompareTag("Player"))
		{
			if(spawnTime + 2 < Time.time)
			{
				Inventory playerInventory = collision.GetComponent<Inventory>();
				int addedAmount = playerInventory.Add(item, amount);
				amount -= addedAmount;
				if (amount <= 0)
				{
					picked = true;
					Destroy(gameObject);
				}
				else
				{
					SetAmount(amount);
				}
			}
		}
		else
		{
			ItemEntity itemEntity = collision.GetComponent<ItemEntity>();
			if (itemEntity.picked) return;
			if (itemEntity.item == item)
			{
				if (item.stackable)
				{
					if (amount >= itemEntity.amount)
					{
						int amountToAdd = Mathf.Min(64 - amount, itemEntity.amount);
						if(amountToAdd == itemEntity.amount)
						{
							itemEntity.picked = true;
							SetAmount(amount + amountToAdd);
							spawnTime = Time.time;
							Destroy(itemEntity.gameObject);
						}
						else if(amountToAdd > 0)
						{
							itemEntity.spawnTime = spawnTime = Time.time;
							SetAmount(amount + amountToAdd);
							itemEntity.SetAmount(itemEntity.amount - amountToAdd);
						}
					}
				}
			}

		}
	}
}
