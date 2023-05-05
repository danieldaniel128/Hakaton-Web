using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerClass : MonoBehaviour
{
    int ID;
    bool isAbilityReady;
    public bool isImposter { get; protected set; }
    public bool isTargetable { get; protected set; } = true;
    public bool isUsingAbility { get; private set; }
    public Vote vote { get; protected set; }
    [SerializeField] public PlayerClass targetPlayer { get; protected set; }

    virtual protected void OpenAbilityMenu()
    {
        //open little ui window
    }

    abstract protected void UseAbility(PlayerClass player);

    [ContextMenu("voteyes")]
    public void SetVoteYay()
    {
        vote = new Vote(this, true);
    }

    [ContextMenu("voteno")]
    public void SetVoteNay()
    {
        vote = new Vote(this, false);
    }

    public void TargetPlayer(PlayerClass player)
    {
        targetPlayer = player;
    }

    //NEEDS TO RUN AFTER EVERY TURN
    public void ResetTargetability()
    {
        isTargetable = true;
    }

    public void CancelAbility()
    {
        isUsingAbility = false;
    }

    public void ReplenishAbility()
    {
        isAbilityReady = true;
    }
}
