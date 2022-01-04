using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Image shopBtn;
    [SerializeField] private Image swordBtn;
    [SerializeField] private Image worldBtn;
    [SerializeField] private Image talantBtn;
    [SerializeField] private Image bookBtn;
    [SerializeField] private Image shopImage;
    [SerializeField] private Image swordImage;
    [SerializeField] private Image worldImage;
    [SerializeField] private Image talantImage;
    [SerializeField] private Image bookImage;
    [SerializeField] private TextMeshProUGUI shopText;
    [SerializeField] private TextMeshProUGUI equipmentText;
    [SerializeField] private TextMeshProUGUI worldText;
    [SerializeField] private TextMeshProUGUI talantText;
    [SerializeField] private TextMeshProUGUI bookText;
    [SerializeField] private GameObject equipmentMenu;
    [SerializeField] private GameObject worldMenu;
    [SerializeField] private GameObject talantMenu;
    [SerializeField] private GameObject shopMenu;
    [SerializeField] private GameObject bookMenu;
    [SerializeField] private RectTransform worldRectTransform;
    [SerializeField] private GameObject buyEnergyView;
    [SerializeField] private GameObject dailySetView;
    [SerializeField] private GameObject giftSetView;
    [SerializeField] private GameObject planet;
    private Vector3 previousPos;

    private void Start()
    {
        ShowWorld();
    }
    public void ShowEquipment()
    {
        ChoiceMenu(equipmentMenu);
        planet.SetActive(false);
    }
    public void ShowShop()
    {
        ChoiceMenu(shopMenu);
        planet.SetActive(false);
    }
    public void ShowWorld()
    {
        ChoiceMenu(worldMenu);
        planet.SetActive(true);
    }
    public void ShowTalant()
    {
        ChoiceMenu(talantMenu);
        planet.SetActive(false);
    }
    public void ShowBook()
    {
        ChoiceMenu(bookMenu);
        planet.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ShowBuyEnergyView()
    {
        buyEnergyView.SetActive(true);
    }
    public void HideBuyEnergyView()
    {
        buyEnergyView.SetActive(false);
    }
    public void ShowDaylySetView()
    {
        dailySetView.SetActive(true);
        planet.SetActive(false);
    }
    public void HideDaylySetView()
    {
        dailySetView.SetActive(false);
        planet.SetActive(true);
    }
    public void ShowGiftSetView()
    {
        giftSetView.SetActive(true);
        planet.SetActive(false);
    }
    public void HideGiftSetView()
    {
        giftSetView.SetActive(false);
        planet.SetActive(true);
    }

    public void SetActivBtn(int id)
    {

        Image[] btns = { shopBtn, swordBtn, worldBtn, talantBtn, bookBtn };
        TextMeshProUGUI[] texts = { shopText, equipmentText, worldText, talantText, bookText };
        Image[] images = { shopImage, swordImage, worldImage, talantImage, bookImage };        
        for (int i = 0; i <btns.Length; i++)
        {
            if(id == i)
            {
                btns[i].gameObject.GetComponent<Button>().interactable = false;
                btns[i].gameObject.GetComponent<LayoutElement>().minWidth = 300;
                var alfa = btns[i].color;
                alfa.a = 0;
                btns[i].color = alfa;
                texts[i].gameObject.Show();
                if(images[i].gameObject.transform.localScale == Vector3.one) images[i].gameObject.transform.localScale *= 1.5f;
                images[i].gameObject.GetComponent<RectTransform>().localPosition = worldRectTransform.localPosition;
            }
            else
            {
                btns[i].gameObject.GetComponent<Button>().interactable = true;
                previousPos = btns[i].gameObject.transform.position;
                btns[i].gameObject.GetComponent<LayoutElement>().minWidth = 0;
                var alfa = btns[i].color;
                alfa.a = 1;
                btns[i].color = alfa;
                texts[i].gameObject.Hide();
                images[i].gameObject.transform.localScale = Vector3.one;
                var pos = images[i].gameObject.transform.position;
                pos = previousPos;
                images[i].gameObject.transform.position = pos;
            }
        
        }
    }

    private void ChoiceMenu(GameObject menu)
    {
        GameObject[] menus =  { equipmentMenu, worldMenu, talantMenu, shopMenu, bookMenu };
        foreach(var go in menus)
        {
            if (go == menu) go.Show();
            else go.Hide();
        }
    }
    
}
