using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New aristocrat", menuName = "Aristocrat")]
public class AristocratObject : ScriptableObject
{
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
