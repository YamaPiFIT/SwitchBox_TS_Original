using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vortice.XInput;
using System.Runtime.InteropServices;


namespace SelectMessageApp
{
    public partial class SetupMeny : Form
    {

        private struct XINPUT_GAMEPAD
        {
            public UInt16 wButtons;
            public Byte bLeftTrigger;
            public Byte bRightTrigger;
            public Int16 sThumbLX;
            public Int16 sThumbLY;
            public Int16 sThumbRX;
            public Int16 sThumbRY;
        }
        private struct XINPUT_STATE
        {
            public int dwPacketNumber;
            public XINPUT_GAMEPAD Gamepad;
        }
        private struct XINPUT_VIBRATION
        {
            public ushort wLeftMotorSpeed;
            public ushort wRightMotorSpeed;
        }
        [DllImport("xinput1_3.dll")]
        private static extern bool XInputGetState(int uJoyID, ref XINPUT_STATE GameState);
        [DllImport("xinput1_3.dll")]
        private static extern Int16 XInputSetState(int uJoyID, ref XINPUT_VIBRATION GameState);
        [DllImport("user32.dll")]
        private static extern int GetAsyncKeyState(int vKey);
        private bool Result;
        private Int16 Resultv;
        private XINPUT_STATE GS;
        private XINPUT_VIBRATION GSV;
        private BufferedGraphicsContext currentContext;
        private BufferedGraphics drawBuffer;
        private Graphics gr;
        int KC = 0;

        Device joystick = null;

        // ゲームパッド取得用変数
        private Joystick _joy;
        public int? GamepadIndex { get; set; }

        public SetupMeny()
        {
            InitializeComponent();

            //test1();
            //test2();
            //test3();
            test4();
        }

        //test1
        /*
        private void test1() {
            
            // 入力周りの初期化
            DirectInput dinput = new DirectInput();

            // 使用するゲームパッドのID
            var joystickGuid = Guid.Empty;
            // ゲームパッドからゲームパッドを取得する
            if (joystickGuid == Guid.Empty)
            {
                foreach (DeviceInstance device in dinput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
                {
                    joystickGuid = device.InstanceGuid;
                    break;
                }
            }
            // ジョイスティックからゲームパッドを取得する
            if (joystickGuid == Guid.Empty)
            {
                foreach (DeviceInstance device in dinput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
                {
                    joystickGuid = device.InstanceGuid;
                    break;
                }
            }

            // 見つかった場合
            if (joystickGuid != Guid.Empty)
            {
                // パッド入力周りの初期化
                _joy = new Joystick(dinput, joystickGuid);
                if (_joy != null)
                {
                    // バッファサイズを指定
                    _joy.Properties.BufferSize = 128;

                    // 相対軸・絶対軸の最小値と最大値を
                    // 指定した値の範囲に設定する
                    foreach (DeviceObjectInstance deviceObject in _joy.GetObjects())
                    {
                        switch (deviceObject.ObjectId.Flags)
                        {
                            case DeviceObjectTypeFlags.Axis:
                            // 絶対軸or相対軸
                            case DeviceObjectTypeFlags.AbsoluteAxis:
                            // 絶対軸
                            case DeviceObjectTypeFlags.RelativeAxis:
                                // 相対軸
                                var ir = _joy.GetObjectPropertiesById(deviceObject.ObjectId);
                                if (ir != null)
                                {
                                    try
                                    {
                                        ir.Range = new InputRange(-1000, 1000);
                                    }
                                    catch (Exception) { }
                                }
                                break;
                        }
                    }
                }
            }
            
        }
        */

        //test2
        /*
        private void test2() {
            // ゲームパッド取得用変数
            Joystick _joy;

            // 入力周りの初期化
            DirectInput dinput = new DirectInput();

            // 使用するゲームパッドのID
            var joystickGuid = Guid.Empty;
            // ゲームパッドからゲームパッドを取得する
            if (joystickGuid == Guid.Empty)
            {
                foreach (DeviceInstance device in dinput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
                {
                    joystickGuid = device.InstanceGuid;
                    break;
                }
            }
            // ジョイスティックからゲームパッドを取得する
            if (joystickGuid == Guid.Empty)
            {
                foreach (DeviceInstance device in dinput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
                {
                    joystickGuid = device.InstanceGuid;
                    break;
                }
            }

            // 見つかった場合
            if (joystickGuid != Guid.Empty)
            {
                // パッド入力周りの初期化
                _joy = new Joystick(dinput, joystickGuid);
                if (_joy != null)
                {
                    // バッファサイズを指定
                    _joy.Properties.BufferSize = 128;

                    // 相対軸・絶対軸の最小値と最大値を
                    // 指定した値の範囲に設定する
                    foreach (DeviceObjectInstance deviceObject in _joy.GetObjects())
                    {
                        switch (deviceObject.ObjectId.Flags)
                        {
                            case DeviceObjectTypeFlags.Axis:
                            // 絶対軸or相対軸
                            case DeviceObjectTypeFlags.AbsoluteAxis:
                            // 絶対軸
                            case DeviceObjectTypeFlags.RelativeAxis:
                                // 相対軸
                                var ir = _joy.GetObjectPropertiesById(deviceObject.ObjectId);
                                if (ir != null)
                                {
                                    try
                                    {
                                        ir.Range = new InputRange(-1000, 1000);
                                    }
                                    catch (Exception) { }
                                }
                                break;
                        }
                    }
                }
            }
        }
        */


        //test3
        private State? test3() {

            // 認識済みの場合、認識済みのゲームパッドを使う
            if (GamepadIndex != null)
            {
                if (XInput.GetState(GamepadIndex.Value, out var keystate))
                    return keystate;
                else
                    // 認識済みのゲームパッドが無効になったとみなす
                    GamepadIndex = null;
            }
            else
                // 未認識の場合、0 ～ 10 の順で有効なゲームパッドを探す
                for (var i = 0; i < 10; ++i)
                    if (XInput.GetState(i, out var keystate))
                    {
                        GamepadIndex = i;
                        return keystate;
                    }

            return null;
        }

        //test4
        private void test4() {

            //ini
            currentContext = new BufferedGraphicsContext();
            this.DoubleBuffered = true;
            KeyPreview = true;
            gr = drawBuffer.Graphics;


            Result = XInputGetState(0, ref GS);

            gr.Clear(Color.Black);
            if (Result == false)
            {
                gr.DrawString("KeyCode:" + KC.ToString(), new Font("ゴシック", 12), Brushes.White, 40, 20);
                gr.DrawString("UP:" + (GS.Gamepad.wButtons & 0x1).ToString(), new Font("ゴシック", 12), Brushes.White, 40, 40);
                gr.DrawString("DOUN:" + (GS.Gamepad.wButtons & 0x2).ToString(), new Font("ゴシック", 12), Brushes.White, 40, 40 + 20 * 1);
                gr.DrawString("LEFT:" + (GS.Gamepad.wButtons & 0x4).ToString(), new Font("ゴシック", 12), Brushes.White, 40, 40 + 20 * 2);
                gr.DrawString("RIGHT:" + (GS.Gamepad.wButtons & 0x8).ToString(), new Font("ゴシック", 12), Brushes.White, 40, 40 + 20 * 3);
                gr.DrawString("START:" + (GS.Gamepad.wButtons & 0x10).ToString(), new Font("ゴシック", 12), Brushes.White, 40, 40 + 20 * 4);
                gr.DrawString("BACK:" + (GS.Gamepad.wButtons & 0x20).ToString(), new Font("ゴシック", 12), Brushes.White, 40, 40 + 20 * 5);
                gr.DrawString("LEFT THUMB:" + (GS.Gamepad.wButtons & 0x40).ToString(), new Font("ゴシック", 12), Brushes.White, 40, 40 + 20 * 6);
                gr.DrawString("RIGHT THUMB:" + (GS.Gamepad.wButtons & 0x80).ToString(), new Font("ゴシック", 12), Brushes.White, 40, 40 + 20 * 7);
                gr.DrawString("LEFT SHOULDER:" + (GS.Gamepad.wButtons & 0x100).ToString(), new Font("ゴシック", 12), Brushes.White, 40, 40 + 20 * 8);
                gr.DrawString("RIGHT SHOULDER:" + (GS.Gamepad.wButtons & 0x200).ToString(), new Font("ゴシック", 12), Brushes.White, 40, 40 + 20 * 9);
                gr.DrawString("A:" + (GS.Gamepad.wButtons & 0x1000).ToString(), new Font("ゴシック", 12), Brushes.White, 40, 40 + 20 * 10);
                gr.DrawString("B:" + (GS.Gamepad.wButtons & 0x2000).ToString(), new Font("ゴシック", 12), Brushes.White, 40, 40 + 20 * 11);
                gr.DrawString("X:" + (GS.Gamepad.wButtons & 0x4000).ToString(), new Font("ゴシック", 12), Brushes.White, 40, 40 + 20 * 12);
                gr.DrawString("Y:" + (GS.Gamepad.wButtons & 0x8000).ToString(), new Font("ゴシック", 12), Brushes.White, 40, 40 + 20 * 13);
                gr.DrawString("LEFT TRIGGER:" + GS.Gamepad.bLeftTrigger.ToString(), new Font("ゴシック", 12), Brushes.White, 40, 40 + 20 * 14);
                gr.DrawString("RIGHT TRIGGER:" + GS.Gamepad.bRightTrigger.ToString(), new Font("ゴシック", 12), Brushes.White, 40, 40 + 20 * 15);
                gr.DrawString("LEFT X THUMB:" + GS.Gamepad.sThumbLX.ToString(), new Font("ゴシック", 12), Brushes.White, 40, 40 + 20 * 16);
                gr.DrawString("LEFT Y THUMB:" + GS.Gamepad.sThumbLY.ToString(), new Font("ゴシック", 12), Brushes.White, 40, 40 + 20 * 17);
                gr.DrawString("RIGHT X THUMB:" + GS.Gamepad.sThumbRX.ToString(), new Font("ゴシック", 12), Brushes.White, 40, 40 + 20 * 18);
                gr.DrawString("RIGHT Y THUMB:" + GS.Gamepad.sThumbRY.ToString(), new Font("ゴシック", 12), Brushes.White, 40, 40 + 20 * 19);

            }
        }


    }
}
