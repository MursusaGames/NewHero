using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseMonoSystem : MonoBehaviour
{
    public AppData data;
    public virtual void Init(AppData data)
    {
        this.data = data;
    }
}
