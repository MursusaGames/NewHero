using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public event Action<int> changeArena;
    public event Action<int> levelComplit;
    [SerializeField] private GameObject secondLifeWindow;
    [SerializeField] private GameObject portal;
    public List<GameObject> enemysInLevel; 
    private UnitController player;
    private int playerDeadCount = 0;
    private int _currentArena = 0;

    
    public int CurrentArena => _currentArena;

    private void OnEnable()
    {
        enemysInLevel = new List<GameObject>(5);
    }
    private void OnDisable()
    {
        enemysInLevel.Clear();
    }
    public void PlayerDead()
    {
        playerDeadCount++;
        if(playerDeadCount == 1)
        {
            Time.timeScale = 0;
            secondLifeWindow.Show();
        }
        else
        {
            playerDeadCount = 0;
            GameOver();
        }
    }
    public void GetPlayer(UnitController _player)
    {
        player = _player;
    }

    public void StendUpPlayer()
    {
        player.health = 100;
        secondLifeWindow.Hide();
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        secondLifeWindow.Hide();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void RemoveEnemy(GameObject enemy)
    {
        enemysInLevel.Remove(enemy);
        if(enemysInLevel.Count == 0)
        {
            player.IsWin = true;
            ShowPortal();
        }
    }
    private void ShowPortal()
    {
        portal.Show();
        levelComplit?.Invoke(_currentArena);
    }

    public void GoToNextArena()
    {
        _currentArena++;
        portal.Hide();
        changeArena?.Invoke(_currentArena);
    }


}
