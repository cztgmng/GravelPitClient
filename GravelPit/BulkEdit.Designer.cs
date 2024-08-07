namespace GravelPit
{
    partial class BulkEdit
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
            label6 = new Label();
            button1 = new Button();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            label5 = new Label();
            textBox5 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            button3 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(423, 48);
            label6.Name = "label6";
            label6.RightToLeft = RightToLeft.Yes;
            label6.Size = new Size(85, 15);
            label6.TabIndex = 36;
            label6.Text = "(dd-mm-yyyy)";
            // 
            // button1
            // 
            button1.ForeColor = Color.Black;
            button1.Location = new Point(12, 176);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 35;
            button1.Text = "Delete";
            button1.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            comboBox2.BackColor = Color.White;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(89, 103);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(419, 23);
            comboBox2.TabIndex = 34;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.White;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(89, 74);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(419, 23);
            comboBox1.TabIndex = 33;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(8, 135);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.Yes;
            label5.Size = new Size(51, 15);
            label5.TabIndex = 32;
            label5.Text = "Amount";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(89, 132);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(419, 23);
            textBox5.TabIndex = 31;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(8, 106);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.Yes;
            label4.Size = new Size(31, 15);
            label4.TabIndex = 30;
            label4.Text = "Type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(8, 77);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(38, 15);
            label3.TabIndex = 29;
            label3.Text = "Client";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(8, 48);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(31, 15);
            label2.TabIndex = 28;
            label2.Text = "Date";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(89, 45);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(328, 23);
            textBox2.TabIndex = 27;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(8, 15);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(31, 15);
            label1.TabIndex = 26;
            label1.Text = "ID(s)";
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(89, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(419, 23);
            textBox1.TabIndex = 25;
            // 
            // button3
            // 
            button3.ForeColor = Color.Black;
            button3.Location = new Point(433, 176);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 24;
            button3.Text = "Save";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.ForeColor = Color.Black;
            button2.Location = new Point(217, 176);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 23;
            button2.Text = "CopyID";
            button2.UseVisualStyleBackColor = true;
            // 
            // BulkEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 39);
            ClientSize = new Size(594, 337);
            Controls.Add(label6);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(textBox5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            ForeColor = Color.White;
            Name = "BulkEdit";
            Text = "BulkEdit";
            Load += BulkEdit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label6;
        private Button button1;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Label label5;
        private TextBox textBox5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox textBox2;
        private Label label1;
        private TextBox textBox1;
        private Button button3;
        private Button button2;
    }
}