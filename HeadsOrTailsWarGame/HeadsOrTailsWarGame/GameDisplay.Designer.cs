namespace HeadsOrTailsWarGame
{
    partial class GameDisplay
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btn_ResetSelections = new System.Windows.Forms.Button();
            this.btn_SelectOtherStateAreas = new System.Windows.Forms.Button();
            this.lbl_PlayerTurn = new System.Windows.Forms.Label();
            this.btn_SelectSelectorAreas = new System.Windows.Forms.Button();
            this.btn_CaptureAreas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ResetSelections
            // 
            this.btn_ResetSelections.Location = new System.Drawing.Point(902, 178);
            this.btn_ResetSelections.Name = "btn_ResetSelections";
            this.btn_ResetSelections.Size = new System.Drawing.Size(92, 64);
            this.btn_ResetSelections.TabIndex = 0;
            this.btn_ResetSelections.Text = "Reset Selections!";
            this.btn_ResetSelections.UseVisualStyleBackColor = true;
            this.btn_ResetSelections.Click += new System.EventHandler(this.btn_ResetSelections_Click);
            // 
            // btn_SelectOtherStateAreas
            // 
            this.btn_SelectOtherStateAreas.Location = new System.Drawing.Point(902, 291);
            this.btn_SelectOtherStateAreas.Name = "btn_SelectOtherStateAreas";
            this.btn_SelectOtherStateAreas.Size = new System.Drawing.Size(92, 70);
            this.btn_SelectOtherStateAreas.TabIndex = 1;
            this.btn_SelectOtherStateAreas.Text = "Select to Try Capture Areas!";
            this.btn_SelectOtherStateAreas.UseVisualStyleBackColor = true;
            this.btn_SelectOtherStateAreas.Click += new System.EventHandler(this.btn_SelectOtherStateAreas_Click);
            // 
            // lbl_PlayerTurn
            // 
            this.lbl_PlayerTurn.AutoSize = true;
            this.lbl_PlayerTurn.Location = new System.Drawing.Point(890, 70);
            this.lbl_PlayerTurn.Name = "lbl_PlayerTurn";
            this.lbl_PlayerTurn.Size = new System.Drawing.Size(104, 17);
            this.lbl_PlayerTurn.TabIndex = 2;
            this.lbl_PlayerTurn.Text = "1.Player\'s Turn";
            // 
            // btn_SelectSelectorAreas
            // 
            this.btn_SelectSelectorAreas.Location = new System.Drawing.Point(902, 390);
            this.btn_SelectSelectorAreas.Name = "btn_SelectSelectorAreas";
            this.btn_SelectSelectorAreas.Size = new System.Drawing.Size(92, 63);
            this.btn_SelectSelectorAreas.TabIndex = 3;
            this.btn_SelectSelectorAreas.Text = "Select to Your Bet Areas!";
            this.btn_SelectSelectorAreas.UseVisualStyleBackColor = true;
            this.btn_SelectSelectorAreas.Click += new System.EventHandler(this.btn_SelectSelectorAreas_Click);
            // 
            // btn_CaptureAreas
            // 
            this.btn_CaptureAreas.Location = new System.Drawing.Point(902, 486);
            this.btn_CaptureAreas.Name = "btn_CaptureAreas";
            this.btn_CaptureAreas.Size = new System.Drawing.Size(92, 61);
            this.btn_CaptureAreas.TabIndex = 4;
            this.btn_CaptureAreas.Text = "Try to Capture Areas!";
            this.btn_CaptureAreas.UseVisualStyleBackColor = true;
            this.btn_CaptureAreas.Click += new System.EventHandler(this.btn_CaptureAreas_Click);
            // 
            // GameDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.btn_CaptureAreas);
            this.Controls.Add(this.btn_SelectSelectorAreas);
            this.Controls.Add(this.lbl_PlayerTurn);
            this.Controls.Add(this.btn_SelectOtherStateAreas);
            this.Controls.Add(this.btn_ResetSelections);
            this.Name = "GameDisplay";
            this.Text = "HOTWarG";
            this.Load += new System.EventHandler(this.GameDisplay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btn_ResetSelections;
        private System.Windows.Forms.Button btn_SelectOtherStateAreas;
        private System.Windows.Forms.Label lbl_PlayerTurn;
        private System.Windows.Forms.Button btn_SelectSelectorAreas;
        private System.Windows.Forms.Button btn_CaptureAreas;
    }
}

