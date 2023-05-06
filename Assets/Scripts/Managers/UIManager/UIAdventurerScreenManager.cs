using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIAdventurerScreenManager : MonoBehaviour
{
    public static UIAdventurerScreenManager Instance;


    [SerializeField] GameObject _yesAndNoButtons;
    [SerializeField] GameObject _passOrFailButtons;
    [SerializeField] List<TextMeshProUGUI> _selectedPlayersNames_TMP;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        _yesAndNoButtons.SetActive(false);
        _passOrFailButtons.SetActive(false);
    }


    public void ActivateYesOrNoChooseAdventurer()
    {
        _yesAndNoButtons.SetActive(true);


    }
    public void DisableYesOrNoChooseAdventurer()
    {
        _yesAndNoButtons.SetActive(false);
    }

    public void SetTextOfSelectedPlayers() 
    {
        foreach (TextMeshProUGUI item in _selectedPlayersNames_TMP)
        {
            string[] playerNames= OnlineGameManager.Instance.GetListOfActivePlayers();
            for (int i = 0; i < OnlineGameManager.Instance.SelectedPlayers.Length; i++)
            {
                item.text = playerNames[OnlineGameManager.Instance.SelectedPlayers[i]];
            }
        }
    }




}
