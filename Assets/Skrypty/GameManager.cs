using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Gracze
    public List<Player> players=new List<Player>();
    //Tokeny
    public int BlackTokens,WhiteTokens,RedTokens,BlueTokens,GreenTokens;

    //Talie Kart
    public List<Card> TierI = new List<Card>();
    public List<Card> TierII = new List<Card>();
    public List<Card>  TierIII = new List<Card>();

    //Talie Arystokratów 
    public List<Arystokrata> PulaArystokratow = new List<Arystokrata>();



    //void change Player()
    //Void CheckWin()
    //linser dobrania karty 

    //public int GetCard()

    
}


public enum GameStatus
{
    Pause,Menu,Game,ChangePlayer,End
}