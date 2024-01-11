using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera mainCamera;

    private Card zoomCard;

    [SerializeField]
    private List<GameObject> tableCards;

    private void Awake()
    {
        mainCamera = Camera.main;

        zoomCard = GameObject.Find("Zoom Card").GetComponent<Card>();
    }

    private void HideLayers()
    {
        foreach (var card in tableCards)
        {
            card.GetComponent<Card>().HideActionsLayer();
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if (!rayHit.collider)
        {
            HideLayers();
           
            zoomCard.HideCard();

            return;
        }

        HideLayers();

        Card clickedCard = rayHit.collider.GetComponent<Card>();

        zoomCard.LoadCard(clickedCard.GetCardObject());

        clickedCard.ToggleActions();
    }
}
