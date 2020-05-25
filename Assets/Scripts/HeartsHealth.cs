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
        HeartsHealthSystem heartsHealthSystem = new HeartsHealthSystem(4);
        SetHeartsHealthSystem(heartsHealthSystem);

        heartsHealthSystem.Damage(3);
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
            heartAnchoredPosition += new Vector2(30, 0);
        }

        heartsHealthSystem.OnDamaged += HeartsHealthSystem_OnDamaged;
    }

    private void HeartsHealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        List<HeartsHealthSystem.Heart> heartList = heartsHealthSystem.GetHeartList();
        for(int i = 0; i < heartImageList.Count; i++)
        {
            HeartImage heartImage = heartImageList[i];
            HeartsHealthSystem.Heart heart = heartList[i];
            heartImageList[i].SetHeartFragments(heartsHealthSystem.GetHeartList()[i].GetFragmentAmount());
        }
    }

    private HeartImage CreateHeartImage(Vector2 anchoredPosition)
    {
        GameObject heartGameObject = new GameObject("HeartFull", typeof(Image));
        heartGameObject.transform.parent = transform;

        heartGameObject.GetComponent<Image>().sprite = heartSpriteFull;
        heartGameObject.transform.localPosition = Vector3.zero;

        heartGameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        heartGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(10, 10);

        Image heartImageUI = heartGameObject.GetComponent<Image>();
        heartImageUI.sprite = heartSpriteFull;

        HeartImage heartImage = new HeartImage(this, heartImageUI);
        heartImageList.Add(heartImage);

        return heartImage;
    }

    public class HeartImage
    {
        private Image heartImage;
        private HeartsHealth heartsHealth;
        public HeartImage(HeartsHealth heartsHealth, Image heartImage)
        {
            this.heartImage = heartImage;
            this.heartsHealth = heartsHealth;
        }

        public void SetHeartFragments(int fragments)
        {
            switch(fragments)
            {
                case 0: heartImage.sprite = heartsHealth.heartSpriteEmpty; 
                        break;
                case 1: heartImage.sprite = heartsHealth.heartSpriteHalf;
                        break;
                case 2: heartImage.sprite = heartsHealth.heartSpriteFull;
                        break;
            }
        }
    }

}
