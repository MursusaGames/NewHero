using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private Vector3 pos;
    [SerializeField] private float xBoards = 2.5f;
    [SerializeField] private float zBoards = 13.5f;


    void Update()
    {
        pos = transform.position;
        if (transform.position.x > xBoards)
        {
            pos.x = xBoards;            
        }
        else if(transform.position.x < -xBoards)
        {
            pos.x = -xBoards;            
        }

        if (transform.position.z > zBoards)
        {
            pos.z = zBoards;            
        }
        else if (transform.position.z < 0)
        {
            pos.z = 0;            
        }
        transform.position = pos;
    }
}
