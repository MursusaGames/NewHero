using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class ScinSystem : BaseMonoSystem
{
    [SerializeField] private GameObject shopView;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject scinPanel;
    [SerializeField] private Image scinBtn;
    [SerializeField] private Image shopBtn;
    [SerializeField] private List<Image> buyBtns = new List<Image>();
    [SerializeField] private GameObject usualMarker;
    [SerializeField] private GameObject epicMarker;
    [SerializeField] private GameObject randomMarker;
    [SerializeField] private GameObject shop;
    [SerializeField] private List<GameObject> scins = new List<GameObject>();
    [SerializeField] private MoneySystem moneySystem;

    private int scinMode;
    [SerializeField] private List<int> price = new List<int>();



    public override void Init(AppData data)
    {
        base.Init(data);
        SetObservables();
    }

    private void SetObservables()
    {
        data.matchData.state
            .Where(x => x == MatchData.State.StartGame)
            .Subscribe(_ => SetScins());
        
    }

    private void SetScins()
    {
        for(int i = 0; i < scins.Count; i++)
        {
            if(PlayerPrefs.GetInt(i.ToString() ) == 1)
            {
                scins[i].Show();
                
            }
        }
    }
    public void ShowShop()
    {
        shop.Show();
    }
    public void HideShop()
    {
        shop.Hide();
    }
    public void Buy( int id)
    {
        switch (id)
        {
            case 0:
                if (moneySystem.Buy(price[id]))
                {
                    scins[id].Show();
                    PlayerPrefs.SetInt("0", 1);
                    buyBtns[id].color = Color.gray;
                    buyBtns[id].gameObject.GetComponent<Button>().interactable = false;
                }
                break;
        }
    }
    public void ChangeScinMode()
    {
        switch (scinMode)
        {
            case 0:
                usualMarker.Hide();
                epicMarker.Show();
                scinMode++;
                break;
            case 1:
                epicMarker.Hide();
                randomMarker.Show();
                scinMode++;
                break;
            case 2:
                randomMarker.Hide();
                usualMarker.Show();
                scinMode= 0;
                break;
        }
    }
    public void OpenShop()
    {
        shopView.Show();
        data.matchData.state.Value = MatchData.State.OpenShop;
    }
    public void CloseShop()
    {
        shopView.Hide();
        data.matchData.state.Value = MatchData.State.CloseShop;
    }
    public void ShowShopPanel()
    {
        shopPanel.Show();
        scinPanel.Hide();
        shopBtn.color = Color.yellow;
        scinBtn.color = Color.blue;
    }
    public void HideShopPanel()
    {
        scinPanel.Show();
        shopPanel.Hide();
        scinBtn.color = Color.yellow;
        shopBtn.color = Color.blue;
    }
}
