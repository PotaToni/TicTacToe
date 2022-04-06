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

namespace TicTacToe_Server
{
    public partial class Form1 : Form
    {
        Int32 port = 50000;
        String IP = "127.0.0.1";
        IPAddress localAddr = IPAddress.Parse("127.0.0.1");
        bool server_started = false;
        bool client_connected_to_server = false;
        TcpListener server = null;
        Thread server_thread;

        public Form1()
        {
            InitializeComponent();
            this.Text = "TicTacToe Server";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!server_started)
            {
                label2.Text = "Waiting for a connection...";
                server_thread = new Thread(serverListen);
                server_thread.Start();
                server_started = true;
            }
        }

        Byte[] bytes = new Byte[256];
        String data = null;
        NetworkStream stream;
        void HandleClient(TcpClient obj)
        {
            TcpClient client = obj;
            if (client.Connected)
            {
                label2.Invoke((MethodInvoker)(() => label2.Text = "Client connected to Server!"));
                client_connected_to_server = true;
            }

            stream = client.GetStream();

            int i;

            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                listBox1.Invoke((MethodInvoker)(() => listBox1.Items.Add(data)));
            }

            client.Close();
        }
        
        void serverListen()
        {
            server = new TcpListener(localAddr, port);
            server.Start();
            while (server_started)
            {
                try
                {
                    label2.Invoke((MethodInvoker)(() => label2.Text = "Waiting for a connection..."));
                    client_connected_to_server = false;
                    TcpClient client = server.AcceptTcpClient();
                    if (client.Connected)
                    {
                        label2.Invoke((MethodInvoker)(() => label2.Text = "Client connected to Server!"));
                        client_connected_to_server = true;
                    }

                    stream = client.GetStream();

                    int i;

                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        listBox1.Invoke((MethodInvoker)(() => listBox1.Items.Add(data)));
                    }
                    client.Close();
                }
                catch
                {

                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (server_started)
            {
                server.Stop();
                server_started = false;
                server_thread.Join();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (server_started)
            {
                server.Stop();
                server_started = false;
                server_thread.Join();
                label2.Text = "Offline";
            }
        }
    }
}
