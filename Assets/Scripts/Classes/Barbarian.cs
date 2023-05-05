using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barbarian : PlayerClass
{
    public override void UseAbility(PlayerClass player)
    {
        throw new System.NotImplementedException();
    }

    public void Rage()
    {
        isTargetable = false;
    }
}
