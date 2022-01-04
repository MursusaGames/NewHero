using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/UserData")]
public class UserData : ScriptableObject
{
    [Header("Main")]
    public string nickname;
    public float coins;
    public float crystals;
    public float energy;
    public float maxEnergy;
    public float mana;
    public float maxMana;
    public Character character;    
}
