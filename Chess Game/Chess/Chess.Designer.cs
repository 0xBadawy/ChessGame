namespace Chess
{
    partial class Chess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chess));
            this.PlayerName1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.LableTimerPlayer2 = new System.Windows.Forms.Label();
            this.panelPlayer2 = new System.Windows.Forms.Panel();
            this.panelPlayer1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PlayerName2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LableTimerPlayer1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GameTypeLable = new System.Windows.Forms.Label();
            this.panelPlayer2.SuspendLayout();
            this.panelPlayer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayerName1
            // 
            this.PlayerName1.AutoSize = true;
            this.PlayerName1.BackColor = System.Drawing.Color.Transparent;
            this.PlayerName1.Font = new System.Drawing.Font("Microsoft Tai Le", 26F, System.Drawing.FontStyle.Bold);
            this.PlayerName1.Location = new System.Drawing.Point(6, 42);
            this.PlayerName1.Name = "PlayerName1";
            this.PlayerName1.Size = new System.Drawing.Size(160, 45);
            this.PlayerName1.TabIndex = 0;
            this.PlayerName1.Text = "----------";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SaddleBrown;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Linen;
            this.button1.Location = new System.Drawing.Point(773, 607);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(340, 47);
            this.button1.TabIndex = 1;
            this.button1.Text = "Exit Game";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LableTimerPlayer2
            // 
            this.LableTimerPlayer2.AutoSize = true;
            this.LableTimerPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.LableTimerPlayer2.Font = new System.Drawing.Font("Microsoft Tai Le", 55F, System.Drawing.FontStyle.Bold);
            this.LableTimerPlayer2.Location = new System.Drawing.Point(5, 81);
            this.LableTimerPlayer2.Name = "LableTimerPlayer2";
            this.LableTimerPlayer2.Size = new System.Drawing.Size(272, 94);
            this.LableTimerPlayer2.TabIndex = 0;
            this.LableTimerPlayer2.Text = "00 : 00";
            this.LableTimerPlayer2.Click += new System.EventHandler(this.LableTimerPlayer2_Click);
            // 
            // panelPlayer2
            // 
            this.panelPlayer2.Controls.Add(this.pictureBox2);
            this.panelPlayer2.Controls.Add(this.label1);
            this.panelPlayer2.Controls.Add(this.LableTimerPlayer2);
            this.panelPlayer2.Controls.Add(this.PlayerName1);
            this.panelPlayer2.Location = new System.Drawing.Point(752, 173);
            this.panelPlayer2.Name = "panelPlayer2";
            this.panelPlayer2.Size = new System.Drawing.Size(371, 185);
            this.panelPlayer2.TabIndex = 2;
            // 
            // panelPlayer1
            // 
            this.panelPlayer1.Controls.Add(this.pictureBox1);
            this.panelPlayer1.Controls.Add(this.label3);
            this.panelPlayer1.Controls.Add(this.PlayerName2);
            this.panelPlayer1.Controls.Add(this.LableTimerPlayer1);
            this.panelPlayer1.Location = new System.Drawing.Point(752, 387);
            this.panelPlayer1.Name = "panelPlayer1";
            this.panelPlayer1.Size = new System.Drawing.Size(371, 190);
            this.panelPlayer1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Chess.Properties.Resources._2King;
            this.pictureBox1.Location = new System.Drawing.Point(270, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Chess.Properties.Resources.King;
            this.pictureBox2.Location = new System.Drawing.Point(269, 79);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(101, 98);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 26F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Turn of";
            // 
            // PlayerName2
            // 
            this.PlayerName2.AutoSize = true;
            this.PlayerName2.BackColor = System.Drawing.Color.Transparent;
            this.PlayerName2.Font = new System.Drawing.Font("Microsoft Tai Le", 26F, System.Drawing.FontStyle.Bold);
            this.PlayerName2.Location = new System.Drawing.Point(4, 47);
            this.PlayerName2.Name = "PlayerName2";
            this.PlayerName2.Size = new System.Drawing.Size(160, 45);
            this.PlayerName2.TabIndex = 0;
            this.PlayerName2.Text = "----------";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 26F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 45);
            this.label3.TabIndex = 0;
            this.label3.Text = "Turn of";
            // 
            // LableTimerPlayer1
            // 
            this.LableTimerPlayer1.AutoSize = true;
            this.LableTimerPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.LableTimerPlayer1.Font = new System.Drawing.Font("Microsoft Tai Le", 55F, System.Drawing.FontStyle.Bold);
            this.LableTimerPlayer1.Location = new System.Drawing.Point(7, 93);
            this.LableTimerPlayer1.Name = "LableTimerPlayer1";
            this.LableTimerPlayer1.Size = new System.Drawing.Size(272, 94);
            this.LableTimerPlayer1.TabIndex = 0;
            this.LableTimerPlayer1.Text = "00 : 00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(749, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(374, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "----------------------------";
            // 
            // GameTypeLable
            // 
            this.GameTypeLable.BackColor = System.Drawing.Color.Transparent;
            this.GameTypeLable.Font = new System.Drawing.Font("Microsoft Tai Le", 26F, System.Drawing.FontStyle.Bold);
            this.GameTypeLable.ForeColor = System.Drawing.Color.Sienna;
            this.GameTypeLable.Location = new System.Drawing.Point(778, 58);
            this.GameTypeLable.Name = "GameTypeLable";
            this.GameTypeLable.Size = new System.Drawing.Size(316, 45);
            this.GameTypeLable.TabIndex = 0;
            this.GameTypeLable.Text = "turn of";
            this.GameTypeLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Chess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1265, 721);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GameTypeLable);
            this.Controls.Add(this.panelPlayer1);
            this.Controls.Add(this.panelPlayer2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.Name = "Chess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Chess_Load);
            this.panelPlayer2.ResumeLayout(false);
            this.panelPlayer2.PerformLayout();
            this.panelPlayer1.ResumeLayout(false);
            this.panelPlayer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PlayerName1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LableTimerPlayer2;
        private System.Windows.Forms.Panel panelPlayer2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelPlayer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LableTimerPlayer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label PlayerName2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label GameTypeLable;
    }
}

