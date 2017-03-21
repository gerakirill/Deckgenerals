using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClasses;

namespace DeckGenerals
{
    class Controller
    {
        /// <summary>
        /// Class controller ctor
        /// </summary>
        /// <param name="UI">Userinterface</param>
        public Controller(UserInterface UI)
        {
            _UI = UI;
            _field = new Field();
            _UI.ProceedClickEvent += ProceedClickEventHandler;
            _UI.PictureClickEvent += PictureClickEventHandler;
            _UI.NoCardsLeftEvent += NoCardsEventHandler;
            _UI.EndTurnClickEvent += PlayerEndTurnEventHandler;
        }
        /// <summary>
        /// By "Procced" button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProceedClickEventHandler(object sender, ChoosePlayerNameEventArgs e)
        {
            MyPictureBox pctBox = sender as MyPictureBox;
            CreatePlayers(e._playerName);
            Deck cityDeck = CreateDeck("city");             //creating a deck with only city cards
            _UI.SetActivePage(Pages.tabpg_draftmenu);
            _UI.ShowCards(cityDeck.cardsInCollection);
        //    _UI.UpdateVisual(_field.GetArmorCard(), _field.GetInfantryCard(), _player1.cityCard.StrengthOfCard, _computerPlayer.cityCard.StrengthOfCard,
         //      _player1.resourceQuantity, _computerPlayer.resourceQuantity, _field.armorOccupiedByPlayer, _field.infantryOccupiedByPlayer,
           //    _computerPlayer.playerHand.cardsInCollection.Count);
        }


        /// <summary>
        /// By Picture click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureClickEventHandler(object sender, EventArgs e)
        {
            MyPictureBox pctBox = sender as MyPictureBox;
            if (pctBox._card.TypeOfCard == CardTypes.city)
            {
                this.PlayCard(pctBox._card, _player1);      //if the card is city card - play it
            }
            else
            {
                if (_gameStarted == false)                  //if the game is not stated - then it's a draft, so we adding cards to our deck
                {
                    int copiesInDeck = 4;                   //Copies if card to add into a deck
                    _UI.AddToLog(_player1.playerName + " picked " + pctBox._card.NameOfCard);
                    for (int i = 0; i < copiesInDeck; i++)
                    {
                        _player1.playerDeck.FillPlayersDeck(pctBox._card);
                    }                    
                    _UI.ShowLastPlayedCard(pctBox._card);
                    _UI.RemoveCard(pctBox);
                    Random rnd = new Random();
                    ComputerPlayerDraft(rnd);               //Letting compute plaer to draft
                }
                else                                        //If game started, we check if card can be played, if true - play it
                {
                    if (_player1.CanBePlayed(pctBox._card))
                    {
                        this.PlayCard(pctBox._card, _player1);
                        _UI.RemoveCard(pctBox);
                    }

                }
            }
        }

        /// <summary>
        /// Start main game stage
        /// </summary>
        private void StartGame()
        {
            _gameStarted = true;        //Changing game status to "true"
            _UI.SetActivePage(Pages.tabpg_gamemenu);
            _UI.SetCityVisual(_player1.cityCard, _computerPlayer.cityCard);
            int shuffleNumber = 4;      //Number of times we shuffle our deck
            int startCardsInHand = 4;   //Number of cards in hand on start game
            for (int i = 0; i < shuffleNumber; i++)
            {
                _player1.playerDeck.ShuffleDeck();
                _computerPlayer.playerDeck.ShuffleDeck();
            }
            for (int i = 0; i < startCardsInHand; i++)
            {
                _player1.playerHand.AddCardFromDeck(ref _player1.playerDeck);
                _computerPlayer.playerHand.AddCardFromDeck(ref _computerPlayer.playerDeck);
            }
            StartNewTurn();
        }

        /// <summary>
        /// Func creates deck with specific card types
        /// </summary>
        /// <param name="deckType">type of cards to include into deck</param>
        /// <returns></returns>
        private Deck CreateDeck(string deckType)
        {
            Deck cardsDeck = new Deck();
            List<Card> allcards = cardsDeck.CreateCards();
            cardsDeck.FillDeck(deckType, allcards);
            return cardsDeck;
        }

        /// <summary>
        /// Func create players
        /// </summary>
        /// <param name="name">Name of player</param>
        private void CreatePlayers(string name)
        {
            _player1.playerName = name;
            _player1.playerDeck = new Deck();
            _player1.playerHand = new Hand();
            _player1.resourceQuantity = 0;
            _computerPlayer.playerName = "Computer";
            _computerPlayer.playerDeck = new Deck();
            _computerPlayer.playerHand = new Hand();
            _computerPlayer.resourceQuantity = 0;
        }

        /// <summary>
        /// Func starts the draft stage of game
        /// </summary>
        private void StartDraft()
        {
            Deck draftDeck = CreateDeck("playerdeck");       //Creating a deck with all cards excluding "city" and "scene" cards            
            int shuffleNumber = 4;                           //Number of deck shuffles
            for (int i = 0; i < shuffleNumber; i++)
            {
                draftDeck.ShuffleDeck();                    
            }
            _UI.ShowCards(draftDeck.cardsInCollection);
        }

        /// <summary>
        /// Compute player draft
        /// </summary>
        /// <param name="rnd"></param>
        private void ComputerPlayerDraft(Random rnd)
        {
            int copiesInDeck = 4;
            List<MyPictureBox> availableCards = new List<MyPictureBox>(0);  
            foreach (MyPictureBox card in _UI.Cards)                  //Getting the available cads to draft
            {
                availableCards.Add(card);
            }
            int randomChoose = rnd.Next(0, availableCards.Count);      //Randomly choosing cards from available
            if (availableCards.Count > 0)
            {
                for (int i = 0; i < copiesInDeck; i++)
                {
                    _computerPlayer.playerDeck.FillPlayersDeck(availableCards[randomChoose]._card);
                }                
                _UI.AddToLog(_computerPlayer.playerName + " picked " + availableCards[randomChoose]._card.NameOfCard);
                _UI.RemoveCard(availableCards[randomChoose]);
            }            
        }


        /// <summary>
        /// Func starts new game turn
        /// </summary>
        private void StartNewTurn()
        {
            _player1.resourceQuantity++;                                    //Adding rosources
            _player1.playerHand.AddCardFromDeck(ref _player1.playerDeck);   //Taking a card from deck
            _UI.RemoveAllCards();
            _UI.ShowCards(_player1.playerHand.cardsInCollection);
            _UI.StartTurn();
            _UI.UpdateVisual(_field.GetArmorCard(), _field.GetInfantryCard(), _player1.cityCard.StrengthOfCard, _computerPlayer.cityCard.StrengthOfCard,
                _player1.resourceQuantity, _computerPlayer.resourceQuantity, _field.armorOccupiedByPlayer, _field.infantryOccupiedByPlayer,
                _computerPlayer.playerHand.cardsInCollection.Count);
        }

        /// <summary>
        /// Func makes computer player move
        /// </summary>
        private void AIMove()
        {
            _computerPlayer.resourceQuantity++;                                             //Adding resources
            _computerPlayer.playerHand.AddCardFromDeck(ref _computerPlayer.playerDeck);     //Taking card fom deck
            for (int i = 0; i < _computerPlayer.playerHand.numberOfCards; i++)
            {
                if (_computerPlayer.CanBePlayed(_computerPlayer.playerHand.cardsInCollection[i])) //playing every card, which is possible
                {
                    this.PlayCard(_computerPlayer.playerHand.cardsInCollection[i], _computerPlayer);
                    break;
                }
            }
            EndTurn();
            StartNewTurn();
        }

        /// <summary>
        /// Func peforms action depending on what playe which card played
        /// </summary>
        /// <param name="card">Played card</param>
        /// <param name="player">Player that played</param>
        private void PlayCard(Card card, Player player)
        {
            switch (card.TypeOfCard)
            {
                case CardTypes.empty:
                    break;
                case CardTypes.city:
                    player.cityCard = (Card)card.Clone();                    
                    _computerPlayer.cityCard = (Card)card.Clone();                    
                    _UI.ShowLastPlayedCard(card);
                    _UI.RemoveAllCards();
                    _UI.SetCityVisual(_player1.cityCard, _computerPlayer.cityCard);
                    StartDraft();
                    break;
                case CardTypes.resource:
                    break;
                case CardTypes.scene:
                    break;
                case CardTypes.armor:
                    _field.CardPlayed((Card)card.Clone(), player.playerName);
                    _UI.ShowLastPlayedCard((Card)card.Clone());
                    _UI.AddToLog(player.playerName + " played " + card.NameOfCard);
                    player.playerHand.RemoveCard(card);
                    break;
                case CardTypes.material:
                    break;
                case CardTypes.infantry:
                    _field.CardPlayed((Card)card.Clone(), player.playerName);
                    _UI.ShowLastPlayedCard((Card)card.Clone());
                    _UI.AddToLog(player.playerName + " played " + card.NameOfCard);
                    player.playerHand.RemoveCard(card);
                    break;
                default:
                    break;
            }
            player.resourceQuantity -= card.ResOfCard;
            _UI.UpdateVisual(_field.GetArmorCard(), _field.GetInfantryCard(), _player1.cityCard.StrengthOfCard, _computerPlayer.cityCard.StrengthOfCard,
                _player1.resourceQuantity, _computerPlayer.resourceQuantity, _field.armorOccupiedByPlayer, _field.infantryOccupiedByPlayer,
                _computerPlayer.playerHand.cardsInCollection.Count);
        }

        private void PlayerEndTurnEventHandler()
        {
            EndTurn();
            AIMove();
        }

        /// <summary>
        /// Func ends turn and deals damage to players, dependan on what player occupied field
        /// </summary>
        private void EndTurn()
        {
            string nameOfPlayerArmor = _field.armorOccupiedByPlayer;
            string nameOfPlayerInfantry = _field.infantryOccupiedByPlayer;
            if (nameOfPlayerArmor != null)
            {
                if (nameOfPlayerArmor == _player1.playerName)
                {
                    _computerPlayer.cityCard.ChangeCardStrength(-_field.GetArmorCard().AttackOfCard);
                }
                else
                {
                    _player1.cityCard.ChangeCardStrength(-_field.GetArmorCard().AttackOfCard);
                }
            }
            if (nameOfPlayerInfantry != null)
            {
                if (nameOfPlayerInfantry == _player1.playerName)
                {
                    _computerPlayer.cityCard.ChangeCardStrength(-_field.GetInfantryCard().AttackOfCard);
                }
                else
                {
                    _player1.cityCard.ChangeCardStrength(-_field.GetInfantryCard().AttackOfCard);
                }
            }
            _UI.UpdateVisual(_field.GetArmorCard(), _field.GetInfantryCard(), _player1.cityCard.StrengthOfCard, _computerPlayer.cityCard.StrengthOfCard,
                _player1.resourceQuantity, _computerPlayer.resourceQuantity, _field.armorOccupiedByPlayer, _field.infantryOccupiedByPlayer,
                _computerPlayer.playerHand.cardsInCollection.Count);
        }


        private void NoCardsEventHandler()
        {
            if (_gameStarted == true)
            {

            }
            else
            {
                StartGame();
            }
        }


        private Player _player1 = new Player();             //Player1
        private Player _computerPlayer = new Player();      //Computer player
        private UserInterface _UI;                          //Use Interface
        private bool _gameStarted = false;                  //Main stage of game is started
        private Field _field;                               //Game field
    }
}
