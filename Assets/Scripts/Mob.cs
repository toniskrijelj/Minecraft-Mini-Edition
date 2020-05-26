using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mob : MonoBehaviour
{
    ResourceSystem hp;
    protected void Awake()
    {
        //hp = new ResourceSystem(HeartsAmount());
    }

    protected abstract int HeartsAmount();

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
