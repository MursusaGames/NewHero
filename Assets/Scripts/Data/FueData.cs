using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SomeFuesData", menuName = "Data/FueData")]
public class FueData : ScriptableObject
{
    [SerializeField] private Sprite _fueSprites;
    [SerializeField] private string _fueSubscribe;
    [SerializeField] private string _fueNames;
    [SerializeField] private string _fueSubscribeEN;
    [SerializeField] private string _fueNamesEN;
    
    public Sprite FueSprites => _fueSprites;
    public string FueSubscribe => _fueSubscribe;
    public string FueNames => _fueNames;
    public string FueSubscribeEN => _fueSubscribeEN;
    public string FueNamesEN => _fueNamesEN;    
}
