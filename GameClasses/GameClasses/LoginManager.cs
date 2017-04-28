using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClasses
{
    /// <summary>
    /// Manager in main menu of game 
    /// </summary>
    public class LoginManager
    {
        public LoginManager()
        {
            _sql.UserCreated += UserCreatedEventHandler;
            _sql.DeckCreated += DeckCreatedEventHandler;
        }

        public event Action UserCreateSuccess;
        public event Action DeckCreateSuccess;



        /// <summary>
        /// Func directs new user to sql manager to add
        /// </summary>
        /// <param name="user">user to add</param>
        public void AddUser(User user)
        {
            _sql.AddNewUser(user);
        }

        /// <summary>
        /// Func directs login to sql manager to check if it is already used
        /// </summary>
        /// <param name="login">user login</param>
        /// <returns>true if used, false if not</returns>
        public bool IsLoginUsed(string login)
        {
            return _sql.IfLogInUsed(login);
        }

        /// <summary>
        /// Func directs login and pass to sql manager to validate user
        /// </summary>
        /// <param name="userLogin">user login</param>
        /// <param name="userPass">user password</param>
        /// <returns>true if validated, false if not</returns>
        public bool IsUserValidated(string userLogin, string userPass)
        {
            return _sql.UserValidated(userLogin, userPass);
        }

        /// <summary>
        /// Func sets player after validation
        /// </summary>
        /// <param name="userLogin">user login</param>
        public void SetPlayer(string userLogin)
        {
            User usr = _sql.GetUser(userLogin);
            _plyr = new Player();
            _plyr.playerName = usr.login;
            _plyr.Points = usr.points;
        }
        public void SetPlayerDeck(Deck deck)
        {
            _plyr.playerDeck = (Deck)deck.Clone();
            _plyr.cityCard = _plyr.playerDeck.CityCard;
        }

        /// <summary>
        /// Func sets AI player
        /// </summary>
        /// <returns></returns>
        public GameManager SetUpNewGame()
        {
            Player AIPlayer = new Player();
            AIPlayer.playerName = "Computer";
            AIPlayer.playerDeck = _sql.GetDeck("Computer", SQLManager.ALL_CARDS_DECK);
            AIPlayer.cityCard = AIPlayer.playerDeck.cardsInCollection[0];
            GameManager _mng = new GameManager(_plyr, AIPlayer);
            return _mng;
        }

        /// <summary>
        /// Func updates player points
        /// </summary>
        /// <param name="playerName">Player name</param>
        /// <param name="pointsDelta">Point difference</param>
        public void UpdatePoints(string playerName, int pointsDelta)
        {
            _sql.UpdatePoints(playerName, pointsDelta);
        }

        /// <summary>
        /// Func returns current logined players decks
        /// </summary>
        /// <returns>Player's decks</returns>
        public List<Deck> GetDecks()
        {
           return _sql.GetDecks(_plyr.playerName);
        }

        /// <summary>
        /// Func returns current logined players deck
        /// </summary>
        /// <param name="deckName">Name of deck to return</param>
        /// <returns>Specified deck of player</returns>
        public Deck GetDeck(string deckName)
        {
            return _sql.GetDeck(_plyr.playerName, deckName);
        }

        /// <summary>
        /// Func adds Deck to database
        /// </summary>
        /// <param name="newDeck">name of new deck</param>
        public void AddNewDeck(Deck newDeck)
        {
            _sql.AddNewDeck(newDeck, _plyr.playerName);
        }

        /// <summary>
        /// Func deletes deck from db
        /// </summary>
        /// <param name="deckName">Name of deck to delete</param>
        public void Deletedeck(string deckName)
        {
            _sql.DeleteDeck(deckName, _plyr.playerName);
        }

        public void UserCreatedEventHandler()
        {
            UserCreateSuccess();
        }

        public void DeckCreatedEventHandler()
        {
            DeckCreateSuccess();
        }

        public Player Player
        {
            get
            {
                return _plyr;
            }
        }



        private Player _plyr;
        private SQLManager _sql = new SQLManager();
    }
}
