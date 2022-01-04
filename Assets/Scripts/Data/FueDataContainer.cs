using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FueDataContainer", menuName = "Data/FueDataContainer")]
public class FueDataContainer : ScriptableObject
{
    [SerializeField] private List<FueData> _fueItems;
    public List<FueData> FueItems => _fueItems;
}