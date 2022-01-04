using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemySystem : MonoBehaviour
{
    public List<GameObject> enemys = new List<GameObject>(5);
    public List<Vector3> positions = new List<Vector3>(5);
    [SerializeField] private GameController gameController;
    void Start()
    {
        InitSpawn(0);
        gameController.changeArena += InitSpawn;
    }
    private void OnDisable()
    {
        gameController.changeArena -= InitSpawn;
    }

    private void InitSpawn(int currentArena)
    {
        for (int i = 0; i < currentArena + 1; i++)
        {
            var enemy = Instantiate(enemys[i], positions[i], Quaternion.identity);
            gameController.enemysInLevel.Add(enemy);
        }
    }
    
}
