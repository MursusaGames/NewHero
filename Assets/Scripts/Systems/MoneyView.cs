using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using TMPro;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    public void ChangeValue(float value)
    {
        text.text = value.ToString();
    }
   
}
