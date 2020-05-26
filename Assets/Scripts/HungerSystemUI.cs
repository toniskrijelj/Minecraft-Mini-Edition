using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerSystemUI : ResourceSystemUI
{
	protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.J))
        {
            resourceResourceSystem.Decrease(1);
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            resourceResourceSystem.Increase(1);
        }
        Shake(0);
    }
}
