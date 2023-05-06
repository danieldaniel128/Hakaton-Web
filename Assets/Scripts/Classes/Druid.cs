using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Druid : PlayerClass
{
    public override string abilityDescription { get; protected set; } = "Can replenish a party member's ability when GMing";

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
