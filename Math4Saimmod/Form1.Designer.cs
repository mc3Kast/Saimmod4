namespace Math4Saimmod
{
    partial class Form1
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
            lbLoch = new Label();
            lbWoch = new Label();
            tbRun = new Button();
            tbP1 = new TextBox();
            tbP2 = new TextBox();
            tbTicks = new TextBox();
            lbLc = new Label();
            lbWc = new Label();
            SuspendLayout();
            // 
            // lbLoch
            // 
            lbLoch.AutoSize = true;
            lbLoch.Location = new Point(12, 91);
            lbLoch.Name = "lbLoch";
            lbLoch.Size = new Size(33, 15);
            lbLoch.TabIndex = 0;
            lbLoch.Text = "Loch";
            // 
            // lbWoch
            // 
            lbWoch.AutoSize = true;
            lbWoch.Location = new Point(88, 91);
            lbWoch.Name = "lbWoch";
            lbWoch.Size = new Size(38, 15);
            lbWoch.TabIndex = 1;
            lbWoch.Text = "Woch";
            // 
            // tbRun
            // 
            tbRun.Location = new Point(288, 24);
            tbRun.Name = "tbRun";
            tbRun.Size = new Size(95, 36);
            tbRun.TabIndex = 2;
            tbRun.Text = "Run";
            tbRun.UseVisualStyleBackColor = true;
            tbRun.Click += tbRun_Click;
            // 
            // tbP1
            // 
            tbP1.Location = new Point(118, 24);
            tbP1.Name = "tbP1";
            tbP1.Size = new Size(67, 23);
            tbP1.TabIndex = 3;
            tbP1.Text = "0,1";
            // 
            // tbP2
            // 
            tbP2.Location = new Point(197, 24);
            tbP2.Name = "tbP2";
            tbP2.Size = new Size(56, 23);
            tbP2.TabIndex = 4;
            tbP2.Text = "0,125";
            // 
            // tbTicks
            // 
            tbTicks.Location = new Point(12, 24);
            tbTicks.Name = "tbTicks";
            tbTicks.Size = new Size(100, 23);
            tbTicks.TabIndex = 5;
            tbTicks.Text = "1000000";
            // 
            // lbLc
            // 
            lbLc.AutoSize = true;
            lbLc.Location = new Point(12, 125);
            lbLc.Name = "lbLc";
            lbLc.Size = new Size(19, 15);
            lbLc.TabIndex = 6;
            lbLc.Text = "Lc";
            // 
            // lbWc
            // 
            lbWc.AutoSize = true;
            lbWc.Location = new Point(88, 125);
            lbWc.Name = "lbWc";
            lbWc.Size = new Size(24, 15);
            lbWc.TabIndex = 7;
            lbWc.Text = "Wc";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 263);
            Controls.Add(lbWc);
            Controls.Add(lbLc);
            Controls.Add(tbTicks);
            Controls.Add(tbP2);
            Controls.Add(tbP1);
            Controls.Add(tbRun);
            Controls.Add(lbWoch);
            Controls.Add(lbLoch);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbLoch;
        private Label lbWoch;
        private Button tbRun;
        private TextBox tbP1;
        private TextBox tbP2;
        private TextBox tbTicks;
        private Label lbLc;
        private Label lbWc;
    }
}