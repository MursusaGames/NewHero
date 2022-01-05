using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/GiftData")]
public class GiftData : ScriptableObject
{
    [Header("Main")]
    public List<bool> days;
    public int currentDay;
    
}
