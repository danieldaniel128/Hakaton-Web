using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonPUN<GameManager>
{
    //Scene
    [SerializeField] Transform objectSpawnLocation;

    //UI
    [SerializeField] GameObject NormieUI;
    [SerializeField] GameObject GMUI;

    int currentPlayerTurn;
    int playerID;

    private void Start()
    {
        
    }

    public enum CombatType
    {
        Damage,
        Utility,
        Heal
    }

    int turn;
    CombatType currentMission;


}
