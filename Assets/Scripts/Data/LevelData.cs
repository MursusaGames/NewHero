using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SomeLevelsData", menuName = "Data/LevelData")]
public class LevelData : ScriptableObject
{
    [Header("Circles Settings")]
    [SerializeField] private CircleData[] _circles;

    [Header("Enemies Settings")]
    [SerializeField] private int _enemiesAmount;

    [Header("Obstacle Settings")]
    [SerializeField] private int _obstacleAmount;

    [Header("Minions Settings")]
    [SerializeField] private int _minionsAmount;
    [SerializeField] private Vector2 _minionsCountInGroup;

    [Header("Health")]
    [SerializeField] private float _bossHealth = 20;


    [Header("PlatformsSettings")]
    [SerializeField] public int _numberPlatformsInLevel = 10;

    [Header("SpeedSettings")]

    [Header("DistanceSettings")]

    [SerializeField] private int _minXDistance = 2;
    [SerializeField] private int _maxXDistance = 7;
    [SerializeField] private int _minYDistance = 1;
    [SerializeField] private int _maxYDistance = 3;

    [Header("TimerSettings")]
    [SerializeField] private float _upDownMoveDelay;
    [SerializeField] private float _leftRightMoveDelay;

    [Header("NameSettings")]
    [SerializeField] private string _levelSubscribe;
    [SerializeField] private string _levelName;
    [SerializeField] private string _levelSubscribeEN;
    [SerializeField] private string _levelNameEN;


    public CircleData[] Circles => _circles;

    public float BossHealth => _bossHealth;
    public float LeftRightMoveDelay => _leftRightMoveDelay;

    public int MinionsAmount => _minionsAmount;
    public int EnemiesAmount => _enemiesAmount;
    public int ObstacleAmount => _obstacleAmount;


    public int MinXDistance => _minXDistance;
    public int MaxXDistance => _maxXDistance;
    public int MinYDistance => _minYDistance;
    public int MaxYDistance => _maxYDistance;

    public int NamberPlatformsInLevel => _numberPlatformsInLevel;

    public string LevelSubscribe => _levelSubscribe;
    public string LevelName => _levelName;
    public string LevelSubscribeEN => _levelSubscribeEN;
    public string LevelNameEN => _levelNameEN;
}
[System.Serializable]
public struct CircleData
{
    public float CircleRadius;
    public Material Material;
    public int EnemyAmount;
    [SerializeField] private int _minionsGroupAmount;
    public Vector2 EnemyGroupsAmount;
}
