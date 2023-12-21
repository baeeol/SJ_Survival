using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public static readonly EPlayerStatusEffect EPlayerStatusEffect;
}

public enum EPlayerStatusEffect {
    Normal = 0,
    Stagger = 1,
    Slow = 2,
};