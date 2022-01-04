using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDataMonoSystem : MonoBehaviour
{
    [SerializeField] public AppData data;
    public virtual void Init(AppData data)
    {
        this.data = data;
    }
}
