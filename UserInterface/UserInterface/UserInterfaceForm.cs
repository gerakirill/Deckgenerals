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
using System.IO;

namespace UserInterface
{
    //Game pages
    public enum Pages
    {
        empty = 10,
        tabpg_mainmenu = 0,
        tabpg_draftmenu = 1,
        tabpg_gamemenu = 2,
        tabpg_winmenu = 3,
        tabpg_register = 4,
        tabpg_loginmenu = 5

    }

    public delegate void PlayerCreater(object sender, CreateNewPlayerEventArgs args);
    public delegate void LogIner(object sender, LogInPlayerEventArgs args);



    public partial class UserInterface : Form, IViewable
    {
        public UserInterface()
        {
            InitializeComponent();
        }


        public UserInterface(GameManager mngr)
        {
            InitializeComponent();
            _mngr = mngr;
            _mngr.GameSetUpEvent += GameSetUpEventHandler;
            _mngr.VictoryEvent += VictoryEventHandler;
            _mngr.CardPlayedEvent += CardPlayedEventHandler;
            _mngr.StartNewTurnEvent += AIStartNewTurnEventHandler;
            _mngr.field.FieldChangedEvent += FieldChangedEventHandler;
            _mngr.EndTurnEvent += EndTurnEventHandler;
            _mngr.PlayerStartNewTurnEvent += StartNewTurnEventHandler;            
            
        }

        public void  SetEvents(GameManager mngr)
        {
            _mngr = mngr;
            _mngr.GameSetUpEvent += GameSetUpEventHandler;
            _mngr.VictoryEvent += VictoryEventHandler;
            _mngr.CardPlayedEvent += CardPlayedEventHandler;
            _mngr.StartNewTurnEvent += AIStartNewTurnEventHandler;
            _mngr.field.FieldChangedEvent += FieldChangedEventHandler;
            _mngr.EndTurnEvent += EndTurnEventHandler;
            _mngr.PlayerStartNewTurnEvent += StartNewTurnEventHandler;            
            
        }

        public GameManager _mngr;

        public event PlayerCreater CreateNewPlayerEvent;
        public event LogIner LogInPlayerEvent;
        public event EventHandler PictureClickEvent;
        public event Action NoCardsLeftEvent;
        public event Action EndTurnClickEvent;
        public event Action PlayAgainEvent;
        public event Action QuitEvent;
        public event Action StartGameVSAI;

        /// <summary>
        /// Func sets active game page
        /// </summary>
        /// <param name="page"></param>
        public void SetActivePage(Pages page)
        {

            tabControl1.SelectTab(page.ToString());
        }

        /// <summary>
        /// Func removes all card pictureboxes from form
        /// </summary>
        public void RemoveAllCards()
        {
            foreach (MyPictureBox pct in pictureBoxCards)
            {
                tabControl1.TabPages[2].Controls.Remove(pct);
            }

            //foreach (Control ctrl in tabControl1.TabPages)
            //{
            //    if (ctrl is MyPictureBox)
            //    {
            //        tabControl1.TabPages[Pages.tabpg_gamemenu.ToString()].Controls.Remove(ctrl);
            //    }
            //}
        }


        //Procced button event handler
        private void btn_proceed_Click(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Adds card picture to Picture Box "Last played"
        /// </summary>
        /// <param name="card">Card to show</param>
        public void ShowLastPlayedCard(Card card)
        {
            this.pct_lastplayed.Image = card.VisualOfCard;
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
        }

        /// <summary>
        /// Func add cards picture boxes to form 
        /// </summary>
        /// <param name="cardsList">Card list ta add</param>
        public void ShowCards(List<Card> cardsList)
        {
            int windowWidth = this.Size.Width;
            int windowHeight = this.Size.Height;
            int cardImageWidth = 150;               //Setting card image size
            int cardImageHeight = 225;
            int indent = 5;                         //Setting inden between cards
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
                    tabControl1.TabPages[Pages.tabpg_gamemenu.ToString()].Controls.Add(picture);
                    i += cardImageWidth + indent;
                }
                else
                {
                    i = cardImageWidth + indent;
                    j += cardImageHeight + indent;
                    picture.Location = new Point(i, j);
                    tabControl1.TabPages[Pages.tabpg_gamemenu.ToString()].Controls.Add(picture);
                    i += cardImageWidth + indent;
                }
                pictureBoxCards.Add(picture);
            }

        }

        /// <summary>
        /// Picture clock event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void picture_Click(object sender, EventArgs args)
        {
            MyPictureBox pctBox = sender as MyPictureBox;
            PictureClickEvent(pctBox, new EventArgs());
            //if (pictureBoxCards.Count <= 0)
            //{
            //    if (NoCardsLeftEvent != null)
            //    {
            //        NoCardsLeftEvent();
            //    }
            //}
            //tabControl1.Refresh();pictureBoxCards.Add(picture);
        }

        /// <summary>
        /// Adding text to logb
        /// </summary>
        /// <param name="text">Text to add</param>
        public void AddToLog(string text)
        {
            this.txt_log.AppendText(text + Environment.NewLine + "___________________" + Environment.NewLine);
        }

        /// <summary>
        /// End Turn button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_endturn_Click(object sender, EventArgs e)
        {
            this.btn_endturn.Enabled = false;
            foreach (Control ctrl in tabControl1.TabPages[Pages.tabpg_gamemenu.ToString()].Controls)
            {
                if (ctrl is MyPictureBox)
                {
                    ctrl.Enabled = false;
                }
            }
            if (EndTurnClickEvent != null)
            {
                EndTurnClickEvent();
            }

        }

        public void StartTurn()
        {
            this.btn_endturn.Enabled = true;
            foreach (Control ctrl in tabControl1.TabPages[Pages.tabpg_gamemenu.ToString()].Controls)
            {
                if (ctrl is MyPictureBox)
                {
                    ctrl.Enabled = true;
                }
            }
        }

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
        /// <param name="computerCardsNumber">Numbe of cards in computer player hand</param>
        public void UpdatePlayerInfoVisual(int playerResources, int computerResources, int computerCardsNumber)
        {
            lbl_numbeofresources.Text = playerResources.ToString();
            lbl_computerresources.Text = computerResources.ToString();
            lbl_computercardsnum.Text = computerCardsNumber.ToString();
        }

        private void btn_playagain_Click(object sender, EventArgs e)
        {
            if (PlayAgainEvent != null)
            {
                PlayAgainEvent();
            }
        }
        private void btn_quit_Click(object sender, EventArgs e)
        {
            if (QuitEvent != null)
            {
                QuitEvent();
            }
        }

        private void btn_quitmain_Click(object sender, EventArgs e)
        {
            if (QuitEvent != null)
            {
                QuitEvent();
            }
        }

        public List<MyPictureBox> pictureBoxCards = new List<MyPictureBox>(0);


        public void RemoveCard(Card card)
        {

            foreach (Control ctrl in tabControl1.TabPages[Pages.tabpg_gamemenu.ToString()].Controls)
            {
                if (ctrl is MyPictureBox)
                {
                    MyPictureBox pctr = ctrl as MyPictureBox;
                    if (card.NameOfCard == pctr._card.NameOfCard)
                    {
                        tabControl1.TabPages[Pages.tabpg_gamemenu.ToString()].Controls.Remove(ctrl);
                        pictureBoxCards.Remove(pctr);
                        break;
                    }
                }
            }
        }

        private void btn_about_Click(object sender, EventArgs e)
        {

        }

        public void CardPlayedEventHandler(object sender, CardPlayedEventArgs args)
        {
            _mngr = sender as GameManager;
            ShowLastPlayedCard(args._card);
            RemoveCard(args._card);

            UpdateCityVisual(_mngr.player1.cityCard.StrengthOfCard, _mngr.computerPlayer.cityCard.StrengthOfCard);
            UpdateFieldVisual(_mngr.field.GetArmorCard(), _mngr.field.GetInfantryCard());
            UpdatePlayerInfoVisual(_mngr.player1.resourceQuantity, _mngr.computerPlayer.resourceQuantity, _mngr.computerPlayer.playerHand.cardsInCollection.Count);
        }

        public void AIStartNewTurnEventHandler(object sender, EventArgs args)
        {
            _mngr = sender as GameManager;
            UpdatePlayerInfoVisual(_mngr.player1.resourceQuantity, _mngr.computerPlayer.resourceQuantity, _mngr.computerPlayer.playerHand.cardsInCollection.Count);
        }

        public void StartNewTurnEventHandler(object sender, EventArgs args)
        {
            RemoveAllCards();
            _mngr = sender as GameManager;
            ShowCards(_mngr.player1.playerHand.cardsInCollection);
            UpdatePlayerInfoVisual(_mngr.player1.resourceQuantity, _mngr.computerPlayer.resourceQuantity, _mngr.computerPlayer.playerHand.cardsInCollection.Count);
            this.btn_endturn.Enabled = true;
            foreach (Control ctrl in tabControl1.TabPages[Pages.tabpg_gamemenu.ToString()].Controls)
            {
                if (ctrl is MyPictureBox)
                {
                    ctrl.Enabled = true;
                }
            }
        }

        public void EndTurnEventHandler(object sender, EventArgs args)
        {
            _mngr = sender as GameManager;
            UpdateCityVisual(_mngr.player1.cityCard.StrengthOfCard, _mngr.computerPlayer.cityCard.StrengthOfCard);
        }

        public void VictoryEventHandler(object sender, VictoryEventArgs e)
        {

            _mngr = sender as GameManager;
            lbl_playername.Text = e._whoWon;
            lbl_playerpoints.Text = _mngr.player1.cityCard.StrengthOfCard.ToString();
            lbl_computerpoints.Text = _mngr.computerPlayer.cityCard.StrengthOfCard.ToString();
            SetActivePage(Pages.tabpg_winmenu);
        }

        public void GameSetUpEventHandler(object sender, EventArgs e)
        {
            _mngr = sender as GameManager;
            SetCityVisual(_mngr.player1.cityCard, _mngr.computerPlayer.cityCard);
            tabControl1.SelectTab(Pages.tabpg_gamemenu.ToString());
        }

        public void FieldChangedEventHandler(object sender, EventArgs e)
        {
            Field fld = sender as Field;
            UpdateFieldVisual(fld.GetArmorCard(), fld.GetInfantryCard());
            UpdateButtonVisual(fld.armorOccupiedByPlayer, fld.infantryOccupiedByPlayer);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btn_regproceed_Click(object sender, EventArgs e)
        {
            if (CreateNewPlayerEvent != null)
            {
                CreateNewPlayerEvent(this, new CreateNewPlayerEventArgs(txt_login.Text, txt_password.Text, txt_email.Text));
            }
        }

        public void ShowMessage(string text)
        {
            MessageBox.Show(text);
        }

        public void UserCreatedEventHandler()
        {
            SetActivePage(Pages.tabpg_mainmenu);
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            SetActivePage(Pages.tabpg_register);           
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            txt_loginmain.Enabled = true;
            txt_loginmain.Visible = true;
            txt_passmain.Enabled = true;
            txt_passmain.Visible = true;
            lbl_passmain.Visible = true;
            lbl_passmain.Enabled = true;
            lbl_enternamemain.Visible = true;
            lbl_enternamemain.Enabled = true;
            btn_proceedmain.Visible = true;
            btn_proceedmain.Enabled = true;
        }

        private void btn_proceedmain_Click(object sender, EventArgs e)
        {
            if (LogInPlayerEvent != null)
            {
                LogInPlayerEvent(this, new LogInPlayerEventArgs(txt_loginmain.Text, txt_passmain.Text));
            }
        }

        private void btn_playvsai_Click(object sender, EventArgs e)
        {
            if (StartGameVSAI != null)
            {
                StartGameVSAI();
            }

        }
    }
    public class CreateNewPlayerEventArgs
    {
        public CreateNewPlayerEventArgs(string login, string pass, string email)
        {
            playerLogin = login;
            playerPassword = pass;
            playerEmail = email;
        }
        public string playerLogin { get; private set; }
        public string playerPassword { get; private set; }
        public string playerEmail { get; private set; }
    }

    public class LogInPlayerEventArgs
    {
        public LogInPlayerEventArgs(string login, string pass)
        {
            playerLogin = login;
            playerPassword = pass;
        }
        public string playerLogin { get; private set; }
        public string playerPassword { get; private set; }

    }
}
