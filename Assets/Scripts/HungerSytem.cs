using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerSytem : ResourceSystem
{
    float lastUpdateTime;
    float lastHealTime;
    float timeBetweenHeal = 4;
    int numberOfHeals;
    HealthSystem healthSystem;
    protected override void Awake()
    {
        base.Awake();
        healthSystem = GetComponent<HealthSystem>();
    }
    private void Update()
    {
        if (Time.time > lastUpdateTime + 30)
        {
            Decrease(1);
            lastUpdateTime = Time.time;
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            Increase(1);
        }
        if(!healthSystem.IsFull() && resourceList[8].GetFragmentAmount() == 2)
        {
            if (IsFull())
            {
                timeBetweenHeal = 1.5f;
            }
            else
            {
                timeBetweenHeal = 4;
            }
            if (Time.time > lastHealTime + timeBetweenHeal)
            {
                lastHealTime = Time.time;
                numberOfHeals++;
                healthSystem.Increase(1);
                if(numberOfHeals == 4)
                {
                    numberOfHeals = 0;
                    Decrease(1);
                }
            }
        }
    }
}
