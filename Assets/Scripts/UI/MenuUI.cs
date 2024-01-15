using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuUI : MonoBehaviour
{
    private Button startBtn;
    private Button creditsBtn;
    private Button exitBtn;

    private Button players2Btn;
    private Button players3Btn;
    private Button players4Btn;

    private VisualElement creditsVisual;
    private VisualElement playOptionsVisual;

    private GameManager gameManager;


    private void OnEnable()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        var uiDocument = GetComponent<UIDocument>();

        startBtn = uiDocument.rootVisualElement.Q("PlayButton") as Button;
        creditsBtn = uiDocument.rootVisualElement.Q("CreditsButton") as Button;
        exitBtn = uiDocument.rootVisualElement.Q("ExitButton") as Button;

        players2Btn = uiDocument.rootVisualElement.Q("2PlayersBtn") as Button;
        players3Btn = uiDocument.rootVisualElement.Q("3PlayersBtn") as  Button;
        players4Btn = uiDocument.rootVisualElement.Q("4PlayersBtn") as Button;

        creditsVisual = uiDocument.rootVisualElement.Q("Credits");
        playOptionsVisual = uiDocument.rootVisualElement.Q("PlayOptions");

        startBtn.RegisterCallback<ClickEvent>(OnPlayClick);
        creditsBtn.RegisterCallback<ClickEvent>(OnCreditsClick);
        exitBtn.RegisterCallback<ClickEvent>(OnExitClick);

        players2Btn.RegisterCallback<ClickEvent>(OnPlayers2Click);
        players3Btn.RegisterCallback<ClickEvent>(OnPlayers3Click);
        players4Btn.RegisterCallback<ClickEvent>(OnPlayers4Click);
    }

    private void OnPlayClick(ClickEvent evt)
    {
        creditsVisual.style.display = DisplayStyle.None;
        playOptionsVisual.style.display = DisplayStyle.Flex;
    }
    private void OnCreditsClick(ClickEvent evt)
    {
        creditsVisual.style.display = DisplayStyle.Flex;
        playOptionsVisual.style.display = DisplayStyle.None;
    }

    private void OnExitClick(ClickEvent evt)
    {
        Application.Quit();
    }

    private void OnPlayers2Click(ClickEvent evt)
    {
        gameManager.CreateGame(2);
    }
    private void OnPlayers3Click(ClickEvent evt)
    {
        gameManager.CreateGame(3);
    }
    private void OnPlayers4Click(ClickEvent evt)
    {
        gameManager.CreateGame(4);
    }
}
