using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HeartsHealth : MonoBehaviour
{
    [SerializeField] private Sprite heartSpriteFull;
    [SerializeField] private Sprite heartSpriteHalf;
    [SerializeField] private Sprite heartSpriteEmpty;

    private List<HeartImage> heartImageList;
    private HeartsHealthSystem heartsHealthSystem;

    private void Awake()
    {
        heartImageList = new List<HeartImage>();
    }

    private void Start()
    {
        HeartsHealthSystem heartsHealthSystem = new HeartsHealthSystem(10);
        SetHeartsHealthSystem(heartsHealthSystem);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            heartsHealthSystem.Damage(1);
        }
        else if(Input.GetKeyDown(KeyCode.H))
        {
            heartsHealthSystem.Heal(1);
        }
    }
    public void SetHeartsHealthSystem(HeartsHealthSystem heartsHealthSystem)
    {
        this.heartsHealthSystem = heartsHealthSystem;

        List<HeartsHealthSystem.Heart> heartList = heartsHealthSystem.GetHeartList();
        Vector2 heartAnchoredPosition = new Vector2(0, 0);
        for(int i = 0; i < heartList.Count; i++)
        {
            HeartsHealthSystem.Heart heart = heartList[i];
            CreateHeartImage(heartAnchoredPosition).SetHeartFragments(heart.GetFragmentAmount());
            heartAnchoredPosition += new Vector2(50, 0);
        }

        heartsHealthSystem.OnDamaged += HeartsHealthSystem_OnDamaged;
        heartsHealthSystem.OnHealed += HeartsHealthSystem_OnHealed;
        heartsHealthSystem.OnDead += HeartsHealthSystem_OnDead;
    }

    private void HeartsHealthSystem_OnDead(object sender, EventArgs e)
    {
        Debug.Log("Dead");
    }

    private void HeartsHealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        RefreshAllHearts();
    }

    private void RefreshAllHearts()
    {
        List<HeartsHealthSystem.Heart> heartList = heartsHealthSystem.GetHeartList();
        for (int i = 0; i < heartImageList.Count; i++)
        {
            HeartImage heartImage = heartImageList[i];
            HeartsHealthSystem.Heart heart = heartList[i];
            heartImageList[i].SetHeartFragments(heartsHealthSystem.GetHeartList()[i].GetFragmentAmount());
        }

    }
    private void HeartsHealthSystem_OnHealed(object sender, System.EventArgs e)
    {
        RefreshAllHearts();
    }

    private HeartImage CreateHeartImage(Vector2 anchoredPosition)
    {
        GameObject heartGameObject = new GameObject("HeartFull", typeof(Image));
        heartGameObject.transform.SetParent(transform);

        heartGameObject.GetComponent<Image>().sprite = heartSpriteFull;
        heartGameObject.transform.localPosition = Vector3.zero;

        heartGameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        heartGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(13, 13);

        Image heartImageUI = heartGameObject.GetComponent<Image>();
        heartImageUI.sprite = heartSpriteFull;

        HeartImage heartImage = new HeartImage(this, heartImageUI);
        heartImageList.Add(heartImage);

        return heartImage;

    }

    public class HeartImage
    {
        private Image heartSprite;
        private HeartsHealth heartsHealth;
        public HeartImage(HeartsHealth heartsHealth, Image heartImage)
        {
            this.heartSprite = heartImage;
            this.heartsHealth = heartsHealth;
        }

        public void SetHeartFragments(int fragments)
        {
            switch(fragments)
            {
                case 0: heartSprite.sprite = heartsHealth.heartSpriteEmpty; 
                        break;
                case 1: heartSprite.sprite = heartsHealth.heartSpriteHalf;
                        break;
                case 2: heartSprite.sprite = heartsHealth.heartSpriteFull;
                        break;
            }
        }
    }

}
