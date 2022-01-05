using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerView : MonoBehaviour
{
    [SerializeField] private AppData data;
   
    [SerializeField] private Text _hours;
    [SerializeField] private Text _minits;
    [SerializeField] private Text _secunds;
    [SerializeField] private GiftSet giftSet;

    public void ShowTime(float hours, float minits, float secunds)
    {
        _hours.text = hours.ToString()+"÷.";
        _minits.text = minits.ToString()+"ì.";
        _secunds.text = secunds.ToString()+"c.";
    }
    public void OnEnable()
    {
        if(data.giftData.currentDay != 0) StartCoroutine(nameof(timer));
    }

    private IEnumerator timer()
    {
        while (true)
        {
            
            DateTime dateCurrent = DateTime.Now;
            DateTime dateNext = DateTime.Parse(data.timerData.giftDate);
            int day = (dateCurrent - dateNext).Days;
            int hour = 23 -( dateCurrent - dateNext).Hours;
            int minutes = 59 - (dateCurrent- dateNext).Minutes;
            int seconds = 60 - (dateCurrent- dateNext).Seconds;
            if ((day * -24) + hour < 0)
            {
                giftSet.CheckDay(data.giftData.currentDay);
                gameObject.SetActive(false);
                StopCoroutine(nameof(timer));
            }

            ShowTime(hour, minutes, seconds);
            yield return new WaitForSeconds(1f);
        }
    }
}
