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
            this.MessageAppStartButon = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SetupButton
            // 
            this.SetupButton.Font = new System.Drawing.Font("UD デジタル 教科書体 NK-B", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SetupButton.Location = new System.Drawing.Point(155, 398);
            this.SetupButton.Name = "SetupButton";
            this.SetupButton.Size = new System.Drawing.Size(350, 54);
            this.SetupButton.TabIndex = 0;
            this.SetupButton.Text = "Setup";
            this.SetupButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MessageAppStartButon
            // 
            this.MessageAppStartButon.Font = new System.Drawing.Font("UD デジタル 教科書体 NK-B", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MessageAppStartButon.Location = new System.Drawing.Point(104, 492);
            this.MessageAppStartButon.Name = "MessageAppStartButon";
            this.MessageAppStartButon.Size = new System.Drawing.Size(450, 54);
            this.MessageAppStartButon.TabIndex = 1;
            this.MessageAppStartButon.Text = "Message App Start";
            this.MessageAppStartButon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(678, 644);
            this.Controls.Add(this.MessageAppStartButon);
            this.Controls.Add(this.SetupButton);
            this.Name = "MainMenu";
            this.Text = "Setup Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SetupButton;
        private System.Windows.Forms.TextBox MessageAppStartButon;
    }
}

