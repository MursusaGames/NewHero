using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubscribePanel : MonoBehaviour
{
    [SerializeField] GameObject panPrefab;
    [SerializeField] CustomChoiceSystem customSystem;
    private GameObject panel;
    private const int BUYED_SKIN = 1;
    private string zero = "0";

    private void Start()
    {
        panel = Instantiate(panPrefab, transform, false);
    }
    public void ShowPanel(int id)
    {
        var customPrefab = panel.GetComponentInChildren<CustomPrefab>();
        customPrefab.customImage.sprite = customSystem.customsSprites[id];
        customPrefab.customPower.text = PlayerPrefs.HasKey("PlayerSprites") && BUYED_SKIN == PlayerPrefs.GetInt("id" + id.ToString())? zero :
            customSystem.customsPrices[id];

        customPrefab.customSubscribe.text = LocalizationSystem.GetCurrentLang() == Language.Russian ? customSystem.customsSubscribe[id]
            : customSystem.customsSubscribeEN[id];

        customPrefab.customName.text = LocalizationSystem.GetCurrentLang() == Language.Russian ? customSystem.customsNames[id]
            : customSystem.customsNamesEN[id];
        
    }

        
}
