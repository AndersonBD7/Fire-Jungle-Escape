﻿using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

[CreateAssetMenu(fileName ="New Move",menuName ="Move")]
public class Move_Obj_Script : ScriptableObject
{

    [Header("Set Move")]
    [HideInInspector] public float Speed=5;
    public float Pos_End = 0;


    public bool End(float RealPos)
    {
        if (RealPos <= Pos_End)
        {
            return true;
        }
        return false;
    }

}
