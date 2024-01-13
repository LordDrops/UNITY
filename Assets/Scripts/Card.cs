using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    public int id;

    public int tier;
    public ENUM_Benefit benefit;

    public SpriteRenderer artworkRender;
    public Sprite artwork;

    public Sprite tokenSprite;

    [SerializeField]
    private CardObject cardObject;

    public int points;

    public int costBlack;
    public int costWhite;
    public int costRed;
    public int costBlue;
    public int costGreen;

    // Visual elements
    private TextMeshPro whiteCost;
    private TextMeshPro blueCost;
    private TextMeshPro greenCost;
    private TextMeshPro redCost;
    private TextMeshPro blackCost;

    private TextMeshPro profitValue;
    private SpriteRenderer profitToken;

    [SerializeField]
    private GameObject actionLayer;

    private bool actionsActive = false;


    public CardObject GetCardObject()
    {
        return cardObject;
    }

    public void HideCard()
    {
        gameObject.SetActive(false);
        actionLayer.SetActive(false);
    }

    public void HideActionsLayer()
    {
        actionsActive = false;

        actionLayer.SetActive(actionsActive);
    }

    public void ToggleActions()
    {
        actionsActive = !actionsActive;

        actionLayer.SetActive(actionsActive);
    }

    private void RenderCard()
    {
        artworkRender.sprite = artwork;
        profitToken.sprite = tokenSprite;

        // Activate all elements and remove ones with value 0

        whiteCost.gameObject.SetActive(true);
        greenCost.gameObject.SetActive(true);
        blackCost.gameObject.SetActive(true);
        blueCost.gameObject.SetActive(true);
        redCost.gameObject.SetActive(true);

        if (this.costWhite > 0)
        {
            whiteCost.SetText(this.costWhite.ToString());
        }
        else
        {
            whiteCost.gameObject.SetActive(false);
        }

        if (this.costBlue > 0)
        {
            blueCost.SetText(this.costBlue.ToString());
        }
        else
        {
            blueCost.gameObject.SetActive(false);
        }

        if (this.costGreen > 0)
        {
            greenCost.SetText(this.costGreen.ToString());
        }
        else
        {
            greenCost.gameObject.SetActive(false);
        }

        if (this.costRed > 0)
        {
            redCost.SetText(this.costRed.ToString());
        }
        else
        {
            redCost.gameObject.SetActive(false);
        }

        if (this.costBlack > 0)
        {
            blackCost.SetText(this.costBlack.ToString());
        }
        else
        {
            blackCost.gameObject.SetActive(false);
        }

        if (this.points > 0)
        {
            profitValue.SetText(this.points.ToString());
        }
        else
        {
            profitValue.SetText("");
        }

    }

    public void LoadCard(CardObject cardObject)
    {
        if (cardObject == null) 
        { 
            this.gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);

        this.cardObject = cardObject;

        tier = cardObject.tier;
        benefit = cardObject.benefit;
        artwork = cardObject.artwork;
        tokenSprite = cardObject.tokenSprite;
        points = cardObject.points;
        id = cardObject.id;
        costBlack = cardObject.costBlack;
        costWhite = cardObject.costWhite;
        costRed = cardObject.costRed;
        costBlue = cardObject.costBlue;
        costGreen = cardObject.costGreen;

        RenderCard();
    }

    public void BindObjects()
    {
        // Objects to render
        artworkRender = transform.Find("Image").GetComponent<SpriteRenderer>();

        Transform costsGroup = transform.Find("Costs");

        whiteCost = costsGroup.Find("White").gameObject.GetComponent<TextMeshPro>();
        blueCost = costsGroup.Find("Blue").gameObject.GetComponent<TextMeshPro>();
        greenCost = costsGroup.Find("Green").gameObject.GetComponent<TextMeshPro>();
        redCost = costsGroup.Find("Red").gameObject.GetComponent<TextMeshPro>();
        blackCost = costsGroup.Find("Black").gameObject.GetComponent<TextMeshPro>();

        profitValue = transform.Find("Profit").gameObject.GetComponent<TextMeshPro>();
        profitToken = transform.Find("Profit").transform.Find("Token").gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        BindObjects();
    }
}

public enum ENUM_Benefit
{
    Black, White, Red, Blue, Green, NULL
}
