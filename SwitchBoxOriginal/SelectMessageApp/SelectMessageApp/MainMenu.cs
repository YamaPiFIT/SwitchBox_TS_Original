using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX;
using SharpDX.DirectInput;

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

        /// <summary>
        /// セットアップボタンを押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetupButton_Click(object sender, EventArgs e)
        {
            SetupMeny _setupMeny = new SetupMeny();
            _setupMeny.Show();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            GamePadTest _gamePadTest = new GamePadTest();
            _gamePadTest.Show();
        }

        private void PORT_Click(object sender, EventArgs e)
        {
            Form1 _form1 = new Form1();
            _form1.Show();
        }
    }
}
