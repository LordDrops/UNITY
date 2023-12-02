using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public ENUM_Tiers tier;
    public ENUM_Benefit benefit;

    public Sprite artwork;
    public int id;


    public int points;

    public int costBlack;
    public int costWhite;
    public int costRed;
    public int costBlue;
    public int costGreen;

    public void LoadCard(CardObject cardObject)
    {
        this.tier = cardObject.tier;
        this.benefit = cardObject.benefit;
        this.artwork = cardObject.artwork;
        this.id = cardObject.id;
        this.costBlack = cardObject.costBlack;
        this.costWhite = cardObject.costWhite;
        this.costRed = cardObject.costRed;
        this.costBlue = cardObject.costBlue;
        this.costGreen = cardObject.costGreen;
    }


}
