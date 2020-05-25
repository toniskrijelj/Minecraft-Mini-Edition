using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mob : MonoBehaviour
{
    HeartsHealthSystem hp;
    protected void Awake()
    {
        hp = new HeartsHealthSystem(HeartsAmount());
    }

    protected abstract int HeartsAmount();

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
