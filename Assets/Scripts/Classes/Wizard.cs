using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : PlayerClass
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

}
