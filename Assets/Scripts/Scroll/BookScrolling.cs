﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BookScrolling : MonoBehaviour
{
    [Range(1, 10)]
    [Header("Contollers")]
    private int panCount;
    [Range(0, 700)]
    public int panSpace;
    [Range(0f, 20f)]
    public float snapSpeed;
    [Range(0f, 5f)]
    public float scaleOffset;
    [Header("Other Objects")]
    public GameObject panPrefab;
    
    [SerializeField]  TextMeshProUGUI bayBtnText;
    [SerializeField] TextMeshProUGUI subscribeText;
    [SerializeField]  Image buyBtnImage;
    [SerializeField] SubscribePanel panel;
    [SerializeField] private CustomChoiceSystem spellSystem;
    GameObject[] instPans;
    Vector2[] panPos;
    Vector2[] panScale;
    Vector2 contentVector;
    [SerializeField] private List<string> animatorBools;
    private List<Animator> animators = new List<Animator>();
    RectTransform contentRect;
    int selectedPanID;
    public bool isScrolling;
    public string buyBtnTitle = "BUY";
    private bool isStart;
    private int magicIndex;
    private bool changeIndex;
    public int MagicIndex
    {
        get { return magicIndex; }
        set { magicIndex = value;
            changeIndex = true;
        }
    }

    public ScrollRect scrollRect;
    //[SerializeField] GameObject brainPrefab;
    //[SerializeField] GameObject swipeHand;

    private void OnEnable()
    {
        if (!isStart) return;
        for(int i = 0; i < instPans.Length; i++)
        {
            instPans[i].GetComponentInChildren<Animator>().SetTrigger(animatorBools[i]);
        }
    }
    private void Start()
    {
        panCount = System.Enum.GetValues(typeof(BookType)).Length/3;       
        panScale = new Vector2[panCount];
        contentRect = GetComponent<RectTransform>();
        panPos = new Vector2[panCount];
        instPans = new GameObject[panCount];

        for (int i = 0; i < panCount; i++)
        {
            instPans[i] = Instantiate(panPrefab, transform, false);
            animators.Add(instPans[i].GetComponentInChildren<Animator>());
            animators[i].SetTrigger(animatorBools[i]);
            //instPans[i].GetComponentInChildren<Image>().sprite = spellSystem.customsSprites[i];            
            if (i == 0) continue;

            var tmpX = instPans[i - 1].transform.localPosition.x + panPrefab.GetComponent<RectTransform>().sizeDelta.x/2 + panSpace;
            instPans[i].transform.localPosition = new Vector2(tmpX, instPans[i].transform.localPosition.y);
            panPos[i] = -instPans[i].transform.localPosition;
        }
        isStart = true;
    }

    private void FixedUpdate()
    {
        /*if(isScrolling && !PlayerPrefs.HasKey("SwipeHelp"))
        {
            PlayerPrefs.SetString("SwipeHelp", "Used");
            swipeHand.SetActive(false);
        }*/

        if (!isScrolling && (contentRect.anchoredPosition.x >= panPos[0].x || contentRect.anchoredPosition.x <= panPos[panPos.Length - 1].x))
        {
            scrollRect.inertia = false;
        }
            

        float nearestPos = float.MaxValue;
        for (int i = 0; i < panCount; i++)
        {
            float distance = Mathf.Abs(contentRect.anchoredPosition.x - panPos[i].x);
            if (distance < nearestPos)
            {
                nearestPos = distance;
                selectedPanID = i;
            }

            float scale = Mathf.Clamp(1 / (distance / panSpace) * scaleOffset, .5f, 1f);
            panScale[i].x = Mathf.SmoothStep(instPans[i].transform.localScale.x, scale, 10 * Time.fixedDeltaTime);
            panScale[i].y = Mathf.SmoothStep(instPans[i].transform.localScale.y, scale, 10 * Time.fixedDeltaTime);
            instPans[i].transform.localScale = panScale[i];
        }

        float scrollVelosity = Mathf.Abs(scrollRect.velocity.x);

        if (scrollVelosity < 1000 && !isScrolling)
            scrollRect.inertia = false;

        if (isScrolling || scrollVelosity > 1000)
            return;

        contentVector.x = Mathf.SmoothStep(contentRect.anchoredPosition.x, panPos[selectedPanID].x, snapSpeed * Time.fixedDeltaTime);
        contentRect.anchoredPosition = contentVector;
        UpgradePanel();
    }

    public void UpgradePanel()
    {

        panel.ShowPanel(magicIndex + selectedPanID);
        if (changeIndex)
        {
            for (int i = 0; i < animators.Count; i++)
            {
                animators[i].SetTrigger(animatorBools[i + magicIndex]);
            }
            changeIndex = false;
        }
        
        if (0 <= selectedPanID && System.Enum.GetValues(typeof(BookType)).Length >= selectedPanID)
        {
            //subscribeText.text = customSystem.customsSubscribe[selectedPanID];
            if (selectedPanID == PlayerPrefs.GetInt("PlayerSprites"))
            {
                bayBtnText.text = "Chosen";
                buyBtnImage.color = Color.gray;
                buyBtnImage.gameObject.GetComponent<Button>().interactable = false;
                return;
            }

            buyBtnImage.color = Color.green;
            buyBtnImage.gameObject.GetComponent<Button>().interactable = true;

            bayBtnText.text = PlayerPrefs.HasKey("PlayerSprites") && 1 == PlayerPrefs.GetInt("id" + selectedPanID.ToString()) ||
                PlayerPrefs.HasKey("PlayerSprites") && 0 == selectedPanID ? "CHOICE" : buyBtnTitle;            
        }
        else
            Debug.Log("Number out of range");
    }

    public void Scroll(bool scroll)
    {
        isScrolling = scroll;

        if (scroll)
            scrollRect.inertia = true;
    }
    public void BayCustom()
    {
        //customSystem.BayCustom(selectedPanID);
    }

}
