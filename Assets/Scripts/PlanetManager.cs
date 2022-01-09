using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    [SerializeField] private GameObject planet;

    private void OnEnable()
    {
        planet.SetActive(true);
    }

    private void OnDisable()
    {
        if(planet) planet.SetActive(false);
    }
}
