using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleric : PlayerClass
{
    public override string abilityDescription { get; protected set; } = "Can negate an ability";

    [ContextMenu("Ability")]
    public void Ability()
    {
        UseAbility(targetPlayer);
    }
    public override void UseAbility(PlayerClass player)
    {
        isUsingAbility = true;

    }

}
