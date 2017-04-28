using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClasses;




namespace UserInterface
{
    /// <summary>
    /// Game process controller
    /// </summary>
    class GameController
    {
        public GameController()
        {

        }
        public GameController(GameMenuInterface UI, GameManager mngr)
        {
            _UI = UI;
            _UI.PictureClickEvent += PictureClickEventHandler;
            _UI.EndTurnClickEvent += PlayerEndTurnEventHandler;
            _mngr = mngr;
            _mngr.VictoryEvent += VictoryEventHandler;
        }

        public event VictorySetter AddPointsEvent;
       
        
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


        /// <summary>
        /// Func sets up game
        /// </summary>
        public void SetUpGame()
        {
            _mngr.Main();
        }

        private void VictoryEventHandler(object sender, VictoryEventArgs e)
        {
            if (e._whoWon != "Computer")
            {
                AddPointsEvent(sender, e);
            }
        }

        private GameMenuInterface _UI;
        private GameManager _mngr;      
    }
}
