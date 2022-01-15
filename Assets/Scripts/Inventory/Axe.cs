using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var freeBox = PlayerPrefs.GetInt("FreeBox");
            PlayerPrefs.SetString(freeBox.ToString(), "axe");
            freeBox++;
            PlayerPrefs.SetInt("FreeBox", freeBox);
            Destroy(gameObject);
        }
    }
}
