using UnityEngine;
using System.Collections.Generic;
using UniRx;

public class SettingMenuSystem : BaseMonoSystem
{
    [SerializeField] private SettingMenu settingMenu;
    
    [SerializeField] private AudioSource hitSound;
    private bool onSound;
    private bool onVibro;
    private const int ON = 1;
    private List<int> previousId = new List<int>();

    public override void Init(AppData data)
    {
        base.Init(data);
        SetObservables();

    }

    private void SetObservables()
    {
        data.matchData.state
            .Where(x => x == MatchData.State.StartGame)
            .Subscribe(_ => ClearList());
    }

    private void ClearList()
    {
        previousId.Clear();
    }
    void Start()
    {
        if (!PlayerPrefs.HasKey("Sound")) PlayerPrefs.SetInt("Sound", ON);
        if (!PlayerPrefs.HasKey("Vibro")) PlayerPrefs.SetInt("Vibro", ON);
        
        onSound = (PlayerPrefs.GetInt("Sound") == ON);
        onVibro = (PlayerPrefs.GetInt("Vibro") == ON);        
    }

    private void OnEnable()
    {
        settingMenu.ChangeSoundSettings += ChangeSoundSettings;
        settingMenu.ChangeVibroSettings += ChangeVibroSettings;
        
    }
    private void OnDisable()
    {
        settingMenu.ChangeSoundSettings -= ChangeSoundSettings;
        settingMenu.ChangeVibroSettings -= ChangeVibroSettings;
       
    }
    private void ChangeSoundSettings()
    {
        onSound = !onSound;
    }
    private void ChangeVibroSettings()
    {
        onVibro = !onVibro;
    }

    public void VibroOn(int id)
    {
        for(int i = 0; i < previousId.Count; i++)
        {
            if (id == previousId[i]) return;
        }
        if(onVibro) Handheld.Vibrate();
        previousId.Add(id);
    }
    public void SoundOn()
    {
        if (onSound) hitSound.Play();
    }
}
