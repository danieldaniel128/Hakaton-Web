using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject GameMasterScreenPanal;
    public GameObject AdventureScreenPanel;
    TextMeshProUGUI playerIdAndNickName;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void UpdatePlayerIdAndNickName(string str) 
    {
        playerIdAndNickName.text = str;
    }
    public void StartGame()
    {
        //DisableMainMenu();
        //Level1.SetActive(true);
    }


    public void ChangeTurn() 
    {
        OnlineGameManager.Instance.PhotonView.RPC("UpdateTurn", RpcTarget.AllViaServer);
        //ChangeCurrentGameMaster();
    }
    public void ChangeCurrentGameMaster()
    {
        OnlineGameManager.Instance.PhotonView.RPC("UpdateGameMaster", RpcTarget.AllViaServer);
    }




}
