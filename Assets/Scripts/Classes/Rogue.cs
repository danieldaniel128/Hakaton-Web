using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : PlayerClass
{
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
