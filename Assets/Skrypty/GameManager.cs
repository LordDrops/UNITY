using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Gracze
    public List<Player> players=new List<Player>();
    //Tokeny
    public int BlackTokens,WhiteTokens,RedTokens,BlueTokens,GreenTokens;

    //Talie Kart
    public List<Card> TierI = new List<Card>();
    public List<Card> TierII = new List<Card>();
    public List<Card>  TierIII = new List<Card>();

    //Talie Arystokrat�w 
    public List<Arystokrata> PulaArystokratow = new List<Arystokrata>();



    //void change Player()
    //Void CheckWin()
    //linser dobrania karty 

    //public int GetCard()

    
}
public class CardManager : MonoBehaviour{ //inicjowanie kart 

    public Card[] cards; 
    void Start(){
        LoadCards();
    }

    void LoadCards(){ // O(n^2) gdyby wszystkie karty w jednym folderze to O(n)
        string cardsFolderPath = "Assets/Skrypty/Talie";
        for (int tier = 1; tier <= 3; tier++) //przez foldery 
        {
            string tierFolderPath = Path.Combine(cardsFolderPath, "Teir" + tier.ToString());
            foreach (string color in new[] { "Białe", "Czarne", "Czerwone", "Niebieskie", "Zielone" }){ // przez foldery kolorów
                string colorFolderPath = Path.Combine(tierFolderPath, color);

                Card[] cardsInFolder = Resources.LoadAll<Card>(colorFolderPath); //ładowanie kart z folderu
            }
        }
    }
}

public enum GameStatus
{
    Pause,Menu,Game,ChangePlayer,End
}