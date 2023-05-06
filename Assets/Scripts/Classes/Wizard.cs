using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : PlayerClass
{
    public override string abilityDescription { get; protected set; } = "Turns the vote anonymous";

    [ContextMenu("Ability")]
    public void Ability()
    {
        UseAbility(this);
    }
    public override void UseAbility(PlayerClass player)
    {
        isUsingAbility = true;

    }

}
