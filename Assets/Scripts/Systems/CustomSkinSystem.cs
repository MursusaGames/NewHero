using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomSkinSystem : MonoBehaviour
{
    [SerializeField] private GameObject skinWindow;
    [SerializeField] private GameObject skinPanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject skinMode1Btn;
    [SerializeField] private GameObject skinMode2Btn;
    [SerializeField] private GameObject skinMode3Btn;
    [SerializeField] private Image skinBtnImage;
    [SerializeField] private Image shopBtnImage;

    private int skinMode = 0;

    public void ShowSkinWindow()
    {
        skinWindow.Show();
    }

    public void HideSkinWindow()
    {
        skinWindow.Hide();
    }
    public void ShowShopPanel()
    {
        shopPanel.Show();
        skinPanel.Hide();
        skinBtnImage.color = Color.blue;
        shopBtnImage.color = Color.yellow;
    }

    public void HideShopPanel()
    {
        skinPanel.Show();
        shopPanel.Hide();
        skinBtnImage.color = Color.yellow;
        shopBtnImage.color = Color.blue;
    }
    public void ChangeSkinMode()
    {
        switch (skinMode)
        {
            case 0:
                skinMode1Btn.Hide();
                skinMode2Btn.Show();
                skinMode++;
                break;
            case 1:
                skinMode2Btn.Hide();
                skinMode3Btn.Show();
                skinMode++;
                break;
            case 2:
                skinMode3Btn.Hide();
                skinMode1Btn.Show();
                skinMode = 0;
                break;

        }
    }

}
