using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using UnityEngine;

public class OnlineGameManager : MonoBehaviourPun
{
    public static OnlineGameManager Instance;


    public int MyPlayerID;

    public int CurrentTurn = 1;
    public int CurrentGameMaster = 1;

    public List<bool> ChoosedOptions;//attack or run

    public int[] SelectedPlayers;
    bool PatricipateInMission;

    public List<PlayerClass> PlayerClasses = new();
    public PlayerClass newPlayerClass;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        MyPlayerID = PhotonNetwork.LocalPlayer.ActorNumber;
        PlayerManager.Instance.PlayerDataInisilize();
    }

    [PunRPC]
    public void UpdatePlayerClasses()
    {
        PlayerClasses.Add(newPlayerClass);
    }

    [PunRPC]
    public void UpdateSelectedPlayers(int[] selectedPlayers) 
    {
        SelectedPlayers = selectedPlayers;
    }

    [PunRPC]
    public void UpdateTurn()
    {
        CurrentTurn++;
    }
    [PunRPC]
    public void UpdateGameMaster() 
    {
        CurrentGameMaster++;
        if (CurrentGameMaster == PhotonNetwork.CountOfPlayers + 1)
            CurrentGameMaster = 1;
    }


    [PunRPC]
    public void UpdateChoosedOptions(bool choosedOptions) 
    {
        ChoosedOptions.Add(choosedOptions);
        if (ChoosedOptions.Count == PhotonNetwork.CountOfPlayers)
            ChecksIfParticipatingInMission();
    }

    void ChecksIfParticipatingInMission() 
    {
        if(ChoosedOptions.Count(c=>!c) < PhotonNetwork.CountOfPlayers/2)
            PatricipateInMission = true;
    }
    

    public string[] GetListOfActivePlayers() 
    {
        string[] playerNames = new string[PhotonNetwork.CountOfPlayers];
        for (int i = 0; i < PhotonNetwork.CountOfPlayers; i++)
        {
            playerNames[i] = PhotonNetwork.PlayerList[i].NickName;
        }
        return playerNames;
    }
    public int GetCountOfPlayers() 
    {
        return PhotonNetwork.CountOfPlayers;
    }


    //UI

    [PunRPC]
    public void YesAndNOAdventurer() 
    {
        if(!PlayerManager.Instance.ChecksIFSelectedByGM())
            UIAdventurerScreenManager.Instance.ActivateYesOrNoChooseAdventurer();   
    }




}
