using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDataContainer", menuName = "Data/LevelDataContainer")]

public class LevelDataContainer : ScriptableObject
{
    [SerializeField] private List<LevelData> _levelItems;
    public List<LevelData> LevelItems => _levelItems;
}
