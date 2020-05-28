using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Block
{
	bool open;

	private void Awake()
	{
		transform.localScale = new Vector3(Mathf.Sign(transform.position.x - Player.Instance.transform.position.x), 1, 1);
		specialAction = () =>
		{
			if (!open)
			{
				if (blockCollider.enabled == false) return;
				blockCollider.enabled = false;
				spriteRenderer.sprite = BlockData.blockData.doorTextureOpen;
				open = true;
			}
			else
			{
				blockCollider.enabled = true;
				spriteRenderer.sprite = BlockData.blockData.doorTextureClosed;
				open = false;
			}
		};
	}
}
