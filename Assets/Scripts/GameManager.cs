using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<PlayerStats> players = new List<PlayerStats>();

    public Player currentPlayer;

    private TableUI tableUI;

    private TableSetup tableSetup;

    public int blackTokens = 7;
    public int redTokens = 7;
    public int greenTokens = 7;
    public int blueTokens = 7;
    public int whiteTokens = 7;
    public int goldTokens = 5;

    private List<GameObject> blackTokensTable = new List<GameObject>();
    private List<GameObject> redTokensTable = new List<GameObject>();
    private List<GameObject> greenTokensTable = new List<GameObject>();
    private List<GameObject> blueTokensTable = new List<GameObject>();
    private List<GameObject> whiteTokensTable = new List<GameObject>();
    private List<GameObject> goldTokensTable = new List<GameObject>();

    public bool isOverUI = false;

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
            tableUI = GameObject.Find("UI").GetComponent<TableUI>();
            currentPlayer = GameObject.Find("Player").GetComponent<Player>();
            tableUI.RenderPlayerScore(players.Count);
            currentPlayer.StartTurn(players[0]);

            blackTokensTable.AddRange(GameObject.FindGameObjectsWithTag("Black"));
            redTokensTable.AddRange(GameObject.FindGameObjectsWithTag("Red"));
            greenTokensTable.AddRange(GameObject.FindGameObjectsWithTag("Green"));
            blueTokensTable.AddRange(GameObject.FindGameObjectsWithTag("Blue"));
            whiteTokensTable.AddRange(GameObject.FindGameObjectsWithTag("White"));
            goldTokensTable.AddRange(GameObject.FindGameObjectsWithTag("Gold"));
        }
    }

    public List<PlayerStats> GetPlayers()
    {
        return players;
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
            PlayerStats player = new PlayerStats();
            player.playerId = i;
            players.Add(player);
        }
    }

    public bool CanTakeToken(string token)
    {
        switch (token)
        {
            case "Black":
                if(blackTokens > 0)
                {
                    return true;
                }
                break;
            case "White":
                if (whiteTokens > 0)
                {
                    return true;
                }
                break;
            case "Red":
                if (redTokens > 0)
                {
                    return true;
                }
                break;
            case "Blue":
                if (blueTokens > 0)
                {
                    return true;
                }
                break;
            case "Green":
                if (greenTokens > 0)
                {
                    return true;
                }
                break;
            case "Gold":
                if (goldTokens > 0)
                {
                    return true;
                }
                break;
        }

        return false;
    }

    private void SavePlayerStats()
    {
        int id = currentPlayer.playerId;

        players[id].points = currentPlayer.points;

        players[id].playerDeck = currentPlayer.playerDeck;

        players[id].lockedCards = currentPlayer.lockedCards;

        players[id].blackToken = currentPlayer.blackToken;
        players[id].whiteToken = currentPlayer.whiteToken;
        players[id].redToken = currentPlayer.redToken;
        players[id].blueToken = currentPlayer.blueToken;
        players[id].greenToken = currentPlayer.greenToken;
        players[id].goldToken = currentPlayer.goldToken;

        players[id].blackTokenPermanent = currentPlayer.blackTokenPermanent;
        players[id].whiteTokenPermanent = currentPlayer.whiteTokenPermanent;
        players[id].redTokenPermanent = currentPlayer.redTokenPermanent;
        players[id].blueTokenPermanent = currentPlayer.blueTokenPermanent;
        players[id].greenTokenPermanent = currentPlayer.greenTokenPermanent;
    }

    private void LoadPlayerStats(PlayerStats playerStats)
    {
        currentPlayer.points = playerStats.points;

        currentPlayer.playerDeck = playerStats.playerDeck;

        currentPlayer.lockedCards = playerStats.lockedCards;

        currentPlayer.blackToken = playerStats.blackToken;
        currentPlayer.whiteToken = playerStats.whiteToken;
        currentPlayer.redToken = playerStats.redToken;
        currentPlayer.blackToken = playerStats.blueToken;
        currentPlayer.greenToken = playerStats.greenToken;
        currentPlayer.goldToken = playerStats.goldToken;

        currentPlayer.blackTokenPermanent = playerStats.blackTokenPermanent;
        currentPlayer.whiteTokenPermanent = playerStats.whiteTokenPermanent;
        currentPlayer.redTokenPermanent = playerStats.redTokenPermanent;
        currentPlayer.blueTokenPermanent = playerStats.blueTokenPermanent;
        currentPlayer.greenTokenPermanent = playerStats.greenTokenPermanent;

        currentPlayer.moves = 3;
    }

    private void GameOver()
    {
        Debug.Log("Player " + currentPlayer.playerId + " has won!");
        tableUI.GameOver(currentPlayer.playerId);
    }

    public void ChangePlayer()
    {
        SavePlayerStats();

        if (currentPlayer.points >= 15)
        {
            GameOver();
            return;
        }

        int currentPlayerIndex = currentPlayer.playerId;
        int nextPlayerIndex;
        if (currentPlayerIndex + 1 == players.Count)
        {
            nextPlayerIndex = 0;
        }
        else
        {
            nextPlayerIndex = currentPlayerIndex + 1;
        }

        tableUI.EndTurn(nextPlayerIndex + 1);
        currentPlayer.StartTurn(players[nextPlayerIndex]);
        Debug.Log("Now playing - player" + nextPlayerIndex);

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

    private void RenderTokens(List<GameObject> tokens, int amount)
    {
        if(amount >= 6)
        {
            foreach(var token in tokens)
            {
                token.SetActive(true);
            }
        } 
        else if (amount >= 4)
        {

            foreach (var token in tokens)
            {
                token.SetActive(false);
            }
            for (int i = 0; i < 3; i++)
            {
                tokens[i].SetActive(true);
            }
        }
        else if (amount >= 2)
        {

            foreach (var token in tokens)
            {
                token.SetActive(false);
            }
            for (int i = 0; i < 2; i++)
            {
                tokens[i].SetActive(true);
            }
        }
        else if (amount == 1)
        {
            foreach (var token in tokens)
            {
                token.SetActive(false);
            }
            
            tokens[0].SetActive(true);
        }
        else
        {
            foreach (var token in tokens)
            {
                token.SetActive(false);
            }
        }
    }

    public void TakeToken(string token)
    {
        if (!currentPlayer.CanTakeToken() || !CanTakeToken(token)) return;

        currentPlayer.TakeToken(token);

        switch (token)
        {
            case "Black":
                blackTokens--;
                RenderTokens(blackTokensTable, blackTokens);
                break;
            case "White":
                whiteTokens--;
                RenderTokens(whiteTokensTable, whiteTokens);
                break;
            case "Red":
                redTokens--;
                RenderTokens(redTokensTable, redTokens);
                break;
            case "Blue":
                blueTokens--;
                RenderTokens(blueTokensTable, blueTokens);
                break;
            case "Green":
                greenTokens--;
                RenderTokens(greenTokensTable, greenTokens);
                break;
            case "Gold":
                goldTokens--;
                RenderTokens(goldTokensTable, goldTokens);
                break;
        }
    }
}

public class PlayerStats
{
    public int playerId;

    public int points = 0;

    public List<CardObject> playerDeck = new List<CardObject>();

    public List<CardObject> lockedCards = new List<CardObject>();

    public int blackToken = 0;
    public int whiteToken = 0;
    public int redToken = 0;
    public int blueToken = 0;
    public int greenToken = 0;
    public int goldToken = 0;

    public int blackTokenPermanent = 0;
    public int whiteTokenPermanent = 0;
    public int redTokenPermanent = 0;
    public int blueTokenPermanent = 0;
    public int greenTokenPermanent = 0;

    public int moves;
}