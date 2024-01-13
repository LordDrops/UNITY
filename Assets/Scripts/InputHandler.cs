using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera mainCamera;

    private Card zoomCard;

    [SerializeField]
    private List<GameObject> tableCards;

    private TableSetup tableSetup;

    private void Awake()
    {
        tableSetup = transform.parent.GetComponent<TableSetup>();

        mainCamera = Camera.main;

        zoomCard = GameObject.Find("Zoom Card").GetComponent<Card>();

        zoomCard.gameObject.SetActive(false);

        SetTableCards();
    }

    private void HideLayers()
    {
        foreach (var card in tableCards)
        {
            card.GetComponent<Card>().HideActionsLayer();
        }

        foreach(var card in GameObject.FindGameObjectsWithTag("Locked card"))
        {
            card.GetComponent<Card>().HideActionsLayer();
        }
    }

    private void LiftCard(Card card)
    {
        card.transform.localPosition += new Vector3(0f, 0.7f, -0.1f);
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if (!rayHit.collider)
        {
            HideLayers();

            player.SetPlayerDeckDefaultPosition();

            zoomCard.HideCard();

            return;
        }

        string tag = rayHit.collider.tag;
        
        if (tag == "Card")
        {
            HideLayers();

            player.SetPlayerDeckDefaultPosition();

            Card clickedCard = rayHit.collider.GetComponent<Card>();

            zoomCard.LoadCard(clickedCard.GetCardObject());

            clickedCard.ToggleActions();
        }
        else if (tag == "Aristocrat")
        {
            HideLayers();

            player.SetPlayerDeckDefaultPosition();

            Card clickedCard = rayHit.collider.GetComponent<Card>();

            zoomCard.LoadCard(clickedCard.GetCardObject());
        }
        else if (tag == "UI Card")
        {
            HideLayers();

            player.SetPlayerDeckDefaultPosition();

            Card clickedCard = rayHit.collider.GetComponent<Card>();

            zoomCard.LoadCard(clickedCard.GetCardObject());

            LiftCard(clickedCard);
        }
        else if (tag == "Locked card")
        {
            HideLayers();

            player.SetPlayerDeckDefaultPosition();

            Card clickedCard = rayHit.collider.GetComponent<Card>();

            zoomCard.LoadCard(clickedCard.GetCardObject());

            clickedCard.ToggleActions();
        }
        else if (tag == "Buy")
        {
            Card clickedCard = rayHit.transform.parent.parent.GetComponent<Card>();
            // Get active player from game manager

            // Temporary solution

            if (player.HasEnoughTokens(clickedCard) && player.CanBuyOrLockCard())
            {
                player.BuyCard(clickedCard);

                if (clickedCard.CompareTag("Card"))
                {
                    tableSetup.ChangeCard(clickedCard);
                }
                else
                {
                    Destroy(clickedCard.gameObject);
                }

                HideLayers();
                zoomCard.HideCard();

                GameObject aristocrats = tableSetup.GetTableCardAristocrats();

                foreach (Transform aristocrat in aristocrats.transform)
                {
                    Card cardComponent = aristocrat.GetComponent<Card>();
                    if (player.HasEnoughPermanentTokens(cardComponent))
                    {
                        player.BuyCard(cardComponent);
                        tableSetup.ChangeCard(cardComponent);
                        return;
                    }
                }
            }
        }
        else if (tag == "Lock")
        {
            Card clickedCard = rayHit.transform.parent.parent.GetComponent<Card>();

            if (player.LockCard(clickedCard))
            {
                tableSetup.ChangeCard(clickedCard);
                HideLayers();
                zoomCard.HideCard();
            }
        }
        else if (tag == "Zoom card")
        {
            return;
        }
        else if (tag != "Untagged" && player.CanTakeToken())
        {
            HideLayers();
            player.TakeToken(tag);
            player.SetPlayerDeckDefaultPosition();
            zoomCard.HideCard();
        }
    }

    private void SetTableCards()
    {
        tableCards.AddRange(GameObject.FindGameObjectsWithTag("Card"));
        tableCards.AddRange(GameObject.FindGameObjectsWithTag("Aristocrat"));
    }
}
