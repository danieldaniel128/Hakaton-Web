using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Bard : PlayerClass
{
    //Can control the vote of another party member
    //flips the vote or just chooses it?
    public bool charmTo { get; private set; }

    protected override void UseAbility(PlayerClass player)
    {

    }

    [ContextMenu("charm")]
    public void CharmYay()
    {
        charmTo = true;
    }

    public void CharmNay()
    {
        charmTo = false;
    }
}
