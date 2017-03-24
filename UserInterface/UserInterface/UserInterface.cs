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
        tabpg_winmenu = 3
    }

    public delegate void ChoosePlayerNamer(object sender, ChoosePlayerNameEventArgs args);
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        public event ChoosePlayerNamer ProceedClickEvent;
        public event EventHandler PictureClickEvent;
        public event Action NoCardsLeftEvent;
        public event Action EndTurnClickEvent;
        public event Action PlayAgainEvent;
        public event Action QuitEvent;

        /// <summary>
        /// Func sets active game page
        /// </summary>
        /// <param name="page"></param>
        public void SetActivePage(Pages page)
        {
            _activePageNumber = page;

            switch (page)
            {
                case Pages.empty:
                    break;
                case Pages.tabpg_mainmenu:
                    break;
                case Pages.tabpg_draftmenu:
                    break;
                case Pages.tabpg_gamemenu:      //if setting game menu - adding game log and "last picked" picture
                    tabControl1.TabPages[_activePageNumber.ToString()].Controls.Add(txt_log);
                    tabControl1.TabPages[_activePageNumber.ToString()].Controls.Add(pct_lastplayed);
                    tabControl1.TabPages[_activePageNumber.ToString()].Controls.Add(lbl_lastpicked);
                    tabControl1.TabPages[_activePageNumber.ToString()].Controls.Add(lbl_log);
                    this.lbl_lastpicked.Text = "Last played";
                    this.pct_lastplayed.Image = null;
                    break;
                case Pages.tabpg_winmenu:
                    break;
                default:
                    break;
            }
            tabControl1.SelectTab(page.ToString());
        }

        /// <summary>
        /// Button start event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_start_Click(object sender, EventArgs e)
        {
            this.lbl_entername.Enabled = true;          //Making visible and enbled buttons "enter name" and "proceed"
            this.txt_entername.Enabled = true;
            this.btn_proceed.Enabled = true;
            this.lbl_entername.Visible = true;
            this.txt_entername.Visible = true;
            this.btn_proceed.Visible = true;
        }

        public void SetVictoryVisual(string playerName, string playerWon, int playerCityStrength, int computerCityStrength)
        {
            lbl_playername.Text = playerName;
            if (playerWon != "DRAW")
            {
                lbl_playerwon.Text = playerName + "  WON";
            }
            else
            {
                lbl_playerwon.Text = playerWon;
            }

            lbl_playerpoints.Text = playerCityStrength.ToString();
            lbl_computerpoints.Text = computerCityStrength.ToString();

        }


        /// <summary>
        /// Func removes all card pictureboxes from form
        /// </summary>
        public void RemoveAllCards()
        {
            foreach (MyPictureBox card in pictureBoxCards)
            {
                tabControl1.TabPages[_activePageNumber.ToString()].Controls.Remove(card);
            }
            pictureBoxCards.Clear();
        }


        //Procced button event handler
        private void btn_proceed_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabpg_draftmenu);
            if (ProceedClickEvent != null)
            {
                ProceedClickEvent(this, new ChoosePlayerNameEventArgs(txt_entername.Text));
            }

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
            int iMax = windowWidth - cardImageWidth - indent;           //if active page - game menu - visualising cards in bottom of window
            if (_activePageNumber.ToString() == "tabpg_gamemenu")
            {
                j = windowHeight - cardImageHeight - indent - 70;
                iMax = windowWidth - 2 * cardImageWidth - indent;
            }
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
                    tabControl1.TabPages[_activePageNumber.ToString()].Controls.Add(picture);
                    i += cardImageWidth + indent;
                }
                else
                {
                    i = cardImageWidth + indent;
                    j += cardImageHeight + indent;
                    picture.Location = new Point(i, j);
                    tabControl1.TabPages[_activePageNumber.ToString()].Controls.Add(picture);
                    i += cardImageWidth + indent;
                }
                pictureBoxCards.Add(picture);
            }
            tabControl1.Refresh();

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
            if (pictureBoxCards.Count <= 0)
            {
                if (NoCardsLeftEvent != null)
                {
                    NoCardsLeftEvent();
                }
            }
            tabControl1.Refresh();
        }

        /// <summary>
        /// Adding text to log
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
            foreach (MyPictureBox card in pictureBoxCards)
            {
                card.Enabled = false;
            }
            if (EndTurnClickEvent != null)
            {
                EndTurnClickEvent();
            }

        }

        public void StartTurn()
        {
            this.btn_endturn.Enabled = true;
            foreach (MyPictureBox card in pictureBoxCards)
            {
                card.Enabled = true;
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
            tabControl1.Refresh();
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

        private Pages _activePageNumber = Pages.tabpg_mainmenu;

        public void RemoveCard(MyPictureBox pctr)
        {
            tabControl1.TabPages[_activePageNumber.ToString()].Controls.Remove(pctr);
            pictureBoxCards.Remove(pctr);
        }

        public void AddNewLog()
        {
            tabControl1.TabPages[_activePageNumber.ToString()].Controls.Add(txt_log);
            tabControl1.TabPages[_activePageNumber.ToString()].Controls.Add(lbl_lastpicked);
            pct_lastplayed.Image = null;
            tabControl1.TabPages[_activePageNumber.ToString()].Controls.Add(pct_lastplayed);
            lbl_lastpicked.Text = "Last picked";
            txt_log.Clear();
        }

        private void btn_about_Click(object sender, EventArgs e)
        {

        }
    }
    public class ChoosePlayerNameEventArgs
    {
        public ChoosePlayerNameEventArgs(string playerName)
        {
            _playerName = playerName;
        }
        public string _playerName { get; private set; }
    }
}
