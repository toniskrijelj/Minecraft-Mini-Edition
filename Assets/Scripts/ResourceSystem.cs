using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public abstract class ResourceSystem : MonoBehaviour
{

    [SerializeField] int resourceAmount = 0;
    public const int MaxFragmentAmount = 2;

    public event EventHandler OnResourceDecreased;
    public event EventHandler OnResourceIncreased;
    public event EventHandler OnResourceEmpty;

    protected List<Resource> resourceList;

    protected virtual void Awake()
    {
        resourceList = new List<Resource>();
        for (int i = 0; i < resourceAmount; i++)
        {
            Resource resource = new Resource(2);
            resourceList.Add(resource);
        }
    }

    public void Decrease(int decreaseAmount)
    {
        for(int i = resourceList.Count-1; i>=0; i--)
        {
            Resource resource = resourceList[i];
            if(decreaseAmount > resource.GetFragmentAmount())
            {
                decreaseAmount -= resource.GetFragmentAmount();
                resource.Decrease(resource.GetFragmentAmount());
            }
            else
            {
                resource.Decrease(decreaseAmount);
                break;
            }
        }

        if(OnResourceDecreased!= null)
        {
            OnResourceDecreased(this, EventArgs.Empty);
        }

        if (IsEmpty())
        {
            if (OnResourceEmpty != null)
            {
                OnResourceEmpty(this, EventArgs.Empty);
            }
        }
    }

    public void Increase(int increaseAmount)
    {
        for(int i = 0; i < resourceList.Count; i++)
        {
            Resource resource = resourceList[i];
            int missingFragments = MaxFragmentAmount - resource.GetFragmentAmount();
            if(increaseAmount > missingFragments)
            {
                increaseAmount -= missingFragments;
                resource.Increase(missingFragments);
            }
            else
            {
                resource.Increase(increaseAmount);
                break;
            }
        }

        if (OnResourceIncreased != null)
        {
            OnResourceIncreased(this, EventArgs.Empty);
        }
    }

    public bool IsEmpty()
    {
        return resourceList[0].GetFragmentAmount() == 0;
    }
    public bool IsFull()
    {
        return resourceList[9].GetFragmentAmount() == 2;
    }
    public List<Resource> GetResourceList()
    {
        return resourceList;
    }
    public class Resource
    {
        private int fragments;
        public Resource(int fragments)
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
        
        public void Decrease(int decreaseAmount)
        {
            if(decreaseAmount >= fragments)
            {
                fragments = 0;
            }
            else
            {
                fragments -= decreaseAmount;
            }
        }

        public void Increase(int increaseAmount)
        {
            if(fragments + increaseAmount > MaxFragmentAmount)
            {
                fragments = MaxFragmentAmount;
            }
            else
            {
                fragments += increaseAmount;
            }
        }
    }
}
