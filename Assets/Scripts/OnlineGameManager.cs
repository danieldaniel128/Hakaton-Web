using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;

public class OnlineGameManager : MonoBehaviourPun
{
    public const string NETWORK_PLAYER_PREFAB_NAME = "NetworkPlayerObject";
    public static OnlineGameManager Instance;
    public PhotonView PhotonView;
    int newPlayerID = 0;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        //PhotonView photonView;
        //_photonView.RPC("ChatMessage", RpcTarget.All, "jup", "and jup.");
    }

    private void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            GameManagerData gameManagerData = PhotonNetwork.Instantiate("Game Manager Data", Vector3.zero, Quaternion.identity).GetComponent<GameManagerData>();
            gameManagerData.PlayerId = ++newPlayerID;
        }
    }
   
    

    
    //
    //void UpdateTurn() 
    //{

    //}


}
