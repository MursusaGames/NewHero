using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SomeCustomsData", menuName = "Data/CustomData")]
public class CustomData : ScriptableObject
{
    [SerializeField] private BookType _customSkinType;
    [SerializeField] private Sprite _customSprites;
    [SerializeField] private string _customSubscribe;
    [SerializeField] private string _customNames;
    [SerializeField] private string _customSubscribeEN;
    [SerializeField] private string _customNamesEN;
    [SerializeField] private string _customPrices;

    public BookType CustomSkinType => _customSkinType;
    public Sprite CustomSprites => _customSprites;
    public string CustomSubscribe => _customSubscribe;
    public string CustomNames => _customNames;
    public string CustomSubscribeEN => _customSubscribeEN;
    public string CustomNamesEN => _customNamesEN;
    public string CustomPrices => _customPrices;
}
