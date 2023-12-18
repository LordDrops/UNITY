using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName ="New Card",menuName ="Card")]
public class CardObject : ScriptableObject
{ 
    public int id;

    public int tier;
    public ENUM_Benefit benefit;

    public Sprite artwork;
    public Sprite tokenSprite;

    public int points;

    public int costBlack;
    public int costWhite;
    public int costRed;
    public int costBlue;
    public int costGreen;
    
    //void draw Card()
}
