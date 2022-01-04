using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MoneySystem : BaseMonoSystem
{
    [SerializeField] private MoneyView view;
    

    public override void Init(AppData data)
    {
        base.Init(data);
        SetObservables();
    }

    private void SetObservables()
    {
        view.ChangeValue(data.userData.coins);
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
        view.gameObject.Show();
    }

    private void HideView()
    {
        view.gameObject.Hide();
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
        view.ChangeValue(data.userData.coins);
        data.moneyData.state.Value = MoneyData.State.Accept;
        return true;
    }

    public void AddMoney(int addedMoney)
    {
        data.userData.coins += addedMoney;
        //data.matchData.sessionMoney += addedMoney;
        view.ChangeValue(data.userData.coins);
    }
    public void ReduceMoney(int reduceMoney)
    {
        data.userData.coins -= reduceMoney;
        //data.matchData.sessionMoney -= reduceMoney;
        view.ChangeValue(data.userData.coins);
    }
}
