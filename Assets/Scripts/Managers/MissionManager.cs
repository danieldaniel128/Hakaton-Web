using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//instantiate this and assign classes
public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    const string BARBARIAN = "Barbarian";
    const string BARD = "Bard";
    const string CLERIC = "Cleric";
    const string DRUID = "Druid";
    const string MONK = "Monk";
    const string ROGUE = "Rogue";
    const string SORCERER = "Sorcerer";
    const string WIZARD = "Wizard";

    [SerializeField] List<PlayerClass> party = new List<PlayerClass>();
    List<PlayerClass> abilitiesActivatedList = new List<PlayerClass>();
    List<Vote> votes = new List<Vote>();
    bool isMissionPassed;
    bool voteIsAnonymous = false;

    readonly List<string> classes = new List<string>
    {
        BARBARIAN,
        CLERIC,
        BARD,
        MONK,
        ROGUE,
        WIZARD,
        SORCERER,
        DRUID
    };

    [ContextMenu("bro")]
    public void GetVotes()
    {
        foreach (var player in party)
        {
            if (player.isUsingAbility)
            {
                abilitiesActivatedList.Add(player);
            }
        }
        PlayAbilities();

        foreach (var player in party)
        {
            votes.Add(player.vote);
        }
        CountVotes();
    }

    public void PlayAbilities()
    {
        foreach (var item in classes)
        {
            Debug.Log("checking " + item);
            foreach (var pClass in abilitiesActivatedList)
            {
                if (pClass.GetType().ToString() == item && pClass.isUsingAbility)
                {
                    switch (item)
                    {
                        case BARBARIAN:
                            var barbarian = pClass as Barbarian;
                            barbarian.Rage();
                            break;

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
                            if (abilitiesActivatedList.Count > 1) Debug.Log("an ability was used");
                            else Debug.Log("no abilities were used");
                            break;

                        case WIZARD:
                            voteIsAnonymous = true;
                            break;

                        default:
                            break;
                    }
                }

            }
        }
    }

    public void CountVotes()
    {
        int votesYes = 0, votesNo = 0;
        foreach (var vote in votes)
        {
            if (vote.vote) votesYes++;
            else votesNo++;
        }
        if (voteIsAnonymous)
        {
            Debug.Log($"{votesYes} yes, {votesNo} no");
            voteIsAnonymous = false;
        }
        else
        {
            foreach (var vote in votes)
            {
                Debug.Log(vote.player + " " + vote.vote);
            }
        }
        //count votes and show success/failure
    }

    public void AssisgnParty()
    {
        //assign classes into party
    }

}

