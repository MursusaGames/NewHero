using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    private float timeToDestroy = 5f;
    private void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(nameof(Enemy)))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
