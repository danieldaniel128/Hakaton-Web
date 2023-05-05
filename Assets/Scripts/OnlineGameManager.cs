using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;

public class OnlineGameManager : MonoBehaviourPun
{
    public const string NETWORK_PLAYER_PREFAB_NAME = "NetworkPlayerObject";
    public static OnlineGameManager Instance;
    [SerializeField] int newPlayerID = 0;

    public PhotonView PhotonView;


    GameManagerData gameManagerData;
    public List<GameManagerData> gameManagerDatas;
    public int MyPlayerID;
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
            PhotonView.RPC("UpdatePlayerId", RpcTarget.AllViaServer);
            MyPlayerID = newPlayerID;
            Debug.Log("");
        }
    }
    [PunRPC]
    public void UpdatePlayerId()
    {
        if(gameManagerDatas.Count<PhotonNetwork.CountOfPlayers)
        gameManagerData = PhotonNetwork.Instantiate("Game Manager Data", Vector3.zero, Quaternion.identity).GetComponent<GameManagerData>();
        ++newPlayerID;
        gameManagerData.PlayerId = newPlayerID;
        gameManagerDatas.Add(gameManagerData);
    }


}
