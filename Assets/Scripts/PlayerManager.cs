using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerManager : MonoBehaviourPun
{
    public static PlayerManager Instance;
    public int PlayerID;
    public bool IsGameMaster = false;
    public int SelectedPlayersCount=0;
    public int[] SelectedPlayers = new int[1];//maybe devide by two of max or value from outside
    public bool IsSelectedPlayer;
    PlayerClass PlayerClass;//=casting or something

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
   
    public bool ChecksIFSelectedByGM() 
    {
        foreach (var player in OnlineGameManager.Instance.SelectedPlayers)
        {
            if(player== PlayerID)
                return true;
        }
        return false;
    }

    public void PlayerDataInisilize() 
    {
        PlayerID = OnlineGameManager.Instance.MyPlayerID;
        if (OnlineGameManager.Instance.CurrentGameMaster == PlayerID)
            IsGameMaster = true;
    }
}
