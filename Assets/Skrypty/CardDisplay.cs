using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;


    private void OnEnable()
    {
        card = GetComponent<Card>();
    }

    public void DisplayAttributes()
    { 

            

    }
}
