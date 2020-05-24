using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
	public static PlayerSprite Instance { get; private set; }

	public Sprite left = null;
	public Sprite right = null;
	[SerializeField] Animator animator;

	public Sprite lastSprite { get; private set; }

	Rigidbody2D rb;
	SpriteRenderer sr;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		Instance = this;
	}

	void FixedUpdate()
    {
		Sprite sprite = lastSprite;
		float xSpeed = rb.velocity.x;
		if(xSpeed < 0f)
		{
			sprite = left;
		}
		else if(xSpeed > 0f)
		{
			sprite = right;
		}
		if (lastSprite != sprite)
		{
			sr.sprite = sprite;
			lastSprite = sprite;
		}
		int intSpeed = Mathf.CeilToInt(xSpeed);
		if(intSpeed != 0)
		{
			float sign = Mathf.Sign(intSpeed);
			animator.transform.localScale = new Vector3(-sign, 1, 1);
		}
		animator.SetInteger("Speed", intSpeed);
    }
}
