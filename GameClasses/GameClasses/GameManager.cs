using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace GameClasses
{
   
    public delegate void VictorySetter (object sender, VictoryEventArgs args);
    public delegate void CardPlayer(object sender, CardPlayedEventArgs args);
    

    /// <summary>
    /// Game process main manager
    /// </summary>
    public class GameManager
    {
        public GameManager()
        {

        }
        public GameManager(Player player, Player computerPlayer)
        {
            field = new Field();
            player1 = player;            
            this.computerPlayer = computerPlayer;
        }



        public Player player1;                              //Player1
        public Player computerPlayer;                       //Computer player        
        public Field field;                                 //Game field
        public const int IN_HAND_START_CARDS_NUMBER = 4;    //Number of _cards in hand on the start   

        public event CardPlayer CardPlayedEvent;            
        public event EventHandler StartNewTurnEvent;
        public event EventHandler EndTurnEvent;
        public event VictorySetter VictoryEvent;
        public event EventHandler GameSetUpEvent;
        public event EventHandler PlayerStartNewTurnEvent;

        /// <summary>
        /// Func plays and removes card from player Deck 
        /// </summary>
        /// <param name="card">Card to play</param>
        public void PlayerPlayCard(Card card)
        {
            if (player1.CanBePlayed(card))
            {
                switch (card.TypeOfCard)
                {
                    case CardTypes.empty:
                        break;
                    case CardTypes.city:                        
                        break;
                    case CardTypes.resource:
                        player1.resourceQuantity += card.AbilityValOfCard;                        
                        break;
                    case CardTypes.scene:
                        break;
                    case CardTypes.armor:
                        field.CardPlayed((Card)card.Clone(), player1.playerName);                        
                        break;
                    case CardTypes.infantry:
                        field.CardPlayed((Card)card.Clone(), player1.playerName);
                        
                        break;
                    default:
                        break;
                }
                player1.playerHand.RemoveCard(card);
                player1.resourceQuantity -= card.ResOfCard;
                CardPlayedEvent(this, new CardPlayedEventArgs(player1.playerName,card));
            }  
        }

        /// <summary>
        /// Func plays and removes card from computer Deck 
        /// </summary>
        /// <param name="card">Card to play</param>
        public void ComputerPlayCard(Card card)
        {
            switch (card.TypeOfCard)
                {
                    case CardTypes.empty:
                        break;
                    case CardTypes.city:
                        break;
                    case CardTypes.resource:
                        computerPlayer.resourceQuantity += card.AbilityValOfCard;                        
                        break;
                    case CardTypes.scene:
                        break;
                    case CardTypes.armor:
                        field.CardPlayed((Card)card.Clone(), computerPlayer.playerName);                        
                        break;
                    case CardTypes.infantry:
                        field.CardPlayed((Card)card.Clone(), computerPlayer.playerName);                        
                        break;
                    default:
                        break;
                }
                computerPlayer.playerHand.RemoveCard(card);
                computerPlayer.resourceQuantity -= card.ResOfCard;
                CardPlayedEvent(this, new CardPlayedEventArgs(computerPlayer.playerName,card));
        }

        /// <summary>
        /// Start main game stage
        /// </summary>
        private void SetUpGame()
        {
            player1.playerHand = new Hand();
            computerPlayer.playerHand = new Hand();

            player1.playerDeck.ShuffleDeck();                                           //Shuffling players decks
            computerPlayer.playerDeck.ShuffleDeck();

            for (int i = 0; i < IN_HAND_START_CARDS_NUMBER; i++)                        //Adding cards to players hand
            {
                player1.playerHand.AddCardFromDeck(player1.playerDeck);
                computerPlayer.playerHand.AddCardFromDeck(computerPlayer.playerDeck);
            }


            player1.resourceQuantity = 0;               //Setting players resources to "0"
            computerPlayer.resourceQuantity = 0;
            GameSetUpEvent(this, new EventArgs());
        } 

        /// <summary>
        /// Func starts new game turn
        /// </summary>
        private void PlayerStartNewTurn()
        {            
            player1.resourceQuantity++;                                    //Adding rosources
            player1.playerHand.AddCardFromDeck(player1.playerDeck);        //Taking a card from deck
            PlayerStartNewTurnEvent(this, new EventArgs());
        }

        public void AIStartNewTurn()
        {
            computerPlayer.resourceQuantity++;                                      //Adding rosources
            computerPlayer.playerHand.AddCardFromDeck(computerPlayer.playerDeck);   //Taking a card from deck
            StartNewTurnEvent(this, new EventArgs());
            AIMove();
        }

        /// <summary>
        /// Func makes computer player move
        /// </summary>
        private void AIMove()
        {
            List<Card> availableCards = (from c in computerPlayer.playerHand.cardsInCollection      //Getting cards that are available to play
                                        where computerPlayer.CanBePlayed(c)
                                        select c).ToList();

            if (field.armorOccupiedByPlayer != computerPlayer.playerName)                       //Checking if the armor field is not occupied by AI
            {
                foreach (Card card in availableCards)                                            //If not - playing card to occupy the field
                {
                    if (card.TypeOfCard == CardTypes.armor)
                    {
                        ComputerPlayCard(card);
                        break;
                    }
                }
            }
            else
            {                                                                               //Checking if the infantry field is not occupied by AI
                if (field.infantryOccupiedByPlayer != computerPlayer.playerName)
                {
                    foreach (Card card in availableCards)                                  //If not - playing card to occupy the field
                    {
                        if (card.TypeOfCard == CardTypes.infantry)
                        {
                            ComputerPlayCard(card);
                            break;
                        }
                    }
                }
                else
                {                                                                         //If fields are empty - playing first card
                    if (availableCards.Count > 0)
                    {
                        ComputerPlayCard(availableCards[0]);
                    }                   
                }

            }
            EndTurn();
            PlayerStartNewTurn();
        }
        

        /// <summary>
        /// Player end turn
        /// </summary>
        public void PlayerEndTurn()
        {
            EndTurn();
            if (!isVictory())
            {
                AIStartNewTurn();
            }           
        }

        /// <summary>
        /// Func ends turn and deals damage to players, dependent on what player occupied field
        /// </summary>
        private void EndTurn()
        {
            string nameOfPlayerArmor = field.armorOccupiedByPlayer;
            string nameOfPlayerInfantry = field.infantryOccupiedByPlayer;
            if (nameOfPlayerArmor != null)                                                              //Checking if field occupied by someone
            {
                if (nameOfPlayerArmor == player1.playerName)                                            //If occupied by player - dealing damage to AI
                {
                    computerPlayer.cityCard.ChangeCardStrength(-field.GetArmorCard().AttackOfCard);
                }
                else
                {                                                                                       //If occupied by AI - dealing damage to player
                    player1.cityCard.ChangeCardStrength(-field.GetArmorCard().AttackOfCard);
                }
            }
            if (nameOfPlayerInfantry != null)
            {
                if (nameOfPlayerInfantry == player1.playerName)
                {
                    computerPlayer.cityCard.ChangeCardStrength(-field.GetInfantryCard().AttackOfCard);
                }
                else
                {
                    player1.cityCard.ChangeCardStrength(-field.GetInfantryCard().AttackOfCard);
                }
            }                   
            if (!isVictory())
            {
                EndTurnEvent(this, new EventArgs());
            }
            else
            {
                PlayerWon();
            }         
        }

        public void Main()
        {
            SetUpGame();
            PlayerStartNewTurn();
        }


        /// <summary>
        /// Func checks if one of the players won
        /// </summary>
        /// <returns>true if won, false if not</returns>
        private bool isVictory()
        {
            bool isVictory = false;
            if (player1.cityCard.StrengthOfCard <= 0)               //If players city cards stength is 0 or less - isVictory = true
            {   
                isVictory = true;
            }
            if (computerPlayer.cityCard.StrengthOfCard <= 0)
            {
                isVictory = true;
            }
            return isVictory;           
        }

        /// <summary>
        /// Func sets victory events
        /// </summary>
        public void PlayerWon()
        {
            string wonPlayer = null;
            if (player1.cityCard.StrengthOfCard <= 0)                   //if player's city card strength <= 0 - AI won
            {
                wonPlayer = computerPlayer.playerName;
                if (computerPlayer.cityCard.StrengthOfCard <= 0)        //if both players city card strength <= 0 - Draw
                {
                    wonPlayer = "DRAW";
                }                
            }
            else
            {
                if (computerPlayer.cityCard.StrengthOfCard <= 0)        //If AI city card strength <=0 - player won
                {
                    wonPlayer = player1.playerName;                    
                }
            }
            VictoryEvent(this, new VictoryEventArgs(wonPlayer));
        }
        
    }
}
