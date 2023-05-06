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


    [SerializeField] Vector2 startGenerateButtonPosition;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        LoadScreenAndButton();
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
        ChangeCurrentGameMaster();
    }
    public void ChangeCurrentGameMaster()
    {
        OnlineGameManager.Instance.photonView.RPC("UpdateGameMaster", RpcTarget.AllViaServer);
        LoadScreen();
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
            GameObject newButtonGameObject = new GameObject("PlayerButton" + (i + 1));
            newButtonGameObject.transform.SetParent(ChoosePlayerButtonLocations[i], false);
            Image image = newButtonGameObject.AddComponent<Image>();
            image.sprite = ImageSpriteBtn;
            Button button = newButtonGameObject.AddComponent<Button>();
            RectTransform rectTransformBtn = newButtonGameObject.GetComponent<RectTransform>();
            GameObject TextPlayer = new GameObject();
            TextPlayer.transform.SetParent(rectTransformBtn, false);
            TextMeshProUGUI playerName = TextPlayer.AddComponent<TextMeshProUGUI>();
            playerName.font = fontAsset;
            playerName.text = OnlineGameManager.Instance.GetListOfActivePlayers()[i];
            playerName.enableAutoSizing = true;
            playerName.autoSizeTextContainer=true;
            playerName.color= Color.black;
            ChoosePlayersButtons.Add(button);
            rectTransformBtn.anchoredPosition = rectTransformBtn.anchoredPosition;

            //newButtonGameObject.transform.parent = GameMasterScreenPanal.transform;
        }

        if (OnlineGameManager.Instance.CurrentGameMaster == OnlineGameManager.Instance.MyPlayerID)
        {
            ActivateGMScreen();
        }
        else
        {
            ActivateAdventureScreen();
            selectorTransform.gameObject.SetActive(false);
        }
    }

    void LoadScreen()
    {
        if (OnlineGameManager.Instance.CurrentGameMaster == OnlineGameManager.Instance.MyPlayerID)
        {
            ActivateGMScreen();
        }
        else
        {
            ActivateAdventureScreen();
        }
    }
}
