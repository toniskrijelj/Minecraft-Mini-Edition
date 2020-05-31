using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DoorSave
{
	public int x, y, z;
	public float xScale;
}

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

	public DoorSave Save(int x, int y, int z)
	{
		return new DoorSave() { xScale = transform.localScale.x , x = x, y = y, z = z};
	}

	
	public void Load(DoorSave data)
	{
		transform.localScale = new Vector3(data.xScale, 1, 1);
	}
}
