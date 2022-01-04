using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

[CreateAssetMenu(menuName = "Data/MatchData")]
public class MatchData : ScriptableObject
{
    public UserData playerUser;
    public CameraSystem cameraSystem;
    
    public enum State
    {
        MainMenu,
        OpenShop,
        CloseShop,
        ClosingMainMenu,
        LevelInitializing,
        Initializing,
        StartGame,       
        Movement,
        CheckHealth,
        EndGame,
        Observer,
        Finish,
        CharacterDeath
    }

    public ReactiveProperty<State> state = new ReactiveProperty<State>(State.MainMenu);
    public State _state;
    public IntReactiveProperty playerHealth = new IntReactiveProperty(100);
    public float jumpMultiplier = 1;
}
