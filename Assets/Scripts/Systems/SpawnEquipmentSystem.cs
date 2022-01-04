using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEquipmentSystem : MonoBehaviour
{
    [SerializeField] private MeshRenderer plane;
    [SerializeField] private GameController gameController;
    [SerializeField] private List<Material> levelsMaterials = new List<Material>();
    void Start()
    {
        InitEquipment(0);
        gameController.changeArena += InitEquipment;
    }
    private void OnDisable()
    {
        gameController.changeArena -= InitEquipment;
    }

    void InitEquipment(int currentLevel)
    {
        plane.material = levelsMaterials[currentLevel];
    }
}
