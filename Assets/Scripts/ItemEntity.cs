using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEntity : MonoBehaviour
{
	[SerializeField] float bobbingSpeed = 2f;
	[SerializeField] SpriteRenderer spriteRenderer = null;
	[SerializeField] Rigidbody2D rb = null;

	private Item item;
	private float spawnTime;

	bool startedBobbing = false;
	float startTime;
	float originalY;

	public void Setup(Item item)
	{
		this.item = item;
		spriteRenderer.sprite = item.GetIcon();
	}

	private void Awake()
	{
		spawnTime = Time.time;
	}

	private void Update()
	{
		if(rb.velocity.sqrMagnitude < 0.1f)
		{
			if(!startedBobbing)
			{
				startedBobbing = true;
				originalY = spriteRenderer.transform.position.y;
				startTime = Time.time;
			}
			spriteRenderer.transform.localPosition = Vector3.up * Mathf.Sin((Time.time - startTime) * bobbingSpeed) / 10f;
		}
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
