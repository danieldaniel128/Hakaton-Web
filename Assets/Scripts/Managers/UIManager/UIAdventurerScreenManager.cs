using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAdventurerScreenManager : MonoBehaviour
{
    public static UIAdventurerScreenManager Instance;


    [SerializeField] GameObject _yesAndNoButtons;
    [SerializeField] GameObject _passOrFailButtons;

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





}
