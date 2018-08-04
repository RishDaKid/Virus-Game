namespace VirusOpdracht
{
	partial class Speelveld
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
            this.lblPointsPlayer = new System.Windows.Forms.Label();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.lblAI = new System.Windows.Forms.Label();
            this.lblPointsAI = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPointsPlayer
            // 
            this.lblPointsPlayer.AutoSize = true;
            this.lblPointsPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsPlayer.Location = new System.Drawing.Point(114, 22);
            this.lblPointsPlayer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPointsPlayer.Name = "lblPointsPlayer";
            this.lblPointsPlayer.Size = new System.Drawing.Size(26, 29);
            this.lblPointsPlayer.TabIndex = 2;
            this.lblPointsPlayer.Text = "1";
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer.Location = new System.Drawing.Point(9, 22);
            this.lblPlayer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(81, 29);
            this.lblPlayer.TabIndex = 3;
            this.lblPlayer.Text = "Player";
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(14, 526);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(112, 35);
            this.btnRestart.TabIndex = 4;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.BtnRestart_Click);
            // 
            // pbMain
            // 
            this.pbMain.Location = new System.Drawing.Point(170, 22);
            this.pbMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(556, 538);
            this.pbMain.TabIndex = 5;
            this.pbMain.TabStop = false;
            this.pbMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbMain_MouseClick);
            // 
            // lblAI
            // 
            this.lblAI.AutoSize = true;
            this.lblAI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAI.Location = new System.Drawing.Point(42, 81);
            this.lblAI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAI.Name = "lblAI";
            this.lblAI.Size = new System.Drawing.Size(34, 29);
            this.lblAI.TabIndex = 6;
            this.lblAI.Text = "AI";
            // 
            // lblPointsAI
            // 
            this.lblPointsAI.AutoSize = true;
            this.lblPointsAI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsAI.Location = new System.Drawing.Point(114, 81);
            this.lblPointsAI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPointsAI.Name = "lblPointsAI";
            this.lblPointsAI.Size = new System.Drawing.Size(26, 29);
            this.lblPointsAI.TabIndex = 7;
            this.lblPointsAI.Text = "1";
            // 
            // Speelveld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 579);
            this.Controls.Add(this.lblPointsAI);
            this.Controls.Add(this.lblAI);
            this.Controls.Add(this.pbMain);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.lblPointsPlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Speelveld";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Speelveld";
            this.Load += new System.EventHandler(this.Speelveld_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lblPointsPlayer;
		private System.Windows.Forms.Label lblPlayer;
		private System.Windows.Forms.Button btnRestart;
		private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.Label lblAI;
        private System.Windows.Forms.Label lblPointsAI;
    }
}

