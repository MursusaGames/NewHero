using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;

public class GameOverSystem : BaseMonoSystem
{
    [SerializeField] private GameObject player;
    [SerializeField] GameObject gameOverWindow;
    [SerializeField] WinSystem winSystem;
    [SerializeField] PlayerMovementSystem movSystem;

    private bool isWin;
    private bool isGame;
    public override void Init(AppData data)
    {
        base.Init(data);
        SetObservables();
    }

    private void SetObservables()
    {
        data.matchData.state
            .Where(x => x == MatchData.State.StartGame)
            .Subscribe(_ => InitGame());
        data.matchData.state
            .Where(x => x == MatchData.State.Finish)
            .Subscribe(_ => PlayerWin());
    }

    private void InitGame()
    {
        isGame = true;
        isWin = false;
    }

    private void PlayerWin()
    {
        isWin = true;
        AddPlayerReward();
        //player.GetComponent<UnitController>().ObjectWin();
        //movSystem.ClearUnits();

    }

    private void AddPlayerReward()
    {
        //for (int i = 0; i < movSystem.units.Count; i++)
        {
           // data.userData.coins += data.userData.levelRewardPerUnit;
        }
    }

    void Update()
    {
        if (!isGame) return;

        if (!player.activeInHierarchy)
        {
            isGame = false;
            data.matchData.state.Value = MatchData.State.EndGame;
            if (!isWin) gameOverWindow.SetActive(true);
            else winSystem.ShowWinWindow();
        }
    }

    public void BackInGame()
    {
        gameOverWindow.SetActive(false);
        data.matchData.state.Value = MatchData.State.MainMenu;
    }
}
