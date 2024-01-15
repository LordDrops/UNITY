using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TableUI : MonoBehaviour
{
    public GameManager gameManager;

    private VisualElement stats;

    private Button showStatsBtn;
    private Button hideStatsBtn;


    private VisualElement pauseMenu;
    private Button resumeBtn;
    private Button tutorialBtn;
    private Button exitBtn;

    private VisualElement nextPlayerLayer;
    private TextElement nextPlayerName;

    private TextElement blackTokens;
    private TextElement redTokens;
    private TextElement greenTokens;
    private TextElement blueTokens;
    private TextElement whiteTokens;
    private TextElement goldTokens;

    private VisualElement player1Container;
    private VisualElement player2Container;
    private VisualElement player3Container;
    private VisualElement player4Container;

    private VisualElement tutorial;

    private TextElement player1Points;
    private TextElement player2Points;
    private TextElement player3Points;
    private TextElement player4Points;

    private Button gameOver;

    private List<TextElement> playerPoints = new List<TextElement>();

    void OnEnable()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();  

        var uiDocument = GetComponent<UIDocument>();

        pauseMenu = uiDocument.rootVisualElement.Q("Menu");
        resumeBtn = uiDocument.rootVisualElement.Q("Resume") as Button;
        tutorialBtn = uiDocument.rootVisualElement.Q("Tutorial") as Button;
        exitBtn = uiDocument.rootVisualElement.Q("Exit") as Button;

        stats = uiDocument.rootVisualElement.Q("Stats");
        showStatsBtn = uiDocument.rootVisualElement.Q("StatsButton") as Button;
        hideStatsBtn = uiDocument.rootVisualElement.Q("CloseStats") as Button;

        blackTokens = uiDocument.rootVisualElement.Q("blackTokens") as TextElement;
        redTokens = uiDocument.rootVisualElement.Q("redTokens") as TextElement;
        greenTokens = uiDocument.rootVisualElement.Q("greenTokens") as TextElement;
        blueTokens = uiDocument.rootVisualElement.Q("blueTokens") as TextElement;
        whiteTokens = uiDocument.rootVisualElement.Q("whiteTokens") as TextElement;
        goldTokens = uiDocument.rootVisualElement.Q("goldTokens") as TextElement;

        player1Container = uiDocument.rootVisualElement.Q("player1Container");
        player1Points = uiDocument.rootVisualElement.Q("player1")as TextElement;
        
        player2Container = uiDocument.rootVisualElement.Q("player2Container");
        player2Points = uiDocument.rootVisualElement.Q("player2") as TextElement;

        player3Container = uiDocument.rootVisualElement.Q("player3Container");
        player3Points = uiDocument.rootVisualElement.Q("player3") as TextElement;
        
        player4Container = uiDocument.rootVisualElement.Q("player4Container");
        player4Points = uiDocument.rootVisualElement.Q("player4") as TextElement;

        nextPlayerLayer = uiDocument.rootVisualElement.Q("nextPlayer");
        nextPlayerName = uiDocument.rootVisualElement.Q("nextPlayerText") as TextElement;

        gameOver = uiDocument.rootVisualElement.Q("gameOver") as Button;

        tutorial = uiDocument.rootVisualElement.Q("TutorialLayer");

        showStatsBtn.RegisterCallback<ClickEvent>(ShowStatsBar);
        hideStatsBtn.RegisterCallback<ClickEvent>(CloseStatsBar);

        nextPlayerLayer.RegisterCallback<MouseEnterEvent>(OnMouseOverUI);
        stats.RegisterCallback<MouseEnterEvent>(OnMouseOverUI);

        nextPlayerLayer.RegisterCallback<MouseLeaveEvent>(OnMouseNotOverUI);
        stats.RegisterCallback<MouseLeaveEvent>(OnMouseNotOverUI);

        resumeBtn.RegisterCallback<ClickEvent>(TogglePauseMenu);
        tutorialBtn.RegisterCallback<ClickEvent>(ShowTutorial);
        exitBtn.RegisterCallback<ClickEvent>(LoadInitScene);

        gameOver.RegisterCallback<ClickEvent>(LoadInitScene);

        tutorial.RegisterCallback<ClickEvent>(HideTutorial);
    }

    public void RenderPlayerScore(int playersAmount)
    {
        if(playersAmount == 2)
        {
            player3Container.style.display = DisplayStyle.None;
            player4Container.style.display = DisplayStyle.None;
            playerPoints.Add(player1Points);
            playerPoints.Add(player2Points);
        } else if(playersAmount == 3)
        {
            player4Container.style.display = DisplayStyle.None;
            playerPoints.Add(player1Points);
            playerPoints.Add(player2Points);
            playerPoints.Add(player3Points);
        } else
        {
            playerPoints.Add(player1Points);
            playerPoints.Add(player2Points);
            playerPoints.Add(player3Points);
            playerPoints.Add(player4Points);
        }
    }

    private void UpdatePlayersPoints()
    {
        int i = 0;

        foreach(var player in gameManager.GetPlayers())
        {
            playerPoints[i].text = player.points.ToString();
            i++;
        }
    }

    private void UpdateCurrentPlayerToken()
    {
        blackTokens.text = (gameManager.currentPlayer.blackToken + gameManager.currentPlayer.blackTokenPermanent).ToString();
        redTokens.text = (gameManager.currentPlayer.redToken + gameManager.currentPlayer.redTokenPermanent).ToString();
        greenTokens.text = (gameManager.currentPlayer.greenToken + gameManager.currentPlayer.greenTokenPermanent).ToString();
        blueTokens.text = (gameManager.currentPlayer.blueToken + gameManager.currentPlayer.blueTokenPermanent).ToString();
        whiteTokens.text = (gameManager.currentPlayer.whiteToken + gameManager.currentPlayer.whiteTokenPermanent).ToString();
        goldTokens.text = (gameManager.currentPlayer.goldToken).ToString();
    }

    private void ShowStatsBar(ClickEvent _)
    {
        stats.style.display = DisplayStyle.Flex;
        UpdateCurrentPlayerToken();
        UpdatePlayersPoints();
    }

    private void CloseStatsBar(ClickEvent _)
    {
        stats.style.display = DisplayStyle.None;
    }

    IEnumerator AddClickCallbackAfterDelay()
    { 
        yield return new WaitForSeconds(2);
        nextPlayerLayer.RegisterCallback<ClickEvent>(OnNextPlayerClick);
    }

    public void EndTurn(int nextPlayer)
    {
        nextPlayerName.text = "Gracz " + nextPlayer.ToString();
        nextPlayerLayer.style.display = DisplayStyle.Flex;
        StartCoroutine(AddClickCallbackAfterDelay());
    }

    private void OnNextPlayerClick(ClickEvent evt)
    {
            nextPlayerLayer.style.display = DisplayStyle.None;
            nextPlayerLayer.UnregisterCallback<ClickEvent>(OnNextPlayerClick);
            return;
    }

    private void OnMouseOverUI(MouseEnterEvent evt)
    {
        if(evt.target == nextPlayerLayer || evt.target == stats)
        {
            gameManager.isOverUI = true;
        }
    }
    
    private void OnMouseNotOverUI(MouseLeaveEvent evt)
    {
        if(evt.target == nextPlayerLayer || evt.target == stats)
        {
            gameManager.isOverUI = false;
        }
    }

    public void TogglePauseMenu(ClickEvent _ = null)
    {
        if(pauseMenu.style.display == DisplayStyle.None)
        {
            gameManager.isOverUI = true;
            pauseMenu.style.display = DisplayStyle.Flex;
        } 
        else
        {
            gameManager.isOverUI = false;
            pauseMenu.style.display = DisplayStyle.None;
        }
    }

    private void ShowTutorial(ClickEvent _)
    {
        tutorial.style.display = DisplayStyle.Flex;
    }

    private void HideTutorial(ClickEvent _)
    { 
        tutorial.style.display = DisplayStyle.None;
    }

    private void LoadInitScene(ClickEvent _)
    {
        Destroy(gameManager.gameObject);
        SceneManager.LoadScene(0);
    }

    public void GameOver(int playerIndex)
    {
        string message = "Gracz " + (playerIndex + 1).ToString() + " wygral!";
        nextPlayerLayer.UnregisterCallback<ClickEvent>(OnNextPlayerClick);
        nextPlayerLayer.style.display = DisplayStyle.Flex;
        nextPlayerName.text = message;
        gameOver.style.display = DisplayStyle.Flex;
    }
}   
