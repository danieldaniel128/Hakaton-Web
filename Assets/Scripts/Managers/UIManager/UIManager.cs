using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [Header("Screens")]
    public GameObject GameMasterScreenPanal;
    public GameObject AdventureScreenPanel;


    TextMeshProUGUI playerIdAndNickName;


    [Header("Accept Quest Buttons")]
    [SerializeField] Button Accept_BTN;
    [SerializeField] Button Refuse_BTN;

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


    public void AcceptQuest() 
    {
        OnlineGameManager.Instance.photonView.RPC("UpdateChoosedOptions", RpcTarget.AllViaServer,true);// ChoosedOptions.Add()
        Accept_BTN.interactable = false;
        Refuse_BTN.interactable = false;
    }
    public void RefuseQuest()
    {
        OnlineGameManager.Instance.photonView.RPC("UpdateChoosedOptions", RpcTarget.AllViaServer, false);// ChoosedOptions.Add()
        Accept_BTN.interactable = false;
        Refuse_BTN.interactable = false;
    }

}
