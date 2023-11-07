using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName ="New Card",menuName ="Card")]
public class Card:ScriptableObject
{ 

    public ENUM_Tiers Tier;
    public ENUM_Benefit Benefit;

    public Sprite artwork;
    public int ID;


    public int Points;

    public int CostBlack;
    public int CostWhite;
    public int CostRed;
    public int CostBlue;
    public int CostGreen;
    
    //void draw Card()
}
