using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public List<Player> players;

    //void change Player()
    //Void CheckWin()
}

public enum GameStatus
{
    Pause,Menu,Game,ChangePlayer,End
}