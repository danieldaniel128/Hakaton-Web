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
    bool voteIsAnonymous = false;


    [ContextMenu("bro")]
    void GetVotes()
    {
        foreach (var player in party)
        {
            if (player.isUsingAbility)
            {
                UseAbility(player);
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
        int votesYes = 0, votesNo = 0;
        foreach (var vote in votes)
        {
            if (vote.vote) votesYes++;
            else votesNo++;
        }
        Debug.Log(isMissionPassed);
        if (voteIsAnonymous)
        {
            Debug.Log($"{votesYes} yes, {votesNo} no");
            voteIsAnonymous = false;
        }
        else
        {
            foreach (var vote in votes)
            {
                Debug.Log(vote.player.GetType() + " " + vote.vote);
            }
        }
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
                voteIsAnonymous = true;
                break;
            default:
                break;
        }
    }

    private void Start()
    {

    }

}

