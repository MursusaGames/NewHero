using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    private Camera mainCamera;
    private bool isCamera; 
    
    private void Start()
    {
        Destroy(gameObject,4f);
        mainCamera = Camera.main;
        isCamera = true;
    }

    

    private void Update()
    {
        if (isCamera) transform.LookAt(mainCamera.transform);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(nameof(Player)))
        {
            other.gameObject.GetComponent<UnitController>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag(nameof(Wall)))
        {
            Destroy(gameObject);
        }
    }    
}
