using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private List<Image> boxes = new List<Image>();
    [SerializeField] private InventoryData inventoryData;
    private const string Init_Box_Value = "none";
    public int freeInventoryBox; 

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(0.ToString()))
        {
            for(int i = 0; i < boxes.Count; i++)
            {
                PlayerPrefs.SetString(i.ToString(), Init_Box_Value);
            }
        }
        if (!PlayerPrefs.HasKey("FreeBox"))
        {
            PlayerPrefs.SetInt("FreeBox", 0);
        }       

    }
    private void OnEnable()
    {
        for(int i = 0; i < boxes.Count; i++)
        {
            var sprite = PlayerPrefs.GetString(i.ToString());
            switch (sprite)
            {
                case "none":
                    boxes[i].sprite = inventoryData.none;
                    break;
                case "axe":
                    boxes[i].sprite = inventoryData.axe;
                    break;
                case "bow":
                    boxes[i].sprite = inventoryData.bow;
                    break;
                case "luck":
                    boxes[i].sprite = inventoryData.luck;
                    break;
            }
            
        }
        freeInventoryBox = PlayerPrefs.GetInt("FreeBox");        
    }
}
