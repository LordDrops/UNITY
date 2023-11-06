using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName ="New Card",menuName ="Card")]
public class Card:ScriptableObject
{ 

    public ENUM_Tiers Tier;

    public Sprite artwork;
    public int ID;
    public int Points;

    public int CostBlack;
    public int CostWhite;
    public int CostRed;
    public int CostBlue;
    public int CostGreen;

    public int BenefitBlack;
    public int BenefitWhite;
    public int BenefitRed;
    public int BenefitBlue;
    public int BenefitGreen;

    public Card (int id,ENUM_Tiers tier, int points, int CostBLACK, int CostWHITE, int CostRED, int CostBLUE, int CostGREEN, int BenefitBLACK, int BenefitWHITE, int BenefitRED, int BenefitBLUE, int BenefitGREEN,Sprite spriteimage)
    {   
        ID = id;
        Tier = tier;
        Points = points;
        CostBlack = CostBLACK;
        CostWhite = CostWHITE;
        CostRed = CostRED;
        CostBlue = CostBLUE;
        CostGreen = CostGREEN;

        BenefitBlack = BenefitBLACK;
        BenefitWhite = BenefitWHITE;
        BenefitRed = BenefitRED;
        BenefitBlue = BenefitBLUE;
        BenefitGreen = BenefitGREEN;

        Sprite sprite = spriteimage;
    }



}
