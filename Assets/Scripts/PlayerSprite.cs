using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
	public static PlayerSprite Instance { get; private set; }

	private Rigidbody2D rb;
	private Animator animator;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = transform.Find("Skin").GetComponent<Animator>();
		Instance = this;
	}

	void FixedUpdate()
    {
		float xSpeed = rb.velocity.x;
		int intSpeed = Mathf.CeilToInt(xSpeed);
		if(intSpeed != 0)
		{
			float sign = Mathf.Sign(intSpeed);
			animator.transform.localScale = new Vector3(-sign * Mathf.Abs(animator.transform.localScale.x), animator.transform.localScale.y, 1);
		}
		animator.SetInteger("Speed", intSpeed);
		animator.SetFloat("MovingSpeed", xSpeed);
		animator.SetBool("Crouching", Input.GetKey(KeyCode.LeftShift));
    }
}
