using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move 
{
    public UnityMove Base{get; set;}
    public int pp{get;set;}
    public Move(UnityMove pBase)
    {
        Base=pBase;
        pp = pBase.PP;
    }
}
