using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClasses
{
   
    public delegate void VictorySetter (object sender, VictoryEventArgs args);
    public delegate void CardPlayer(object sender, CardPlayedEventArgs args);

    public class VictoryEventArgs
    {
        public VictoryEventArgs(string whoWon)
        {
            _whoWon = whoWon;
        }
        public string _whoWon { get; private set; }
    }

    public class CardPlayedEventArgs
    {
        public CardPlayedEventArgs(Card card)
        {
            _card = (Card)card.Clone();
        }
        public Card _card;
    }

    public class GameManager
    {
        public GameManager(Player player, Player computerPlayer)
        {
            field = new Field();
            player1 = player;            
            this.computerPlayer = computerPlayer;

        }

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
                CardPlayedEvent(this, new CardPlayedEventArgs(card));
            }  
        }

        /// <summary>
        /// Func plays and removes card from computer Deck 
        /// </summary>
        /// <param name="card">Card to play</param>
        public void ComputerPlayCard(Card card)
        {
            if (computerPlayer.CanBePlayed(card))
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
                CardPlayedEvent(this, new CardPlayedEventArgs(card));
            }
        }

        /// <summary>
        /// Start main game stage
        /// </summary>
        private void SetUpGame()
        {
            for (int i = 0; i < SHUFFLE_NUMBER; i++)
            {
                player1.playerDeck.ShuffleDeck();
                computerPlayer.playerDeck.ShuffleDeck();
            }
            for (int i = 0; i < IN_HAND_START_CARDS_NUMBER; i++)
            {
                player1.playerHand.AddCardFromDeck(player1.playerDeck);
                computerPlayer.playerHand.AddCardFromDeck(computerPlayer.playerDeck);
            }
            player1.resourceQuantity = 0;
            computerPlayer.resourceQuantity = 0;
            GameSetUpEvent(this, new EventArgs());
        } 

        /// <summary>
        /// Func starts new game turn
        /// </summary>
        private void PlayerStartNewTurn()
        {            
            player1.resourceQuantity++;                                    //Adding rosources
            player1.playerHand.AddCardFromDeck(player1.playerDeck);   //Taking a card from deck
            PlayerStartNewTurnEvent(this, new EventArgs());
        }

        public void AIStartNewTurn()
        {
            computerPlayer.resourceQuantity++;                                    //Adding rosources
            computerPlayer.playerHand.AddCardFromDeck(computerPlayer.playerDeck);   //Taking a card from deck
            StartNewTurnEvent(this, new EventArgs());
            AIMove();
        }

        /// <summary>
        /// Func makes computer player move
        /// </summary>
        private void AIMove()
        {            
            for (int i = 0; i < computerPlayer.playerHand.cardsInCollection.Count; i++)
            {
                if (computerPlayer.CanBePlayed(computerPlayer.playerHand.cardsInCollection[i])) //playing every card, which is possible
                {
                    ComputerPlayCard(computerPlayer.playerHand.cardsInCollection[i]);
                    break;
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
            if (nameOfPlayerArmor != null)
            {
                if (nameOfPlayerArmor == player1.playerName)
                {
                    computerPlayer.cityCard.ChangeCardStrength(-field.GetArmorCard().AttackOfCard);
                }
                else
                {
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
            if (player1.cityCard.StrengthOfCard <= 0)
            {   
                isVictory = true;
            }
            if (computerPlayer.cityCard.StrengthOfCard <= 0)
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
            if (player1.cityCard.StrengthOfCard <= 0)
            {
                wonPlayer = computerPlayer.playerName;
                if (computerPlayer.cityCard.StrengthOfCard <= 0)
                {
                    wonPlayer = "DRAW";
                }                
            }
            else
            {
                if (computerPlayer.cityCard.StrengthOfCard <= 0)
                {
                    wonPlayer = player1.playerName;                    
                }
            }
            VictoryEvent(this, new VictoryEventArgs(wonPlayer));
        }

       
        public Player player1;                              //Player1
        public Player computerPlayer ;                      //Computer player        
        public Field field;                                 //Game field
        public const int SHUFFLE_NUMBER = 4;                //Number of shuffles
        public const int IN_HAND_START_CARDS_NUMBER = 4;    //Number of cards in hand on the start     
    }
}
