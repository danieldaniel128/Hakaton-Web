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

    [SerializeField] Button GoNextTurn;

    [Header("Game Master Choose Player Buttons")]
    List<Button> ChoosePlayersButtons;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        if (OnlineGameManager.Instance.CurrentGameMaster == OnlineGameManager.Instance.MyPlayerID)
        {
            GameMasterScreenPanal.SetActive(true);
            for (int i = 0; i < OnlineGameManager.Instance.GetCountOfPlayers(); i++)
            {
                GameObject newButtonGameObject = new GameObject();
                Button button = newButtonGameObject.AddComponent<Button>();
                RectTransform rectTransformBtn = newButtonGameObject.GetComponent<RectTransform>();
                ChoosePlayersButtons.Add(button);
                newButtonGameObject.transform.parent = GameMasterScreenPanal.transform;
                //rectTransformBtn=
            }
        }
        else
            AdventureScreenPanel.SetActive(true);
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
        OnlineGameManager.Instance.photonView.RPC("UpdateTurn", RpcTarget.AllViaServer);
        //ChangeCurrentGameMaster();
    }
    public void ChangeCurrentGameMaster()
    {
        OnlineGameManager.Instance.photonView.RPC("UpdateGameMaster", RpcTarget.AllViaServer);
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


    public void ActivateGMScreen() 
    {
        GameMasterScreenPanal.SetActive(true);
        AdventureScreenPanel.SetActive(false);
    }

    public void ActivateAdventureScreen()
    {
        GameMasterScreenPanal.SetActive(false);
        AdventureScreenPanel.SetActive(true);
    }


}
