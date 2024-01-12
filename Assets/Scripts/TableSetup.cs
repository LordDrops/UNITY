using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TableSetup : MonoBehaviour
{
    [SerializeField]
    private List<CardObject> deckTier1;

    [SerializeField]
    private List<CardObject> deckTier2;

    [SerializeField]
    private List<CardObject> deckTier3;
    
    [SerializeField]
    private List<CardObject> deckAristocrats;

    [SerializeField]
    private GameObject tableCardsTier1;
    
    [SerializeField]
    private GameObject tableCardsTier2;
    
    [SerializeField]
    private GameObject tableCardsTier3;
    
    [SerializeField]
    private GameObject tableCardsAristocrats;


    // Start is called before the first frame update
    void Start()
    {
        SetCardsRows();
    }

    public CardObject DrawCardFromDeck(List<CardObject> deck)
    {
        if(deck.Count == 0) return null;

        int cardIndex = Random.Range(0, deck.Count);
        
        CardObject card = deck[cardIndex];

        deck.Remove(card);

        return card;
    }

    public void ChangeCard(Card card)
    {
        switch (card.tier)
        {
            case 1:
                card.LoadCard(DrawCardFromDeck(deckTier1));
                break;
            case 2:
                card.LoadCard(DrawCardFromDeck(deckTier2));
                break;
            case 3:
                card.LoadCard(DrawCardFromDeck(deckTier3));
                break;
            default:
                card.LoadCard(DrawCardFromDeck(deckAristocrats));
                break;
        }

    }

    private void SetCardsRows()
    {
        foreach (Transform card in tableCardsTier1.transform)
        {
            card.GetComponent<Card>().LoadCard(DrawCardFromDeck(deckTier1));
        }
        
        foreach (Transform card in tableCardsTier2.transform)
        {
            card.GetComponent<Card>().LoadCard(DrawCardFromDeck(deckTier2));
        }

        foreach (Transform card in tableCardsTier3.transform)
        {
            card.GetComponent<Card>().LoadCard(DrawCardFromDeck(deckTier3));
        }

        foreach (Transform card in tableCardsAristocrats.transform)
        {
            card.GetComponent<Card>().LoadCard(DrawCardFromDeck(deckAristocrats));
        }
        //TODO Add aristocrats
    }

}