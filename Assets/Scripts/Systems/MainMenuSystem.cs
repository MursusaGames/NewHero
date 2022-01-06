using System;
using System.Collections.Generic;
using UnityEngine;
//using Cysharp.Threading.Tasks;
using UniRx;

public class MainMenuSystem : BaseMonoSystem
{
   
    [SerializeField] private GameObject view;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject planet;

    public override void Init(AppData data)
    {
        base.Init(data);
        SetObservables();
        ShowMenu();
    }

    private void SetObservables()
    {
        data.matchData.state
            .Where(x => x == MatchData.State.ClosingMainMenu)
            .Subscribe(_ => CloseMenu());
        data.matchData.state
            .Where(x => x == MatchData.State.MainMenu)
            .Subscribe(_ => ShowMenu());
    }

    private void ShowMenu()
    {
        view.gameObject.SetActive(true);        
    }

    private void CloseMenu()
    {
        view.gameObject.SetActive(false);        
        GameInitializing();
    }
    public void ShowSettingsMenu()
    {
        settingsMenu.SetActive(true);
        planet.SetActive(false);
    }
    public void HideSettingsMenu()
    {
        settingsMenu.SetActive(false);
        planet.SetActive(true);
    }

    public void GameInitializing()
    {
        data.matchData.state.Value = MatchData.State.LevelInitializing;
    }

    public void StartGame()
    {
        data.matchData.state.Value = MatchData.State.ClosingMainMenu;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
