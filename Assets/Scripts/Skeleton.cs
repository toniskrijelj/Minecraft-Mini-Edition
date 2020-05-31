using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Mob
{
	protected override void Mob_OnResourceEmpty(object sender, EventArgs e)
	{
		ItemEntity.Spawn(transform.position, Item.Sand, 3);
		ItemEntity.Spawn(transform.position, Item.Wheat, 1);
		base.Mob_OnResourceEmpty(sender, e);
	}
}
