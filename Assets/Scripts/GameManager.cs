using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Player> players = new List<Player>();
    public Player currentPlayer;

    private TableSetup tableSetup;

    public int blackTokens = 7;
    public int redTokens = 7;
    public int greenTokens = 7;
    public int blueTokens = 7;
    public int whiteTokens = 7;
    public int goldTokens = 5;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        tableSetup = GetComponent<TableSetup>();
    }

    IEnumerator WaitForSceneLoad()
    {
        while (SceneManager.GetActiveScene().buildIndex != 1)
        {
            yield return null;
        }

        // Do anything after proper scene has been loaded
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            tableSetup.enabled = true;
            currentPlayer = GameObject.Find("Player").GetComponent<Player>();
        }
    }

    public void CreateGame(int playersAmount)
    {
        CreatePlayers(playersAmount);

        SceneManager.LoadScene(1);

        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            StartCoroutine("WaitForSceneLoad");
        }

    }

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

    public void BuyCard(Card card)
    {
        if(card.GetCardObject().tier != 4)
        {
            blackTokens += currentPlayer.GetTokensToReturn(currentPlayer.blackTokenPermanent, currentPlayer.blackToken, card.costBlack);
            redTokens += currentPlayer.GetTokensToReturn(currentPlayer.redTokenPermanent, currentPlayer.redToken, card.costRed);
            greenTokens += currentPlayer.GetTokensToReturn(currentPlayer.greenTokenPermanent, currentPlayer.greenToken, card.costGreen);
            blueTokens += currentPlayer.GetTokensToReturn(currentPlayer.blueTokenPermanent, currentPlayer.blueToken, card.costBlue);
            whiteTokens += currentPlayer.GetTokensToReturn(currentPlayer.whiteTokenPermanent, currentPlayer.whiteToken, card.costWhite);

            goldTokens += currentPlayer.GetGoldTokensToReturn(card);
        }
        currentPlayer.BuyCard(card);
    }

    public void TakeToken(string token)
    {
        if (!currentPlayer.CanTakeToken()) return;

        currentPlayer.TakeToken(token);

        switch (token)
        {
            case "Black":
                blackTokens--;
                break;
            case "White":
                whiteTokens--;
                break;
            case "Red":
                redTokens--;
                
                break;
            case "Blue":
                blueTokens--;
                
                break;
            case "Green":
                greenTokens--;
                
                break;
            case "Gold":
                goldTokens--;
                break;
        }
    }
}
