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


    void YesOrNoChooseAdventurer() 
    {
        _yesAndNoButtons.SetActive(true);


    }





}
