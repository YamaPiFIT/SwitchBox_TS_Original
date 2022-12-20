using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelectMessageApp
{
    public partial class SendMessage : Form
    {

        //マウスのクリック位置を記憶
        private Point mousePoint;

        //false -> 透明化（動かないモード)  true -> 不透明化（動くモード ）
        private Boolean positionState = false;


        public SendMessage()
        {
            InitializeComponent();
            initialize();
        }

        /// <summary>
        /// 初期設定
        /// </summary>
        private void initialize() {

            // フォーム全体を透過する
            this.TransparencyKey = this.BackColor;
            //this.TransparencyKey = Color.White;

            //フォームの境界線をなくす
            this.FormBorderStyle = FormBorderStyle.None;

            //フォームを最前面にする
            this.TopMost = true;

            changeStateControlBox(true);
            /*
            //フォームの最大化ボタンの表示、非表示を切り替える
            this.MaximizeBox = !this.MaximizeBox;
            //フォームの最小化ボタンの表示、非表示を切り替える
            this.MinimizeBox = !this.MinimizeBox;
            //フォームのコントロールボックスの表示、非表示を切り替える
            //コントロールボックスを非表示にすると最大化、最小化、閉じるボタンも消える
            this.ControlBox = !this.ControlBox;

            //タイトルバーを非表示にする
            this.ControlBox = false;
            this.Text = "";*/

            MoveStateButton.Text = "to Unachieve transparency";

        }

        //Form1のMouseDownイベントハンドラ
        //マウスのボタンが押されたとき
        private void SendMessage_MouseDown(object sender,
            System.Windows.Forms.MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                //位置を記憶する
                mousePoint = new Point(e.X, e.Y);
            }
        }

        //Form1のMouseMoveイベントハンドラ
        //マウスが動いたとき
        private void SendMessage_MouseMove(object sender,
            System.Windows.Forms.MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Left += e.X - mousePoint.X;
                this.Top += e.Y - mousePoint.Y;
                //または、つぎのようにする
                //this.Location = new Point(
                //    this.Location.X + e.X - mousePoint.X,
                //    this.Location.Y + e.Y - mousePoint.Y);
            }
        }

        private void MoveStateButton_Click(object sender, EventArgs e)
        {
            if (positionState == false)
            {
                this.Cursor = Cursors.SizeAll;
                this.BackColor = Color.Red;
                this.TransparencyKey = Color.White;
                MoveStateButton.Text = "to Unachieve transparency";
                this.Opacity = 0.60f;
                changeStateControlBox(false);
                positionState = true;
            }else{
                this.Cursor = Cursors.Default;
                this.BackColor = SystemColors.Control;
                this.TransparencyKey = this.BackColor;
                MoveStateButton.Text = "to achieve transparency";
                
                this.Opacity = 1.00f;
                positionState = false;
            }
        }

        /// <summary>
        /// コントロールボックスの活性(false)・非活性(true)の切り替え
        /// </summary>
        /// <param name="_state"></param>
        /// 初期描画の時しか切り変え出来ないみたい...
        private void changeStateControlBox(Boolean _state) 
        {
            if (_state == true)
            {
                //フォームの最大化ボタンの表示、非表示を切り替える
                this.MaximizeBox = false;
                //フォームの最小化ボタンの表示、非表示を切り替える
                this.MinimizeBox = false;
                //フォームのコントロールボックスの表示、非表示を切り替える
                //コントロールボックスを非表示にすると最大化、最小化、閉じるボタンも消える
                this.ControlBox = false;

                //タイトルバーを非表示にする
                this.ControlBox = false;
                this.Text = "";
            } else {
                //フォームの最大化ボタンの表示、非表示を切り替える
                this.MaximizeBox = true;
                //フォームの最小化ボタンの表示、非表示を切り替える
                this.MinimizeBox = true;
                //フォームのコントロールボックスの表示、非表示を切り替える
                //コントロールボックスを非表示にすると最大化、最小化、閉じるボタンも消える
                this.ControlBox = true;

                //タイトルバーを非表示にする
                this.ControlBox = true;
                this.Text = "";
            }
        }
    }
}
