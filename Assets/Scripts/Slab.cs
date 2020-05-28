using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slab : Block
{
	bool background;

	private void Start()
	{
		if (!blockCollider.enabled) background = true;
	}

	private void Update()
	{
		if (background) return;
		blockCollider.enabled = !Input.GetKey(KeyCode.LeftShift);
	}
}
