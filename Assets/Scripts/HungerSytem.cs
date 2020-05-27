using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerSytem : ResourceSystem
{
    float lastUpdateTime;
    float lastTimeStarve = 60;
    float lastHealTime;
    float timeBetweenHeal = 4;

    float timeOfChange;
    HealthSystem healthSystem;
    Rigidbody2D rb;
    protected override void Awake()
    {
        base.Awake();
        healthSystem = GetComponent<HealthSystem>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(Time.time > (timeOfChange + 1) && Mathf.Abs(rb.velocity.x) >= 0.1)
        {
            lastTimeStarve -= 1;
            timeOfChange = Time.time;
            Debug.Log(lastTimeStarve);
        }
        if (Time.time > lastUpdateTime + lastTimeStarve)
        {
            Decrease(1);
            lastTimeStarve = 60;
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
                healthSystem.Increase(1);
            }
        }
    }
}
