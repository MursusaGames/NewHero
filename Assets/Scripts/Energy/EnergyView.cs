using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnergyView : MonoBehaviour
{
    [SerializeField] private TMP_Text energyCount;
    [SerializeField] private TMP_Text energyMaxCount;
    [SerializeField] private Image energyBar;
    private float energy;
    private float maxEnergy;
    public void ChangeEnergyValue(float value)
    {
        energyCount.text = value.ToString();
        energy = value;
        ChangeBar();
    }
    public void ChangeMaxEnergyValue(float value)
    {
        energyMaxCount.text = value.ToString();
        maxEnergy = value;
        ChangeBar();
    }
    private void ChangeBar()
    {
        var amount = energy / maxEnergy;
        if (amount > 1) amount = 1f;
        energyBar.fillAmount = amount;
    }
}
