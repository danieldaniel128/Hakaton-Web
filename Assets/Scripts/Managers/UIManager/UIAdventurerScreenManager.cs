using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAdventurerScreenManager : MonoBehaviour
{
    [SerializeField] GameObject _yesAndNoButtons;
    private void Start()
    {
        _yesAndNoButtons.SetActive(false);
    }


    void YesOrNoChooseAdventurer() 
    {
        _yesAndNoButtons.SetActive(true);


    }

}
