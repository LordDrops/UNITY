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





    private void RenderCard()
    {
        //TODO add sprite change
        artworkRender.sprite = artwork;
        //TODO add token sprite change

        profitToken.sprite = tokenSprite;



        whiteCost.SetText(this.costWhite.ToString());
        blueCost.SetText(this.costBlue.ToString());
        greenCost.SetText(this.costGreen.ToString());
        redCost.SetText(this.costRed.ToString());
        blackCost.SetText(this.costBlack.ToString());

        profitValue.SetText(this.points.ToString());
    }

    public void LoadCard(CardObject cardObject)
    {
        this.tier = cardObject.tier;
        this.benefit = cardObject.benefit;
        this.artwork = cardObject.artwork;
        this.tokenSprite = cardObject.tokenSprite;
        this.points = cardObject.points;
        this.id = cardObject.id;
        this.costBlack = cardObject.costBlack;
        this.costWhite = cardObject.costWhite;
        this.costRed = cardObject.costRed;
        this.costBlue = cardObject.costBlue;
        this.costGreen = cardObject.costGreen;

        RenderCard();
    }



    private void OnEnable()
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

        LoadCard(cardObject);
    }
}

public enum ENUM_Benefit
{
    Black, White, Red, Blue, Green

}
