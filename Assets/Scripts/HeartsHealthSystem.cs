﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class HeartsHealthSystem
{
    

    public const int MaxFragmentAmount = 2;

    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;
    public event EventHandler OnDead;

    private List<Heart> heartList;
    public HeartsHealthSystem(int heartAmount)
    {
        heartList = new List<Heart>();
        for(int i = 0; i < heartAmount; i++)
        {
            Heart heart = new Heart(2);
            heartList.Add(heart);
        }
    }

    public void Damage(int damageAmount)
    {
        for(int i = heartList.Count-1; i>=0; i--)
        {
            Heart heart = heartList[i];
            if(damageAmount > heart.GetFragmentAmount())
            {
                damageAmount -= heart.GetFragmentAmount();
                heart.Damage(heart.GetFragmentAmount());
            }
            else
            {
                heart.Damage(damageAmount);
                break;
            }
        }

        if(OnDamaged!= null)
        {
            OnDamaged(this, EventArgs.Empty);
        }

        if (IsDead())
        {
            if (OnDead != null)
            {
                OnDead(this, EventArgs.Empty);
            }
        }
    }

    public void Heal(int healAmount)
    {
        for(int i = 0; i < heartList.Count; i++)
        {
            Heart heart = heartList[i];
            int missingFragments = MaxFragmentAmount - heart.GetFragmentAmount();
            if(healAmount > missingFragments)
            {
                healAmount -= missingFragments;
                heart.Heal(missingFragments);
            }
            else
            {
                heart.Heal(healAmount);
                break;
            }
        }

        if (OnHealed != null)
        {
            OnHealed(this, EventArgs.Empty);
        }
    }

    public bool IsDead()
    {
        return heartList[0].GetFragmentAmount() == 0;
    }

    public List<Heart> GetHeartList()
    {
        return heartList;
    }
    public class Heart
    {
        private int fragments;
        public Heart(int fragments)
        {
            this.fragments = fragments;
        }
        public int GetFragmentAmount()
        {
            return fragments;
        }

        public void SetFragments(int fragments)
        {
            this.fragments = fragments;
        }
        
        public void Damage(int damageAmount)
        {
            if(damageAmount >= fragments)
            {
                fragments = 0;
            }
            else
            {
                fragments -= damageAmount;
            }
        }

        public void Heal(int healAmount)
        {
            if(fragments + healAmount > MaxFragmentAmount)
            {
                fragments = MaxFragmentAmount;
            }
            else
            {
                fragments += healAmount;
            }
        }
    }
}
