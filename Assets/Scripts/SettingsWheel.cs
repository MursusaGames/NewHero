using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsWheel : MonoBehaviour
{
    

    // Update is called once per frame
    void FixedUpdate()
    {
        this.gameObject.transform.Rotate(Vector3.forward*0.2f);
    }
}
