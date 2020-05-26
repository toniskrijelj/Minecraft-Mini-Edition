using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthSystemUI : ResourceSystemUI
{
    [SerializeField] List<Image> outLines;
    [SerializeField] float timeBetween = 0.1f;
    protected override void ResourceSystem_OnResourceDecreased(object sender, EventArgs e)
    {
        base.ResourceSystem_OnResourceDecreased(sender, e);
        StopAllCoroutines();
        StartCoroutine(FlashHearts(3));
    }
    protected override void ResourceSystem_OnResourceIncreased(object sender, EventArgs e)
    {
        base.ResourceSystem_OnResourceIncreased(sender, e);
        StopAllCoroutines();
        StartCoroutine(FlashHearts(1));
    }
    IEnumerator FlashHearts(int count)
    {
        for(int i = 0; i< count; i++)
        {
            yield return new WaitForSeconds(timeBetween);
            SetOutLineColor(Color.white);
            yield return new WaitForSeconds(timeBetween);
            SetOutLineColor(Color.black);
        }
    }
    /*
    private void Update()
    {
        if(resourceResourceSystem.GetResourceList()[2].GetFragmentAmount() == 0)
        {
            for(int i = 0; i < 10; i++)
            {
                ((RectTransform)(resourceImageList[i].resourceSprite.transform));
            }
        }
    }
    */

    private void SetOutLineColor(Color color)
    {
        foreach (var outLine in outLines)
        {
            outLine.color = color;
        }
    }
}
