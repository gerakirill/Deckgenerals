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
    public partial class ShopInterface : Form
    {
        public ShopInterface()
        {
            InitializeComponent();
        }

        public event EventHandler DeckClickEvent;
        public event Action ReturnClickEvent;

        /// <summary>
        /// Func shows booster decks to interface
        /// </summary>
        /// <param name="deckList">list of booster decks to show</param>
        public void ShowDecks(List<BoosterDeck> deckList)
        {
            int windowWidth = this.Size.Width;
            int windowHeight = this.Size.Height;
            int cardImageWidth = 150;               //Setting card image size
            int cardImageHeight = 225;
            int indent = 5;                         //Setting inden between _cards
            int i = cardImageWidth + indent;
            int j = indent + 50;
            int iMax = windowWidth - cardImageWidth - indent;
            j = cardImageHeight - indent;
            iMax = windowWidth - 2 * cardImageWidth - indent;
            foreach (BoosterDeck deck in deckList)
            {
                BoosterPictureBox picture = new BoosterPictureBox(deck);
                picture.Size = new Size(cardImageWidth, cardImageHeight);
                picture.BorderStyle = BorderStyle.Fixed3D;
                picture.ImageLocation = "..\\..\\..\\..\\cards.img\\Shirt.jpg";
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                Label lbl_deckname = new Label();
                lbl_deckname.AutoSize = true;                
                lbl_deckname.BackColor = Color.Transparent;
                lbl_deckname.ForeColor = Color.DarkCyan;
                lbl_deckname.Font = new Font("Stencil", 10, FontStyle.Regular);
                lbl_deckname.Location = new Point(i, j);
                lbl_deckname.AutoSize = true;
                string boosterText = "";
                switch (picture.boosterDeck.BType)
                {
                    case BoosterType.empty:
                        break;
                    case BoosterType.small:
                        boosterText = "3 cards\n30 points";
                        break;
                    case BoosterType.big:
                        boosterText = "6 cards\n50 points";
                        break;
                    default:
                        break;
                }
                lbl_deckname.BackColor = Color.White;
                lbl_deckname.Text = boosterText;
                this.Controls.Add(lbl_deckname);
                _pictureBoosters.Add(picture);
                _labels.Add(lbl_deckname);

                picture.Click += new EventHandler(deck_click);
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
            }
        }

        /// <summary>
        /// Func showing cards in booster decks to interface
        /// </summary>
        /// <param name="deck"></param>
        public void ShowCards(Deck deck)
        {
            int windowWidth = this.Size.Width;
            int windowHeight = this.Size.Height;
            int cardImageWidth = 150;               //Setting card image size
            int cardImageHeight = 225;
            int indent = 5;                         //Setting inden between _cards
            int i = cardImageWidth + indent;
            int j = indent + 50;
            int iMax = windowWidth - cardImageWidth - indent;
            j = indent;
            iMax = windowWidth - 2 * cardImageWidth - indent;
            foreach (Card card in deck.cardsInCollection)
            {
                MyPictureBox picture = new MyPictureBox(card);
                picture.Size = new Size(cardImageWidth, cardImageHeight);
                picture.Image = card.VisualOfCard;
                picture.SizeMode = PictureBoxSizeMode.StretchImage;               
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
            }
        }

        /// <summary>
        /// Func updates player info
        /// </summary>
        /// <param name="playerName">player login</param>
        /// <param name="playerPoints">plyer points</param>
        public void UpdateInfo(string playerName, int playerPoints)
        {
            lbl_playerName.Text = playerName;
            lbl_playerPoints.Text = string.Format("Points: {0}", playerPoints.ToString());
        }

        /// <summary>
        /// Func removes booster decks from interface
        /// </summary>
        public void RemoveDecks()
        {
            foreach (BoosterPictureBox booster in _pictureBoosters)
            {
                this.Controls.Remove(booster);
            }
            foreach (Label lbl in _labels)
            {
                this.Controls.Remove(lbl);
            }
            _pictureBoosters.Clear();
            _labels.Clear();
        }

        /// <summary>
        /// Click on deck event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deck_click(object sender, EventArgs e)
        {
            if (DeckClickEvent!=null)
            {
                DeckClickEvent(sender, e);
            }
        }

        /// <summary>
        /// Button return click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_return_Click(object sender, EventArgs e)
        {
            if (ReturnClickEvent != null)
            {
                ReturnClickEvent();
            }
        }

        private List<BoosterPictureBox> _pictureBoosters = new List<BoosterPictureBox>();
        private List<Label> _labels = new List<Label>();


    }
}
