using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Vote
{
    PlayerClass player;
    public bool vote;
    //bool isUsingSkill;
    public Vote(PlayerClass p ,bool v)
    {
        player = p;
        vote = v;
    }
}
