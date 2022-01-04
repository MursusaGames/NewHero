using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BildBoardUI : MonoBehaviour
{
    private Camera playerCamera;
    void Start()
    {
        playerCamera = Camera.main; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        transform.LookAt(transform.position + playerCamera.transform.rotation*Vector3.forward, playerCamera.transform.rotation * Vector3.up);
    }
}
