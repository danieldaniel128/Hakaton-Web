using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField] TMP_FontAsset fontAsset;

    [Header("Accept Quest Buttons")]
    [SerializeField] Button Accept_BTN;
    [SerializeField] Button Refuse_BTN;

    [SerializeField] Button GoNextTurn;

    [Header("Game Master Choose Player Buttons")]
    [SerializeField] List<Button> ChoosePlayersButtons;
    [SerializeField] List<RectTransform> ChoosePlayerButtonLocations;
    [SerializeField] Sprite ImageSpriteBtn;
    [SerializeField] RectTransform selectorTransform;
    [SerializeField] GameObject ButtonPrefab;

    [SerializeField] Vector2 startGenerateButtonPosition;
    

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        LoadScreenAndButton();
    }
    private void Update()
    {
        LoadScreen();
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
        Accept_BTN.interactable = true;
        Refuse_BTN.interactable = true;
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

    void LoadScreenAndButton() 
    {
        for (int i = 0; i < OnlineGameManager.Instance.GetCountOfPlayers(); i++)
        {
            GameObject newButtonGameObject = Instantiate(ButtonPrefab, selectorTransform);
            newButtonGameObject.name = "PlayerButton" + (i + 1);
            newButtonGameObject.transform.SetParent(ChoosePlayerButtonLocations[i], false);
            Button button = newButtonGameObject.GetComponent<Button>();
            //RectTransform rectTransformBtn = newButtonGameObject.GetComponent<RectTransform>();
            TextMeshProUGUI playerName = newButtonGameObject.GetComponentInChildren<TextMeshProUGUI>();
            playerName.text = OnlineGameManager.Instance.GetListOfActivePlayers()[i];
            button.onClick.AddListener(delegate { SendIdToManager(playerName.text); });
            ChoosePlayersButtons.Add(button);

            //newButtonGameObject.transform.parent = GameMasterScreenPanal.transform;
        }

        if (OnlineGameManager.Instance.CurrentGameMaster == OnlineGameManager.Instance.MyPlayerID)
        {
            ActivateGMScreen();
            selectorTransform.gameObject.SetActive(true);
        }
        else
        {
            ActivateAdventureScreen();
            selectorTransform.gameObject.SetActive(false);
        }
    }

    public void SendIdToManager(string selectPlayerName) 
    {
        string[] playerNames = OnlineGameManager.Instance.GetListOfActivePlayers();
        Debug.Log("selectPlayerButton: " + selectPlayerName);
        for (int i = 0; i < OnlineGameManager.Instance.GetCountOfPlayers(); i++)
        {
            if (playerNames[i].Equals(selectPlayerName))
            { 
                PlayerManager.Instance.SelectedPlayers[PlayerManager.Instance.SelectedPlayersCount++] = i + 1;
                break;
            }
        }
        if(PlayerManager.Instance.SelectedPlayers.Length== PlayerManager.Instance.SelectedPlayersCount)
            foreach (Button button in ChoosePlayersButtons)
            {
                button.interactable = false;
            }

    }

    void LoadScreen()
    {
        if (OnlineGameManager.Instance.CurrentGameMaster == OnlineGameManager.Instance.MyPlayerID)
        {
            ActivateGMScreen();
            selectorTransform.gameObject.SetActive(true);
        }
        else
        {
            ActivateAdventureScreen();
        }
    }
}
