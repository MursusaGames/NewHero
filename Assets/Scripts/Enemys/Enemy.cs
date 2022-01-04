using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float _health;
    public int _damage;
    public string _name;
    public float _timeToAttack = 5f;
    public Transform player;
    public float yOffset = 5;
    public float _maxHealth;
    
    public float force;

    [SerializeField] protected GameObject bulletPrefab;
    private GameController gameController;
    [SerializeField] protected Image bar;
    protected float time;
    protected bool isAttack;
    private Camera mainCamera;

    protected void Start()
    {
        gameController = FindObjectOfType<GameController>();
        mainCamera = Camera.main;
        _maxHealth = _health;
        ShowHealthBar();
        player = FindObjectOfType<UnitController>().transform;        
    }
    private void ShowHealthBar()
    {
        bar.fillAmount = _health / _maxHealth;
    }
    protected void Timer()
    {
        time += 0.02f;
        if(time > _timeToAttack)
        {
            isAttack = true;
            time = 0;
        }
    }
    
    protected void FixedUpdate()
    {
        transform.LookAt(mainCamera.transform);
        Timer();
        if (isAttack)
        {
            isAttack = false;
            Attack();
        }
    }

    protected void Attack()
    {
        //var tempScale = mouth.transform.localScale;
        //tempScale.x = 0.35f;
        //mouth.transform.localScale = tempScale;
        bulletPrefab.transform.position = transform.position;
        var bullet = Instantiate(bulletPrefab, transform.position,Quaternion.identity);        
        var spearBody = bullet.GetComponent<Rigidbody>();
        //var randomScatter = Random.Range(minScatterValue, maxScatterValue);
        Vector3 offsetDir = new Vector3(player.position.x, player.position.y+yOffset, player.position.z);
        Vector3 throwDir = (offsetDir - transform.position).normalized;
        spearBody.AddForce(throwDir * force, ForceMode.Impulse);
        var rot = Quaternion.LookRotation(throwDir);
        spearBody.rotation = rot;
        //Invoke(nameof(CloseMouth), 0.5f);
    }

    /*protected void CloseMouth()
    {
        var tempScale = mouth.transform.localScale;
        tempScale.x = 0.02f;
        mouth.transform.localScale = tempScale;
    }*/
    public void TakeDamage(int damage)
    {
        _health -= damage;
        ShowHealthBar();
        if (_health <= 0)
        {
            gameController.RemoveEnemy(this.gameObject);
            Destroy(gameObject);
        }
            
    }

}
