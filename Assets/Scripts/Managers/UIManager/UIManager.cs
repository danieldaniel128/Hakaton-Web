using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] GameObject GameMasterScreenPanal;
    [SerializeField] GameObject AdventureScreenPanel;
   

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void StartGame()
    {
        //DisableMainMenu();
        //Level1.SetActive(true);
    }


    public void ChangeTurn() 
    {
        OnlineGameManager.Instance.PhotonView.RPC("UpdateTurn", RpcTarget.AllViaServer);
        ChangeCurrentGameMaster();
    }
    private void ChangeCurrentGameMaster()
    {
        OnlineGameManager.Instance.PhotonView.RPC("UpdateCurrentGameMaster", RpcTarget.AllViaServer);
    }




}
