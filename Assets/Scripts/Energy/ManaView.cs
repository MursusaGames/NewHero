using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ManaView : MonoBehaviour
{
    [SerializeField] private TMP_Text manaCount;
    [SerializeField] private TMP_Text manaMaxCount;
    [SerializeField] private Image manaBar;
    private float mana;
    private float maxMana;
    public void ChangeManaValue(float value)
    {
        manaCount.text = value.ToString();
        mana = value;
        ChangeBar();
    }
    public void ChangeMaxManaValue(float value)
    {
        manaMaxCount.text = value.ToString();
        maxMana = value;
        ChangeBar();
    }

    private void ChangeBar()
    {
        var amount = mana / maxMana;
        if (amount > 1) amount = 1f;
        manaBar.fillAmount = amount;
    }
}
