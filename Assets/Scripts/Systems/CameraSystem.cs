using UnityEngine;
using UniRx;


public class CameraSystem : BaseMonoSystem
{
    [SerializeField] public Camera cam;
    public GameObject player;
    [SerializeField] private float cameraShift;    
    [SerializeField] private Transform _cameraTransform;    
    [SerializeField] Transform camStartPos;
    public GameObject target;   
    private float _yCameraBaseOffset;
    
    public float CameraShift => cameraShift;

    private bool isFollowing;    
   

    public override void Init(AppData data)
    {
        base.Init(data);
        SetObservables();
    }

    private void SetObservables()
    {
        data.matchData.state
            .Where(x => x == MatchData.State.StartGame)
            .Subscribe(_ => EnableFollowing());
        data.matchData.state
            .Where(x => x == MatchData.State.EndGame)
            .Subscribe(_ => DisableFollowing());
        data.matchData.state
           .Where(x => x == MatchData.State.Finish)
           .Subscribe(_ => DisableFollowing());
        data.matchData.cameraSystem = this;
    }

    
    
    public void InitTarget(GameObject _target)
    {
        target = _target;       
    }
    public void InitPlayer(GameObject _player)
    {
        player = _player;        
    }

    private void EnableFollowing()
    {
        cam.transform.position = camStartPos.position;       
        isFollowing = true;        
    }

    private void DisableFollowing()
    {
        isFollowing = false;        
    }

    private void Update()
    {
        if (target && isFollowing && player)
        {
            var pos = _cameraTransform.position;            
            pos.y += _yCameraBaseOffset;            
            _cameraTransform.position = pos;
            
        }        
    }

   
}
