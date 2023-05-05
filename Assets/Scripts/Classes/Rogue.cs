using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : PlayerClass
{
    protected override void UseAbility(PlayerClass player)
    {
        throw new System.NotImplementedException();
    }

    string Disguise;
    public void SetDisguise(string d)
    {
        Disguise = d;
    }
}
