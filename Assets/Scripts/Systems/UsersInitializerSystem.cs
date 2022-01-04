using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsersInitializerSystem : BaseDataMonoSystem
{
    public override void Init(AppData data)
    {
        base.Init(data);
        //GetPlayerData();
    }
    private void GetPlayerData()
    {
        data.matchData.playerUser = data.userData;
        Character playerCharacter = ScriptableObject.CreateInstance<Character>();
        //playerCharacter.unitPrefab = data.characterData.unitPrefab;
        data.matchData.playerUser.character = playerCharacter;
    }
}
