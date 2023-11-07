using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public Image artwork;

    public Text Points;

    public Text CostRed;
    public Text CostGreen;
    public Text CostBlue;
    public Text CostBlack;
    public Text CostWhite;

    public Image BenefitIcon;



    // Start is called before the first frame update
    void Update()
    {
        Points.text = card.Points.ToString();

        artwork.sprite = card.artwork;

        CostBlack.text=card.CostBlack.ToString();
        CostWhite.text=card.CostWhite.ToString();
        CostRed.text=card.CostRed.ToString();   
        CostBlue.text=card.CostBlue.ToString();
        CostGreen.text=card.CostGreen.ToString();

        switch(card.Benefit)
        { 
            case ENUM_Benefit.Black:
               BenefitIcon.sprite= Resources.Load<Sprite>("Images/Tokens/czarny_preview_rev_1");
                break;

            case ENUM_Benefit.White:
                BenefitIcon.sprite = Resources.Load<Sprite>("Images/Tokens/biay_preview_rev_1");
                break;

            case ENUM_Benefit.Red:
                BenefitIcon.sprite = Resources.Load<Sprite>("Images/Tokens/czerwony_preview_rev_1");
                break;

            case ENUM_Benefit.Blue:
                BenefitIcon.sprite = Resources.Load<Sprite>("Images/Tokens/niebieski_preview_rev_1");
                break;

            case ENUM_Benefit.Green:
                BenefitIcon.sprite = Resources.Load<Sprite>("Images/Tokens/zielony_preview_rev_1");
                break;

        }
            

    }
}
