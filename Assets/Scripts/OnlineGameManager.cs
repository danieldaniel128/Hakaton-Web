using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class OnlineGameManager : MonoBehaviourPun
{
    public const string NETWORK_PLAYER_PREFAB_NAME = "NetworkPlayerObject";
    public static OnlineGameManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
    }

}
