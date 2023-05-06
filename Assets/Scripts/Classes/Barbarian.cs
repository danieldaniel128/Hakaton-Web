using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barbarian : PlayerClass
{
    public override string abilityDescription { get; protected set; } = "Gain immunity to abilities";

    [ContextMenu("Ability")]
    public void Ability()
    {
        UseAbility(this);
    }
    public override void UseAbility(PlayerClass player)
    {
        isUsingAbility = true;
    }

    public void Rage()
    {
        isTargetable = false;
    }
}
