using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_SetupApp
{
    /// <summary>
    /// Page2.xaml の相互作用ロジック
    /// </summary>
    public partial class Page2 : Page
    {

        private const int BUTTON_MODE = 0;
        private const int SWITCH_MODE = 1;
        private const int ROTARY_MODE = 2;

        public Page2()
        {
            InitializeComponent();
            Initialize();
        }

        /// <summary>
        ///初期設定 
        /// </summary>
        private void Initialize() {
            ButtonIsIndeterminateState(0);
            SwitchIsIndeterminateState(0);
            RotaryIsIndeterminateState(0);
        }

        /// <summary>
        /// ボタンの選択のアクティブ設定
        /// </summary>
        /// <param name="_number">0~9 0は全て選択を非アクティブ化する</param>
        private void ButtonIsIndeterminateState(int _number) 
        {
            Button1.DataContext = new { IsIndeterminateState = false };
            Button2.DataContext = new { IsIndeterminateState = false };
            Button3.DataContext = new { IsIndeterminateState = false };
            Button4.DataContext = new { IsIndeterminateState = false };
            Button5.DataContext = new { IsIndeterminateState = false };
            Button6.DataContext = new { IsIndeterminateState = false };
            Button7.DataContext = new { IsIndeterminateState = false };
            Button8.DataContext = new { IsIndeterminateState = false };
            Button9.DataContext = new { IsIndeterminateState = false };

            switch (_number) 
            {
                case 0:
                    break;

                case 1:
                    Button1.DataContext = new { IsIndeterminateState = true };
                    break;

                case 2:
                    Button2.DataContext = new { IsIndeterminateState = true };
                    break;

                case 3:
                    Button3.DataContext = new { IsIndeterminateState = true };
                    break;

                case 4:
                    Button4.DataContext = new { IsIndeterminateState = true };
                    break;

                case 5:
                    Button5.DataContext = new { IsIndeterminateState = true };
                    break;

                case 6:
                    Button6.DataContext = new { IsIndeterminateState = true };
                    break;  

                case 7:
                    Button7.DataContext = new { IsIndeterminateState = true };
                    break;

                case 8:
                    Button8.DataContext = new { IsIndeterminateState = true };
                    break;

                case 9:
                    Button9.DataContext = new { IsIndeterminateState = true };
                    break;
            }
        }

        /// <summary>
        /// スイッチボタンの選択のアクティブ設定
        /// </summary>
        /// <param name="_number">0~4 0は全て選択を非アクティブ化する</param>
        private void SwitchIsIndeterminateState(int _number)
        {
            Switch1.DataContext = new { IsIndeterminateState = false };
            Switch2.DataContext = new { IsIndeterminateState = false };
            Switch3.DataContext = new { IsIndeterminateState = false };
            Switch4.DataContext = new { IsIndeterminateState = false };

            switch (_number)
            {
                case 0:
                    break;

                case 1:
                    Switch1.DataContext = new { IsIndeterminateState = true };
                    break;

                case 2:
                    Switch2.DataContext = new { IsIndeterminateState = true };
                    break;

                case 3:
                    Switch3.DataContext = new { IsIndeterminateState = true };
                    break;

                case 4:
                    Switch4.DataContext = new { IsIndeterminateState = true };
                    break;
            }
        }

        /// <summary>
        /// ロータリーの選択のアクティブ設定
        /// </summary>
        /// <param name="_number">0~6 0は全て選択を非アクティブ化する</param>
        private void RotaryIsIndeterminateState(int _number)
        {
            Rotary1.DataContext = new { IsIndeterminateState = false };
            Rotary2.DataContext = new { IsIndeterminateState = false };
            Rotary3.DataContext = new { IsIndeterminateState = false };
            Rotary4.DataContext = new { IsIndeterminateState = false };
            Rotary5.DataContext = new { IsIndeterminateState = false };
            Rotary6.DataContext = new { IsIndeterminateState = false };

            switch (_number)
            {
                case 0:
                    break;

                case 1:
                    Rotary1.DataContext = new { IsIndeterminateState = true };
                    break;

                case 2:
                    Rotary2.DataContext = new { IsIndeterminateState = true };
                    break;

                case 3:
                    Rotary3.DataContext = new { IsIndeterminateState = true };
                    break;

                case 4:
                    Rotary4.DataContext = new { IsIndeterminateState = true };
                    break;

                case 5:
                    Rotary5.DataContext = new { IsIndeterminateState = true };
                    break;

                case 6:
                    Rotary6.DataContext = new { IsIndeterminateState = true };
                    break;
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            var page1 = new Page1();
            NavigationService.Navigate(page1);
        }

        /// <summary>
        /// ボタンが選択された時のイベント
        /// </summary>
        /// <param name="_mode"></param>
        private void setInfoVisibility(int _mode) 
        {
            switch (_mode)
            {
                case BUTTON_MODE:
                    setButtonVisibility(Visibility.Visible);
                    setSwitchVisibility(Visibility.Hidden);
                    setRotaryVisibility(Visibility.Hidden);
                    break;

                case SWITCH_MODE:
                    setButtonVisibility(Visibility.Hidden);
                    setSwitchVisibility(Visibility.Visible);
                    setRotaryVisibility(Visibility.Hidden);
                    break;

                case ROTARY_MODE:
                    setButtonVisibility(Visibility.Hidden);
                    setSwitchVisibility(Visibility.Hidden);
                    setRotaryVisibility(Visibility.Visible);
                    break;
            }
        }

        private void setButtonVisibility(Visibility _visibility) 
        {
            text_Button_displayed.Visibility = _visibility;
            text_Button_method.Visibility = _visibility;
            textBox_method.Visibility = _visibility;
            textBox_displayed.Visibility = _visibility;
            /*
            //非表示時は初期化する
            if (_visibility == Visibility.Hidden) 
            {
                textBox_method.Text = string.Empty;
                textBox_displayed.Text = string.Empty;
            }
            */
        }

        private void setSwitchVisibility(Visibility _visibility)
        {
            text_Switch_On.Visibility = _visibility;
            text_Switch_On_displayed.Visibility = _visibility;
            textBox_On_displayed.Visibility = _visibility;
            text_Switch_Off.Visibility = _visibility;
            text_Switch_Off_displayed.Visibility = _visibility;
            textBox_Off_displayed.Visibility = _visibility;

            /*
            //非表示時は初期化する
            if (_visibility == Visibility.Hidden)
            {
                textBox_On_displayed.Text = string.Empty;
                textBox_Off_displayed.Text = string.Empty;
            }
            */
        }

        private void setRotaryVisibility(Visibility _visibility)
        {
            text_Rotary_Left.Visibility = _visibility;
            text_Rotary_Left_displayed.Visibility = _visibility;
            textBox_Left_Displayed.Visibility = _visibility;
            text_Rotary_Right.Visibility = _visibility;
            text_Rotary_Right_displayed.Visibility = _visibility;
            textBox_Right_Displayed.Visibility = _visibility;

            /*
            //非表示時は初期化する
            if (_visibility == Visibility.Hidden)
            {
                textBox_Left_Displayed.Text = string.Empty;
                textBox_Right_Displayed.Text = string.Empty;
            }
            */
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            ButtonIsIndeterminateState(1);
            SwitchIsIndeterminateState(0);
            RotaryIsIndeterminateState(0);
            setInfoVisibility(BUTTON_MODE);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            ButtonIsIndeterminateState(2);
            SwitchIsIndeterminateState(0);
            RotaryIsIndeterminateState(0);
            setInfoVisibility(BUTTON_MODE);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            ButtonIsIndeterminateState(3);
            SwitchIsIndeterminateState(0);
            RotaryIsIndeterminateState(0);
            setInfoVisibility(BUTTON_MODE);
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            ButtonIsIndeterminateState(4);
            SwitchIsIndeterminateState(0);
            RotaryIsIndeterminateState(0);
            setInfoVisibility(BUTTON_MODE);
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            ButtonIsIndeterminateState(5);
            SwitchIsIndeterminateState(0);
            RotaryIsIndeterminateState(0);
            setInfoVisibility(BUTTON_MODE);
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            ButtonIsIndeterminateState(6);
            SwitchIsIndeterminateState(0);
            RotaryIsIndeterminateState(0);
            setInfoVisibility(BUTTON_MODE);
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            ButtonIsIndeterminateState(7);
            SwitchIsIndeterminateState(0);
            RotaryIsIndeterminateState(0);
            setInfoVisibility(BUTTON_MODE);
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            ButtonIsIndeterminateState(8);
            SwitchIsIndeterminateState(0);
            RotaryIsIndeterminateState(0);
            setInfoVisibility(BUTTON_MODE);
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            ButtonIsIndeterminateState(9);
            SwitchIsIndeterminateState(0);
            RotaryIsIndeterminateState(0);
            setInfoVisibility(BUTTON_MODE);
        }

        private void Switch1_Click(object sender, RoutedEventArgs e)
        {
            ButtonIsIndeterminateState(0);
            SwitchIsIndeterminateState(1);
            RotaryIsIndeterminateState(0);
            setInfoVisibility(SWITCH_MODE);
        }

        private void Switch2_Click(object sender, RoutedEventArgs e)
        {
            ButtonIsIndeterminateState(0);
            SwitchIsIndeterminateState(2);
            RotaryIsIndeterminateState(0);
            setInfoVisibility(SWITCH_MODE);
        }

        private void Switch3_Click(object sender, RoutedEventArgs e)
        {
            ButtonIsIndeterminateState(0);
            SwitchIsIndeterminateState(3);
            RotaryIsIndeterminateState(0);
            setInfoVisibility(SWITCH_MODE);
        }

        private void Switch4_Click(object sender, RoutedEventArgs e)
        {
            ButtonIsIndeterminateState(0);
            SwitchIsIndeterminateState(4);
            RotaryIsIndeterminateState(0);
            setInfoVisibility(SWITCH_MODE);
        }

        private void Rotary1_Click(object sender, RoutedEventArgs e)
        {
            ButtonIsIndeterminateState(0);
            SwitchIsIndeterminateState(0);
            RotaryIsIndeterminateState(1);
            setInfoVisibility(ROTARY_MODE);
        }

        private void Rotary2_Click(object sender, RoutedEventArgs e)
        {
            ButtonIsIndeterminateState(0);
            SwitchIsIndeterminateState(0);
            RotaryIsIndeterminateState(2);
            setInfoVisibility(ROTARY_MODE);
        }

        private void Rotary3_Click(object sender, RoutedEventArgs e)
        {
            ButtonIsIndeterminateState(0);
            SwitchIsIndeterminateState(0);
            RotaryIsIndeterminateState(3);
            setInfoVisibility(ROTARY_MODE);
        }

        private void Rotary4_Click(object sender, RoutedEventArgs e)
        {
            ButtonIsIndeterminateState(0);
            SwitchIsIndeterminateState(0);
            RotaryIsIndeterminateState(4);
            setInfoVisibility(ROTARY_MODE);
        }

        private void Rotary5_Click(object sender, RoutedEventArgs e)
        {
            ButtonIsIndeterminateState(0);
            SwitchIsIndeterminateState(0);
            RotaryIsIndeterminateState(5);
            setInfoVisibility(ROTARY_MODE);
        }

        private void Rotary6_Click(object sender, RoutedEventArgs e)
        {
            ButtonIsIndeterminateState(0);
            SwitchIsIndeterminateState(0);
            RotaryIsIndeterminateState(6);
            setInfoVisibility(ROTARY_MODE);
        }
    }
}
