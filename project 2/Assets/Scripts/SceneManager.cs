using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class SceneManager : MonoBehaviour
{
    //for all of the text
    public GameObject opponentHandText;
    public GameObject playerHandText;
    public GameObject opponentTotalText;
    public GameObject playerTotalText;
    public GameObject winTextObject;

    //for all of the card display panels
    public GameObject playerCard1Object;
    public GameObject playerCard2Object;
    public GameObject playerCard3Object;
    public GameObject playerCard4Object;
    public GameObject playerCard5Object;
    public GameObject opponentCard1Object;
    public GameObject opponentCard2Object;
    public GameObject opponentCard3Object;
    public GameObject opponentCard4Object;
    public GameObject opponentCard5Object;

    //for all the RawImage objects
    private RawImage playerCard1;
    private RawImage playerCard2;
    private RawImage playerCard3;
    private RawImage playerCard4;
    private RawImage playerCard5;
    private RawImage opponentCard1;
    private RawImage opponentCard2;
    private RawImage opponentCard3;
    private RawImage opponentCard4;
    private RawImage opponentCard5;

    //for all the card textures
    public Texture spadeAce;
    public Texture oneCard;
    public Texture twoCard;
    public Texture threeCard;
    public Texture fourCard;
    public Texture fiveCard;
    public Texture sixCard;
    public Texture sevenCard;
    public Texture eightCard;
    public Texture nineCard;
    public Texture jackCard;
    public Texture queenCard;
    public Texture kingCard;
    public Texture BackCard;

    //for the sounds
    public AudioSource BlackJackClip;
    public AudioSource BustClip;
    public AudioSource CardFlip;

    //for the buttons
    public Button hitButton;
    public Button holdButton;
    public Button newRoundButton; //this is to deal the cards after the round happens if needed

    //for the text
    private TextMeshProUGUI opponentHand { get; set; }
    private TextMeshProUGUI playerHand { get; set; }
    private TextMeshProUGUI opponentTotal { get; set; }
    private TextMeshProUGUI playerTotal { get; set; }
    private TextMeshProUGUI winText { get; set; }

    //variables. I used them for the lines that set the text. Change them if needed.
    //public int opponentScoreNumber = 0;
    //public int playerScoreNumber = 0;
    //public int opponentHandTotal = 0;
    //public int playerHandTotal = 0;

    //declares objects for the player and opponent
    private Gambler player = new Gambler();
    private Gambler opponent = new Gambler();

    //List containing all the cards that can be drawn
    private List<Card> deck = new List<Card>();

    //targets the current hand position
    private int playerCardPosition;
    private int opponentCardPosition;

    //determines whether or not the game has ended
    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        opponentHand = opponentHandText.GetComponent<TextMeshProUGUI>();
        playerHand = playerHandText.GetComponent<TextMeshProUGUI>();
        opponentTotal = opponentTotalText.GetComponent<TextMeshProUGUI>();
        playerTotal = playerTotalText.GetComponent<TextMeshProUGUI>();
        winText = winTextObject.GetComponent<TextMeshProUGUI>();

        playerCard1 = playerCard1Object.GetComponent<RawImage>();
        playerCard2 = playerCard2Object.GetComponent<RawImage>();
        playerCard3 = playerCard3Object.GetComponent<RawImage>();
        playerCard4 = playerCard4Object.GetComponent<RawImage>();
        playerCard5 = playerCard5Object.GetComponent<RawImage>();
        opponentCard1 = opponentCard1Object.GetComponent<RawImage>();
        opponentCard2 = opponentCard2Object.GetComponent<RawImage>();
        opponentCard3 = opponentCard3Object.GetComponent<RawImage>();
        opponentCard4 = opponentCard4Object.GetComponent<RawImage>();
        opponentCard5 = opponentCard5Object.GetComponent<RawImage>();

        gameOver = false;
        playerCardPosition = 0;
        opponentCardPosition = 0;
        formDeck();
        StartingDeal();
        
        

    }

    // Update is called once per frame
    void Update()
    {
        opponentHand.text = "Dealer's Hand"; //this text does not change
        playerHand.text = "Your Hand"; //this text does not change
        opponentTotal.text = "Total: " + opponent.GetGamblerScore().ToString(); 
        playerTotal.text = "Total: " + player.GetGamblerScore().ToString();

        

    }

    // puts all card objects in the deck array
    public void formDeck()
    {
        deck = new List<Card>{new Card(2, "2"), new Card(3, "3"), new Card(4, "4"), new Card(5, "5"), new Card(6, "6"), new Card(7, "7"), new Card(8, "8"), new Card(9, "9"), new Card(10, "j"), new Card(10, "q"), new Card(10, "k"), new Card(1, "1"),
                              new Card(2, "2"), new Card(3, "3"), new Card(4, "4"), new Card(5, "5"), new Card(6, "6"), new Card(7, "7"), new Card(8, "8"), new Card(9, "9"), new Card(10, "j"), new Card(10, "q"), new Card(10, "k"), new Card(1, "1"),
                              new Card(2, "2"), new Card(3, "3"), new Card(4, "4"), new Card(5, "5"), new Card(6, "6"), new Card(7, "7"), new Card(8, "8"), new Card(9, "9"), new Card(10, "j"), new Card(10, "q"), new Card(10, "k"), new Card(1, "1"),
                              new Card(2, "2"), new Card(3, "3"), new Card(4, "4"), new Card(5, "5"), new Card(6, "6"), new Card(7, "7"), new Card(8, "8"), new Card(9, "9"), new Card(10, "j"), new Card(10, "q"), new Card(10, "k"), new Card(1, "1")};
    }

    public void Deal()
    {
        if(gameOver == false)
        {
            DealtoPlayer();

            CheckScores();

            if(playerCardPosition > 4)
            {
                Hold();
            }
        }
    }

    public void Hold()
    {
        opponent.SetGamblerScore(opponent.GetGamblerScore() + opponent.GetExactHand(0).GetScore());
        opponentCard1.texture = PickCard(opponent.GetExactHand(0));
        while (opponentCardPosition < 6 && gameOver == false)
        {
            
            if (opponent.GetGamblerScore() >= 17)
            {
                if (player.GetGamblerScore() > opponent.GetGamblerScore())
                {
                    winText.text = "You Win!";
                    BlackJackClip.Play();
                    break;
                }
                else if (player.GetGamblerScore() < opponent.GetGamblerScore())
                {
                    winText.text = "Dealer Wins!";
                    BustClip.Play();
                    break;
                }
                else
                {
                    winText.text = "Push! It's a draw!";
                    gameOver = true;
                    break;
                }
            }

            if (opponentCardPosition > 4)
            {
                if (player.GetGamblerScore() > opponent.GetGamblerScore())
                {
                    winText.text = "You Win!";
                    BlackJackClip.Play();
                    break;
                }
                else if (player.GetGamblerScore() < opponent.GetGamblerScore())
                {
                    winText.text = "Dealer Wins!";
                    BustClip.Play();
                    break;
                }
                else
                {
                    winText.text = "Push! It's a draw!";
                    gameOver = true;
                    break;
                }
            }

            DealtoOpponent();

            CheckScores();

        }
    }

    public void CheckScores()
    {
        //displays who won. displays nothing if nobody won. This code is not complete, I made it to show what the text should say.
        if (player.GetGamblerScore() == 21)
        {
            winText.text = "BlackJack! You Win!";
            gameOver = true;
            BlackJackClip.Play();
        }
        else if (opponent.GetGamblerScore() == 21)
        {
            winText.text = "BlackJack! Dealer Wins!";
            gameOver = true;
            BustClip.Play();
        }
        else if (player.GetGamblerScore() > 21)
        {
            winText.text = "Bust! Dealer Wins!";
            gameOver = true;
            BustClip.Play();
        }
        else if (opponent.GetGamblerScore() > 21)
        {
            winText.text = "Bust! You Win!";
            gameOver = true;
            BlackJackClip.Play();
        }
        else
        {
            winText.text = " ";
        }
    }

    //resets scores and hands for all players
    public void NewRound()
    {
        gameOver = false;

        playerCardPosition = 0;
        opponentCardPosition = 0;

        player.SetGamblerScore(0);
        player.SetHand(new Card[5]);

        opponent.SetGamblerScore(0);
        opponent.SetHand(new Card[5]);

        playerCard1.texture = null;
        playerCard2.texture = null;
        playerCard3.texture = null;
        playerCard4.texture = null;
        playerCard5.texture = null;

        opponentCard1.texture = BackCard;
        opponentCard2.texture = null;
        opponentCard3.texture = null;
        opponentCard4.texture = null;
        opponentCard5.texture = null;

        formDeck();
        StartingDeal();
    }

    // deals two cards to both sides at the start of a game
    public void StartingDeal()
    {
        DealtoPlayer();
        DealtoOpponent();

        DealtoPlayer();
        DealtoOpponent();

        opponent.SetGamblerScore(opponent.GetGamblerScore() - opponent.GetExactHand(0).GetScore());

        CheckScores();
    }

    // deals one card to the player
    public void DealtoPlayer()
    {
        int i = Random.Range(0, deck.Count - 1);
        player.SetExactHand(playerCardPosition, deck[i]);
        player.SetGamblerScore(player.GetGamblerScore() + deck[i].GetScore());
        switch (playerCardPosition)
        {
            case 0:
                playerCard1.texture = PickCard(deck[i]);
                break;
            case 1:
                playerCard2.texture = PickCard(deck[i]);
                break;
            case 2:
                playerCard3.texture = PickCard(deck[i]);
                break;
            case 3:
                playerCard4.texture = PickCard(deck[i]);
                break;
            case 4:
                playerCard5.texture = PickCard(deck[i]);
                break;
        }
        deck.RemoveAt(i);
        playerCardPosition++;
        CardFlip.Play();
    }

    // deals one card to the opponent
    public void DealtoOpponent()
    {

        int j = Random.Range(0, deck.Count - 1);
        opponent.SetExactHand(opponentCardPosition, deck[j]);
        opponent.SetGamblerScore(opponent.GetGamblerScore() + deck[j].GetScore());
        switch (opponentCardPosition)
        {
            case 0:
                //opponentCard1.texture = PickCard(deck[j]);
                break;
            case 1:
                opponentCard2.texture = PickCard(deck[j]);
                break;
            case 2:
                opponentCard3.texture = PickCard(deck[j]);
                break;
            case 3:
                opponentCard4.texture = PickCard(deck[j]);
                break;
            case 4:
                opponentCard5.texture = PickCard(deck[j]);
                break;
        }
        deck.RemoveAt(j);
        opponentCardPosition++;
        CardFlip.Play();
    }

    // Determines which texture is displayed in the card panel
    public Texture PickCard(Card c)
    {
        switch (c.GetName())
        {
            case "1":
                return oneCard;
                break;
            case "2":
                return twoCard;
                break;
            case "3":
                return threeCard;
                break;
            case "4":
                return fourCard;
                break;
            case "5":
                return fiveCard;
                break;
            case "6":
                return sixCard;
                break;
            case "7":
                return sevenCard;
                break;
            case "8":
                return eightCard;
                break;
            case "9":
                return nineCard;
                break;
            case "j":
                return jackCard;
                break;
            case "q":
                return queenCard;
                break;
            case "k":
                return kingCard;
                break;
        }
        return spadeAce;
    }
}
