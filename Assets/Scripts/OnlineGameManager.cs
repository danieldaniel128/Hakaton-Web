using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class OnlineGameManager : MonoBehaviourPun
{
    public const string NETWORK_PLAYER_PREFAB_NAME = "NetworkPlayerObject";
    [SerializeField] private Transform[] spawnPoints;

    private PlayerController localPlayerController;
    
    void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            localPlayerController =
                PhotonNetwork.Instantiate(NETWORK_PLAYER_PREFAB_NAME, 
                        spawnPoints[PhotonNetwork.LocalPlayer.ActorNumber - 1].position, 
                        spawnPoints[PhotonNetwork.LocalPlayer.ActorNumber - 1].rotation)
                    .GetComponent<PlayerController>();
        }
    }

}
