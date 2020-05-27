using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Blocks/Sec")]
	[SerializeField] private float crouchSpeed = 3.0f;
	[SerializeField] private float walkSpeed = 4.3f;
	[SerializeField] private float runSpeed = 5.6f;
	[SerializeField] private float jumpHeight = 1.5f;

	private Rigidbody2D rb;
	HungerSytem hungerSystem;

	private float currentSpeed;


	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		hungerSystem = GetComponent<HungerSytem>();
	}

	float lastDir;

	void Update()
	{
		currentSpeed = 0;
		if (Player.Instance.enabled)
		{
			if (Input.GetKey(KeyCode.Space))
			{
				if (GroundCheck())
				{
					rb.velocity = new Vector3(rb.velocity.x, Mathf.Sqrt(rb.gravityScale * -2f * jumpHeight));
				}
			}
			if (Input.GetKey(KeyCode.LeftShift))
			{
				currentSpeed = crouchSpeed;
				float dir = -Input.GetAxisRaw("Horizontal");
				if (dir == 0)
				{
					dir = lastDir;
				}
				lastDir = dir;
				Debug.DrawRay(transform.position - new Vector3(0.25f * dir, 1.5f), Vector2.right * dir * 0.15f, Color.red);
				if (!Physics2D.Raycast(transform.position - new Vector3(0.25f * dir, 1.5f), Vector2.right * dir, 0.15f, 1 << 8))
				{
					if (Physics2D.Raycast(transform.position - new Vector3(0.2f, 1), Vector2.right * dir, 0.2f, 1 << 8))
					{
						currentSpeed = 0;
					}
				}
			}
			else if (Input.GetKey(KeyCode.LeftControl))
			{
				currentSpeed = runSpeed;
			}
			else
			{
				currentSpeed = walkSpeed;
			}
		}
		rb.velocity = new Vector3(Input.GetAxis("Horizontal") * currentSpeed, rb.velocity.y);
	}
	public bool GroundCheck()
	{
		if (Physics2D.Raycast(transform.position + new Vector3(-0.15f, -1.05f), Vector2.right, 0.3f, 1 << 8))
		{
			return true;
		}
		return false;
	}
}
