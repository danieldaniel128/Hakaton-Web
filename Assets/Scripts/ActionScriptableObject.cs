using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "ActionData", menuName = "ScriptableObjects/Action", order = 2)]
[System.Serializable]
public class ActionScriptableObject : ScriptableObject
{
    public string actionName;
    GameManager.CombatType type;
    bool isReady;

    void Use()
    {
        isReady = false;
    }
}
