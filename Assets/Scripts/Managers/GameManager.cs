using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : SingletonPUN<GameManager>
{
    //Scene
    [SerializeField] Transform objectSpawnLocation;

    //UI
    [SerializeField] GameObject NormieUI;
    [SerializeField] TextMeshProUGUI PlayerIDText;
    [SerializeField] GameObject GMUI;

    //Players
    bool[] playersJoinedRoom;
    List<Player> players= new List<Player>();

    int currentPlayerTurn;
    int playerID;

    private void Start()
    {
        if(playersJoinedRoom == null)
        {
            playersJoinedRoom = new bool[PhotonNetwork.PlayerList.Length];
        }

        playerID = PhotonNetwork.LocalPlayer.ActorNumber;
        PlayerIDText.text = "ID: " + playerID;
        playersJoinedRoom[playerID - 1] = true;
        print("playerslist length: " + PhotonNetwork.PlayerList.Length);
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
