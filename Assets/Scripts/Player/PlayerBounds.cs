using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private Vector3 pos;

        
    void Update()
    {
        pos = transform.position;
        if (transform.position.x > 2)
        {
            pos.x = 2;            
        }
        else if(transform.position.x < -2)
        {
            pos.x = -2;            
        }

        if (transform.position.z > 13.5f)
        {
            pos.z = 13.5f;            
        }
        else if (transform.position.z < 0)
        {
            pos.z = 0;            
        }
        transform.position = pos;
    }
}
