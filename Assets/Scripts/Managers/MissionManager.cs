using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//instantiate this and assign classes
public class MissionManager : MonoBehaviour
{
    const string BARD = "Bard";
    const string BARBARIAN = "Barbarian";
    const string CLERIC = "Cleric";
    const string DRUID = "Druid";
    const string MONK = "Monk";
    const string ROGUE = "Rogue";
    const string SORCERER = "Sorcerer";
    const string WIZARD = "Wizard";

    [SerializeField] List<PlayerClass> party = new List<PlayerClass>();
    List<Vote> votes = new List<Vote>();
    bool isMissionPassed;


    [ContextMenu("bro")]
    void GetVotes()
    {
        foreach (var player in party)
        {
            if (player.isUsingAbility)
            {

            }
        }

        foreach (var player in party)
        {
            votes.Add(player.vote);
        }
        CountVotes();
    }

    void CountVotes()
    {
        if (votes[0].vote && votes[1].vote && votes[2].vote)
        {
            isMissionPassed = true;
        }
        else isMissionPassed = false;

        Debug.Log(isMissionPassed);
    }

    public void AssisgnParty()
    {
        //assign classes into party
    }

    void UseAbility(PlayerClass pClass)
    {
        switch (pClass.GetType().ToString())
        {
            case BARD:
                var bard = pClass as Bard;
                if (bard.targetPlayer.isTargetable)
                {
                    if (bard.charmTo)
                        bard.targetPlayer.SetVoteYay();
                    else bard.targetPlayer.SetVoteNay();
                }
                break;
            case CLERIC:
                if (pClass.targetPlayer.isTargetable)
                {
                    pClass.targetPlayer.CancelAbility();
                }
                break;
            case DRUID:
                if (pClass.targetPlayer.isTargetable)
                {
                    pClass.targetPlayer.ReplenishAbility();
                }
                break;
            case MONK:
                //just works when plays GM
                break;
            case ROGUE:
                var rogue = pClass as Rogue;
                rogue.SetDisguise(rogue.targetPlayer.GetType().ToString());
                break;
            case SORCERER:

                break;
            case WIZARD:

                break;
            default:
                break;
        }
    }

    private void Start()
    {

    }

}

