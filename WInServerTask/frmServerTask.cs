using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace WInServerTask
{
    public partial class frmServerTask : Form
    {
        string PGM_ID;
        string hostIP;
        int hostPort;
        string product_id;
        System.Timers.Timer timer1;
        TcpListener listener;
        TcpClient tc;
        NetworkStream stream;
        Random rnd;

        int interval = 0;
        readonly string STX = ((char)2).ToString();
        readonly string ETX = ((char)3).ToString();

        LoggingUtility _logging;
        public LoggingUtility Log
        {
            get { return _logging; }
        }

        public frmServerTask(string pgmID, string host, string port, string product_id, string tact_time)
        {
            InitializeComponent();

            //전역변수 설정
            PGM_ID = pgmID;
            hostIP = host;
            hostPort = int.Parse(port);
            this.product_id = product_id;

            interval = int.Parse(tact_time) * 1000;
        }

        private void AsyncEchoServer()
        {
            while (true)
            {
                tc = listener.AcceptTcpClient();
                stream = tc.GetStream();
                rnd = new Random((int)DateTime.UtcNow.Ticks);

                timer1 = new System.Timers.Timer(interval);
                timer1.Enabled = true;
                timer1.Elapsed += timer1_Elapsed;
                timer1.AutoReset = true;
            }
        }

        private void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            //|20200817 12:01:20 Task|7|65|4|0|
            int n = rnd.Next(10) == 1 ? 0 : 1;
            string msg = $"{STX}|{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")}Task|{PGM_ID.Replace("task", "").TrimStart('0')}|{product_id}|{n}|{Math.Abs(n - 1)}|{ETX}";
            byte[] buff = Encoding.ASCII.GetBytes(msg);

            stream.Write(buff, 0, buff.Length);
            listBox1.Items.Add(msg);
        }

        public void OnStop()
        {
            stream.Close();
            tc.Close();
        }

        private void frmServerTask_Load(object sender, EventArgs e)
        {
            Label1.Text = PGM_ID;
            lblIP.Text = hostIP;
            lblPort.Text = hostPort.ToString();

            listener = new TcpListener(IPAddress.Parse(hostIP), hostPort);
            listener.Start();
            AsyncEchoServer();
        }
    }
}
