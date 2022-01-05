using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GiftSet : MonoBehaviour
{
    [SerializeField] private MoneyView money;
    [SerializeField] private CrystallsView crystalls;
    [SerializeField] private ManaView mana;
    [SerializeField] private EnergyView energy;
    [SerializeField] private AppData data;
    [SerializeField] private Timer timer;
    [SerializeField] private RedRingsSystem redRingsSystem;
    public List<GameObject> btns;
    public List<GameObject> checkmarks;
    public List<GameObject> timers;
    
    private int currentDay;

    private void Start()
    {
        currentDay = data.giftData.currentDay;
        for(int i = 1; i<timers.Count;i++)
        {
            timers[i].SetActive(i == currentDay);            
        }
        foreach(var btn in btns)
        {
            btn.SetActive(false);
        }

        for (int i = 0; i < checkmarks.Count;i++)
        {
            checkmarks[i].SetActive(data.giftData.days[i]);
        }
        if (currentDay == 0) CheckDay(0);
        redRingsSystem.ResetRedRingsInGiftMenu();
    }

    public void CheckDay(int number)
    {
        btns[number].SetActive(true);
    }
    
    public void GetGift(int id)
    {
        switch (id)
        {
            case 0:
                data.userData.crystals += 30;
                crystalls.ChangeValue(data.userData.crystals);
                data.userData.energy += 10;
                energy.ChangeEnergyValue(data.userData.energy);
                data.userData.mana += 10;
                mana.ChangeManaValue(data.userData.mana);
                btns[0].SetActive(false);
                checkmarks[0].SetActive(true);
                timer.StartTimer();
                data.giftData.currentDay = 1;
                data.giftData.days[0] = true;
                Start();
                break;
            case 1:
                data.userData.crystals += 20;
                crystalls.ChangeValue(data.userData.crystals);
                data.userData.energy += 5;
                energy.ChangeEnergyValue(data.userData.energy);
                data.userData.coins += 100;
                money.ChangeValue(data.userData.coins);
                btns[1].SetActive(false);
                checkmarks[1].SetActive(true);
                timer.StartTimer();
                data.giftData.currentDay = 2;
                Start();
                break;
            case 2:
                data.userData.crystals += 10;
                crystalls.ChangeValue(data.userData.crystals);
                data.userData.energy += 10;
                energy.ChangeEnergyValue(data.userData.energy);
                data.userData.coins += 1000;
                money.ChangeValue(data.userData.coins);
                btns[2].SetActive(false);
                checkmarks[2].SetActive(true);
                timer.StartTimer();
                data.giftData.currentDay = 3;
                break;
            case 3:
                data.userData.crystals += 10;
                crystalls.ChangeValue(10);
                data.userData.energy += 10;
                energy.ChangeEnergyValue(10);
                data.userData.coins += 1000;
                money.ChangeValue(1000);
                btns[3].SetActive(false);
                checkmarks[3].SetActive(true);
                timer.StartTimer();
                data.giftData.currentDay = 4;
                break;
            case 4:
                data.userData.crystals += 10;
                crystalls.ChangeValue(10);
                data.userData.energy += 10;
                energy.ChangeEnergyValue(10);
                data.userData.coins += 1000;
                money.ChangeValue(1000);
                btns[4].SetActive(false);
                checkmarks[4].SetActive(true);
                timer.StartTimer();
                data.giftData.currentDay = 5;
                break;
            case 5:
                data.userData.crystals += 10;
                crystalls.ChangeValue(10);
                data.userData.energy += 10;
                energy.ChangeEnergyValue(10);
                data.userData.coins += 1000;
                money.ChangeValue(1000);
                btns[5].SetActive(false);
                checkmarks[5].SetActive(true);
                timer.StartTimer();
                data.giftData.currentDay = 6;
                break;
            case 6:
                data.userData.crystals += 10;
                crystalls.ChangeValue(10);
                data.userData.energy += 10;
                energy.ChangeEnergyValue(10);
                data.userData.coins += 1000;
                money.ChangeValue(1000);
                btns[6].SetActive(false);
                checkmarks[6].SetActive(true);
                timer.StartTimer();
                data.giftData.currentDay = 7;
                break;
            case 7:
                data.userData.crystals += 10;
                crystalls.ChangeValue(10);
                data.userData.energy += 10;
                energy.ChangeEnergyValue(10);
                data.userData.coins += 1000;
                money.ChangeValue(1000);
                btns[7].SetActive(false);
                checkmarks[7].SetActive(true);
                timer.StartTimer();
                data.giftData.currentDay = 8;
                break;
            case 8:
                data.userData.crystals += 10;
                crystalls.ChangeValue(10);
                data.userData.energy += 10;
                energy.ChangeEnergyValue(10);
                data.userData.coins += 1000;
                money.ChangeValue(1000);
                btns[8].SetActive(false);
                checkmarks[8].SetActive(true);
                timer.StartTimer();
                data.giftData.currentDay = 9;
                break;
            case 9:
                data.userData.crystals += 10;
                crystalls.ChangeValue(10);
                data.userData.energy += 10;
                energy.ChangeEnergyValue(10);
                data.userData.coins += 1000;
                money.ChangeValue(1000);
                btns[9].SetActive(false);
                checkmarks[9].SetActive(true);
                timer.StartTimer();
                data.giftData.currentDay = 10;
                break;
            case 10:
                data.userData.crystals += 10;
                crystalls.ChangeValue(10);
                data.userData.energy += 10;
                energy.ChangeEnergyValue(10);
                data.userData.coins += 1000;
                money.ChangeValue(1000);
                btns[10].SetActive(false);
                checkmarks[10].SetActive(true);
                timer.StartTimer();
                data.giftData.currentDay = 11;
                break;
            case 11:
                data.userData.crystals += 10;
                crystalls.ChangeValue(10);
                data.userData.energy += 10;
                energy.ChangeEnergyValue(10);
                data.userData.coins += 1000;
                money.ChangeValue(1000);
                btns[11].SetActive(false);
                checkmarks[11].SetActive(true);
                timer.StartTimer();
                data.giftData.currentDay = 12;
                break;
            case 12:
                data.userData.crystals += 10;
                crystalls.ChangeValue(10);
                data.userData.energy += 10;
                energy.ChangeEnergyValue(10);
                data.userData.coins += 1000;
                money.ChangeValue(1000);
                btns[12].SetActive(false);
                checkmarks[12].SetActive(true);
                timer.StartTimer();
                data.giftData.currentDay = 13;
                break;
            case 13:
                data.userData.crystals += 10;
                crystalls.ChangeValue(10);
                data.userData.energy += 10;
                energy.ChangeEnergyValue(10);
                data.userData.coins += 1000;
                money.ChangeValue(1000);
                btns[13].SetActive(false);
                checkmarks[13].SetActive(true);
                timer.StartTimer();
                data.giftData.currentDay = 14;
                break;
            case 14:
                data.userData.crystals += 10;
                crystalls.ChangeValue(10);
                data.userData.energy += 10;
                energy.ChangeEnergyValue(10);
                data.userData.coins += 1000;
                money.ChangeValue(1000);
                btns[14].SetActive(false);
                checkmarks[14].SetActive(true);
                break;

        }
    }
}
