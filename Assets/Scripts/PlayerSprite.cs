using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
	[SerializeField] Sprite left = null;
	[SerializeField] Sprite right = null;

	Sprite lastSprite = null;

	Rigidbody2D rb;
	SpriteRenderer sr;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
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
    }
}
