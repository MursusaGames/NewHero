using System;
using UnityEngine;
using UnityEngine.UI;


public class UnitController : MonoBehaviour
{
    
    private SettingMenuSystem settingsMenu;
    [SerializeField] private float _moveSpeed = 100;
    [SerializeField] private float _rotateSpeed = 1;
    [SerializeField] private float yOffset;
    [SerializeField] private float force;
    [SerializeField] private bool _inRow;
    [SerializeField] private float turnSpeed = 2f;
    [SerializeField] private GameObject stownBullet;
    [SerializeField] private Transform stownBulletStartPoint;
    [SerializeField] private Transform playerStartPoint;
    [SerializeField] private Image bar;

    private Transform target;
    private Rigidbody _rigidbody;
    private Animator _animator;    
    private PlayerMovementSystem movSystem;
    private GameController gameController;
    [SerializeField] private float time;
    [SerializeField] private float timeToSearch = 1f;
    public bool isDead;
    private bool _isWin;
    private bool _isAttack;
    private bool isRun;
    private bool isSearch;
    public float health = 100;
    public float maxHealth;

    public bool IsWin
    {
        get { return _isWin; }
        set { _isWin = value;
        if(value) _animator.SetBool("InGame", false);
        }

    }

    
    public float MoveSpeed { get => _moveSpeed; set { _moveSpeed = value; } }
    private void Awake()
    {
        _animator = this.GetComponent<Animator>();
        _rigidbody = this.GetComponent<Rigidbody>();        
        movSystem = FindObjectOfType<PlayerMovementSystem>();
        settingsMenu = FindObjectOfType<SettingMenuSystem>();
        
        gameController = FindObjectOfType<GameController>();
    }
    private void OnEnable()
    {
        isDead = false;
        _rigidbody.isKinematic = false;        
    }
    private void OnDisable()
    {
        isDead = true;
        gameController.changeArena -= StartPosPlayer;
    }
    private void Start()
    {
        maxHealth = health;
        ShowHealthBar();
        movSystem.AddUnit(this);
        gameController.GetPlayer(this);
        StartPosPlayer(0);
        gameController.changeArena += StartPosPlayer;
        //_animator.SetBool("InGame", true);
    }

    private void StartPosPlayer(int currentLevel)
    {
        transform.position = playerStartPoint.position;
        _isWin = false;
        _animator.SetBool("InGame", true);
        
    }

    public void Move(Vector3 moveDirection)
    {

        if (isDead) return;
        if(moveDirection != Vector3.zero)
        {
            isRun = true;
            _rigidbody.isKinematic = false;
            _animator.SetBool("Run", true);
            Vector3 offset = moveDirection.normalized * _moveSpeed * Time.deltaTime;
            _rigidbody.velocity = offset;
        }
        else
        {
            isRun = false;
            _rigidbody.velocity = Vector3.zero;
            _animator.SetBool("Run", false);
            _rigidbody.isKinematic = true;
        }        
    }

    public void Rotate(Vector3 moveDirection)
    {
        
        if (Vector3.Angle(transform.forward, moveDirection) > 0 && !isDead)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, _rotateSpeed, 0);
            Quaternion rotation = Quaternion.LookRotation(newDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
        }
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        ShowHealthBar();
        if(health <= 0)
        {
            gameController.PlayerDead();
        }
    }
    private void Timer()
    {
        time += 0.02f;
        if (time > timeToSearch)
        {
            isSearch = true;
            time = 0;
        }
    }

    private void ShowHealthBar()
    {
        bar.fillAmount = health / maxHealth;
    }

    protected void FixedUpdate()
    {
        if (_isWin ) return;
        Timer();
        if (isSearch && !isRun)
        {
            isSearch = false;
            FindTarget();
        }
    }
    private void FindTarget()
    {
        if (_isWin || movSystem._data.userData.weapon == UserData.Weapon.axe) return;
        var enemys = gameController.enemysInLevel;
        float dystance = 100f;
        for(int i = 0; i < enemys.Count; i++)
        {
            var enemyDystance = Vector3.Distance(enemys[i].transform.position, transform.position);
            if (enemyDystance < dystance)
            {
                dystance = enemyDystance;
                target = enemys[i].transform;
            }
        }
        if(!isRun) transform.LookAt(target);

    }
    public void Attack()
    {
        if (_isWin || !target || movSystem._data.userData.weapon == UserData.Weapon.axe) return;
        var bullet = Instantiate(stownBullet, stownBulletStartPoint.position, Quaternion.identity);
        var rg = bullet.GetComponent<Rigidbody>();
        Vector3 offsetDir = new Vector3(target.position.x, target.position.y- yOffset, target.position.z);
        Vector3 throwDir = (offsetDir - transform.position).normalized;
        rg.AddForce(throwDir * force, ForceMode.Impulse);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(movSystem._data.userData.weapon == UserData.Weapon.axe && other.gameObject.CompareTag("Enemy"))
        {
            _animator.SetBool("Axe", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (movSystem._data.userData.weapon == UserData.Weapon.axe && other.gameObject.CompareTag("Enemy"))
        {
            _animator.SetBool("Axe", false);
        }
    }
}
