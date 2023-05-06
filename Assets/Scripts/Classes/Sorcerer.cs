using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorcerer : PlayerClass
{
    public override string abilityDescription { get; protected set; } = "Can see if an ability was used";

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
