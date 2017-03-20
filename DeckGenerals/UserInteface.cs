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
    public delegate void ChoosePlayerNamer(object sender, ChoosePlayerNameEventArgs args);
    public partial class UserInterface : Form
    {

        private List<MyPictureBox> pictureBoxCards = new List<MyPictureBox>(0);

        // 0 - Main Menu
        // 1 - Draft Menu
        // 2 - Game Menu        
        private int activePageNumber = 0;

        public void SetActivePage(int pageNum)
        {
            activePageNumber = pageNum;
            tabControl1.SelectTab(pageNum);
            if (pageNum == 2)
            {
                tabControl1.TabPages[activePageNumber].Controls.Add(txt_log);
                tabControl1.TabPages[activePageNumber].Controls.Add(pct_lastplayed);
                tabControl1.TabPages[activePageNumber].Controls.Add(lbl_lastpicked);
                tabControl1.TabPages[activePageNumber].Controls.Add(lbl_log);
                this.lbl_lastpicked.Text = "Last played";
                this.pct_lastplayed.Image = null;
            }
        }

        internal List<MyPictureBox> Cards
        {
            get
            {
                return pictureBoxCards;
            }
        }

        public UserInterface()
        {
            InitializeComponent();
        }


        private void btn_start_Click(object sender, EventArgs e)
        {
            this.lbl_entername.Enabled = true;
            this.txt_entername.Enabled = true;
            this.btn_proceed.Enabled = true;
            this.lbl_entername.Visible = true;
            this.txt_entername.Visible = true;
            this.btn_proceed.Visible = true;
        }
        internal void RemoveCard(MyPictureBox pctr)
        {
            tabControl1.TabPages[activePageNumber].Controls.Remove(pctr);
            pictureBoxCards.Remove(pctr);
        }

        public void RemoveAllCards()
        {
            foreach (MyPictureBox card in pictureBoxCards)
            {
                tabControl1.TabPages[activePageNumber].Controls.Remove(card);
            }
            Cards.Clear();
        }

        public event ChoosePlayerNamer ProceedClickEvent;
        public event EventHandler PictureClickEvent;
        public event Action NoCardsLeftEvent;
        public event Action EndTurnClickEvent;
        private void btn_proceed_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabpg_draftmenu);
            ProceedClickEvent(this, new ChoosePlayerNameEventArgs(txt_entername.Text));
        }

        public void ShowLastPlayedCard(Card card)
        {
            this.pct_lastplayed.Image = card.VisualOfCard;
        }
        public void ShowCityCards(Card playerCity, Card computerCity)
        {
            pct_playercity.Image = playerCity.VisualOfCard;
            pct_computercity.Image = computerCity.VisualOfCard;
            prgbar_playercitytrength.Maximum = playerCity.AbilityValOfCard;
            prgbar_playercitytrength.Value = playerCity.AbilityValOfCard;
            prgbar_playercitytrength.Style = ProgressBarStyle.Continuous;
            prgbar_computercitystrength.Maximum = computerCity.AbilityValOfCard;
            prgbar_computercitystrength.Value = computerCity.AbilityValOfCard;
            prgbar_computercitystrength.Style = ProgressBarStyle.Continuous;
            lbl_playercitystrength.Text = (playerCity.AbilityValOfCard + "/" + playerCity.AbilityValOfCard);
            lbl_computercitystrength.Text = (computerCity.AbilityValOfCard + "/" + computerCity.AbilityValOfCard);
        }

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
            if (activePageNumber == 2)
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
                    tabControl1.TabPages[activePageNumber].Controls.Add(picture);
                    i += cardImageWidth + indent;
                }
                else
                {
                    i = cardImageWidth + indent;
                    j += cardImageHeight + indent;
                    picture.Location = new Point(i, j);
                    tabControl1.TabPages[activePageNumber].Controls.Add(picture);
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
