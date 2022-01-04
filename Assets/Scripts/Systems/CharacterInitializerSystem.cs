using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;


public class CharacterInitializerSystem : BaseMonoSystem
{
    [SerializeField] private Transform startPos;    
    [SerializeField] GameObject player;

    public override void Init(AppData data)
    {
        base.Init(data);
        SetObservables();
    }

    private void SetObservables()
    {
        data.matchData.state
            .Where(x => x == MatchData.State.Initializing)
            .Subscribe(_ => SpawnPlayerCharacters());
    }

    private void SpawnPlayerCharacters()
    {
        player.Show();
        player.transform.position = startPos.position;      
        data.matchData.state.Value = MatchData.State.StartGame;
    }

    
}
