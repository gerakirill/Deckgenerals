using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClasses;
using System.Windows.Forms;

namespace UserInterface
{
    /// <summary>
    /// Supreme Controller class
    /// </summary>
    public class LoginController
    {
        
        public LoginController (MainMenuInterface UI, LoginManager mngr)
        {
            _mainMenuI = UI;            
            _mainMenuI.StartGameVSAIEvent += StartGameVSAIEventHndler;
            _mainMenuI.CreateNewPlayerEvent += CreateNewPlayerEventHandler;
            _mainMenuI.DeckManagerStartEvent += DeckManagerStartEventHandler;
            _mainMenuI.QuitEvent += QuitEventHandler;
            _mainMenuI.LogInPlayerEvent += LogInPlayerEventHandler;
            _mainMenuI.DeckClickEvent += DeckClickEventHandler;
            _mainMenuI.ShopStartEvent += ShopStartEventHandler;

            _logInManager = mngr;
            _logInManager.UserCreateSuccess += CreateSuccessEventHandler;
            _logInManager.DeckCreateSuccess += CancelNewDeckEventHandler;

        }
        #region Deck manager event handlers


        /// <summary>
        /// Go back to main menu
        /// </summary>
        private void ConfirmClickEventEventHandler()
        {
            _mainMenuI.SetActivePage(Pages.tabpg_loginmenu);
            _mainMenuI.Visible = true;
            _gameI.Close();
        }

        /// <summary>
        /// Deck manager launch event handler
        /// </summary>
        private void DeckManagerStartEventHandler()
        {
            _mainMenuI.Visible = false;
            _deckMangerI = new DeckManagerInterface();
            _deckMangerI.CreateNewDeckEvent += CreateNewDeckEventHandler;
            _deckMangerI.PictureClickEvent += PictureClickEventHandler;
            _deckMangerI.SubmitNewDeckEvent += SubmitNewDeckEventHandler;
            _deckMangerI.CancelNewDeckEvent += CancelNewDeckEventHandler;
            _deckMangerI.DeleteDeckEvent += DeleteDeckEventHandler;
            _deckMangerI.ReturnEvent += ReturnEbentHandler;
            _deckMangerI.Show();
            _deckMangerI.ShowDecks(_logInManager.GetDecks());
        }

        /// <summary>
        /// Click on picture - adds card to deck
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureClickEventHandler(object sender, EventArgs e)
        {
            MyPictureBox pct = sender as MyPictureBox;
            if (_temp.CanBeAdded(pct._card))
            {
                _temp.AddWithRestrictions(pct._card);
                _deckMangerI.AddCardToList(pct._card);
                _deckMangerI.RemoveCard(pct);
            }
            else
            {
                _deckMangerI.ShowMessage("Cannot add card, maximum limit exceeded");
            }

        }

        /// <summary>
        /// Cancelling new deck create 
        /// </summary>
        private void CancelNewDeckEventHandler()
        {
            _temp = null;
            _deckMangerI.ButtonChange();
            _deckMangerI.RemoveCardPictures();
            _deckMangerI.ShowDecks(_logInManager.GetDecks());
        }

        /// <summary>
        /// Creating new deck
        /// </summary>
        private void CreateNewDeckEventHandler()
        {
            _temp = new Deck();
            _deckMangerI.RemoveDeckPictures();
            _deckMangerI.ButtonChange();
            _deckMangerI.ShowCards(_logInManager.GetDeck(SQLManager.ALL_CARDS_DECK));
        }

        /// <summary>
        /// Submitting new deck with restrictions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitNewDeckEventHandler(object sender, CreateDeckEventargs e)
        {
            _temp.DeckName = e.NameOfDeck;
            if (_temp.CityCard != null && _temp.cardsInCollection.Count >= MIN_CARD_NUMBER_IN_DECK && _temp.DeckName != null)
            {
                _logInManager.AddNewDeck(_temp);
            }
            else
            {
                _deckMangerI.ShowMessage("Could not create deck");
            }
        }
        /// <summary>
        /// Deleting deck
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteDeckEventHandler(object sender, EventArgs e)
        {
            DeckPictureBox pct = sender as DeckPictureBox;
            _logInManager.Deletedeck(pct.Deck.DeckName);
            _deckMangerI.RemoveDeckPictures();
            _deckMangerI.ShowDecks(_logInManager.GetDecks());
        }

        /// <summary>
        /// Return to main menu
        /// </summary>
        private void ReturnEbentHandler()
        {
            _mainMenuI.Visible = true;
            _deckMangerI.Close();
        }
        #endregion

        #region Shop event handlers
        /// <summary>
        /// Shop launch event handler
        /// </summary>
        private void ShopStartEventHandler()
        {
            ShopManager shop = new ShopManager();
            _shopI = new ShopInterface();
            ShopController ctrl = new ShopController(_logInManager.Player, _shopI);
            ctrl.QuitShopEvent += QuitShopEventHandler;
            _mainMenuI.Visible = false;
            _shopI.Show();
        }
        /// <summary>
        /// Return to main menu
        /// </summary>
        private void QuitShopEventHandler()
        {
            _logInManager.SetPlayer(_logInManager.Player.playerName);
            _mainMenuI.Visible = true;
            _shopI.Close();
        }
        #endregion


        #region Main Menu Event handler

        /// <summary>
        /// Game start event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeckClickEventHandler(object sender, EventArgs e)
        {
            DeckPictureBox picture = sender as DeckPictureBox;
            _logInManager.SetPlayerDeck(picture.Deck);
            GameManager gm = _logInManager.SetUpNewGame();
            _gameI = new GameMenuInterface();
            _gameI.ConfirmClickEvent += ConfirmClickEventEventHandler;
            _gameI.SetGameManager(gm);
            GameController cntrl = new GameController(_gameI, gm);
            cntrl.AddPointsEvent += AddPointsEventHandler;
            cntrl.SetUpGame();
            _mainMenuI.Visible = false;
            _gameI.Show();
        }
        /// <summary>
        /// Quit
        /// </summary>
        private void QuitEventHandler()
        {
            _mainMenuI.Close();
        }
        
        /// <summary>
        /// If player wins - adding victory points to his profile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPointsEventHandler(object sender, VictoryEventArgs e)
        {
            _logInManager.UpdatePoints(_logInManager.Player.playerName, VICTORY_POINTS);
            _logInManager.SetPlayer(_logInManager.Player.playerName);
        }
        
        /// <summary>
        /// If player register is seccesful - go back to main menu start page
        /// </summary>
        private void CreateSuccessEventHandler()
        {
            _mainMenuI.SetActivePage(Pages.tabpg_mainmenu);
        }

        /// <summary>
        /// Setting up new game vs AI
        /// </summary>
        private void StartGameVSAIEventHndler()
        {
            _mainMenuI.RemoveDecks();
            _mainMenuI.SetActivePage(Pages.tabpg_selectdeck);            
            _mainMenuI.ShowDecks(_logInManager.GetDecks());            
        }

        /// <summary>
        /// Checks player login and password to match database values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogInPlayerEventHandler(object sender, LogInPlayerEventArgs e)
        {
            string login = e.playerLogin.Trim();
            string pwd = e.playerPassword.Trim();
            if (login == "")
            {
                _mainMenuI.ShowMessage("You must enter login");
            }
            else
            {
                if (pwd == "")
                {
                    _mainMenuI.ShowMessage("You must enter password");
                }
                else
                {
                    if (_logInManager.IsUserValidated(login, pwd))
                    {
                        _logInManager.SetPlayer(login);
                        _mainMenuI.SetActivePage(Pages.tabpg_loginmenu);                        
                    }
                    else
                    {
                        _mainMenuI.ShowMessage("Log in failed");
                    }
                }
            }
        }
        
        private void CreateNewPlayerEventHandler(object sender, CreateNewPlayerEventArgs e)
        {
            string logIn = e.playerLogin.Trim();
            string pwd = e.playerPassword.Trim();
            string eMail = e.playerEmail.Trim();
            if (logIn == "")
            {
                _mainMenuI.ShowMessage("You must enter login");
            }
            else
            {
                if (eMail == "")
                {
                    _mainMenuI.ShowMessage("You must enter email");
                }
                else
                {
                    if (pwd == "")
                    {
                        _mainMenuI.ShowMessage("You must enter password");
                    }
                    else
                    {
                        if (_logInManager.IsLoginUsed(logIn))
                        {
                            User newUser = new User() { login = logIn, pass = pwd, email = eMail };
                            _logInManager.AddUser(newUser);
                        }
                        else
                        {
                            _mainMenuI.ShowMessage("Player with such login exists");
                        }
                    }
                }
            }
        }
        #endregion


        private const int MIN_CARD_NUMBER_IN_DECK = 10;         //Minimum number of cards in deck
        private const int VICTORY_POINTS = 5;                   //Points added to player in case of his victory
        private LoginManager _logInManager;
        private MainMenuInterface _mainMenuI;
        private DeckManagerInterface _deckMangerI;
        private GameMenuInterface _gameI;
        private ShopInterface _shopI;
        private Deck _temp;

    }
}
