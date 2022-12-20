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
            this.LOGO = new System.Windows.Forms.TextBox();
            this.MessageAppStartButon = new System.Windows.Forms.Button();
            this.SetupButton = new System.Windows.Forms.Button();
            this.TestButton = new System.Windows.Forms.Button();
            this.PORT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LOGO
            // 
            this.LOGO.Font = new System.Drawing.Font("UD デジタル 教科書体 NK-B", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LOGO.Location = new System.Drawing.Point(155, 74);
            this.LOGO.Name = "LOGO";
            this.LOGO.Size = new System.Drawing.Size(351, 54);
            this.LOGO.TabIndex = 2;
            this.LOGO.Text = "ロゴ";
            this.LOGO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MessageAppStartButon
            // 
            this.MessageAppStartButon.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MessageAppStartButon.Font = new System.Drawing.Font("UD デジタル 教科書体 NK-B", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MessageAppStartButon.Location = new System.Drawing.Point(77, 500);
            this.MessageAppStartButon.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MessageAppStartButon.Name = "MessageAppStartButon";
            this.MessageAppStartButon.Size = new System.Drawing.Size(527, 78);
            this.MessageAppStartButon.TabIndex = 3;
            this.MessageAppStartButon.Text = "MessageAppStart";
            this.MessageAppStartButon.UseVisualStyleBackColor = false;
            this.MessageAppStartButon.Click += new System.EventHandler(this.MessageAppStartButon_Click);
            // 
            // SetupButton
            // 
            this.SetupButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SetupButton.Font = new System.Drawing.Font("UD デジタル 教科書体 NK-B", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SetupButton.Location = new System.Drawing.Point(77, 388);
            this.SetupButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.SetupButton.Name = "SetupButton";
            this.SetupButton.Size = new System.Drawing.Size(527, 78);
            this.SetupButton.TabIndex = 4;
            this.SetupButton.Text = "Setup";
            this.SetupButton.UseVisualStyleBackColor = false;
            this.SetupButton.Click += new System.EventHandler(this.SetupButton_Click);
            // 
            // TestButton
            // 
            this.TestButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TestButton.Font = new System.Drawing.Font("UD デジタル 教科書体 NK-B", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TestButton.Location = new System.Drawing.Point(75, 282);
            this.TestButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(527, 78);
            this.TestButton.TabIndex = 5;
            this.TestButton.Text = "TestButton";
            this.TestButton.UseVisualStyleBackColor = false;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // PORT
            // 
            this.PORT.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PORT.Font = new System.Drawing.Font("UD デジタル 教科書体 NK-B", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PORT.Location = new System.Drawing.Point(75, 175);
            this.PORT.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.PORT.Name = "PORT";
            this.PORT.Size = new System.Drawing.Size(527, 78);
            this.PORT.TabIndex = 6;
            this.PORT.Text = "PORT SETUP";
            this.PORT.UseVisualStyleBackColor = false;
            this.PORT.Click += new System.EventHandler(this.PORT_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(678, 644);
            this.Controls.Add(this.PORT);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.SetupButton);
            this.Controls.Add(this.MessageAppStartButon);
            this.Controls.Add(this.LOGO);
            this.Name = "MainMenu";
            this.Text = "Setup Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox LOGO;
        private System.Windows.Forms.Button MessageAppStartButon;
        private System.Windows.Forms.Button SetupButton;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.Button PORT;
    }
}

