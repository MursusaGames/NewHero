using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 target;
    [SerializeField] private float speed = 1.5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        target = new Vector3(transform.position.x, transform.position.y, player.transform.position.z-6);
        transform.position = Vector3.Lerp(target, transform.position, speed * Time.fixedDeltaTime);
    }
}
