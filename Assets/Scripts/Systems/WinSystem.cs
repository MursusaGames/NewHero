using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class WinSystem : BaseMonoSystem
{
    private Player player;
    [SerializeField] GameObject winWindow;
    [SerializeField] LevelDataSystem levelSystem;
    public override void Init(AppData data)
    {
        base.Init(data);
        SetObservables();
    }

    private void SetObservables()
    {
        data.matchData.state
            .Where(x => x == MatchData.State.MainMenu)
            .Subscribe(_ => CloseWinWindow());
    }



    public void ShowWinWindow()
    {
        var currentLevel = PlayerPrefs.GetInt(ConstanCes.CURRENT_LEVEL);
        currentLevel++;
        PlayerPrefs.SetInt(ConstanCes.CURRENT_LEVEL, currentLevel);
        levelSystem.SetCurrentLevel();
        winWindow.SetActive(true);

        //player.GetComponent<UnitController>().DestroyTheObject();
        //data.matchData.state.Value = MatchData.State.EndGame;
    }



    private void CloseWinWindow()
    {
        winWindow.SetActive(false);
    }
}
