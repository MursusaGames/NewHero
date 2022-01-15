using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class InventorySystem : BaseMonoSystem
{
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
}
