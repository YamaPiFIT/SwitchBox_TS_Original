﻿using System;
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
    public partial class SendMessage : Form
    {
        public SendMessage()
        {
            InitializeComponent();

            // フォーム全体を透過する
            this.TransparencyKey = this.BackColor;
        }
    }
}
