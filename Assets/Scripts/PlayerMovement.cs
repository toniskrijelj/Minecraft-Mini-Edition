using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Blocks/Sec")]
	[SerializeField] float walkSpeed = 4.3f;
	[SerializeField] float runSpeed = 5.6f;
	[SerializeField] float jumpHeight = 1.5f;

	Rigidbody2D rb;

	float currentSpeed;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
    {
        if(Input.GetKey(KeyCode.Space))
		{
			if(GroundCheck())
			{
				rb.velocity = new Vector3(rb.velocity.x, Mathf.Sqrt(rb.gravityScale * -2f * jumpHeight));
			}
		}

		currentSpeed = Input.GetKey(KeyCode.LeftControl) ? runSpeed : walkSpeed;

		rb.velocity = new Vector3(Input.GetAxis("Horizontal") * currentSpeed, rb.velocity.y);
    }

	public bool GroundCheck()
	{
		if (Physics2D.Raycast(transform.position + new Vector3(-0.15f, -1.05f), Vector2.right, 0.3f , 1 << 8))
		{
			return true;
		}
		return false;
	}
}
