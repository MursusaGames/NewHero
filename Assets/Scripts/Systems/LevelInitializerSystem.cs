using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

public class LevelInitializerSystem : BaseMonoSystem
{
    private const float NEXT_CIRCLE_OFFSET = 0.010f;
    private const float SPAWN_BORDER = 3.0f;
    // Модели имеют разный размер, поэтому нужно подгонять максимальный спавн юнитов относительно текущих размеров (% от размера макс. круга)
    private const float LEVEL_WIDTH_MULTIPLY = 0.5f;
    private const float PLAYER_START_POS_Y = 0.17f;

    public MatchData MatchData { get; private set; }

    [SerializeField] private LevelDataSystem _levelSystem;

    [SerializeField] private Transform _playerStartPos;
    [SerializeField] private Transform _levelParent;
    [SerializeField] private Transform _circlePrefab;

    [SerializeField] private List<GameObject> _units = new List<GameObject>();
    [SerializeField] private List<GameObject> _enemies = new List<GameObject>();
    [SerializeField] private List<Transform> _circles = new List<Transform>();

    private int _currentLevel;
    private float _levelWidth;

    public override void Init(AppData data)
    {
        base.Init(data);

        MatchData = data.matchData;
        SetObservables();
    }

    private void SetObservables()
    {
        data.matchData.state
            .Where(x => x == MatchData.State.LevelInitializing)
            .Subscribe(_ => SpawnPlayerCharacters());

        data.matchData.state
            .Where(x => x == MatchData.State.EndGame)
            .Subscribe(_ => EndGame());
    }

    private void SpawnPlayerCharacters()
    {
        _currentLevel = _levelSystem.CurrentLevel;
        var currentLevelData = data.LevelDataContainer.LevelItems[_currentLevel];
        var character = data.matchData.playerUser.character;

        SpawnCircle(currentLevelData.Circles);
        SetPlayerStartPosition();

        //SpawnEntity(currentLevelData.MinionsAmount, character.unitPrefab);
        //SpawnEntity(currentLevelData.ObstacleAmount, character.obstaclePrefab, true);
        data.matchData.state.Value = MatchData.State.Initializing;
    }

    private void SpawnCircle(CircleData[] circles)
    {
        for (int i = 0; i < circles.Length; i++)
        {
            var circle = Instantiate(_circlePrefab, _levelParent);
            circle.localScale = new Vector3(circles[i].CircleRadius, 0.1f, circles[i].CircleRadius);
            if (i > 0) circle.localPosition = new Vector3(circle.position.x, _circles[i - 1].localPosition.y - NEXT_CIRCLE_OFFSET, circle.position.z);
            circle.GetComponent<Renderer>().material = circles[i].Material;

            _circles.Add(circle);

            float prevCircleWidth = 0;
            if (i > 0) prevCircleWidth = circles[i - 1].CircleRadius * LEVEL_WIDTH_MULTIPLY;
            SpawnEnemy(circles[i], prevCircleWidth, i);
        }

        _levelWidth = circles[circles.Length - 1].CircleRadius;
        _levelWidth *= LEVEL_WIDTH_MULTIPLY;
    }

    private void SetPlayerStartPosition()
    {
        _playerStartPos.position = new Vector3(0, PLAYER_START_POS_Y, -_levelWidth);
    }

    /*private void SpawnEntity(float numberUnits, EntityController entityPrefab, bool isObstacle = false)
    {
        for (int i = 0; i < numberUnits; i++)
        {
            Vector3 randomPos = Vector3.zero + UnityEngine.Random.insideUnitSphere * _levelWidth;
            if (randomPos.x < SPAWN_BORDER && randomPos.x > -SPAWN_BORDER) randomPos.x = UnityEngine.Random.Range(3f, 20f);
            var unit = Instantiate(entityPrefab, randomPos, Quaternion.identity);
            unit.transform.position = new Vector3(unit.transform.position.x, 0, unit.transform.position.z);
            unit.name += "_" + i;

            if (isObstacle) continue;

            _units.Add(unit.gameObject);
        }
    }*/

    private void SpawnEnemy(CircleData circleData, float prevCircleWidth, int circleNum)
    {
        var circleWidth = circleData.CircleRadius * LEVEL_WIDTH_MULTIPLY;
        //var entityPrefab = data.matchData.playerUser.character.policePrefab;
        
        // [TODO] Spawn enemies by groups, not by max enemies in circle
        var groupsInCircle = UnityEngine.Random.Range(circleData.EnemyGroupsAmount.x, circleData.EnemyGroupsAmount.y + 1);

        for(int i=0; i < groupsInCircle; i++)
        {

        }

        for (int i = 0; i < circleData.EnemyAmount; i++)
        {
            Vector3 randomPos = GetRandomCirclePosition(circleWidth, prevCircleWidth);
            //var unit = Instantiate(entityPrefab, randomPos, Quaternion.identity);
            //unit.transform.position = new Vector3(unit.transform.position.x, 0, unit.transform.position.z);
            //unit.name = "Police_" + i + "_Circle_" + circleNum;

            //_enemies.Add(unit.gameObject);
        }
    }

    private Vector3 GetRandomCirclePosition(float circleWidth, float prevCircleWidth)
    {
        Vector3 randomPos;
        float d;

        do
        {
            randomPos = Vector3.zero + UnityEngine.Random.insideUnitSphere * circleWidth;
            d = Mathf.Sqrt(Mathf.Pow(randomPos.x - 0, 2) + Mathf.Pow(randomPos.z - 0, 2));
        } while (!(d >= prevCircleWidth && d <= circleWidth));

        return randomPos;
    }

    private void EndGame()
    {
        foreach (var unit in _units)
            Destroy(unit);
        foreach (var unit in _enemies)
            Destroy(unit);
        foreach (var circle in _circles)
            Destroy(circle.gameObject);
            

        _units.Clear();
        _enemies.Clear();
        _circles.Clear();
    }
}
