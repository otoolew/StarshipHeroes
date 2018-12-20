using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchException : BaseException
{
    public readonly Starship attacker;
    public readonly Starship target;

    public MatchException(Starship attacker, Starship target) : base(false)
    {
        this.attacker = attacker;
        this.target = target;
    }
}
