using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerManager : MonoBehaviourPun
{
    public static PlayerManager Instance;
    public int PlayerID;
    public bool IsGameMaster = false;
    public int SelectedPlayersCount=0;
    public int[] SelectedPlayers = new int[3];//maybe devide by two of max or value from outside
    public bool IsSelectedPlayer;
    [SerializeField] PlayerClass PlayerClass;//=casting or something

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        AssignClass();
    }

    public bool ChecksIFSelectedByGM() 
    {
        foreach (var player in OnlineGameManager.Instance.SelectedPlayers)
        {
            if(player== PlayerID)
                return true;
        }
        return false;
    }

    public void PlayerDataInisilize() 
    {
        PlayerID = OnlineGameManager.Instance.MyPlayerID;
        if (OnlineGameManager.Instance.CurrentGameMaster == PlayerID)
            IsGameMaster = true;
    }

    public void AssignClass()
    {

        bool assigned = false;
        while(!assigned)
        {
            int rand = Random.Range(0, 8);
            switch(rand)
            {
                case 0:
                    PlayerClass = new Bard();
                    break;
                case 1:
                    PlayerClass= new Barbarian();
                    break;
                case 2:
                    PlayerClass= new Wizard();
                    break;
                case 3:
                    PlayerClass= new Sorcerer();
                    break;
                case 4:
                    PlayerClass= new Rogue();
                    break;
                case 5:
                    PlayerClass= new Druid();
                    break;
                case 6:
                    PlayerClass= new Cleric();
                    break;
                case 7:
                    PlayerClass= new Monk();
                    break;

            }
            assigned = checkIfExists(assigned);

        }
        OnlineGameManager.Instance.photonView.RPC("UpdatePlayerClasses", RpcTarget.AllViaServer,PlayerClass);
    }

    private bool checkIfExists(bool assigned)
    {
        if(OnlineGameManager.Instance.PlayerClasses.Count > 0)
        {

            foreach (var c in OnlineGameManager.Instance.PlayerClasses)
            {
                if (PlayerClass == c)
                {
                    assigned = false; break;
                }
                assigned = true;
            }
        }
        else
        {
            assigned = true;
        }

        return assigned;
    }
}
