using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace TicTacToe_Client
{
    public partial class Form1 : Form
    {
        TcpClient client = null;
        Thread client_thread;
        bool client_connected = false;
        public Form1()
        {
            InitializeComponent();
            this.Text = "TicTacToe Client";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            client.Connect(IP.Text.ToString(), int.Parse(port.Text));
            client_connected = true;
            client_thread = new Thread(Client);
            client_thread.Start();
        }
        void Client()
        {
            try
            {
                label4.Invoke((MethodInvoker)(() => label4.Text = "Connected!"));
                while (client_connected)
                {

                }
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (client_connected)
            {
                client_connected = false;
                client.Close();
                client_thread.Join();
                label4.Text = "Disconnected";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (client_connected)
            {
                try
                {
                    string textToSend = "clientReady";
                    NetworkStream nwStream = client.GetStream();
                    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);
                    nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                }
                catch (Exception ex) { }
            }
        }
    }
}
