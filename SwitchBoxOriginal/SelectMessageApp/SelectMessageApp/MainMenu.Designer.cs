namespace SelectMessageApp
{
    partial class MainMenu
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.SetupButton = new System.Windows.Forms.TextBox();
            this.LOGO = new System.Windows.Forms.TextBox();
            this.MessageAppStartButon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SetupButton
            // 
            this.SetupButton.Font = new System.Drawing.Font("UD デジタル 教科書体 NK-B", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SetupButton.Location = new System.Drawing.Point(93, 265);
            this.SetupButton.Margin = new System.Windows.Forms.Padding(2);
            this.SetupButton.Name = "SetupButton";
            this.SetupButton.Size = new System.Drawing.Size(212, 38);
            this.SetupButton.TabIndex = 0;
            this.SetupButton.Text = "Setup";
            this.SetupButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LOGO
            // 
            this.LOGO.Font = new System.Drawing.Font("UD デジタル 教科書体 NK-B", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LOGO.Location = new System.Drawing.Point(93, 49);
            this.LOGO.Margin = new System.Windows.Forms.Padding(2);
            this.LOGO.Name = "LOGO";
            this.LOGO.Size = new System.Drawing.Size(212, 38);
            this.LOGO.TabIndex = 2;
            this.LOGO.Text = "ロゴ";
            this.LOGO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MessageAppStartButon
            // 
            this.MessageAppStartButon.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MessageAppStartButon.Font = new System.Drawing.Font("UD デジタル 教科書体 NK-B", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MessageAppStartButon.Location = new System.Drawing.Point(46, 333);
            this.MessageAppStartButon.Name = "MessageAppStartButon";
            this.MessageAppStartButon.Size = new System.Drawing.Size(316, 52);
            this.MessageAppStartButon.TabIndex = 3;
            this.MessageAppStartButon.Text = "MessageAppStartButon";
            this.MessageAppStartButon.UseVisualStyleBackColor = false;
            this.MessageAppStartButon.Click += new System.EventHandler(this.MessageAppStartButon_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(407, 429);
            this.Controls.Add(this.MessageAppStartButon);
            this.Controls.Add(this.LOGO);
            this.Controls.Add(this.SetupButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainMenu";
            this.Text = "Setup Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SetupButton;
        private System.Windows.Forms.TextBox LOGO;
        private System.Windows.Forms.Button MessageAppStartButon;
    }
}

