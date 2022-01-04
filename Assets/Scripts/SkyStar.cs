using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyStar : MonoBehaviour
{
    private bool isRotate;
    private bool increace;
    private float speed;
    private float scalePower = 0.005f;
    void OnEnable()
    {
        Invoke(nameof(Rotate), Random.Range(0f, 1f));
    }
    private void OnDisable()
    {
        isRotate = false;        
    }

    private void Rotate()
    {
        isRotate = true;       
    }
  
    void FixedUpdate()
    {
        if (isRotate)
        {
            if (this.gameObject.transform.localScale.x < 0) increace = true;
            else if (this.gameObject.transform.localScale.x > 2) increace = false;            
            if (!increace) this.gameObject.transform.localScale -= Vector3.one*scalePower;
            else this.gameObject.transform.localScale += Vector3.one*scalePower;
        }
    }


}
