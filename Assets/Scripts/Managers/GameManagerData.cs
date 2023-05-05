using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerData : MonoBehaviourPun
{


    public GameManagerData Instance;

    public enum CombatType
    {
        Damage,
        Utility,
        Heal
    }

    public PhotonView PhotonView;

    CombatType currentMission;


    public int CurrentTurn = 1;
    public int CurrentGameMaster;//num id of player

    public List<bool> ChoosedOptions;//attack or run


    [SerializeField] private int _playerId => PhotonNetwork.LocalPlayer.ActorNumber;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        //PhotonView photonView;
        //_photonView.RPC("ChatMessage", RpcTarget.All, "jup", "and jup.");
    }
    [PunRPC]
    public void UpdateTurn()
    {
        CurrentTurn++;
    }
    [PunRPC]
    public void UpdateCurrentGameMaster()
    {
        if (PhotonNetwork.CountOfPlayers == _playerId)
            CurrentGameMaster = 1;
        else
            CurrentGameMaster = _playerId + 1;
    }


}
