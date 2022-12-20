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


//https://qiita.com/kob58im/items/0273632e96afceca7d0a
namespace SelectMessageApp
{
    public partial class GamePadTest : Form
    {


        [StructLayout(LayoutKind.Sequential)]
        private struct JOYINFOEX
        {
            public int dwSize;
            public int dwFlags;
            public int dwXpos;
            public int dwYpos;
            public int dwZpos;
            public int dwRpos;
            public int dwUpos;
            public int dwVpos;
            public int dwButtons;
            public int dwButtonNumber;
            public int dwPOV;
            public int dwReserved1;
            public int dwReserved2;
        }

        const int MM_JOY1MOVE = 0x3A0;//  Joystick JOYSTICKID1 changed position in the x- or y-direction.
        const int MM_JOY2MOVE = 0x3A1;//  Joystick JOYSTICKID2 changed position in the x- or y-direction
        const int MM_JOY1ZMOVE = 0x3A2;//  Joystick JOYSTICKID1 changed position in the z-direction.
        const int MM_JOY2ZMOVE = 0x3A3;//  Joystick JOYSTICKID2 changed position in the z-direction.
        const int MM_JOY1BUTTONDOWN = 0x3B5;//  A button on joystick JOYSTICKID1 has been pressed.
        const int MM_JOY2BUTTONDOWN = 0x3B6;//  A button on joystick JOYSTICKID2 has been pressed.
        const int MM_JOY1BUTTONUP = 0x3B7;//  A button on joystick JOYSTICKID1 has been released.
        const int MM_JOY2BUTTONUP = 0x3B8;//  A button on joystick JOYSTICKID2 has been released.

        // https://docs.microsoft.com/en-us/windows/win32/multimedia/mm-joy1buttondown


        const int JOYSTICKID1 = 0;

        const int MMSYSERR_BADDEVICEID = 2; // The specified joystick identifier is invalid.
        const int MMSYSERR_NODRIVER = 6;    // The joystick driver is not present.
        const int MMSYSERR_INVALPARAM = 11; // An invalid parameter was passed.
        const int JOYERR_PARMS = 165;       // The specified joystick identifier is invalid.
        const int JOYERR_NOCANDO = 166;     // Cannot capture joystick input because a required service (such as a Windows timer) is unavailable.
        const int JOYERR_UNPLUGGED = 167;   // The specified joystick is not connected to the system.

        const int JOY_RETURNX = 0x001;
        const int JOY_RETURNY = 0x002;
        const int JOY_RETURNZ = 0x004;
        const int JOY_RETURNR = 0x008;
        const int JOY_RETURNU = 0x010;
        const int JOY_RETURNV = 0x020;
        const int JOY_RETURNPOV = 0x040;
        const int JOY_RETURNBUTTONS = 0x080;
        const int JOY_RETURNALL = 0x0FF;

        const int JOY_RETURNRAWDATA = 0x100;
        const int JOY_RETURNPOVCTS = 0x200;
        const int JOY_RETURNCENTERED = 0x400;

        MyMessageFilter messageFilter;


        public GamePadTest()
        {
            InitializeComponent();

            Text = "GamePadTest";

            ClientSize = new Size(300, 300);

            var btnDevNum = new Button()
            {
                Location = new Point(0, 0),
                Size = new Size(200, 30),
                Text = "Call joyGetNumDevs",
            };
            btnDevNum.Click += (s, e) => {
                int n = NativeMethods.joyGetNumDevs();
                Console.Write("joyGetNumDevs:");
                Console.WriteLine(n);
            };
            Controls.Add(btnDevNum);


            var btnDevPos = new Button()
            {
                Location = new Point(0, 60),
                Size = new Size(200, 30),
                Text = "Call joyGetPosEx",
            };
            btnDevPos.Click += (s, e) => {
                var joyInfo = new JOYINFOEX();
                joyInfo.dwSize = Marshal.SizeOf(joyInfo);
                joyInfo.dwFlags = JOY_RETURNALL;
                int mmresultCode = NativeMethods.joyGetPosEx(JOYSTICKID1, ref joyInfo);
                Console.Write("joyGetPosEx:");
                Console.WriteLine(mmresultCode);
                Console.Write("dwButtons:0x");
                Console.WriteLine(joyInfo.dwButtons.ToString("X8"));
            };
            Controls.Add(btnDevPos);


            Load += (s, e) => {
                messageFilter = new MyMessageFilter();
                Application.AddMessageFilter(messageFilter);

                NativeMethods.joySetCapture(this.Handle, JOYSTICKID1, 50, 1);
            };

            Closed += (s, e) => {
                NativeMethods.joyReleaseCapture(JOYSTICKID1);
            };
        }

        /*
        [STAThread]
        static void Main(string[] args)
        {
            Application.Run(new GamePadTest());
        }
        */

        class MyMessageFilter : IMessageFilter
        {

            MyMessageFilter messageFilter;

            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == MM_JOY1BUTTONDOWN
                 || m.Msg == MM_JOY1BUTTONUP
                 || m.Msg == MM_JOY1MOVE
                 || m.Msg == MM_JOY1ZMOVE)
                {
                    try
                    {
                        int fwButtons = (int)m.WParam;
                        ulong tmp = (ulong)m.LParam; // 64bit環境で31bit目が1のIntPtrをuintにキャストするとOverflowExceptionが発生するっぽい???ので対策。
                        int xPos = (int)(tmp & 0xFFFF);
                        int yPos = (int)((tmp >> 16) & 0xFFFF);
                        Console.Write("Message:0x");
                        Console.WriteLine(m.Msg.ToString("X3"));
                        Console.Write("buttons:0x");
                        Console.WriteLine(fwButtons.ToString("X8"));
                        Console.Write("x:");
                        Console.WriteLine(xPos);
                        Console.Write("y:");
                        Console.WriteLine(yPos);
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine(e);
                    }
                }
                return false;
            }
        }

        private static class NativeMethods
        {
            [DllImport("winmm.dll")]
            public static extern int joyGetNumDevs();

            [DllImport("winmm.dll")]
            public static extern int joyGetPosEx(int uJoyID, ref JOYINFOEX pji);


            // hwnd  ... Handle to the window to receive the joystick messages.
            // uJoyID ... Identifier of the joystick to be captured. Valid values for uJoyID range from zero (JOYSTICKID1) to 15.
            // uPeriod ... Polling frequency, in milliseconds.
            // fChanged ... Change position flag. Specify TRUE for this parameter to send messages only when the position changes by a value greater than the joystick movement threshold. Otherwise, messages are sent at the polling frequency specified in uPeriod.
            [DllImport("winmm.dll")]
            public static extern int joySetCapture(IntPtr hwnd, int uJoyID, int uPeriod, int fChanged);


            [DllImport("winmm.dll")]
            public static extern int joyReleaseCapture(int uJoyID);
        }

    }
}
