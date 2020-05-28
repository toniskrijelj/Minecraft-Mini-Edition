using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : Block
{
	private void Awake()
	{
		transform.localScale = new Vector3(Mathf.Sign(Player.Instance.transform.position.x - transform.position.x), 1, 1);
	}
}
