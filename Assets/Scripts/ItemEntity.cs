using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEntity : MonoBehaviour
{
	private static ItemEntity prefab = null;
	public static ItemEntity Prefab
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

	[SerializeField] float bobbingSpeed = 2f;
	[SerializeField] SpriteRenderer spriteRenderer = null;
	float amount;

	private Item item;
	private float spawnTime;

	public void Setup(Item item)
	{
		this.item = item;
		Debug.Log(item);
		Debug.Log(spriteRenderer);
		spriteRenderer.sprite = item.GetIcon();
	}

	private void Awake()
	{
		spawnTime = Time.time;
	}

	private void Update()
	{
		spriteRenderer.transform.localPosition = Vector3.up * Mathf.Sin((Time.time - spawnTime) * bobbingSpeed) / 10f;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("picked");
		/*
		 * if(spawnTime + 2 > Time.time) return;
		if(player.TryAddItem(type))
		{
			Destroy(gameObject);
		}
		*/
	}
}
