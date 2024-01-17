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

    private VisualElement tutorial;

    private VisualElement player3Container;
    private VisualElement player4Container;

    private TextElement player1Points;
    private TextElement player2Points;
    private TextElement player3Points;
    private TextElement player4Points;

    private TextElement player1BlackTokens;
    private TextElement player2BlackTokens;
    private TextElement player3BlackTokens;
    private TextElement player4BlackTokens;
    
    private TextElement player1RedTokens;
    private TextElement player2RedTokens;
    private TextElement player3RedTokens;
    private TextElement player4RedTokens;
    
    private TextElement player1GreenTokens;
    private TextElement player2GreenTokens;
    private TextElement player3GreenTokens;
    private TextElement player4GreenTokens;
    
    private TextElement player1BlueTokens;
    private TextElement player2BlueTokens;
    private TextElement player3BlueTokens;
    private TextElement player4BlueTokens;
    
    private TextElement player1WhiteTokens;
    private TextElement player2WhiteTokens;
    private TextElement player3WhiteTokens;
    private TextElement player4WhiteTokens;
    
    private TextElement player1GoldTokens;
    private TextElement player2GoldTokens;
    private TextElement player3GoldTokens;
    private TextElement player4GoldTokens;



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

        player1Points = uiDocument.rootVisualElement.Q("player1")as TextElement;
        player1BlackTokens = uiDocument.rootVisualElement.Q("player1Black") as TextElement;
        player1RedTokens = uiDocument.rootVisualElement.Q("player1Red") as TextElement;
        player1GreenTokens = uiDocument.rootVisualElement.Q("player1Green") as TextElement;
        player1BlueTokens = uiDocument.rootVisualElement.Q("player1Blue") as TextElement;
        player1WhiteTokens = uiDocument.rootVisualElement.Q("player1White") as TextElement;
        player1GoldTokens = uiDocument.rootVisualElement.Q("player1Gold") as TextElement;
        
        player2Points = uiDocument.rootVisualElement.Q("player2") as TextElement;
        player2BlackTokens = uiDocument.rootVisualElement.Q("player2Black") as TextElement;
        player2RedTokens = uiDocument.rootVisualElement.Q("player2Red") as TextElement;
        player2GreenTokens = uiDocument.rootVisualElement.Q("player2Green") as TextElement;
        player2BlueTokens = uiDocument.rootVisualElement.Q("player2Blue") as TextElement;
        player2WhiteTokens = uiDocument.rootVisualElement.Q("player2White") as TextElement;
        player2GoldTokens = uiDocument.rootVisualElement.Q("player2Gold") as TextElement;

        player3Container = uiDocument.rootVisualElement.Q("player3Container");
        player3Points = uiDocument.rootVisualElement.Q("player3") as TextElement;
        player3BlackTokens = uiDocument.rootVisualElement.Q("player3Black") as TextElement;
        player3RedTokens = uiDocument.rootVisualElement.Q("player3Red") as TextElement;
        player3GreenTokens = uiDocument.rootVisualElement.Q("player3Green") as TextElement;
        player3BlueTokens = uiDocument.rootVisualElement.Q("player3Blue") as TextElement;
        player3WhiteTokens = uiDocument.rootVisualElement.Q("player3White") as TextElement;
        player3GoldTokens = uiDocument.rootVisualElement.Q("player3Gold") as TextElement;
        
        player4Container = uiDocument.rootVisualElement.Q("player4Container");
        player4Points = uiDocument.rootVisualElement.Q("player4") as TextElement;
        player4BlackTokens = uiDocument.rootVisualElement.Q("player4Black") as TextElement;
        player4RedTokens = uiDocument.rootVisualElement.Q("player4Red") as TextElement;
        player4GreenTokens = uiDocument.rootVisualElement.Q("player4Green") as TextElement;
        player4BlueTokens = uiDocument.rootVisualElement.Q("player4Blue") as TextElement;
        player4WhiteTokens = uiDocument.rootVisualElement.Q("player4White") as TextElement;
        player4GoldTokens = uiDocument.rootVisualElement.Q("player4Gold") as TextElement;

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

    private void UpdatePlayersTokens()
    {
        List<PlayerStats> players = gameManager.GetPlayers();

        player1BlackTokens.text = (players[0].blackToken + players[0].blackTokenPermanent).ToString();
        player1RedTokens.text = (players[0].redToken + players[0].redTokenPermanent).ToString();
        player1GreenTokens.text = (players[0].greenToken + players[0].greenTokenPermanent).ToString();
        player1BlueTokens.text = (players[0].blueToken + players[0].blueTokenPermanent).ToString();
        player1WhiteTokens.text = (players[0].whiteToken + players[0].whiteTokenPermanent).ToString();
        player1GoldTokens.text = (players[0].goldToken).ToString();

        player2BlackTokens.text = (players[1].blackToken + players[1].blackTokenPermanent).ToString();
        player2RedTokens.text = (players[1].redToken + players[1].redTokenPermanent).ToString();
        player2GreenTokens.text = (players[1].greenToken + players[1].greenTokenPermanent).ToString();
        player2BlueTokens.text = (players[1].blueToken + players[1].blueTokenPermanent).ToString();
        player2WhiteTokens.text = (players[1].whiteToken + players[1].whiteTokenPermanent).ToString();
        player2GoldTokens.text = (players[1].goldToken).ToString();

        if(players.Count > 2)
        {
            player3BlackTokens.text = (players[2].blackToken + players[2].blackTokenPermanent).ToString();
            player3RedTokens.text = (players[2].redToken + players[2].redTokenPermanent).ToString();
            player3GreenTokens.text = (players[2].greenToken + players[2].greenTokenPermanent).ToString();
            player3BlueTokens.text = (players[2].blueToken + players[2].blueTokenPermanent).ToString();
            player3WhiteTokens.text = (players[2].whiteToken + players[2].whiteTokenPermanent).ToString();
            player3GoldTokens.text = (players[2].goldToken).ToString();
        }

        if(players.Count > 3) 
        {
            player4BlackTokens.text = (players[3].blackToken + players[3].blackTokenPermanent).ToString();
            player4RedTokens.text = (players[3].redToken + players[3].redTokenPermanent).ToString();
            player4GreenTokens.text = (players[3].greenToken + players[3].greenTokenPermanent).ToString();
            player4BlueTokens.text = (players[3].blueToken + players[3].blueTokenPermanent).ToString();
            player4WhiteTokens.text = (players[3].whiteToken + players[3].whiteTokenPermanent).ToString();
            player4GoldTokens.text = (players[3].goldToken).ToString();
        }
    }

    private void ShowStatsBar(ClickEvent _)
    {
        stats.style.display = DisplayStyle.Flex;
        UpdatePlayersTokens();
        UpdatePlayersPoints();
        gameManager.isOverUI = true;
    }

    private void CloseStatsBar(ClickEvent _)
    {
        stats.style.display = DisplayStyle.None;
        gameManager.isOverUI = false;
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
        if(evt.target == nextPlayerLayer)
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
