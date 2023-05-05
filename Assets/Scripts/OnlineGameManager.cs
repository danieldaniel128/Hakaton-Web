using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;

public class OnlineGameManager : MonoBehaviourPun
{
    public static OnlineGameManager Instance;

    public PhotonView PhotonView;

    public int MyPlayerID;

    public int CurrentTurn = 1;
    public int CurrentGameMaster = 1;

    public List<bool> ChoosedOptions;//attack or run



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
    }
    private void Update()//change later
    {
        if (CurrentGameMaster == MyPlayerID) 
        {
            UIManager.Instance.GameMasterScreenPanal.SetActive(true);
        }
        else
            UIManager.Instance.GameMasterScreenPanal.SetActive(false);
    }

    [PunRPC]
    public void UpdateTurn()
    {
        CurrentTurn++;
        //if (CurrentTurn % PhotonNetwork.CountOfPlayers == 0)
        //{
        //    CurrentGameMaster = PhotonNetwork.CountOfPlayers;
        //}
        //else
        //{
        //    CurrentGameMaster = CurrentTurn % PhotonNetwork.CountOfPlayers;
        //}
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
    }


}
