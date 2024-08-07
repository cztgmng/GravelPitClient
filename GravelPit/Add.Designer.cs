using GravelPit.Properties;
using System.Resources;
using static GravelPit.Localizer;

namespace GravelPit
{
    partial class Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            comboBox2 = new ComboBox();
            textBox1 = new TextBox();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button2 = new Button();
            label3 = new Label();
            richTextBox1 = new RichTextBox();
            panel1 = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            monthCalendar1 = new MonthCalendar();
            label4 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // comboBox2
            // 
            comboBox2.BackColor = Color.White;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(12, 52);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(310, 23);
            comboBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.Location = new Point(78, 128);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(178, 23);
            textBox1.TabIndex = 2;
            textBox1.KeyDown += textBox1_KeyDown;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(136, 110);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 3;
            label1.Text = GetTranslation("Amount") + "(t)";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.ForeColor = Color.White;
            flowLayoutPanel1.Location = new Point(12, 157);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(310, 324);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(125, 487);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = GetTranslation("Confirm");
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(151, 34);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 7;
            label3.Text = GetTranslation("Type");
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(39, 39, 39);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.ForeColor = Color.White;
            richTextBox1.Location = new Point(12, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(310, 22);
            richTextBox1.TabIndex = 8;
            richTextBox1.Text = "";
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(450, 493);
            panel1.Name = "panel1";
            panel1.Size = new Size(623, 528);
            panel1.TabIndex = 15;
            panel1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(124, 211);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 1;
            label2.Text = GetTranslation("Sending") + "...";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.loading;
            pictureBox1.Location = new Point(145, 226);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // monthCalendar1
            // 
            monthCalendar1.CalendarDimensions = new Size(1, 3);
            monthCalendar1.Location = new Point(334, 19);
            monthCalendar1.MaxSelectionCount = 1;
            monthCalendar1.MinDate = new DateTime(2023, 1, 1, 0, 0, 0, 0);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.ShowToday = false;
            monthCalendar1.ShowTodayCircle = false;
            monthCalendar1.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(123, 78);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 17;
            label4.Text = GetTranslation("ChangeDate") + "!";
            // 
            // Add
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 39);
            ClientSize = new Size(617, 522);
            Controls.Add(label4);
            Controls.Add(monthCalendar1);
            Controls.Add(panel1);
            Controls.Add(richTextBox1);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(comboBox2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Add";
            Text = "Add";
            Load += Add_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBox2;
        private TextBox textBox1;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button2;
        private Label label3;
        private RichTextBox richTextBox1;
        private Panel panel1;
        private Label label2;
        private PictureBox pictureBox1;
        private MonthCalendar monthCalendar1;
        private Label label4;
    }
}