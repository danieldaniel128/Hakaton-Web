using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourPun
{


    public GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public enum CombatType
    {
        Damage,
        Utility,
        Heal
    }

    public PhotonView PhotonView;

    CombatType currentMission;


   


    


}
