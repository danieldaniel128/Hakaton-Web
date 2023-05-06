using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monk : PlayerClass
{
    public override string abilityDescription { get; protected set; } = "Can see if the imposter was in the party";

    public override void UseAbility(PlayerClass player)
    {
        throw new System.NotImplementedException();
    }

}
