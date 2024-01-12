using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public List<Player> players = new List<Player>();
    public Player currentPlayer;

    public int blackTokens = 7;
    public int redTokens = 7;
    public int greenTokens = 7;
    public int blueTokens = 7;
    public int whiteTokens = 7;
    public int goldTokens = 5;

    private void CreatePlayers(int playersNumber)
    {
        for(int i = 0; i < playersNumber; i++)
        {
            Player player = new Player();
            players.Add(player);
        }
    }

    private void ChangePlayer()
    {
        int currentPlayerIndex = players.IndexOf(currentPlayer);
        if (currentPlayerIndex + 1 == players.Count)
        {
            currentPlayer = players[0];
        }
        else
        {
            currentPlayer = players[currentPlayerIndex + 1];
        }
    }
}
