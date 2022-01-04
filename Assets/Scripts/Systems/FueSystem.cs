using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FueSystem : BaseMonoSystem
{
    public Sprite[] fuesSprites;
    public string[] fuesSubscribe;
    public string[] fuesNames;
    public string[] fuesSubscribeEN;
    public string[] fuesNamesEN;    

    public override void Init(AppData data)
    {
        base.Init(data);        
        InitializeData();
    }
    private void InitializeData()
    {
        FueDataContainer container = data.FueDataContainer;
        int amount = container.FueItems.Count;

        fuesSprites = new Sprite[amount];
        fuesSubscribe = new string[amount];
        fuesNames = new string[amount];
        fuesSubscribeEN = new string[amount];
        fuesNamesEN = new string[amount];
        

        for (int i = 0; i < amount; i++)
        {
            fuesSprites[i] = container.FueItems[i].FueSprites;
            fuesSubscribe[i] = container.FueItems[i].FueSubscribe;
            fuesNames[i] = container.FueItems[i].FueNames;
            fuesSubscribeEN[i] = container.FueItems[i].FueSubscribeEN;
            fuesNamesEN[i] = container.FueItems[i].FueNamesEN;            
        }
    }
}
