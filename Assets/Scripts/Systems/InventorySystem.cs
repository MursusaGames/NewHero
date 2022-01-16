using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class InventorySystem : BaseMonoSystem
{
    [SerializeField] private ChoiceWindow choiceWindow;
    [SerializeField] private InventoryView inventoryView;
    [SerializeField] private HPInfoPanel hpInfoPanel;
    [SerializeField] private List<Image> slotImages;
    private int slotIndex;
    private int btnId;
    private int spriteIndex;
    public override void Init(AppData data)
    {
        base.Init(data);
        SetObservables();
    }

    private void SetObservables()
    {
        /*data.matchData.state
            .Where(x => x == MatchData.State.StartGame)
            .Subscribe(_ => ShowView());*/       
    }
    public void PushBtn(int id)
    {
        btnId = id;
        var sprite = PlayerPrefs.GetString(id.ToString());
        if (sprite == "none") return;
        else
        {
            switch (sprite)
            {
                case "axe":
                    SetChoiceWindow(1);
                    break;
                case "bow":
                    SetChoiceWindow(2);
                    break;
                case "luck":
                    SetChoiceWindow(3);
                    break;                
            }
            
        }
    }

    private void SetChoiceWindow(int index)
    {
        choiceWindow.gameObject.SetActive(true);
        slotIndex = ((int)data.InventoryDataContainer.InventoryItems[index].slot);
        choiceWindow.nameText.text = data.InventoryDataContainer.InventoryItems[index].itemName;
        spriteIndex = index;
        choiceWindow.sprite.sprite = data.InventoryDataContainer.InventoryItems[index].sprite;
        choiceWindow.attackPointText.text = "+"+data.InventoryDataContainer.InventoryItems[index].attakPoint.ToString();
        choiceWindow.defPointText.text = "+" + data.InventoryDataContainer.InventoryItems[index].defPoint.ToString();
        choiceWindow.livePointText.text = "+" + data.InventoryDataContainer.InventoryItems[index].liewPoint.ToString();
        choiceWindow.speedPointText.text = "+" + data.InventoryDataContainer.InventoryItems[index].speedPoint.ToString();
    }

    public void ResetChoiceWindow()
    {
        choiceWindow.gameObject.SetActive(false);
    }

    public void SetInfoPanel()
    {
        hpInfoPanel.attackPoint.text = data.userData.attakPoint.ToString();
        hpInfoPanel.defPoint.text = data.userData.defPoint.ToString();
        hpInfoPanel.livePoint.text = data.userData.livePoint.ToString();
    }

    public void SetSlot()
    {
        var tempSprite = slotImages[slotIndex].sprite;
        slotImages[slotIndex].sprite = data.InventoryDataContainer.InventoryItems[spriteIndex].sprite;
        data.userData.attakPoint += data.InventoryDataContainer.InventoryItems[spriteIndex].attakPoint;
        data.userData.defPoint += data.InventoryDataContainer.InventoryItems[spriteIndex].defPoint;
        data.userData.speedPoint += data.InventoryDataContainer.InventoryItems[spriteIndex].speedPoint;
        data.userData.livePoint += data.InventoryDataContainer.InventoryItems[spriteIndex].liewPoint;
        switch (spriteIndex)
        {
            case 1:
                data.userData.weapon = UserData.Weapon.axe;
                break;
            case 2:
                data.userData.weapon = UserData.Weapon.bow;
                break;
        }

        inventoryView.SetBoxes(btnId, tempSprite);
        SetInfoPanel();
        ResetChoiceWindow();
    }
    public void SetSlotImages()
    {
        var id = (int)data.userData.weapon;
        if (id > 0)
        {
            slotImages[0].sprite = data.InventoryDataContainer.InventoryItems[id].sprite;
        }
    }
}
