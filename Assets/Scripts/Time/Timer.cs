using System.Collections;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private AppData data;
    private int _hour;
    private int _minits;
    private int _secunds;
    private int _day;

    public void StartTimer()
    {
        data.timerData.giftDate = DateTime.Now.ToString();
    }

    
}
