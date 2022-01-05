using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class RedRingsSystem : BaseMonoSystem
{
    [SerializeField] private GameObject giftBtnRedRing;
    public override void Init(AppData data)
    {
        base.Init(data);
        //SetObservables();        
    }

    private void SetObservables()
    {
        /*data.matchData.state
            .Where(x => x == MatchData.State.ClosingMainMenu)
            .Subscribe(_ => CloseMenu());
        data.matchData.state
            .Where(x => x == MatchData.State.MainMenu)
            .Subscribe(_ => ShowMenu());*/
    }
    private void OnEnable()
    {
        DateTime dateCurrent = DateTime.Now;
        DateTime dateNext = DateTime.Parse(data.timerData.giftDate);
        int hour = 23 - (dateCurrent - dateNext).Hours;
        int day = (dateCurrent - dateNext).Days;        
        giftBtnRedRing.SetActive((day*-24)+hour < 0);
        
    }
    public void ResetRedRingsInGiftMenu()
    {
        OnEnable();
    }

    
}
