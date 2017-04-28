using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameClasses;
 

namespace UserInterface
{
    public partial class GameMenuInterface : Form, IGameViewable
    {
        public GameMenuInterface()
        {
            InitializeComponent();
        }

        public void SetGameManager(GameManager gmMngr)
        {
            _gameMngr = gmMngr;
            _gameMngr.GameSetUpEvent += GameSetUpEventHandler;
            _gameMngr.VictoryEvent += VictoryEventHandler;
            _gameMngr.CardPlayedEvent += CardPlayedEventHandler;
            _gameMngr.StartNewTurnEvent += AIStartNewTurnEventHandler;
            _gameMngr.field.FieldChangedEvent += FieldChangedEventHandler;
            _gameMngr.EndTurnEvent += EndTurnEventHandler;
            _gameMngr.PlayerStartNewTurnEvent += StartNewTurnEventHandler;
        }
        
        public event EventHandler PictureClickEvent;
        public event Action EndTurnClickEvent;
        public event Action ConfirmClickEvent;

        /// <summary>
        /// Func removes all cards from interface
        /// </summary>
        public void RemoveAllCards()
        {
            foreach (MyPictureBox pct in _pictureBoxCards)
            {
                this.Controls.Remove(pct);
            }
            _pictureBoxCards.Clear();
        }

        /// <summary>
        /// Func sets visual of players city cards
        /// </summary>
        /// <param name="playerCity">player city card</param>
        /// <param name="computerCity">computer player city card</param>
        public void SetCityVisual(Card playerCity, Card computerCity)
        {
            pct_playercity.Image = playerCity.VisualOfCard;
            pct_computercity.Image = computerCity.VisualOfCard;
            prgbar_playercitytrength.Maximum = playerCity.StrengthOfCard;
            prgbar_playercitytrength.Value = playerCity.StrengthOfCard;
            prgbar_playercitytrength.Style = ProgressBarStyle.Continuous;
            prgbar_computercitystrength.Maximum = computerCity.StrengthOfCard;
            prgbar_computercitystrength.Value = computerCity.StrengthOfCard;
            prgbar_computercitystrength.Style = ProgressBarStyle.Continuous;
            lbl_playercitystrength.Text = (playerCity.StrengthOfCard + "/" + prgbar_playercitytrength.Maximum);
            lbl_computercitystrength.Text = (computerCity.StrengthOfCard + "/" + prgbar_computercitystrength.Maximum);
            lbl_armorsrtength.Text = "0/0";
            lbl_infantrystrength.Text = "0/0";
        }

        /// <summary>
        /// Func adds cards picture boxes to interface 
        /// </summary>
        /// <param name="cardsList">Card list ta add</param>
        public void ShowCards(List<Card> cardsList)
        {
            int windowWidth = this.Size.Width;
            int windowHeight = this.Size.Height;
            int cardImageWidth = 150;               //Setting card image size
            int cardImageHeight = 225;
            int indent = 5;                         //Setting inden between _cards
            int i = cardImageWidth + indent;
            int j = indent + 50;
            int iMax = windowWidth - cardImageWidth - indent;
            j = windowHeight - cardImageHeight - indent - 70;
            iMax = windowWidth - 2 * cardImageWidth - indent;
            foreach (Card card in cardsList)
            {
                MyPictureBox picture = new MyPictureBox(card);
                picture.Size = new Size(cardImageWidth, cardImageHeight);
                picture.Image = card.VisualOfCard;
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                picture.Click += new EventHandler(picture_Click);
                if (i < iMax)                                          //if exceedeing borders - start visualise from new line
                {
                    picture.Location = new Point(i, j);
                    this.Controls.Add(picture);
                    i += cardImageWidth + indent;
                }
                else
                {
                    i = cardImageWidth + indent;
                    j += cardImageHeight + indent;
                    picture.Location = new Point(i, j);
                    this.Controls.Add(picture);
                    i += cardImageWidth + indent;
                }
                _pictureBoxCards.Add(picture);
            }

        }

        /// <summary>
        /// Func sets colours of buttons depending on which player owns the fields
        /// </summary>
        /// <param name="playername">Name of playe that owns field</param>
        /// <param name="button">Button to set colour</param>
        public void SetButtonBackColor(string playername, Button button)
        {
            if (playername == "Computer")
            {
                button.BackColor = Color.Red;
            }
            else
            {
                if (playername == null)
                {
                    button.BackColor = Color.DarkGray;
                }
                else
                {
                    button.BackColor = Color.Green;
                }
            }
        }

        /// <summary>
        /// Update color of buttons OccupiedByPlayer
        /// </summary>
        /// <param name="armorOccupiedByPlayer">Player name, that occupied armor field</param>
        /// <param name="infantryOccupiedByPlayer">Player name, that occupied infanty field</param>
        public void UpdateButtonVisual(string armorOccupiedByPlayer, string infantryOccupiedByPlayer)
        {
            SetButtonBackColor(armorOccupiedByPlayer, btn_armoroccupied);
            SetButtonBackColor(infantryOccupiedByPlayer, btn_infantryoccupied);
        }

        /// <summary>
        /// Update isual info of players cities
        /// </summary>
        /// <param name="playerCityStrength">Strength of player city</param>
        /// <param name="computerCityStrength">Strength of computer player city</param>
        public void UpdateCityVisual(int playerCityStrength, int computerCityStrength)
        {
            prgbar_playercitytrength.Value = playerCityStrength;
            prgbar_computercitystrength.Value = computerCityStrength;
            lbl_playercitystrength.Text = (playerCityStrength + "/" + prgbar_playercitytrength.Maximum);
            lbl_computercitystrength.Text = (computerCityStrength + "/" + prgbar_computercitystrength.Maximum);
        }

        /// <summary>
        /// Update visual of field
        /// </summary>
        /// <param name="armorCard">Card occupied armor field</param>
        /// <param name="infantryCard">Card occupied infantry field</param>
        public void UpdateFieldVisual(Card armorCard, Card infantryCard)
        {
            pct_armor.Image = armorCard.VisualOfCard;
            pct_infantry.Image = infantryCard.VisualOfCard;
            lbl_armorsrtength.Text = (armorCard.AttackOfCard + "/" + armorCard.StrengthOfCard);
            lbl_infantrystrength.Text = (infantryCard.AttackOfCard + "/" + infantryCard.StrengthOfCard);
        }

        /// <summary>
        /// Update players info visual
        /// </summary>
        /// <param name="playerResources">Number of player resources</param>
        /// <param name="computerResources">Number of computer player resources</param>
        /// <param name="computerCardsNumber">Numbe of _cards in computer player hand</param>
        public void UpdatePlayerInfoVisual(int playerResources, int computerResources, int computerCardsNumber)
        {
            lbl_numbeofresources.Text = playerResources.ToString();
            lbl_computerresources.Text = computerResources.ToString();
            lbl_computercardsnum.Text = computerCardsNumber.ToString();
        }

        /// <summary>
        /// Func removes card from controls
        /// </summary>
        /// <param name="card">Card to remove</param>
        public void RemoveCard(Card card)
        {
            foreach (MyPictureBox ctrl in _pictureBoxCards)
            {
                if (card.NameOfCard == ctrl._card.NameOfCard)
                {
                    this.Controls.Remove(ctrl);
                    _pictureBoxCards.Remove(ctrl);
                    break;
                }
            }
        }


        #region Button clicks
        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (ConfirmClickEvent != null)
            {
                ConfirmClickEvent();
            }
        }

        /// <summary>
        /// Picture click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void picture_Click(object sender, EventArgs args)
        {
            MyPictureBox pctBox = sender as MyPictureBox;
            if (pctBox.Enabled)
            {
                PictureClickEvent(pctBox, new EventArgs());
            }
        }

        /// <summary>
        /// End Turn button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_endturn_Click(object sender, EventArgs e)
        {
            if (EndTurnClickEvent != null)
            {
                EndTurnClickEvent();
            }
        }
        /// <summary>
        /// Func adds card to log
        /// </summary>
        /// <param name="playerName">Name of player, which played the card</param>
        /// <param name="card">Played card</param>
        public void AddCardToList(string playerName, Card card)
        {
            _imgList.Images.Add(card.NameOfCard, card.VisualOfCard);
            _imgList.ImageSize = new Size(40, 60);
            lstview_log.SmallImageList = _imgList;
            string action = String.Format("{0} played {1}", playerName, card.NameOfCard);
            this.lstview_log.Items.Add(action, card.NameOfCard);
        }
        #endregion

        #region Eventhandlers
        public void CardPlayedEventHandler(object sender, CardPlayedEventArgs args)
        {
            _gameMngr = sender as GameManager;

            RemoveCard(args.card);
            AddCardToList(args.playerName, args.card);

            UpdateCityVisual(_gameMngr.player1.cityCard.StrengthOfCard, _gameMngr.computerPlayer.cityCard.StrengthOfCard);
            UpdateFieldVisual(_gameMngr.field.GetArmorCard(), _gameMngr.field.GetInfantryCard());
            UpdatePlayerInfoVisual(_gameMngr.player1.resourceQuantity, _gameMngr.computerPlayer.resourceQuantity, _gameMngr.computerPlayer.playerHand.cardsInCollection.Count);

        }

        public void AIStartNewTurnEventHandler(object sender, EventArgs args)
        {
            _gameMngr = sender as GameManager;
            UpdatePlayerInfoVisual(_gameMngr.player1.resourceQuantity, _gameMngr.computerPlayer.resourceQuantity, _gameMngr.computerPlayer.playerHand.cardsInCollection.Count);
        }

        public void StartNewTurnEventHandler(object sender, EventArgs args)
        {
            
            RemoveAllCards();
            _gameMngr = sender as GameManager;
            ShowCards(_gameMngr.player1.playerHand.cardsInCollection);
            UpdatePlayerInfoVisual(_gameMngr.player1.resourceQuantity, _gameMngr.computerPlayer.resourceQuantity, _gameMngr.computerPlayer.playerHand.cardsInCollection.Count);
            this.btn_endturn.Enabled = true;            
        }

        public void EndTurnEventHandler(object sender, EventArgs args)
        {
            _gameMngr = sender as GameManager;
            UpdateCityVisual(_gameMngr.player1.cityCard.StrengthOfCard, _gameMngr.computerPlayer.cityCard.StrengthOfCard);
        }

        public void VictoryEventHandler(object sender, VictoryEventArgs e)
        {
            btn_endturn.Enabled = false;
            RemoveAllCards();
            _gameMngr = sender as GameManager;
            this.BackgroundImage = Image.FromFile("..\\..\\..\\..\\cards.img\\VictoryBackGround.jpg");
            lbl_playername.Enabled = true;
            lbl_playername.Visible = true;
            lbl_opponentName.Enabled = true;
            lbl_opponentName.Visible = true;
            lbl_playerpoints.Visible = true;
            lbl_playerpoints.Enabled = true;
            lbl_computerpoints.Visible = true;
            lbl_computerpoints.Enabled = true;
            btn_confirm.Enabled = true;
            btn_confirm.Visible = true;
            lbl_playername.Text = _gameMngr.player1.playerName;
            lbl_playerpoints.Text = _gameMngr.player1.cityCard.StrengthOfCard.ToString();
            lbl_computerpoints.Text = _gameMngr.computerPlayer.cityCard.StrengthOfCard.ToString();
        }

        public void GameSetUpEventHandler(object sender, EventArgs e)
        {
            _gameMngr = sender as GameManager;
            SetCityVisual(_gameMngr.player1.cityCard, _gameMngr.computerPlayer.cityCard);        
        }

        public void FieldChangedEventHandler(object sender, EventArgs e)
        {
            Field fld = sender as Field;
            UpdateFieldVisual(fld.GetArmorCard(), fld.GetInfantryCard());
            UpdateButtonVisual(fld.armorOccupiedByPlayer, fld.infantryOccupiedByPlayer);
        }

        #endregion


        private List<MyPictureBox> _pictureBoxCards = new List<MyPictureBox>(0);
        private GameManager _gameMngr;
        private ImageList _imgList = new ImageList();
    }
}
