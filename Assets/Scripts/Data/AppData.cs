using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/AppData")]
public class AppData : ScriptableObject
{
    public MatchData matchData;
    public MoneyData moneyData;
    public UserData userData;
    public CharacterData characterData;
    public LocalizationData localizationData;
    public GiftData giftData;
    public TimerData timerData;

    [Header("Containers")]
    
    public FueDataContainer FueDataContainer;
    public LevelDataContainer LevelDataContainer;
    public CustomsDataContainer CustomDataContainer;
}
