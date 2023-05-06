using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barbarian : PlayerClass
{
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
