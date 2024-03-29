﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MoneySystem : BaseMonoSystem
{
    [SerializeField] private MoneyView moneyView;
    [SerializeField] private CrystallsView crystallsView;

    public override void Init(AppData data)
    {
        base.Init(data);
        SetObservables();
    }

    private void SetObservables()
    {
        moneyView.ChangeValue(data.userData.coins);
        crystallsView.ChangeValue(data.userData.crystals);
        data.matchData.state
            .Where(x => x == MatchData.State.StartGame)
            .Subscribe(_ => ShowView());
        data.matchData.state
            .Where(x => x == MatchData.State.OpenShop)
            .Subscribe(_ => ShowView());
        data.matchData.state
            .Where(x => x == MatchData.State.CloseShop)
            .Subscribe(_ => HideView());
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
        moneyView.gameObject.Show();
    }

    private void HideView()
    {
        moneyView.gameObject.Hide();
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
        moneyView.ChangeValue(data.userData.coins);
        data.moneyData.state.Value = MoneyData.State.Accept;
        return true;
    }

    public void AddMoney(int addedMoney)
    {
        data.userData.coins += addedMoney;
        //data.matchData.sessionMoney += addedMoney;
        moneyView.ChangeValue(data.userData.coins);
    }
    public void ReduceMoney(int reduceMoney)
    {
        data.userData.coins -= reduceMoney;
        //data.matchData.sessionMoney -= reduceMoney;
        moneyView.ChangeValue(data.userData.coins);
    }
}
