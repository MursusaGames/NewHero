using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataSystem : BaseMonoSystem
{
    private int _currentLevel;
    private int numberOfLevels;
    public int _ringWidth = 10;

    public int CurrentLevel
    {
        get { return _currentLevel; }
        set { _currentLevel = value;
            if (value > 2)
            {
                _currentLevel = 0;
                PlayerPrefs.SetInt(ConstanCes.CURRENT_LEVEL, 0);
            }
                
        }
    }
    public float[] bossHealth;
    public int[] _numberRingsInLevel;
    public int[] _numberUnitsInLevel;
    public int[] _numberEnemysInLevel;
    public int[] _numberObstaclesInLevel;

    public void SetCurrentLevel()
    {
        if (!PlayerPrefs.HasKey(ConstanCes.CURRENT_LEVEL)) PlayerPrefs.SetInt(ConstanCes.CURRENT_LEVEL, 0); 
        else CurrentLevel = PlayerPrefs.GetInt(ConstanCes.CURRENT_LEVEL);
    }
    public override void Init(AppData data)
    {
        base.Init(data);
        InitializeData();
    }
    private void InitializeData()
    {
        LevelDataContainer container = data.LevelDataContainer;
        numberOfLevels = container.LevelItems.Count;
        SetCurrentLevel();         
        bossHealth = new float[numberOfLevels];
        _numberRingsInLevel = new int[numberOfLevels];
        _numberUnitsInLevel = new int[numberOfLevels];
        _numberEnemysInLevel = new int[numberOfLevels];
        _numberObstaclesInLevel = new int[numberOfLevels];

        for (int i = 0; i < numberOfLevels; i++)
        {
            //bossHealth[i] = container.LevelItems[i].BossHealth;
            //_numberRingsInLevel[i] = container.LevelItems[i].NumberRingsInLevel;
            //_numberUnitsInLevel[i] = container.LevelItems[i].NumberUnits;
            //_numberEnemysInLevel[i] = container.LevelItems[i].NumberEnemys;
            //_numberObstaclesInLevel[i] = container.LevelItems[i].NumberObstacles;

            // [TODO] [FIX] POL

        }
    }
}
