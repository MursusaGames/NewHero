using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DataInitializer))]
public class SystemInitializer : MonoBehaviour
{
    private void Awake() 
    {
        DataInitializer dataInitializer = GetComponent<DataInitializer>();
        dataInitializer.InitData();

        BaseDataMonoSystem[] dataSystems = GameObject.FindObjectsOfType<BaseDataMonoSystem>();
        foreach (var system in dataSystems)
            system.Init(dataInitializer.data);
        
        BaseMonoSystem[] systems = GameObject.FindObjectsOfType<BaseMonoSystem>();
        foreach (var system in systems)
            system.Init(dataInitializer.data);
    }
}
