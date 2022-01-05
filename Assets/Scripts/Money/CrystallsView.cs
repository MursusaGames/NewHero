using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrystallsView : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    public void ChangeValue(float value)
    {
        text.text = value.ToString();
    }
}
