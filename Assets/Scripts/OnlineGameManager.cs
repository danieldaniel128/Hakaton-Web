using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class OnlineGameManager : MonoBehaviourPun
{
    public const string NETWORK_PLAYER_PREFAB_NAME = "NetworkPlayerObject";
    public static OnlineGameManager Instance;
    public PhotonView PhotonView;



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
            PhotonView PhotonViewGMData = PhotonNetwork.Instantiate("Game Manager Data", Vector3.zero, Quaternion.identity).GetPhotonView();
            if(PhotonViewGMData.Owner.IsMasterClient)
                photonView.ViewID = 1;
        }
    }
   
    

    
    //
    //void UpdateTurn() 
    //{

    //}


}
