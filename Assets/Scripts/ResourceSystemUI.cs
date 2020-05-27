using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResourceSystemUI : MonoBehaviour
{
    [SerializeField] protected ResourceSystem resourceSystem = null;
    [SerializeField] private Sprite resourceSpriteFull = null;
    [SerializeField] private Sprite resourceSpriteHalf = null;
    [SerializeField] private Sprite resourceSpriteEmpty = null; 

    protected List<ResourceImage> resourceImageList;
    protected ResourceSystem resourceResourceSystem;

    float lastUpdateTime;
    bool reseted = true;
    List<Vector2> spriteOriginalPositions;

    protected void Shake(int numberOfResources)
    {
        if (resourceResourceSystem.GetResourceList()[numberOfResources].GetFragmentAmount() == 0)
        {
            if (Time.time > lastUpdateTime + 0.05f)
            {
                for (int i = 0; i < 10; i++)
                {
                    float upOrDown = UnityEngine.Random.Range(-0.5f, 0.5f);
                    if (upOrDown == 0)
                    {
                        upOrDown = 1;
                    }
                    resourceImageList[i].resourceSprite.rectTransform.anchoredPosition = spriteOriginalPositions[i] + Vector2.up * upOrDown * 10;
                }
                reseted = false;
                lastUpdateTime = Time.time;
            }
        }
        else if (!reseted)
        {
            for (int i = 0; i < 10; i++)
            {
                resourceImageList[i].resourceSprite.rectTransform.anchoredPosition = spriteOriginalPositions[i];
            }
            reseted = true;
        }
    }
    private void Awake()
    {
        resourceImageList = new List<ResourceImage>();
    }
    protected virtual void Start()
    {
        SetResourceSystem(resourceSystem);
        spriteOriginalPositions = new List<Vector2>();
        for (int i = 0; i < resourceImageList.Count; i++)
        {
            spriteOriginalPositions.Add(resourceImageList[i].resourceSprite.rectTransform.anchoredPosition);
        }
    }
    protected virtual void Update()
    {

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
