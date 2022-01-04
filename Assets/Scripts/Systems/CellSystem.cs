using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSystem : BaseMonoSystem
{
    [SerializeField] GameObject cell;
    [SerializeField] GameObject parent;
    public bool ShowCells;
    private int xRow = 120;
    private int yRow = 120;
    private float cellsSize = 1f;
    

    private void Awake()
    {
        if (ShowCells)
        {
            for (int i = 0; i < yRow; i++)
            {
                for (int j = 0; j < xRow; j++)
                {
                    Instantiate(cell, new Vector3(-60 + j * cellsSize,0f, -60 + (i * cellsSize)), Quaternion.AngleAxis(90f, Vector3.right), parent.transform);
                }

            }
        }
        
    }
}
