using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//https://qiita.com/u_e_d_a_/items/98991bf3f19f3a6cf0cb#%E5%AE%9F%E8%A3%85%E3%82%B5%E3%83%B3%E3%83%97%E3%83%AB
namespace SelectMessageApp
{
    public partial class SendMessage : Form
    {

        //マウスのクリック位置を記憶
        private Point mousePoint;

        //false -> 透明化（動かないモード)  true -> 不透明化（動くモード ）
        private Boolean positionState = false;
        
        SpeechRecognitionEngine engine;



        public SendMessage()
        {
            InitializeComponent();
            initialize();

            // 音声認識の設定
            StartRecognition();
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

            MoveStateButton.Text = "to Unachieve transparency";

            // 音声認識の設定
            //StartRecognition();
        }


        /// <summary>
        /// 音声認識の設定
        /// </summary>
        private void StartRecognition()
        {
            try
            {
                // 音声認識エンジンの設定
                engine = new SpeechRecognitionEngine(Application.CurrentCulture);

                // 既存のオーディオデバイスをデフォルトの入力とする
                engine.SetInputToDefaultAudioDevice();

                // イベント登録
                engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(SpeechRecognized);

                string grammarPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Grammar.txt");
                if (File.Exists(grammarPath))
                { // 文法ファイルが存在する場合
                    var choices = new Choices();
                    foreach (string line in ReadFile(grammarPath, "#"))
                    {
                        choices.Add(line);
                    }
                    var grammar = new Grammar(choices.ToGrammarBuilder());
                    engine.LoadGrammar(new Grammar(choices.ToGrammarBuilder()));
                }
                else
                {
                    engine.LoadGrammarAsync(new DictationGrammar());
                }

                engine.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception)
            {
                // 音声認識の設定に失敗
                MessageBox.Show("音声認識の設定に失敗しました。", "音声認識", MessageBoxButtons.OK,
                    MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                // 音声認識エンジンのオブジェクトを解放
                engine.Dispose();

                // 音声認識エンジンを初期化
                engine = null;
            }
        }

        private void SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            // 生データを表示
            string recognitionWord = e.Result.Text;
            /*
            this.label.Text = "認識結果：" + recognitionWord;

            if (e.Result.Confidence >= 0.5)
            {
                if (recognitionWord == "音声認識ON")
                {
                    this.checkBoxVoiceInput.Checked = true;
                }
                else if (recognitionWord == "音声認識OFF")
                {
                    this.checkBoxVoiceInput.Checked = false;
                }
                else
                {
                    if (this.checkBoxVoiceInput.Checked)
                    {
                        // 音声認識データをテキストボックスに反映
                        this.textBox.Text += recognitionWord;
                    }
                }
            }*/
            // 音声認識データをテキストボックスに反映
            Console.WriteLine(recognitionWord);
        }

        /// <summary>
        /// ファイル読込み。
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <param name="comment">コメント文字</param>
        /// <returns>読込み結果リスト</returns>
        public static List<string> ReadFile(string path, string comment)
        {
            //コメント以外の行を取得
            var lines = File.ReadAllLines(path, Encoding.Default)
                .Where(line => !line.StartsWith(comment)).ToList();

            return lines;
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
