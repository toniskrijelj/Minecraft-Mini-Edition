using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResourceSystemUI : MonoBehaviour
{
    [SerializeField] private ResourceSystem resourceSystem;
    [SerializeField] private Sprite resourceSpriteFull;
    [SerializeField] private Sprite resourceSpriteHalf;
    [SerializeField] private Sprite resourceSpriteEmpty; 

    protected List<ResourceImage> resourceImageList;
    protected ResourceSystem resourceResourceSystem;

    private void Awake()
    {
        resourceImageList = new List<ResourceImage>();
    }
    private void Start()
    {
        SetResourceSystem(resourceSystem);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            resourceResourceSystem.Decrease(1);
        }
        else if(Input.GetKeyDown(KeyCode.H))
        {
            resourceResourceSystem.Increase(1);
        }
    }
    public void SetResourceSystem(ResourceSystem resourceSystem)
    {
        this.resourceResourceSystem = resourceSystem;

        List<ResourceSystem.Resource> resourceList = resourceSystem.GetResourceList();
        for(int i = 0; i < resourceList.Count; i++)
        {
            ResourceSystem.Resource resource = resourceList[i];
            Image resourceImageUI = transform.Find("Resource"+ (i + 1)).GetComponent<Image>();
            ResourceImage resourceImage = new ResourceImage(this, resourceImageUI);
            resourceImage.SetResourceFragments(resource.GetFragmentAmount());
            resourceImageUI.sprite = resourceSpriteFull;
            resourceImageList.Add(resourceImage);
        }

        resourceSystem.OnResourceDecreased += ResourceSystem_OnResourceDecreased;
        resourceSystem.OnResourceIncreased += ResourceSystem_OnResourceIncreased;
        resourceSystem.OnResourceEmpty += ResourceSystem_OnResourceEmpty;
    }

    protected virtual void ResourceSystem_OnResourceEmpty(object sender, EventArgs e)
    {
        Debug.Log("Dead");
    }


    protected virtual void ResourceSystem_OnResourceIncreased(object sender, EventArgs e)
    {
        Refresh();
    }

    protected virtual void ResourceSystem_OnResourceDecreased(object sender, EventArgs e)
    {
        Refresh();
    }

    private void Refresh()
    {
        List<ResourceSystem.Resource> resourceList = resourceResourceSystem.GetResourceList();
        for (int i = 0; i < resourceImageList.Count; i++)
        {
            resourceImageList[i].SetResourceFragments(resourceResourceSystem.GetResourceList()[i].GetFragmentAmount());
        }

    }

    public class ResourceImage
    {
        public Image resourceSprite { get; private set; }
        private ResourceSystemUI resourceSystemUI;
        public ResourceImage(ResourceSystemUI resourceSystemUI, Image resourceImage)
        {
            this.resourceSprite = resourceImage;
            this.resourceSystemUI = resourceSystemUI;
        }

        public void SetResourceFragments(int fragments)
        {
            switch(fragments)
            {
                case 0: resourceSprite.sprite = resourceSystemUI.resourceSpriteEmpty; 
                        break;
                case 1: resourceSprite.sprite = resourceSystemUI.resourceSpriteHalf;
                        break;
                case 2: resourceSprite.sprite = resourceSystemUI.resourceSpriteFull;
                        break;
            }
        }
    }

}
