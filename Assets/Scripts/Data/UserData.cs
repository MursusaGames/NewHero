using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/UserData")]
public class UserData : ScriptableObject
{
    public enum Weapon
    {
        none,
        axe,
        bow
    }
    public Weapon weapon;
    public string nickname;
    public float coins;
    public float crystals;
    public float energy;
    public float maxEnergy;
    public float mana;
    public float maxMana;
    public float attakPoint;
    public float defPoint;
    public float speedPoint;
    public float livePoint;
    public Character character;    
}
