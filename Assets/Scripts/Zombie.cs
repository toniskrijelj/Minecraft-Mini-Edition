using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Mob
{
	protected override void Mob_OnResourceEmpty(object sender, EventArgs e)
	{
		ItemEntity.Spawn(transform.position, Item.Apple, 1);
		base.Mob_OnResourceEmpty(sender, e);
	}
}
