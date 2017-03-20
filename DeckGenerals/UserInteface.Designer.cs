namespace DeckGenerals
{
    partial class UserInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInterface));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabpg_mainmenu = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_proceed = new System.Windows.Forms.Button();
            this.lbl_entername = new System.Windows.Forms.Label();
            this.txt_entername = new System.Windows.Forms.TextBox();
            this.btn_cardbase = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_about = new System.Windows.Forms.Button();
            this.tabpg_draftmenu = new System.Windows.Forms.TabPage();
            this.lbl_lastpicked = new System.Windows.Forms.Label();
            this.pct_lastplayed = new System.Windows.Forms.PictureBox();
            this.lbl_log = new System.Windows.Forms.Label();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.tabpg_gamemenu = new System.Windows.Forms.TabPage();
            this.lbl_numbeofresources = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_infantrystrength = new System.Windows.Forms.Label();
            this.lbl_armorsrtength = new System.Windows.Forms.Label();
            this.btn_infantryoccupied = new System.Windows.Forms.Button();
            this.btn_armoroccupied = new System.Windows.Forms.Button();
            this.lbl_computercitystrength = new System.Windows.Forms.Label();
            this.btn_endturn = new System.Windows.Forms.Button();
            this.lbl_playercitystrength = new System.Windows.Forms.Label();
            this.prgbar_computercitystrength = new System.Windows.Forms.ProgressBar();
            this.pct_computercity = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_armor = new System.Windows.Forms.Label();
            this.pct_infantry = new System.Windows.Forms.PictureBox();
            this.pct_armor = new System.Windows.Forms.PictureBox();
            this.prgbar_playercitytrength = new System.Windows.Forms.ProgressBar();
            this.pct_playercity = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_computerresources = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_computercardsnum = new System.Windows.Forms.Label();
            this.pct_menucards = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabpg_mainmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabpg_draftmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pct_lastplayed)).BeginInit();
            this.tabpg_gamemenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pct_computercity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_infantry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_armor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_playercity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_menucards)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabpg_mainmenu);
            this.tabControl1.Controls.Add(this.tabpg_draftmenu);
            this.tabControl1.Controls.Add(this.tabpg_gamemenu);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1280, 800);
            this.tabControl1.TabIndex = 0;
            // 
            // tabpg_mainmenu
            // 
            this.tabpg_mainmenu.BackColor = System.Drawing.Color.White;
            this.tabpg_mainmenu.Controls.Add(this.pct_menucards);
            this.tabpg_mainmenu.Controls.Add(this.pictureBox2);
            this.tabpg_mainmenu.Controls.Add(this.label2);
            this.tabpg_mainmenu.Controls.Add(this.pictureBox1);
            this.tabpg_mainmenu.Controls.Add(this.btn_proceed);
            this.tabpg_mainmenu.Controls.Add(this.lbl_entername);
            this.tabpg_mainmenu.Controls.Add(this.txt_entername);
            this.tabpg_mainmenu.Controls.Add(this.btn_cardbase);
            this.tabpg_mainmenu.Controls.Add(this.btn_start);
            this.tabpg_mainmenu.Controls.Add(this.btn_about);
            this.tabpg_mainmenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabpg_mainmenu.Location = new System.Drawing.Point(4, 22);
            this.tabpg_mainmenu.Name = "tabpg_mainmenu";
            this.tabpg_mainmenu.Padding = new System.Windows.Forms.Padding(3);
            this.tabpg_mainmenu.Size = new System.Drawing.Size(1272, 774);
            this.tabpg_mainmenu.TabIndex = 1;
            this.tabpg_mainmenu.Text = "Main Menu";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.ImageLocation = "C:..\\..\\cards.img\\IS2.png";
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(375, 250);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Stencil", 30.25F);
            this.label2.Location = new System.Drawing.Point(433, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(337, 50);
            this.label2.TabIndex = 11;
            this.label2.Text = "DECK GENERALS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.ImageLocation = "cards.img\\Tiger555.png";
            this.pictureBox1.Location = new System.Drawing.Point(901, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(375, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // btn_proceed
            // 
            this.btn_proceed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_proceed.BackColor = System.Drawing.Color.White;
            this.btn_proceed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_proceed.Enabled = false;
            this.btn_proceed.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_proceed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btn_proceed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn_proceed.Font = new System.Drawing.Font("Stencil", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_proceed.Location = new System.Drawing.Point(553, 339);
            this.btn_proceed.Name = "btn_proceed";
            this.btn_proceed.Size = new System.Drawing.Size(100, 50);
            this.btn_proceed.TabIndex = 9;
            this.btn_proceed.Text = "Proceed";
            this.btn_proceed.UseVisualStyleBackColor = false;
            this.btn_proceed.Visible = false;
            this.btn_proceed.Click += new System.EventHandler(this.btn_proceed_Click);
            // 
            // lbl_entername
            // 
            this.lbl_entername.Enabled = false;
            this.lbl_entername.Font = new System.Drawing.Font("Stencil", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_entername.Location = new System.Drawing.Point(537, 295);
            this.lbl_entername.Name = "lbl_entername";
            this.lbl_entername.Size = new System.Drawing.Size(133, 14);
            this.lbl_entername.TabIndex = 8;
            this.lbl_entername.Text = "Enter your name";
            this.lbl_entername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_entername.Visible = false;
            // 
            // txt_entername
            // 
            this.txt_entername.Enabled = false;
            this.txt_entername.Font = new System.Drawing.Font("Stencil", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_entername.Location = new System.Drawing.Point(537, 312);
            this.txt_entername.Name = "txt_entername";
            this.txt_entername.Size = new System.Drawing.Size(133, 21);
            this.txt_entername.TabIndex = 7;
            this.txt_entername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_entername.Visible = false;
            // 
            // btn_cardbase
            // 
            this.btn_cardbase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cardbase.BackColor = System.Drawing.Color.White;
            this.btn_cardbase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_cardbase.Enabled = false;
            this.btn_cardbase.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_cardbase.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btn_cardbase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn_cardbase.Font = new System.Drawing.Font("Stencil", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cardbase.Location = new System.Drawing.Point(553, 242);
            this.btn_cardbase.Name = "btn_cardbase";
            this.btn_cardbase.Size = new System.Drawing.Size(100, 50);
            this.btn_cardbase.TabIndex = 6;
            this.btn_cardbase.Text = "Card base";
            this.btn_cardbase.UseVisualStyleBackColor = false;
            // 
            // btn_start
            // 
            this.btn_start.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_start.BackColor = System.Drawing.Color.White;
            this.btn_start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_start.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btn_start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn_start.Font = new System.Drawing.Font("Stencil", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Location = new System.Drawing.Point(553, 130);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(100, 50);
            this.btn_start.TabIndex = 5;
            this.btn_start.Text = "Start new game";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_about
            // 
            this.btn_about.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_about.BackColor = System.Drawing.Color.White;
            this.btn_about.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_about.Enabled = false;
            this.btn_about.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_about.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btn_about.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn_about.Font = new System.Drawing.Font("Stencil", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_about.Location = new System.Drawing.Point(553, 186);
            this.btn_about.Name = "btn_about";
            this.btn_about.Size = new System.Drawing.Size(100, 50);
            this.btn_about.TabIndex = 4;
            this.btn_about.Text = "Rules";
            this.btn_about.UseVisualStyleBackColor = false;
            // 
            // tabpg_draftmenu
            // 
            this.tabpg_draftmenu.AutoScroll = true;
            this.tabpg_draftmenu.BackColor = System.Drawing.Color.White;
            this.tabpg_draftmenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabpg_draftmenu.Controls.Add(this.lbl_lastpicked);
            this.tabpg_draftmenu.Controls.Add(this.pct_lastplayed);
            this.tabpg_draftmenu.Controls.Add(this.lbl_log);
            this.tabpg_draftmenu.Controls.Add(this.txt_log);
            this.tabpg_draftmenu.Location = new System.Drawing.Point(4, 22);
            this.tabpg_draftmenu.Name = "tabpg_draftmenu";
            this.tabpg_draftmenu.Padding = new System.Windows.Forms.Padding(3);
            this.tabpg_draftmenu.Size = new System.Drawing.Size(1272, 774);
            this.tabpg_draftmenu.TabIndex = 2;
            this.tabpg_draftmenu.Text = "Draft Menu";
            // 
            // lbl_lastpicked
            // 
            this.lbl_lastpicked.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lastpicked.Location = new System.Drawing.Point(0, 144);
            this.lbl_lastpicked.Name = "lbl_lastpicked";
            this.lbl_lastpicked.Size = new System.Drawing.Size(150, 23);
            this.lbl_lastpicked.TabIndex = 3;
            this.lbl_lastpicked.Text = "Last Picked";
            this.lbl_lastpicked.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pct_lastplayed
            // 
            this.pct_lastplayed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pct_lastplayed.Location = new System.Drawing.Point(0, 170);
            this.pct_lastplayed.Name = "pct_lastplayed";
            this.pct_lastplayed.Size = new System.Drawing.Size(150, 225);
            this.pct_lastplayed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pct_lastplayed.TabIndex = 2;
            this.pct_lastplayed.TabStop = false;
            // 
            // lbl_log
            // 
            this.lbl_log.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_log.Location = new System.Drawing.Point(0, 398);
            this.lbl_log.Name = "lbl_log";
            this.lbl_log.Size = new System.Drawing.Size(150, 23);
            this.lbl_log.TabIndex = 1;
            this.lbl_log.Text = "Log";
            this.lbl_log.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_log
            // 
            this.txt_log.BackColor = System.Drawing.Color.White;
            this.txt_log.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_log.Font = new System.Drawing.Font("Stencil", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_log.Location = new System.Drawing.Point(0, 424);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ReadOnly = true;
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_log.Size = new System.Drawing.Size(150, 350);
            this.txt_log.TabIndex = 0;
            this.txt_log.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabpg_gamemenu
            // 
            this.tabpg_gamemenu.AutoScroll = true;
            this.tabpg_gamemenu.Controls.Add(this.lbl_computercardsnum);
            this.tabpg_gamemenu.Controls.Add(this.label6);
            this.tabpg_gamemenu.Controls.Add(this.lbl_computerresources);
            this.tabpg_gamemenu.Controls.Add(this.label4);
            this.tabpg_gamemenu.Controls.Add(this.lbl_numbeofresources);
            this.tabpg_gamemenu.Controls.Add(this.label3);
            this.tabpg_gamemenu.Controls.Add(this.lbl_infantrystrength);
            this.tabpg_gamemenu.Controls.Add(this.lbl_armorsrtength);
            this.tabpg_gamemenu.Controls.Add(this.btn_infantryoccupied);
            this.tabpg_gamemenu.Controls.Add(this.btn_armoroccupied);
            this.tabpg_gamemenu.Controls.Add(this.lbl_computercitystrength);
            this.tabpg_gamemenu.Controls.Add(this.btn_endturn);
            this.tabpg_gamemenu.Controls.Add(this.lbl_playercitystrength);
            this.tabpg_gamemenu.Controls.Add(this.prgbar_computercitystrength);
            this.tabpg_gamemenu.Controls.Add(this.pct_computercity);
            this.tabpg_gamemenu.Controls.Add(this.label1);
            this.tabpg_gamemenu.Controls.Add(this.lbl_armor);
            this.tabpg_gamemenu.Controls.Add(this.pct_infantry);
            this.tabpg_gamemenu.Controls.Add(this.pct_armor);
            this.tabpg_gamemenu.Controls.Add(this.prgbar_playercitytrength);
            this.tabpg_gamemenu.Controls.Add(this.pct_playercity);
            this.tabpg_gamemenu.Location = new System.Drawing.Point(4, 22);
            this.tabpg_gamemenu.Name = "tabpg_gamemenu";
            this.tabpg_gamemenu.Padding = new System.Windows.Forms.Padding(3);
            this.tabpg_gamemenu.Size = new System.Drawing.Size(1272, 774);
            this.tabpg_gamemenu.TabIndex = 3;
            this.tabpg_gamemenu.Text = "Game Menu";
            this.tabpg_gamemenu.UseVisualStyleBackColor = true;
            // 
            // lbl_numbeofresources
            // 
            this.lbl_numbeofresources.Font = new System.Drawing.Font("Stencil", 10F);
            this.lbl_numbeofresources.Location = new System.Drawing.Point(1235, 446);
            this.lbl_numbeofresources.Name = "lbl_numbeofresources";
            this.lbl_numbeofresources.Size = new System.Drawing.Size(29, 17);
            this.lbl_numbeofresources.TabIndex = 16;
            this.lbl_numbeofresources.Text = "1";
            this.lbl_numbeofresources.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Stencil", 10F);
            this.label3.Location = new System.Drawing.Point(1060, 446);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Number of resources:";
            // 
            // lbl_infantrystrength
            // 
            this.lbl_infantrystrength.AutoSize = true;
            this.lbl_infantrystrength.Font = new System.Drawing.Font("Stencil", 12F);
            this.lbl_infantrystrength.Location = new System.Drawing.Point(689, 392);
            this.lbl_infantrystrength.Name = "lbl_infantrystrength";
            this.lbl_infantrystrength.Size = new System.Drawing.Size(0, 19);
            this.lbl_infantrystrength.TabIndex = 14;
            // 
            // lbl_armorsrtength
            // 
            this.lbl_armorsrtength.AutoSize = true;
            this.lbl_armorsrtength.Font = new System.Drawing.Font("Stencil", 12F);
            this.lbl_armorsrtength.Location = new System.Drawing.Point(418, 395);
            this.lbl_armorsrtength.Name = "lbl_armorsrtength";
            this.lbl_armorsrtength.Size = new System.Drawing.Size(0, 19);
            this.lbl_armorsrtength.TabIndex = 13;
            // 
            // btn_infantryoccupied
            // 
            this.btn_infantryoccupied.BackColor = System.Drawing.Color.Gray;
            this.btn_infantryoccupied.Enabled = false;
            this.btn_infantryoccupied.Location = new System.Drawing.Point(734, 391);
            this.btn_infantryoccupied.Name = "btn_infantryoccupied";
            this.btn_infantryoccupied.Size = new System.Drawing.Size(75, 23);
            this.btn_infantryoccupied.TabIndex = 12;
            this.btn_infantryoccupied.UseVisualStyleBackColor = false;
            // 
            // btn_armoroccupied
            // 
            this.btn_armoroccupied.BackColor = System.Drawing.Color.Gray;
            this.btn_armoroccupied.Enabled = false;
            this.btn_armoroccupied.Location = new System.Drawing.Point(479, 391);
            this.btn_armoroccupied.Name = "btn_armoroccupied";
            this.btn_armoroccupied.Size = new System.Drawing.Size(75, 23);
            this.btn_armoroccupied.TabIndex = 11;
            this.btn_armoroccupied.UseVisualStyleBackColor = false;
            // 
            // lbl_computercitystrength
            // 
            this.lbl_computercitystrength.Font = new System.Drawing.Font("Stencil", 10F);
            this.lbl_computercitystrength.Location = new System.Drawing.Point(1162, 6);
            this.lbl_computercitystrength.Name = "lbl_computercitystrength";
            this.lbl_computercitystrength.Size = new System.Drawing.Size(75, 17);
            this.lbl_computercitystrength.TabIndex = 10;
            this.lbl_computercitystrength.Text = "INFANTRY";
            this.lbl_computercitystrength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_endturn
            // 
            this.btn_endturn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_endturn.BackColor = System.Drawing.Color.White;
            this.btn_endturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_endturn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_endturn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btn_endturn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn_endturn.Font = new System.Drawing.Font("Stencil", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_endturn.Location = new System.Drawing.Point(709, 429);
            this.btn_endturn.Name = "btn_endturn";
            this.btn_endturn.Size = new System.Drawing.Size(100, 50);
            this.btn_endturn.TabIndex = 9;
            this.btn_endturn.Text = "END TURN";
            this.btn_endturn.UseVisualStyleBackColor = false;
            this.btn_endturn.Click += new System.EventHandler(this.btn_endturn_Click);
            // 
            // lbl_playercitystrength
            // 
            this.lbl_playercitystrength.Font = new System.Drawing.Font("Stencil", 10F);
            this.lbl_playercitystrength.Location = new System.Drawing.Point(1162, 503);
            this.lbl_playercitystrength.Name = "lbl_playercitystrength";
            this.lbl_playercitystrength.Size = new System.Drawing.Size(75, 17);
            this.lbl_playercitystrength.TabIndex = 8;
            this.lbl_playercitystrength.Text = "INFANTRY";
            this.lbl_playercitystrength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prgbar_computercitystrength
            // 
            this.prgbar_computercitystrength.Location = new System.Drawing.Point(1122, 27);
            this.prgbar_computercitystrength.Name = "prgbar_computercitystrength";
            this.prgbar_computercitystrength.Size = new System.Drawing.Size(150, 20);
            this.prgbar_computercitystrength.TabIndex = 7;
            // 
            // pct_computercity
            // 
            this.pct_computercity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pct_computercity.Location = new System.Drawing.Point(1122, 53);
            this.pct_computercity.Name = "pct_computercity";
            this.pct_computercity.Size = new System.Drawing.Size(150, 225);
            this.pct_computercity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pct_computercity.TabIndex = 6;
            this.pct_computercity.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 12F);
            this.label1.Location = new System.Drawing.Point(689, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "INFANTRY";
            // 
            // lbl_armor
            // 
            this.lbl_armor.AutoSize = true;
            this.lbl_armor.Font = new System.Drawing.Font("Stencil", 12F);
            this.lbl_armor.Location = new System.Drawing.Point(447, 138);
            this.lbl_armor.Name = "lbl_armor";
            this.lbl_armor.Size = new System.Drawing.Size(64, 19);
            this.lbl_armor.TabIndex = 4;
            this.lbl_armor.Text = "ARMOR";
            // 
            // pct_infantry
            // 
            this.pct_infantry.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pct_infantry.Location = new System.Drawing.Point(659, 160);
            this.pct_infantry.Name = "pct_infantry";
            this.pct_infantry.Size = new System.Drawing.Size(150, 225);
            this.pct_infantry.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pct_infantry.TabIndex = 3;
            this.pct_infantry.TabStop = false;
            // 
            // pct_armor
            // 
            this.pct_armor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pct_armor.Location = new System.Drawing.Point(404, 160);
            this.pct_armor.Name = "pct_armor";
            this.pct_armor.Size = new System.Drawing.Size(150, 225);
            this.pct_armor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pct_armor.TabIndex = 2;
            this.pct_armor.TabStop = false;
            // 
            // prgbar_playercitytrength
            // 
            this.prgbar_playercitytrength.Location = new System.Drawing.Point(1122, 523);
            this.prgbar_playercitytrength.Name = "prgbar_playercitytrength";
            this.prgbar_playercitytrength.Size = new System.Drawing.Size(150, 20);
            this.prgbar_playercitytrength.TabIndex = 1;
            // 
            // pct_playercity
            // 
            this.pct_playercity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pct_playercity.Location = new System.Drawing.Point(1122, 549);
            this.pct_playercity.Name = "pct_playercity";
            this.pct_playercity.Size = new System.Drawing.Size(150, 225);
            this.pct_playercity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pct_playercity.TabIndex = 0;
            this.pct_playercity.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Stencil", 10F);
            this.label4.Location = new System.Drawing.Point(1065, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Number of resources:";
            // 
            // lbl_computerresources
            // 
            this.lbl_computerresources.Font = new System.Drawing.Font("Stencil", 10F);
            this.lbl_computerresources.Location = new System.Drawing.Point(1235, 281);
            this.lbl_computerresources.Name = "lbl_computerresources";
            this.lbl_computerresources.Size = new System.Drawing.Size(29, 17);
            this.lbl_computerresources.TabIndex = 18;
            this.lbl_computerresources.Text = "1";
            this.lbl_computerresources.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Stencil", 10F);
            this.label6.Location = new System.Drawing.Point(1114, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Cards in Hand:";
            // 
            // lbl_computercardsnum
            // 
            this.lbl_computercardsnum.Font = new System.Drawing.Font("Stencil", 10F);
            this.lbl_computercardsnum.Location = new System.Drawing.Point(1235, 298);
            this.lbl_computercardsnum.Name = "lbl_computercardsnum";
            this.lbl_computercardsnum.Size = new System.Drawing.Size(29, 17);
            this.lbl_computercardsnum.TabIndex = 20;
            this.lbl_computercardsnum.Text = "1";
            this.lbl_computercardsnum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pct_menucards
            // 
            this.pct_menucards.Location = new System.Drawing.Point(433, 395);
            this.pct_menucards.Name = "pct_menucards";
            this.pct_menucards.Size = new System.Drawing.Size(345, 275);
            this.pct_menucards.TabIndex = 13;
            this.pct_menucards.TabStop = false;
            this.pct_menucards.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pct_menucards.ImageLocation = "C:\\C#\\DeckGenerals\\cards.img\\MainMenuCards.jpg";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.tabControl1);
            this.Name = "UserInterface";
            this.Text = "UserInterface";
            this.tabControl1.ResumeLayout(false);
            this.tabpg_mainmenu.ResumeLayout(false);
            this.tabpg_mainmenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabpg_draftmenu.ResumeLayout(false);
            this.tabpg_draftmenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pct_lastplayed)).EndInit();
            this.tabpg_gamemenu.ResumeLayout(false);
            this.tabpg_gamemenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pct_computercity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_infantry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_armor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_playercity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_menucards)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabpg_mainmenu;
        private System.Windows.Forms.TabPage tabpg_draftmenu;
        private System.Windows.Forms.Button btn_about;
        private System.Windows.Forms.Label lbl_entername;
        private System.Windows.Forms.TextBox txt_entername;
        private System.Windows.Forms.Button btn_cardbase;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_proceed;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.TabPage tabpg_gamemenu;
        private System.Windows.Forms.Label lbl_log;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_lastpicked;
        private System.Windows.Forms.PictureBox pct_lastplayed;
        private System.Windows.Forms.Label lbl_armor;
        private System.Windows.Forms.PictureBox pct_infantry;
        private System.Windows.Forms.PictureBox pct_armor;
        private System.Windows.Forms.ProgressBar prgbar_playercitytrength;
        private System.Windows.Forms.PictureBox pct_playercity;
        private System.Windows.Forms.ProgressBar prgbar_computercitystrength;
        private System.Windows.Forms.PictureBox pct_computercity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_playercitystrength;
        private System.Windows.Forms.Button btn_endturn;
        private System.Windows.Forms.Label lbl_computercitystrength;
        private System.Windows.Forms.Label lbl_numbeofresources;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_infantrystrength;
        private System.Windows.Forms.Label lbl_armorsrtength;
        private System.Windows.Forms.Button btn_infantryoccupied;
        private System.Windows.Forms.Button btn_armoroccupied;
        private System.Windows.Forms.Label lbl_computercardsnum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_computerresources;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pct_menucards;
    }
}