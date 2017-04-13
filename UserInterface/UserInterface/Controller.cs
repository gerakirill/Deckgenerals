using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClasses;




namespace UserInterface
{
    class Controller
    {
        /// <summary>
        /// Class controller ctor
        /// </summary>
        /// <param name="UI">Userinterface</param>
        public Controller(UserInterface UI, GameManager mngr)
        {
            _UI = UI;
            _UI.PictureClickEvent += PictureClickEventHandler;
            //_UI.NoCardsLeftEvent += NoCardsEventHandler;
            _UI.EndTurnClickEvent += PlayerEndTurnEventHandler;
            //_UI.PlayAgainEvent += SetUpNewGame;
            _UI.QuitEvent += QuitEventHandler;
            _mngr = mngr;           

        }
        /// <summary>
        /// By Picture click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureClickEventHandler(object sender, EventArgs e)
        {
            MyPictureBox pctBox = sender as MyPictureBox;
            _mngr.PlayerPlayCard(pctBox._card); 
        }

        /// <summary>
        /// Player end turn
        /// </summary>
        private void PlayerEndTurnEventHandler()
        {
            _mngr.PlayerEndTurn();
            
        }
        
        private void QuitEventHandler()
        {
            Environment.Exit(0);
        }

        public void SetUpGame()
        {
            _mngr.Main();
        }



        private UserInterface _UI;      //User Interafce
        private GameManager _mngr;      //Game manager
    }
}
