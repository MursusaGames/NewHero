using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class VirtualJoysticSystem : BaseMonoSystem
{
    [SerializeField] private GameObject joystick;
    public override void Init(AppData data)
    {
        base.Init(data);
        SetObservables();
    }

    private void SetObservables()
    {
        data.matchData.state
            .Where(x => x == MatchData.State.StartGame)
            .Subscribe(_ => ShowJoystick());
        data.matchData.state
            .Where(x => x == MatchData.State.EndGame)
            .Subscribe(_ => HideJoystick());
        data.matchData.state
           .Where(x => x == MatchData.State.Finish)
           .Subscribe(_ => HideJoystick());
    }

    private void ShowJoystick()
    {
        joystick.Show();
    }
    private void HideJoystick()
    {
        joystick.Hide();
    }
}
