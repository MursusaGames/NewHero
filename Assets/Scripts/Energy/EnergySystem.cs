using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EnergySystem : BaseMonoSystem
{
    [SerializeField] private ManaView manaView;
    [SerializeField] private EnergyView energyView;

    public override void Init(AppData data)
    {
        base.Init(data);
        SetObservables();
    }

    private void SetObservables()
    {
        manaView.ChangeManaValue(data.userData.mana);
        manaView.ChangeMaxManaValue(data.userData.maxMana);
        energyView.ChangeEnergyValue(data.userData.energy);
        energyView.ChangeMaxEnergyValue(data.userData.maxEnergy);
        /*data.matchData.state
            .Where(x => x == MatchData.State.StartGame)
            .Subscribe(_ => ShowView());
        data.matchData.state
            .Where(x => x == MatchData.State.OpenShop)
            .Subscribe(_ => ShowView());
        data.matchData.state
            .Where(x => x == MatchData.State.CloseShop)
            .Subscribe(_ => HideView());*/
        data.moneyData.state
            .Where(x => x == MoneyData.State.Waiting)
            .Subscribe(_ => Buy(data.moneyData.curOrder.price));
        data.matchData.state
            .Where(x => x == MatchData.State.EndGame)
            .Subscribe(_ => ClearMoneyData());
    }

    private void ClearMoneyData()
    {
        data.moneyData.Clear();
        HideView();
    }

    private void ShowView()
    {
        //moneyView.gameObject.Show();
    }

    private void HideView()
    {
        //moneyView.gameObject.Hide();
    }

    public bool Buy(int price)
    {
        data.moneyData.Clear();
        if (price > data.userData.coins)
        {
            //view.NotEnoughAnimation();
            data.moneyData.state.Value = MoneyData.State.Failed;
            return false;
        }

        data.userData.coins -= price;
        manaView.ChangeManaValue(data.userData.coins);
        data.moneyData.state.Value = MoneyData.State.Accept;
        return true;
    }

    public void AddMana(int addedMana)
    {
        data.userData.coins += addedMana;
        //data.matchData.sessionMoney += addedMoney;
        manaView.ChangeManaValue(data.userData.coins);
    }
    public void ReduceMana(int reduceMana)
    {
        data.userData.coins -= reduceMana;
        //data.matchData.sessionMoney -= reduceMoney;
        manaView.ChangeManaValue(data.userData.coins);
    }
}
