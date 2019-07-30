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
            // btn_CaptureAreas
            // 
            this.btn_CaptureAreas.Location = new System.Drawing.Point(902, 291);
            this.btn_CaptureAreas.Name = "btn_CaptureAreas";
            this.btn_CaptureAreas.Size = new System.Drawing.Size(92, 70);
            this.btn_CaptureAreas.TabIndex = 1;
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
            this.Controls.Add(this.btn_ResetSelections);
            this.Name = "GameDisplay";
            this.Text = "HOTWarG";
            this.Load += new System.EventHandler(this.GameDisplay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btn_ResetSelections;
        private System.Windows.Forms.Button btn_CaptureAreas;
    }
}

