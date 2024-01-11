using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int points;

    [SerializeField]
    private List<Card> playerDeck = new List<Card>();

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
    public int goldTokenPermanent;

    public Card LockedCard;

    public void BuyCard(Card card)
    {
        playerDeck.Add(card);

        points += card.points;

        switch(card.benefit)
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
    }
    
}
