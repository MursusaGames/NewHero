using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/InventoryItem")]
public class InentoryItem : ScriptableObject
{
    public enum Slot
    {
        attack,
        def,
        luck,
        ring,
        jack,
        shoe, 
        none
    }
    public Slot slot;
    public int id;
    public Sprite sprite;
    public string itemName;
    public string itemNameEn;
    public float attakPoint;
    public float defPoint;
    public float liewPoint;
    public float speedPoint;
}
