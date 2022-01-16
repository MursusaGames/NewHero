using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private List<Image> boxes = new List<Image>();
    [SerializeField] private List<GameObject> weapons = new List<GameObject>();
    [SerializeField] private InventoryData inventoryData;
    [SerializeField] private InventorySystem inventorySystem;
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
        inventorySystem.SetInfoPanel();
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
        if((int)inventorySystem.data.userData.weapon > 0)
        {
            inventorySystem.SetSlotImages();
            weapons[(int)inventorySystem.data.userData.weapon - 1].SetActive(true);
        }
    }  
    
    public void SetBoxes(int id,Sprite sprite)
    {
        boxes[id].sprite = sprite;
        PlayerPrefs.SetString(id.ToString(), sprite.name.ToString());
        weapons[(int)inventorySystem.data.userData.weapon - 1].SetActive(true);
    }
    
}

