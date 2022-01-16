using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/InventoryDataContainer")]
public class InventoryDataContainer : ScriptableObject
{
    [SerializeField] private List<InentoryItem> inventoryItems;
    public List<InentoryItem> InventoryItems => inventoryItems;
}
