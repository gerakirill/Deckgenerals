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

namespace DeckGenerals
{
    //Game pages
    public enum Pages
    {
        empty = 0,
        tabpg_mainmenu = 1,
        tabpg_draftmenu = 2,
        tabpg_gamemenu = 4
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

        /// <summary>
        /// Func removes all card pictureboxes from form
        /// </summary>
        public void RemoveAllCards()
        {
            foreach (MyPictureBox card in pictureBoxCards)
            {
                tabControl1.TabPages[_activePageNumber.ToString()].Controls.Remove(card);
            }
            Cards.Clear();
        }


        //Procced button event handler
        private void btn_proceed_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabpg_draftmenu);
            ProceedClickEvent(this, new ChoosePlayerNameEventArgs(txt_entername.Text));
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
            lbl_playercitystrength.Text = (playerCity.AbilityValOfCard + "/" + playerCity.AbilityValOfCard);
            lbl_computercitystrength.Text = (computerCity.AbilityValOfCard + "/" + computerCity.AbilityValOfCard);
        }

        /// <summary>
        /// Func add cards picture boxes to form 
        /// </summary>
        /// <param name="cardsList">Card list ta add</param>
        public void ShowCards(List<Card> cardsList)
        {
            int windowWidth = this.Size.Width;
            int windowHeight = this.Size.Height;
            int cardImageWidth = 150;
            int cardImageHeight = 225;
            int indent = 5;
            int i = cardImageWidth + indent;
            int j = indent;
            int iMax = windowWidth - cardImageWidth - indent;
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
                if (i < iMax)
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
        private void picture_Click(object sender, EventArgs args)
        {
            MyPictureBox pctBox = sender as MyPictureBox;
            PictureClickEvent(pctBox, new EventArgs());
            if (pictureBoxCards.Count <= 0)
            {
                NoCardsLeftEvent();
            }
            tabControl1.Refresh();
        }

        public void AddToLog(string text)
        {
            this.txt_log.AppendText(text + Environment.NewLine + "___________________" + Environment.NewLine);
        }

        private void btn_endturn_Click(object sender, EventArgs e)
        {
            this.btn_endturn.Enabled = false;
            foreach (MyPictureBox card in pictureBoxCards)
            {
                card.Enabled = false;
            }
            EndTurnClickEvent();
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

        public void UpdateVisual(Card armorCard, Card infantryCard, int playerCityStrength, int computerCityStrength,
            int playerResources, int computerResources, string armorOccupiedByPlayer, string infantryOccupiedByPlayer, int computerCardsNumber)
        {
            pct_armor.Image = armorCard.VisualOfCard;
            pct_infantry.Image = infantryCard.VisualOfCard;
            prgbar_playercitytrength.Value = playerCityStrength;
            prgbar_computercitystrength.Value = computerCityStrength;
            lbl_playercitystrength.Text = (playerCityStrength + "/" + prgbar_playercitytrength.Maximum);
            lbl_computercitystrength.Text = (computerCityStrength + "/" + prgbar_computercitystrength.Maximum);
            lbl_numbeofresources.Text = playerResources.ToString();
            lbl_armorsrtength.Text = (armorCard.AttackOfCard + "/" + armorCard.StrengthOfCard);
            lbl_infantrystrength.Text = (infantryCard.AttackOfCard + "/" + infantryCard.StrengthOfCard);
            SetButtonBackColor(armorOccupiedByPlayer, btn_armoroccupied);
            SetButtonBackColor(infantryOccupiedByPlayer, btn_infantryoccupied);
            lbl_computerresources.Text = computerResources.ToString();
            lbl_computercardsnum.Text = computerCardsNumber.ToString();
            tabControl1.Refresh();
        }

        private List<MyPictureBox> pictureBoxCards = new List<MyPictureBox>(0);

        // 0 - Main Menu
        // 1 - Draft Menu
        // 2 - Game Menu        
        private Pages _activePageNumber = Pages.tabpg_mainmenu;
        internal List<MyPictureBox> Cards
        {
            get
            {
                return pictureBoxCards;
            }
        }
        internal void RemoveCard(MyPictureBox pctr)
        {
            tabControl1.TabPages[_activePageNumber.ToString()].Controls.Remove(pctr);
            pictureBoxCards.Remove(pctr);
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
