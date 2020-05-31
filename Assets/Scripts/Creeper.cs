using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creeper : Mob
{
	protected override void Mob_OnResourceEmpty(object sender, EventArgs e)
	{
		ItemEntity.Spawn(transform.position, Item.Gunpowder, 2);
		base.Mob_OnResourceEmpty(sender, e);
	}
}
