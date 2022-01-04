using UnityEngine;
using UniRx;
using System.Collections.Generic;


public class PlayerMovementSystem : BaseMonoSystem
{
    private bool _isTouching = false;
    public Vector3 _direction = Vector3.forward;   
    private Camera main;
    private GameObject target;
    private List<UnitController> units;
    private bool endGame;



    public override void Init(AppData data)
    {
        base.Init(data);
        SetObservables();      
    }
    private void OnDisable()
    {
        
    }
    private void OnEnable()
    {
        main = Camera.main;
        units = new List<UnitController>();
    }

    private void SetObservables()
    {
       data.matchData.state
           .Where(x => x == MatchData.State.EndGame)
           .Subscribe(_ => EndGame(transform));       
    }

    public void AddUnit(UnitController unit)
    {
        units.Add(unit);
    }
    
    
    private void Move()
    {
        
        if (!endGame)
        {
            for (int i = 0; i < units.Count; i++)
            {
                units[i].Move(_direction);               
                units[i].Rotate(_direction);
            }
        }
        
    }
    private void EndGame(Transform empty)
    {
          
    } 
    
    

    private void Update()
    {
        _isTouching = InputManager.instance.steering.isTouch;
        var steeringInput = InputManager.instance.steering.delta;
        if (_isTouching)
        {
            _direction.x =  steeringInput.x;
            _direction.z =  steeringInput.y;
           // _direction = (main.transform.up * steeringInput.y) + (main.transform.right * steeringInput.x);
            _direction.y = 0;
        }
        else _direction = Vector3.zero;
    }    
   
    private void FixedUpdate()
    {
        Move();
    }
}
