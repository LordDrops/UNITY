using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite blackTokenSprite;
    public Sprite redTokenSprite;
    public Sprite greenTokenSprite;
    public Sprite blueTokenSprite;
    public Sprite whiteTokenSprite;
    public Sprite goldTokenSprite;

    public int points;

    [SerializeField]
    private List<CardObject> playerDeck = new List<CardObject>();

    [SerializeField]
    private List<CardObject> lockedCards = new List<CardObject>();

    public int blackToken;
    public int whiteToken;
    public int redToken;
    public int blueToken;
    public int greenToken;
    public int goldToken;

    public int blackTokenPermanent;
    public int whiteTokenPermanent;
    public int redTokenPermanent;
    public int blueTokenPermanent;
    public int greenTokenPermanent;

    public int moves = 3;

    public bool returning = false;

    public GameObject tokenPrefab;
    public GameObject cardPrefab;
    public GameObject lockedCardPrefab;

    private float cardY = -6.75f;
    private float cardX = -4.45f;

    public void StartTurn(Player player)
    {
        playerDeck = player.playerDeck;
        lockedCards = player.lockedCards;

        blackToken = player.blackToken;
        whiteToken = player.whiteToken;
        redToken = player.redToken;
        blueToken = player.blueToken;
        greenToken = player.greenToken;
        goldToken = player.goldToken;

        blackTokenPermanent = player.blackTokenPermanent;
        whiteTokenPermanent = player.whiteTokenPermanent;
        redTokenPermanent = player.redTokenPermanent;
        blueTokenPermanent = player.blueTokenPermanent;
        greenTokenPermanent = player.greenTokenPermanent;


        moves = 3;
        RenderPlayerDeck();
        RenderPlayerTokens();
        RenderLockedCards();
    }

    private void HasTooManyTokens()
    {
        returning = blackToken + redToken + greenToken + blackToken + whiteToken + goldToken > 10;
    }

    public void EndTurn()
    {
        while (returning)
        {
            Debug.Log("Return tokens");
        }
    }

    public void ReturnToken(string token)
    {
        switch (token)
        {
            case "Black":
                blackToken--;
                break;
            case "White":
                whiteToken--;
                break;
            case "Red":
                redToken--;
                break;
            case "Blue":
                blueToken--;
                break;
            case "Green":
                greenToken++;
                break;
            case "Gold":
                goldToken--;
                break;
        }

        RenderPlayerTokens();

        HasTooManyTokens();
    }


    public bool CanBuyOrLockCard()
    {
        return moves >= 3;
    }
    
    public bool CanTakeToken()
    {
        return moves >= 1 ? true : false;
    }

    public bool HasEnoughTokens(Card card)
    {
        if (blackToken + blackTokenPermanent >= card.costBlack && redToken + redTokenPermanent >= card.costRed && blueToken + blueTokenPermanent >= card.costBlue && greenToken + greenTokenPermanent >= card.costGreen && whiteToken + whiteTokenPermanent >= card.costWhite) return true;

        int deficit = 0;

        if (card.costBlack > 0 && blackToken + blackTokenPermanent < card.costBlack)
        {
            deficit += card.costBlack - (blackToken + blackTokenPermanent);
        }

        if (card.costRed > 0 && redToken + redTokenPermanent < card.costRed)
        {
            deficit += card.costRed - (redToken + redTokenPermanent);
        }

        if (card.costGreen > 0 && greenToken + greenTokenPermanent < card.costGreen)
        {
            deficit += card.costGreen - (greenToken + greenTokenPermanent);
        }

        if (card.costBlue > 0 && blueToken + blueTokenPermanent < card.costBlue)
        {
            deficit += card.costBlue - (blueToken + blueTokenPermanent);
        }

        if (card.costWhite > 0 && whiteToken + whiteTokenPermanent < card.costWhite)
        {
            deficit += card.costWhite - (whiteToken + whiteTokenPermanent);
        }

        if (goldToken >= deficit) return true;

        return false;
    }

    public bool HasEnoughPermanentTokens(Card card)
    {
        if (blackTokenPermanent >= card.costBlack &&
    redTokenPermanent >= card.costRed &&
    blueTokenPermanent >= card.costBlue &&
    greenTokenPermanent >= card.costGreen &&
    whiteTokenPermanent >= card.costWhite) return true;

        return false;
    }

    private void UpdatePlayerTokens(Card card)
    {
        int costBlackTmp = card.costBlack - blackTokenPermanent;
        int costRedTmp = card.costRed - redTokenPermanent;
        int costGreenTmp = card.costGreen - greenTokenPermanent;
        int costBlueTmp = card.costBlue - blueTokenPermanent;
        int costWhiteTmp = card.costWhite - whiteTokenPermanent;

        if (costBlackTmp > blackToken)
        {
            costBlackTmp -= blackToken;
            blackToken = 0;
            goldToken -= costBlackTmp;
        }
        else if (costBlackTmp > 0)
        {
            blackToken -= costBlackTmp;
        }
        if (costRedTmp > redToken)
        {
            costRedTmp -= redToken;
            redToken = 0;
            goldToken -= costRedTmp;
        }
        else if (costRedTmp > 0)
        {
            redToken -= costRedTmp;
        }
        if (costGreenTmp > greenToken)
        {
            costGreenTmp -= greenToken;
            greenToken = 0;
            goldToken -= costGreenTmp;
        }
        else if (costGreenTmp > 0)
        {
            greenToken -= costGreenTmp;
        }
        if (costBlueTmp > blueToken)
        {
            costBlueTmp -= blueToken;
            blueToken = 0;
            goldToken -= costBlueTmp;
        }
        else if (costBlueTmp > 0)
        {
            blueToken -= costBlueTmp;
        }
        if (costWhiteTmp > whiteToken)
        {
            costWhiteTmp -= whiteToken;
            whiteToken = 0;
            goldToken -= costWhiteTmp;
        }
        else if (costWhiteTmp > 0)
        {
            whiteToken -= costWhiteTmp;
        }

        RenderPlayerTokens();
    }

    public void BuyCard(Card card)
    {
        if (card.benefit != ENUM_Benefit.NULL && !CanBuyOrLockCard()) return;

        playerDeck.Add(card.GetCardObject());

        lockedCards.Remove(card.GetCardObject());

        points += card.points;

        switch (card.benefit)
        {
            case ENUM_Benefit.Black:
                blackTokenPermanent += 1;
                moves -= 3;
                break;
            case ENUM_Benefit.White:
                whiteTokenPermanent += 1;
                moves -= 3;
                break;
            case ENUM_Benefit.Red:
                redTokenPermanent += 1;
                moves -= 3;
                break;
            case ENUM_Benefit.Blue:
                blueTokenPermanent += 1;
                moves -= 3;
                break;
            case ENUM_Benefit.Green:
                greenTokenPermanent += 1;
                moves -= 3;
                break;
            case ENUM_Benefit.NULL:
                break;
            
        }

        UpdatePlayerTokens(card);
        RenderPlayerDeck();
        EndTurn();
    }

    public bool LockCard(Card card)
    {
        if (!CanBuyOrLockCard()) return false;

        if (lockedCards.Contains(card.GetCardObject())) return false;

        if(lockedCards.Count < 3)
        {
            lockedCards.Add(card.GetCardObject());
            TakeToken("Gold");
            RenderLockedCards();
            moves -= 3;
            return true;
        }
        return false;
    }

    public void TakeToken(string token)
    {
        if (!CanTakeToken()) return;

        switch (token)
        {
            case "Black":
                blackToken++;
                moves--;
                break;
            case "White":
                whiteToken++;
                moves--;
                break;
            case "Red":
                redToken++;
                moves--;
                break;
            case "Blue":
                blueToken++;
                moves--;
                break;
            case "Green":
                greenToken++;
                moves--;
                break;
            case "Gold":
                goldToken++;
                break;
        }
        RenderPlayerTokens();
        EndTurn();
    }

    public void RenderPlayerTokens()
    {
        foreach(var token in GameObject.FindGameObjectsWithTag("UI Token"))
        {
            Destroy(token);
        }

        float tokenX = -4.88f;


        Vector3 blackPosition = new Vector3(tokenX, 5f);
        Vector3 redPosition = new Vector3(tokenX, 3.7f);
        Vector3 greenPosition = new Vector3(tokenX, 2.4f);
        Vector3 bluePosition = new Vector3(tokenX, 1.1f);
        Vector3 whitePosition = new Vector3(tokenX, -.2f);
        Vector3 goldPosition = new Vector3(tokenX, -1.5f);

        for(int i = 0; i < blackToken + blackTokenPermanent; i++)
        {
            GameObject token = Instantiate(tokenPrefab, transform);
            token.transform.localPosition = blackPosition + new Vector3(0.2f * i, 0f, -0.001f * i);
            token.GetComponent<SpriteRenderer>().sprite = blackTokenSprite; 
        }

        for(int i = 0; i < redToken + redTokenPermanent; i++)
        {
            GameObject token = Instantiate(tokenPrefab, this.transform);
            token.transform.localPosition = redPosition + new Vector3(0.2f * i, 0f, -0.001f * i);
            token.GetComponent<SpriteRenderer>().sprite = redTokenSprite; 
        }

        for(int i = 0; i < greenToken + greenTokenPermanent; i++)
        {
            GameObject token = Instantiate(tokenPrefab, this.transform);
            token.transform.localPosition = greenPosition + new Vector3(0.2f * i, 0f, -0.001f * i);
            token.GetComponent<SpriteRenderer>().sprite = greenTokenSprite; 
        }

        for(int i = 0; i < blueToken + blueTokenPermanent; i++)
        {
            GameObject token = Instantiate(tokenPrefab, this.transform);
            token.transform.localPosition = bluePosition + new Vector3(0.2f * i, 0f, -0.001f * i);
            token.GetComponent<SpriteRenderer>().sprite = blueTokenSprite; 
        }

        for(int i = 0; i < whiteToken + whiteTokenPermanent; i++)
        {
            GameObject token = Instantiate(tokenPrefab, this.transform);
            token.transform.localPosition = whitePosition + new Vector3(0.2f * i, 0f, -0.001f * i);
            token.GetComponent<SpriteRenderer>().sprite = whiteTokenSprite; 
        }

        for(int i = 0; i < goldToken; i++)
        {
            GameObject token = Instantiate(tokenPrefab, this.transform);
            token.transform.localPosition = goldPosition + new Vector3(0.2f * i, 0f, -0.001f * i);
            token.GetComponent<SpriteRenderer>().sprite = goldTokenSprite; 
        }
    }

    public void RenderPlayerDeck()
    {
        foreach (var card in GameObject.FindGameObjectsWithTag("UI Card"))
        {
            Destroy(card);
        }
        
        for(int i = 0; i < playerDeck.Count; i++)
        {
            GameObject playerCard = Instantiate(cardPrefab, transform);
            playerCard.transform.localPosition = new Vector3(cardX + i * 0.6f, cardY, 0f + i * -0.05f);
            var cardScript = playerCard.GetComponent<Card>();
            cardScript.BindObjects();
            cardScript.LoadCard(playerDeck[i]);
        }
    }

    public void RenderLockedCards()
    {
        foreach (var card in GameObject.FindGameObjectsWithTag("Locked card"))
        {
            Destroy(card);
        }

        for (int i = 0; i < lockedCards.Count; i++)
        {
            GameObject lockedCard = Instantiate(lockedCardPrefab, transform);
            lockedCard.transform.localPosition = new Vector3(-0.92f + i * 1.9f, -3.2f);
            var cardScript = lockedCard.GetComponent<Card>();
            cardScript.BindObjects();
            cardScript.LoadCard(lockedCards[i]);
        }
    }

    public void SetPlayerDeckDefaultPosition()
    {
        int i = 0;
        foreach (var card in GameObject.FindGameObjectsWithTag("UI Card"))
        {
            card.transform.localPosition = new Vector3(cardX + i * 0.6f, cardY, 0f + i * -0.05f);
            i++;
        }
    }
}
