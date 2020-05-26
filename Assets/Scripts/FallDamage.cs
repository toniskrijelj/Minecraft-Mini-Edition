using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
	HealthSystem healthSystem;
	Rigidbody2D rb;
	float lastYVelocity;
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		healthSystem = GetComponent<HealthSystem>();
	}
	private void Update()
    {
		int numberOfBlocks = Mathf.CeilToInt((lastYVelocity * lastYVelocity) / (2 * -rb.gravityScale));
		if (numberOfBlocks >= 4)
		{
			if (Mathf.Abs(rb.velocity.y) <= 0.1f)
			{
				healthSystem.Decrease(numberOfBlocks - 3);
			}
		}
		lastYVelocity = rb.velocity.y;
	}
}
