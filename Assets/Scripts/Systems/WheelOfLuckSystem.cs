using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelOfLuckSystem : MonoBehaviour
{
    private int levelWithWhellOfLuck;
    [SerializeField] private GameObject wheelView;
    [SerializeField] private WheelOfLucy wheel;
    [SerializeField] private int minLimitWheelAppare = 2;
    [SerializeField] private int maxLimitWheelAppare = 4;
    [SerializeField] private GameController gameController;

    void Start()
    {
        levelWithWhellOfLuck = Random.Range(minLimitWheelAppare, maxLimitWheelAppare);
        gameController.levelComplit += ShowWheel;
        wheel.winField += wheelWin;
    }
    private void OnDisable()
    {
        wheel.winField -= wheelWin;
        gameController.levelComplit -= ShowWheel;
    }

    private void ShowWheel(int level)
    {
        if(level == levelWithWhellOfLuck)
        {
            levelWithWhellOfLuck += Random.Range(minLimitWheelAppare, maxLimitWheelAppare);
            wheelView.SetActive(true);
        }
    }
    private void wheelWin(string name)
    {
        wheelView.SetActive(false);
    }
    
}
