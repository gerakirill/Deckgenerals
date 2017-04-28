using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClasses;

namespace UserInterface
{

    /// <summary>
    /// Shop controller class
    /// </summary>
    public class ShopController
    {
        public ShopController(Player player, ShopInterface shop)
        {
            _plyr = player;
            _shopI = shop;
            _shopI.DeckClickEvent += DeckClickEventHandler;
            _shopI.ReturnClickEvent += ReturnClickEventHandler;
            ShowBoosters();
        }

        public event Action QuitShopEvent;

        /// <summary>
        /// Func generates booster and shows it in interface
        /// </summary>
        private void ShowBoosters()
        {
            List<BoosterDeck> boosters = new List<BoosterDeck>();
            boosters.Add(_shopMngr.GenerateBooster(BoosterType.small));
            _shopI.UpdateInfo(_plyr.playerName, _plyr.Points);
            _shopI.ShowDecks(boosters);
        }

        /// <summary>
        /// Quit shop
        /// </summary>
        private void ReturnClickEventHandler()
        {
            if (QuitShopEvent != null)
            {
                QuitShopEvent();
            }
        }

        /// <summary>
        /// Click on booster picture - buys it if player has enough points
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeckClickEventHandler(object sender, EventArgs e)
        {
            BoosterPictureBox pct = sender as BoosterPictureBox;
            if (_plyr.Points >= pct.boosterDeck.PointsCost)
            {
                _shopI.RemoveDecks();
                pct.boosterDeck.DeckName = SQLManager.ALL_CARDS_DECK;
                _shopI.ShowCards(pct.boosterDeck.Booster);
                _shopMngr.UpdatePoints(_plyr.playerName, -pct.boosterDeck.PointsCost);
                _shopMngr.AddCards(pct.boosterDeck, _plyr);
            }
        }

        private Player _plyr;
        private ShopInterface _shopI;
        private ShopManager _shopMngr = new ShopManager();
    }
}
