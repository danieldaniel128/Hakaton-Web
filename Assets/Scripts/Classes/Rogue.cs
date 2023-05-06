using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : PlayerClass
{
    public override string abilityDescription { get; protected set; } = "Can disguise to appear as a different player";

    [ContextMenu("Disguise")]
    public void Ability()
    {
        UseAbility(targetPlayer);
    }

    public override void UseAbility(PlayerClass player)
    {
        isUsingAbility = true;
    }

    string Disguise;
    public void SetDisguise(string d)
    {
        Disguise = d;
        vote = new(Disguise, vote.vote);
    }
}
