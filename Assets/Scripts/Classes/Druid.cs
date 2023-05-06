using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Druid : PlayerClass
{
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
