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

    public Card LockedCard;

    public float moves = 3.0f;

    public GameObject tokenPrefab;
    public GameObject cardPrefab;


    private float cardY = -6.75f;
    private float cardX = -4.45f;

    public bool HasEnoughTokens(Card card)
    {
        if (blackToken + blackTokenPermanent >= card.costBlack && redToken + redTokenPermanent >= card.costRed && blueToken + blueTokenPermanent >= card.costBlue && greenToken + greenTokenPermanent >= card.costGreen && whiteToken + whiteTokenPermanent >= card.costWhite) return true;

        int deficit = 0;

        if(card.costBlack > 0 && blackToken + blackTokenPermanent < card.costBlack)
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

        if(goldToken >= deficit) return true;

        return false;
    }

    private void UpdatePlayerTokens(Card card)
    {
        int costBlackTmp = card.costBlack - blackTokenPermanent;
        int costRedTmp = card.costRed - redTokenPermanent;
        int costGreenTmp = card.costGreen - greenTokenPermanent;
        int costBlueTmp = card.costBlue - blueTokenPermanent;
        int costWhiteTmp = card.costWhite - whiteTokenPermanent;

        if(costBlackTmp > blackToken)
        {
            costBlackTmp -= blackToken;
            blackToken = 0;
            goldToken -= costBlackTmp;
        }
        else if(costBlackTmp > 0)
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
        if(costGreenTmp > greenToken)
        {
            costGreenTmp -= greenToken;
            greenToken = 0;
            goldToken -= costGreenTmp;
        }
        else if (costGreenTmp > 0)
        {
            greenToken -= costGreenTmp;
        }
        if(costBlueTmp > blueToken)
        {
            costBlueTmp -= blueToken;
            blueToken = 0;
            goldToken -= costBlueTmp;
        }
        else if (costBlueTmp > 0)
        {
            blueToken -= costBlueTmp;
        }
        if(costWhiteTmp > whiteToken)
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
        playerDeck.Add(card.GetCardObject());

        points += card.points;

        switch (card.benefit)
        {
            case ENUM_Benefit.Black:
                blackTokenPermanent += 1;
                break;
            case ENUM_Benefit.White:
                whiteTokenPermanent += 1;
                break;
            case ENUM_Benefit.Red:
                redTokenPermanent += 1;
                break;
            case ENUM_Benefit.Blue:
                blueTokenPermanent += 1;
                break;
            case ENUM_Benefit.Green:
                greenTokenPermanent += 1;
                break;
            case ENUM_Benefit.NULL:
                break;
            
        }

        UpdatePlayerTokens(card);
        RenderPlayerDeck();
        moves -= 3.0f;
    }

    public void TakeToken(string token)
    {
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
                moves -= 2;
                break;
        }

        RenderPlayerTokens();
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
