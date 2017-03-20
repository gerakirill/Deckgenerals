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

        public Controller(UserInterface UI)
        {
            _UI = UI;
            _field = new Field();
            _UI.ProceedClickEvent += ProceedClickEventHandler;
            _UI.PictureClickEvent += PictureClickEventHandler;
            _UI.NoCardsLeftEvent += NoCardsEventHandler;
            _UI.EndTurnClickEvent += PlayerEndTurnEventHandler;
        }
        private void ProceedClickEventHandler(object sender, ChoosePlayerNameEventArgs e)
        {
            MyPictureBox pctBox = sender as MyPictureBox;
            CreatePlayers(e._playerName);
            Deck cityDeck = CreateDeck("city");
            _UI.SetActivePage(1);
            _UI.ShowCards(cityDeck.cardsInCollection);
            _UI.UpdateVisual(_field.GetArmorCard(), _field.GetInfantryCard(), _player1.cityStrength, _computerPlayer.cityStrength,
                _player1.resourceQuantity, _computerPlayer.resourceQuantity, _field.armorOccupiedByPlayer, _field.infantryOccupiedByPlayer,
                _computerPlayer.playerHand.cardsInCollection.Count);
        }
        private void PictureClickEventHandler(object sender, EventArgs e)
        {
            MyPictureBox pctBox = sender as MyPictureBox;
            if (pctBox._card.TypeOfCard.HasFlag(CardTypes.city))
            {
                this.PlayCard(pctBox._card, _player1);
            }
            else
            {
                if (_gameStarted == false)
                {
                    _UI.AddToLog(_player1.playerName + " picked " + pctBox._card.NameOfCard);
                    _player1.playerDeck.FillPlayersDeck(pctBox._card);
                    _UI.ShowLastPlayedCard(pctBox._card);
                    _UI.RemoveCard(pctBox);
                    Random rnd = new Random();
                    ComputerPlayerDraft(rnd);
                }
                else
                {
                    if (_player1.CanBePlayed(pctBox._card))
                    {
                        this.PlayCard(pctBox._card, _player1);
                        _UI.RemoveCard(pctBox);
                    }

                }
            }
        }
        private void StartGame()
        {
            _gameStarted = true;
            _UI.SetActivePage(2);
            _UI.ShowCityCards(_player1.cityCard, _computerPlayer.cityCard);
            int shuffleNumber = 4;
            int startCardsInHand = 4;
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

        private Deck CreateDeck(string deckType)
        {
            Deck cardsDeck = new Deck();
            List<Card> allcards = cardsDeck.CreateCards();
            cardsDeck.FillDeck(deckType, allcards);
            return cardsDeck;
        }

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

        private void StartDraft()
        {
            Deck allDeck = CreateDeck("playerdeck");
            Deck draftDeck = new Deck();
            int shuffleNumber = 4;
            foreach (Card card in allDeck)
            {
                draftDeck.FillPlayersDeck(card);
            }
            for (int i = 0; i < shuffleNumber; i++)
            {
                draftDeck.ShuffleDeck();
            }
            _UI.ShowCards(draftDeck.cardsInCollection);
        }

        private void ComputerPlayerDraft(Random rnd)
        {
            List<MyPictureBox> availableCards = new List<MyPictureBox>(0);
            foreach (MyPictureBox card in _UI.Cards)
            {
                availableCards.Add(card);
            }
            int randomChoose = rnd.Next(0, availableCards.Count);
            _computerPlayer.playerDeck.FillPlayersDeck(availableCards[randomChoose]._card);
            _UI.AddToLog(_computerPlayer.playerName + " picked " + availableCards[randomChoose]._card.NameOfCard);
            _UI.RemoveCard(availableCards[randomChoose]);
        }

        private void StartNewTurn()
        {
            _player1.resourceQuantity++;
            _player1.playerHand.AddCardFromDeck(ref _player1.playerDeck);
            _UI.RemoveAllCards();
            _UI.ShowCards(_player1.playerHand.cardsInCollection);
            _UI.StartTurn();
            _UI.UpdateVisual(_field.GetArmorCard(), _field.GetInfantryCard(), _player1.cityStrength, _computerPlayer.cityStrength,
                _player1.resourceQuantity, _computerPlayer.resourceQuantity, _field.armorOccupiedByPlayer, _field.infantryOccupiedByPlayer,
                _computerPlayer.playerHand.cardsInCollection.Count);
        }
        private void AIMove()
        {
            _computerPlayer.resourceQuantity++;
            _computerPlayer.playerHand.AddCardFromDeck(ref _computerPlayer.playerDeck);
            for (int i = 0; i < _computerPlayer.playerHand.numberOfCards; i++)
            {
                if (_computerPlayer.CanBePlayed(_computerPlayer.playerHand.cardsInCollection[i]))
                {
                    this.PlayCard(_computerPlayer.playerHand.cardsInCollection[i], _computerPlayer);
                    break;
                }
            }
            EndTurn();
            StartNewTurn();
        }
        private void PlayCard(Card card, Player player)
        {
            switch (card.TypeOfCard)
            {
                case CardTypes.empty:
                    break;
                case CardTypes.city:
                    player.cityCard = (Card)card.Clone();
                    player.cityStrength = _player1.cityCard.AbilityValOfCard;
                    _computerPlayer.cityCard = (Card)card.Clone();
                    _computerPlayer.cityStrength = _player1.cityCard.AbilityValOfCard;
                    _UI.ShowLastPlayedCard(card);
                    _UI.RemoveAllCards();
                    //  _UI.ShowCityCards(_player1.cityCard, _computerPlayer.cityCard);
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
            _UI.UpdateVisual(_field.GetArmorCard(), _field.GetInfantryCard(), _player1.cityStrength, _computerPlayer.cityStrength,
                _player1.resourceQuantity, _computerPlayer.resourceQuantity, _field.armorOccupiedByPlayer, _field.infantryOccupiedByPlayer,
                _computerPlayer.playerHand.cardsInCollection.Count);
        }

        private void PlayerEndTurnEventHandler()
        {
            EndTurn();
            AIMove();
        }

        private void EndTurn()
        {
            string nameOfPlayerArmor = _field.armorOccupiedByPlayer;
            string nameOfPlayerInfantry = _field.infantryOccupiedByPlayer;
            if (nameOfPlayerArmor != null)
            {
                if (nameOfPlayerArmor == _player1.playerName)
                {
                    _computerPlayer.cityStrength -= _field.GetArmorCard().AttackOfCard;
                }
                else
                {
                    _player1.cityStrength -= _field.GetArmorCard().AttackOfCard;
                }
            }
            if (nameOfPlayerInfantry != null)
            {
                if (nameOfPlayerInfantry == _player1.playerName)
                {
                    _computerPlayer.cityStrength -= _field.GetInfantryCard().AttackOfCard;
                }
                else
                {
                    _player1.cityStrength -= _field.GetInfantryCard().AttackOfCard;
                }
            }
            _UI.UpdateVisual(_field.GetArmorCard(), _field.GetInfantryCard(), _player1.cityStrength, _computerPlayer.cityStrength,
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


        private Player _player1 = new Player();
        private Player _computerPlayer = new Player();
        private UserInterface _UI;
        private bool _gameStarted = false;
        private Field _field;
    }
}
