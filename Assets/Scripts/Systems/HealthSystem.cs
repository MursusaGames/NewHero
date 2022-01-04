using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class HealthSystem : BaseMonoSystem
{
    private int currentLevel;
    private float health;
    public override void Init(AppData data)
    {
        base.Init(data);
        SetObservables();
    }
    private void SetObservables()
    {
        data.matchData.state
            .Where(x => x == MatchData.State.Initializing)
            .Subscribe(_ => InitBossHealth());
        currentLevel = PlayerPrefs.GetInt(ConstanCes.CURRENT_LEVEL);
    }

    private void InitBossHealth()
    {
        health = data.LevelDataContainer.LevelItems[currentLevel].BossHealth;
    }
}
