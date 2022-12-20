namespace SelectMessageApp
{
    partial class SendMessage
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
            this.MoveStateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MoveStateButton
            // 
            this.MoveStateButton.Location = new System.Drawing.Point(14, 615);
            this.MoveStateButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MoveStateButton.Name = "MoveStateButton";
            this.MoveStateButton.Size = new System.Drawing.Size(322, 34);
            this.MoveStateButton.TabIndex = 0;
            this.MoveStateButton.Text = "to achieve transparency";
            this.MoveStateButton.UseVisualStyleBackColor = true;
            this.MoveStateButton.Click += new System.EventHandler(this.MoveStateButton_Click);
            // 
            // SendMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 662);
            this.Controls.Add(this.MoveStateButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "SendMessage";
            this.Text = "SendMessage";
            this.TransparencyKey = System.Drawing.Color.White;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SendMessage_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SendMessage_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MoveStateButton;
    }
}