using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClasses
{
    /// <summary>
    /// Manager in main menu of gme 
    /// </summary>
    public class LoginManager
    {
        public LoginManager()
        {
            _sql.UserCreated += UserCreatedEventHandler;
        }

        public void UserCreatedEventHandler()
        {
            CreateSuccess();
        }        
         
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
            _plyr = new Player();
            _plyr.playerName = userLogin;
            _plyr.playerDeck = new Deck();
            _plyr.playerDeck = _sql.GetDeck(userLogin, "First");
            _plyr.cityCard = _plyr.playerDeck.cardsInCollection[0];
        }

        /// <summary>
        /// Func gets player deck and sets players
        /// </summary>
        /// <returns></returns>
        public GameManager SetUpNewGame()
        {
            Player AIPlayer = new Player();           
            AIPlayer.playerName = "Computer";
            AIPlayer.playerDeck = _sql.GetDeck("Computer", "First");
            AIPlayer.cityCard = AIPlayer.playerDeck.cardsInCollection[0];
            GameManager _mng = new GameManager(_plyr, AIPlayer);
            return _mng;
        }

        public event Action CreateSuccess;

        private Player _plyr;
        private SQLManager _sql = new SQLManager();
    }
}
