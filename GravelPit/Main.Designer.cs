
using static GravelPit.Localizer;



namespace GravelPit
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            button1 = new Button();
            comboBox1 = new ComboBox();
            monthCalendar1 = new MonthCalendar();
            richTextBox1 = new RichTextBox();
            monthCalendar2 = new MonthCalendar();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            label7 = new Label();
            richTextBox2 = new RichTextBox();
            button3 = new Button();
            button4 = new Button();
            SettledButton = new Button();
            NotSettledButton = new Button();
            label9 = new Label();
            toolStrip1 = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            clientsToolStripMenuItem = new ToolStripMenuItem();
            typesToolStripMenuItem = new ToolStripMenuItem();
            settingsDropDownButton = new ToolStripDropDownButton();
            languageDropDownButton = new ToolStripMenuItem();
            englishButton = new ToolStripMenuItem();
            polishButton = new ToolStripMenuItem();
            bulkEditButton = new Button();
            mainPanel = new FlowLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(5, 59);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(5, 120);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(269, 23);
            comboBox1.TabIndex = 1;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(5, 180);
            monthCalendar1.MaxSelectionCount = 1;
            monthCalendar1.MinDate = new DateTime(2023, 1, 1, 0, 0, 0, 0);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.ShowToday = false;
            monthCalendar1.ShowTodayCircle = false;
            monthCalendar1.TabIndex = 2;
            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(39, 39, 39);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.ForeColor = Color.White;
            richTextBox1.Location = new Point(3, 468);
            richTextBox1.Multiline = false;
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(269, 18);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "";
            richTextBox1.WordWrap = false;
            // 
            // monthCalendar2
            // 
            monthCalendar2.Location = new Point(5, 387);
            monthCalendar2.MaxSelectionCount = 1;
            monthCalendar2.MinDate = new DateTime(2023, 1, 1, 0, 0, 0, 0);
            monthCalendar2.Name = "monthCalendar2";
            monthCalendar2.ShowToday = false;
            monthCalendar2.ShowTodayCircle = false;
            monthCalendar2.TabIndex = 10;
            monthCalendar2.DateSelected += monthCalendar2_DateSelected;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(120, 156);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 11;
            label1.Text = "Start";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(118, 363);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 12;
            label2.Text = "End";
            // 
            // button2
            // 
            button2.Location = new Point(92, 499);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 13;
            button2.Text = "Search";
            button2.UseVisualStyleBackColor = true;
            button2.Click += SearchButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(1103, 572);
            panel1.Name = "panel1";
            panel1.Size = new Size(1163, 589);
            panel1.TabIndex = 24;
            panel1.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.loading;
            pictureBox1.Location = new Point(584, 261);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(richTextBox1);
            panel2.Controls.Add(button2);
            panel2.Location = new Point(1, 88);
            panel2.Name = "panel2";
            panel2.Size = new Size(278, 531);
            panel2.TabIndex = 25;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(91, 97);
            label7.Name = "label7";
            label7.Size = new Size(88, 20);
            label7.TabIndex = 26;
            label7.Text = "SearchPanel";
            // 
            // richTextBox2
            // 
            richTextBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            richTextBox2.BackColor = Color.FromArgb(39, 39, 39);
            richTextBox2.BorderStyle = BorderStyle.None;
            richTextBox2.ForeColor = Color.White;
            richTextBox2.Location = new Point(504, 572);
            richTextBox2.Multiline = false;
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox2.Size = new Size(426, 18);
            richTextBox2.TabIndex = 10;
            richTextBox2.Text = "";
            richTextBox2.WordWrap = false;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button3.Location = new Point(1071, 596);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 29;
            button3.Text = "Export";
            button3.UseVisualStyleBackColor = true;
            button3.Visible = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button4.Location = new Point(286, 596);
            button4.Name = "button4";
            button4.Size = new Size(120, 23);
            button4.TabIndex = 30;
            button4.Text = "CheckingMode";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // SettledButton
            // 
            SettledButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            SettledButton.Location = new Point(846, 596);
            SettledButton.Name = "SettledButton";
            SettledButton.Size = new Size(97, 23);
            SettledButton.TabIndex = 31;
            SettledButton.Text = "Settled";
            SettledButton.UseVisualStyleBackColor = true;
            SettledButton.Click += SettledButton_Click;
            // 
            // NotSettledButton
            // 
            NotSettledButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            NotSettledButton.Location = new Point(949, 596);
            NotSettledButton.Name = "NotSettledButton";
            NotSettledButton.Size = new Size(97, 23);
            NotSettledButton.TabIndex = 32;
            NotSettledButton.Text = "NotSettled";
            NotSettledButton.UseVisualStyleBackColor = true;
            NotSettledButton.Click += NotSettledButton_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(11, 39);
            label9.Name = "label9";
            label9.Size = new Size(44, 13);
            label9.TabIndex = 33;
            label9.Text = "version";
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, settingsDropDownButton });
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.Flow;
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.Professional;
            toolStrip1.Size = new Size(1152, 22);
            toolStrip1.TabIndex = 34;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { clientsToolStripMenuItem, typesToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.ShowDropDownArrow = false;
            toolStripDropDownButton1.Size = new Size(63, 19);
            toolStripDropDownButton1.Text = "Company";
            // 
            // clientsToolStripMenuItem
            // 
            clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            clientsToolStripMenuItem.Size = new Size(110, 22);
            clientsToolStripMenuItem.Text = "Clients";
            clientsToolStripMenuItem.Click += clientsToolStripMenuItem_Click;
            // 
            // typesToolStripMenuItem
            // 
            typesToolStripMenuItem.Name = "typesToolStripMenuItem";
            typesToolStripMenuItem.Size = new Size(110, 22);
            typesToolStripMenuItem.Text = "Types";
            typesToolStripMenuItem.Click += typesToolStripMenuItem_Click;
            // 
            // settingsDropDownButton
            // 
            settingsDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            settingsDropDownButton.DropDownItems.AddRange(new ToolStripItem[] { languageDropDownButton });
            settingsDropDownButton.ImageTransparentColor = Color.Magenta;
            settingsDropDownButton.Name = "settingsDropDownButton";
            settingsDropDownButton.ShowDropDownArrow = false;
            settingsDropDownButton.Size = new Size(53, 19);
            settingsDropDownButton.Text = "Settings";
            // 
            // languageDropDownButton
            // 
            languageDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            languageDropDownButton.DropDownItems.AddRange(new ToolStripItem[] { englishButton, polishButton });
            languageDropDownButton.ImageTransparentColor = Color.Magenta;
            languageDropDownButton.Name = "languageDropDownButton";
            languageDropDownButton.Size = new Size(126, 22);
            languageDropDownButton.Text = "Language";
            // 
            // englishButton
            // 
            englishButton.Name = "englishButton";
            englishButton.Size = new Size(112, 22);
            englishButton.Text = "English";
            // 
            // polishButton
            // 
            polishButton.Name = "polishButton";
            polishButton.Size = new Size(112, 22);
            polishButton.Text = "Polish";
            // 
            // bulkEditButton
            // 
            bulkEditButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bulkEditButton.Location = new Point(561, 596);
            bulkEditButton.Name = "bulkEditButton";
            bulkEditButton.Size = new Size(120, 23);
            bulkEditButton.TabIndex = 35;
            bulkEditButton.Text = "BulkEdit";
            bulkEditButton.UseVisualStyleBackColor = true;
            bulkEditButton.Click += bulkEditButton_Click;
            // 
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainPanel.AutoScroll = true;
            mainPanel.BackColor = Color.FromArgb(39, 39, 39);
            mainPanel.Location = new Point(286, 39);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(854, 551);
            mainPanel.TabIndex = 36;
            mainPanel.WrapContents = false;
            mainPanel.Resize += mainPanel_Resize;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 39);
            ClientSize = new Size(1152, 623);
            Controls.Add(panel1);
            Controls.Add(mainPanel);
            Controls.Add(bulkEditButton);
            Controls.Add(toolStrip1);
            Controls.Add(NotSettledButton);
            Controls.Add(SettledButton);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(richTextBox2);
            Controls.Add(label7);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(monthCalendar2);
            Controls.Add(monthCalendar1);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(panel2);
            Controls.Add(label9);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            Text = "GravelPit";
            Load += Main_Load;
            Resize += Main_Resize;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ComboBox comboBox1;
        private MonthCalendar monthCalendar1;
        private RichTextBox richTextBox1;
        private MonthCalendar monthCalendar2;
        private Label label1;
        private Label label2;
        private Button button2;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Label label7;
        private RichTextBox richTextBox2;
        private Button button3;
        private Button button4;
        private Button SettledButton;
        private Button NotSettledButton;
        private Label label9;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripDropDownButton settingsDropDownButton;
        private ToolStripMenuItem clientsToolStripMenuItem;
        private ToolStripMenuItem languageDropDownButton;
        private ToolStripMenuItem englishButton;
        private ToolStripMenuItem polishButton;
        private ToolStripMenuItem typesToolStripMenuItem;
        private Button bulkEditButton;
        private FlowLayoutPanel mainPanel;
    }
}