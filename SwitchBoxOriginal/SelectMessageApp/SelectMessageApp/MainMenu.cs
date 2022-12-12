using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelectMessageApp
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// メッセ－ジアプリ起動ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageAppStartButon_Click(object sender, EventArgs e)
        {
            SendMessage _sendMessage = new SendMessage();
            _sendMessage.Show();
        }
    }
}
