using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    //Gracze
    public List<Player> players=new List<Player>();
    //Tokeny
    public int BlackTokens,WhiteTokens,RedTokens,BlueTokens,GreenTokens;

    //Talie Kart
    public List<CardObject> TierI = new List<CardObject>();
    public List<CardObject> TierII = new List<CardObject>();
    public List<CardObject>  TierIII = new List<CardObject>();

    //Talie Arystokrat�w 
    public List<AristocratObject> PulaArystokratow = new List<AristocratObject>();

    //void change Player()
    //Void CheckWin()
    //linser dobrania karty 

    //public int GetCard()


}

public enum GameStatus
{
    Pause,Menu,Game,ChangePlayer,End
}