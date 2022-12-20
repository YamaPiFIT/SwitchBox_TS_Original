using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Management;
//using System.ServiceProcess;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Net.Mime.MediaTypeNames;

//https://kats-eye.net/info/2020/01/27/arduino-step-motor3/


namespace SelectMessageApp
{
    public partial class Form1 : Form
    {
        string receivedData;
        string chk_rcv_Data;
        int ser_cnt;
        string[] mv_pos = new string[5];

        public Form1()
        {
            InitializeComponent();

            //! 利用可能なシリアルポート名の配列を取得する.
            string[] PortList = SerialPort.GetPortNames();

            cmbPortName.Items.Clear();

            //! シリアルポート名をコンボボックスにセットする.
            foreach (string PortName in PortList)
            {
                cmbPortName.Items.Add(PortName);
            }
            if (cmbPortName.Items.Count > 0)
            {
                cmbPortName.SelectedIndex = 0;
            }


            string[] DeviceList = GetDeviceNames();
            //! シリアルポート名をコンボボックスにセットする.
            comboBox2.Items.Clear();
            foreach (string DeviceName in DeviceList)
            {
                comboBox2.Items.Add(DeviceName);
            }
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }


        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            // 受信文字列の取得
            string tmpRcvDat = "";
            try
            {
                tmpRcvDat = this.serialPort1.ReadExisting();
                receivedData = receivedData + tmpRcvDat;

                int pos_nln = receivedData.IndexOf(this.serialPort1.NewLine);
                int num_chr = receivedData.Length;
                if (pos_nln >= 0 && num_chr > 3)
                {
                    receivedData = receivedData.Substring(0, pos_nln - 1);
                    AddRecievedDataDelegate add = new AddRecievedDataDelegate(AddRecievedData);
                    this.richTextBox1.Invoke(add, receivedData);

                    if (receivedData.IndexOf(chk_rcv_Data) >= 0 && chk_rcv_Data != "")
                    {
                        chk_rcv_Data = "";
                    }

                    return;
                }
            }
            catch (Exception ex)
            {
                string msg_tmp = "データ受信エラーが発生しました。" + Environment.NewLine + Environment.NewLine;
                msg_tmp = msg_tmp + ex.Message;
                MessageBox.Show(msg_tmp, "データ受信エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private delegate void AddRecievedDataDelegate(string data);
        private void AddRecievedData(string data_rcv)
        {
            if (data_rcv == "") { return; }

            DateTime dt = DateTime.Now;
            string result = "[" + dt.ToString("HHmmss") + "]";
            result = "";

            string tmp = data_rcv.Trim();

            this.richTextBox1.Text += tmp + result + Environment.NewLine;
            this.richTextBox1.SelectionStart = this.richTextBox1.Text.Length;
            this.richTextBox1.Focus();
            this.richTextBox1.ScrollToCaret();

            this.textBox3.Text = tmp;
        }

        // 立ち上がり時
        private void Form1_Load(object sender, EventArgs e)
        {
            chk_rcv_Data = "";

            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; ++i)
            {
                string port_name = ports[i];
                //this.serialPort1.Items.Add(port_name);
                //this.serialPort1.Text = port_name;
            }
        }


        private void From1_Closed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        // コムポートを開く
        private void com_open()
        {
            if (serialPort1.IsOpen != true)
            {
                //string com_port = serialPort1.Text;
                string com_port = cmbPortName.Text;
                this.serialPort1.PortName = com_port;
                this.serialPort1.BaudRate = 9600;

                this.serialPort1.Open();
            }
        }





        // ポート切断
        private void Button1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        // LED点滅
        private void Button5_Click(object sender, EventArgs e)
        {
            SendStrInf("LED1_ON", 1);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            SendStrInf("LED2_ON", 1);
        }


        // 原点復帰動作
        private void Button2_Click(object sender, EventArgs e)
        {
            SendStrInf("NEST", 1);
        }

        // 0mm位置移動
        private void Button3_Click(object sender, EventArgs e)
        {
            SendStrInf("MOVE_HOME", 1);
        }

        // 指定座標移動
        private void Button4_Click(object sender, EventArgs e)
        {
            string m_distance = this.textBox3.Text.Trim();
            float m_dist = float.Parse(m_distance);

            //max_step = 15385;
            if (m_dist >= 0 && m_dist <= 200)
            {

                double move_step = Math.Floor(15385 * m_dist / 200);
                string send_step = move_step.ToString();


                SendStrInf("MV" + send_step, 1);
            }
            else
            {
                MessageBox.Show("移動位置の入力値が異常です。", "設定値異常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            mv_pos[0] = textBox2.Text.Trim();
            mv_pos[1] = textBox4.Text.Trim();
            mv_pos[2] = textBox5.Text.Trim();
            mv_pos[3] = textBox6.Text.Trim();
            mv_pos[4] = textBox7.Text.Trim();

            ser_cnt = 0;
            timer1.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (chk_rcv_Data == "")
            {
                if (ser_cnt > 0) { Thread.Sleep(1500); }

                string m_dst = mv_pos[ser_cnt];
                float m_ds = float.Parse(m_dst);

                if (m_ds < 0 || m_ds > 200) { m_ds = 0; }

                double move_step = Math.Floor(15385 * m_ds / 200);
                string send_step = move_step.ToString();

                SendStrInf("MV" + send_step, 1);

                ser_cnt = ser_cnt + 1;
                if (ser_cnt >= 5) { timer1.Enabled = false; }

            }
        }

        private static string[] GetDeviceNames(string[] PortList)
        {
            var deviceNameList = new System.Collections.ArrayList();
            var check = new System.Text.RegularExpressions.Regex("(COM[1-9][0-9]?[0-9]?)");

            ManagementClass mcPnPEntity = new ManagementClass("Win32_PnPEntity");
            ManagementObjectCollection manageObjCol = mcPnPEntity.GetInstances();

            //全てのPnPデバイスを探索しシリアル通信が行われるデバイスを随時追加する
            foreach (ManagementObject manageObj in manageObjCol)
            {
                //Nameプロパティを取得
                var namePropertyValue = manageObj.GetPropertyValue("Name");
                if (namePropertyValue == null)
                {
                    continue;
                }

                //Nameプロパティ文字列の一部が"(COM1)～(COM999)"と一致するときリストに追加"
                string name = namePropertyValue.ToString();
                if (check.IsMatch(name))
                {
                    deviceNameList.Add(name);
                }
            }

            //戻り値作成
            if (deviceNameList.Count > 0)
            {
                string[] deviceNames = new string[deviceNameList.Count];
                int index = 0;
                foreach (var name in deviceNameList)
                {
                    deviceNames[index++] = name.ToString();
                }
                return deviceNames;
            }
            else
            {
                return null;
            }
        }

        public static string[] GetDeviceNames()
        {
            List<string> deviceNameList = new List<string>();
            System.Text.RegularExpressions.Regex check = new System.Text.RegularExpressions.Regex("(COM[1-9][0-9]?[0-9]?)");

            ManagementClass mcPnPEntity = new ManagementClass("Win32_PnPEntity");
            ManagementObjectCollection manageObjCol = mcPnPEntity.GetInstances();

            foreach (ManagementObject manageObj in manageObjCol)
            {
                string name = manageObj.GetPropertyValue("Name") as string;

                try 
                {
                    if (check.IsMatch(name))
                    {
                        deviceNameList.Add(name);
                    }

                } catch (Exception ex){ }
            }

            return (deviceNameList.ToArray());
        }

        private void ComPoenBtn_Click(object sender, EventArgs e)
        {
            string com_port = cmbPortName.Text;
            this.serialPort1.PortName = com_port;
            this.serialPort1.BaudRate = 9600;

            this.serialPort1.Open();

            try {
                SendSetUpInfo();
            }catch(Exception ex) { }

            this.serialPort1.Close();

        }

        /// <summary>
        /// シリアルデータの送信開始
        /// </summary>
        private void SendSetUpInfo() {

            this.serialPort1.Write("-500" + "\r");

        }


        // シリアルデータ送信
        private void SendStrInf(string text, int kbn)
        {
            if (chk_rcv_Data != "") { return; }

            if (kbn == 1) { chk_rcv_Data = text; }

            this.textBox3.Text = "";
            receivedData = "";

            com_open();
            this.serialPort1.Write(text + "\r");
        }
    }
}