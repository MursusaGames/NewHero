using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class SpawnSystem : BaseMonoSystem
{
    [SerializeField] private List<GameObject> levelsPrefab = new List<GameObject>();
    [SerializeField] private LevelDataSystem levelSystem;
   
    private int currentLevel;

    public override void Init(AppData data)
    {
        base.Init(data);
        SetObservables();
    }

    private void SetObservables()
    {
        data.matchData.state
            .Where(x => x == MatchData.State.Initializing)
            .Subscribe(_ => InitPlatform());
        data.matchData.state
            .Where(x => x == MatchData.State.EndGame)
            .Subscribe(_ => DestroyPlatform());
    }

    private void InitPlatform()
    {
        levelsPrefab[currentLevel].Show();        
    }

    private void DestroyPlatform()
    {
        levelsPrefab[currentLevel].Hide();
    }
}
