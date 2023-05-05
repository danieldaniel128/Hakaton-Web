using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class OnlineGameManager : MonoBehaviourPun
{
    public const string NETWORK_PLAYER_PREFAB_NAME = "NetworkPlayerObject";
    public static OnlineGameManager Instance;
    public PhotonView PhotonView;
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
    public void UpdateDataToLocalPlayers()
    {
        //Debug.Log("change current turn: " + CurrentTurn);
        //current turn, who is gm, adveturers //current turn selected yes. //selected play yes or no
        //Debug.Log(string.Format("ChatMessage {0} {1}", a, b));

        //data logic;
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
            CurrentGameMaster = _playerId+1;
    }
    //
    //void UpdateTurn() 
    //{

    //}


}
