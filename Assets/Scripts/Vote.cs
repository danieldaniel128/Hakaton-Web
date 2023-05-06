using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Vote
{
    public string player;
    public bool vote;
    //bool isUsingSkill;
    public Vote(PlayerClass p ,bool v)
    {
        player = p.GetType().ToString();
        vote = v;
    }
    public Vote(string p, bool v)
    {
        player = p;
        vote = v;
    }
}
