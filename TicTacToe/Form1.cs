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
using System.Net.Sockets;
using System.Net;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool server_started = false;
        bool client_connected = false;
        bool client_connected_to_server = false;
        TcpListener server = null;
        TcpClient client = null;
        Thread server_thread;
        Thread client_thread;
        Thread game_thread;
        Int32 port = 5000;
        String IP = "127.0.0.1";
        IPAddress localAddr = IPAddress.Parse("127.0.0.1");
        String user;
        int player = -1;
        bool serverReady = false;
        bool clientReady = false;
        bool inGame = true;
        bool game_started = false;
        bool updateBoard = false;
        bool nextTurn = false;
        int CrossCount = 0;
        int ZeroCount = 0;

        struct BoardInfo
        {
            public int id;
            public string status;
        };

        BoardInfo[] board = new BoardInfo[9];
        static Form f0;
        public Form1()
        {
            InitializeComponent();
            f0 = this;
            textBox1.Text = IP.ToString();
            textBox2.Text = "" + port;
            game_thread = new Thread(mainGame);
            game_thread.Start();
            for(int i = 0; i < board.Length; i++)
            {
                board[i].id = i;
                board[i].status = "";
            }
        }

        void updateBoardInfo()
        {
            if (client_connected_to_server)
            {
                try
                {
                    int updateCount = 0;
                    for (int i = 0; i < board.Length; i++)
                    {
                        if (board[i].status.Length == 0)
                            continue;
                        updateCount++;
                    }
                    string textToSend = "update_" + updateCount;
                    for (int i = 0; i < board.Length; i++)
                    {
                        if (board[i].status.Length == 0)
                            continue;
                        textToSend+="" + board[i].id + board[i].status + " ";
                    }
                    Console.WriteLine(textToSend);
                    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);
                    stream.Write(bytesToSend, 0, bytesToSend.Length);
                    updateBoard = false;
                }
                catch (Exception ex) { }
            }
            else if (client_connected)
            {
                try
                {
                    int updateCount = 0;
                    for (int i = 0; i < board.Length; i++)
                    {
                        if (board[i].status.Length == 0)
                            continue;
                        updateCount++;
                    }
                    string textToSend = "update_" + updateCount;
                    for (int i = 0; i < board.Length; i++)
                    {
                        if (board[i].status.Length == 0)
                            continue;
                        textToSend += "" + board[i].id + board[i].status + " ";
                    }
                    NetworkStream nwStream = client.GetStream();
                    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);
                    nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                    updateBoard = false;
                }
                catch (Exception ex) { }
            }
        }

        void mainGame()
        {
            while(inGame)
            {
                if ((clientReady && serverReady) && !game_started)
                {
                    label6.Invoke((MethodInvoker)(() => label6.Text = "Started"));
                    if(user.Equals("server"))
                        f0.Invoke((MethodInvoker)(() => f0.Text = "TicTacToe - Player 1"));
                    if (user.Equals("client"))
                        f0.Invoke((MethodInvoker)(() => f0.Text = "TicTacToe - Player 2"));
                    Random rand = new Random();
                    player = rand.Next(0,2);
                    if(player == 0)
                        label8.Invoke((MethodInvoker)(() => label8.Text = "Player 1"));
                    if (player == 1)
                        label8.Invoke((MethodInvoker)(() => label8.Text = "Player 2"));
                    game_started = true;
                }

                if(nextTurn)
                {
                    if (player == 0)
                        label8.Invoke((MethodInvoker)(() => label8.Text = "Player 1"));
                    if (player == 1)
                        label8.Invoke((MethodInvoker)(() => label8.Text = "Player 2"));
                    nextTurn = false;
                }
                //if(updateBoard)
                //{
                //    updateBoardInfo();
                //    updateBoard = false;
                //}
            }
        }

        private void startServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!server_started)
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
                    if(client.Connected)
                    {
                        label2.Invoke((MethodInvoker)(() => label2.Text = "Client connected to Server!"));
                        client_connected_to_server = true;
                    } 

                    stream = client.GetStream();
                    
                    int i;

                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        if (data.ToString().Equals("clientReady"))
                        {
                            clientReady = true;
                            readyPlayer2.Invoke((MethodInvoker)(() => readyPlayer2.Text = "Ready"));
                        }
                        if (data.ToString().StartsWith("update_"))
                        {
                            if(player == 0)
                                player = 1;
                            else if(player == 1)
                                player = 0;
                            nextTurn = true;
                            string newData = data.Replace("update_", "");
                            //listBox1.Invoke((MethodInvoker)(() => listBox1.Items.Add(newData)));

                            string count = newData.Substring(0, 1);
                            newData = newData.Remove(0, 1);
                            int cnt = 0;
                            try
                            {
                                cnt = int.Parse(count);
                                for (int j = 0; j < cnt; j++)
                                {
                                    string id = newData.Substring(0, 1);
                                    newData = newData.Remove(0, 1);
                                    string status = newData.Substring(0, newData.IndexOf(" "));
                                    newData = newData.Remove(0, newData.IndexOf(" ") + 1);

                                    if (id.Equals("0"))
                                    {
                                        grid1x1.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\" + status + @".png");
                                        grid1x1.BackgroundImageLayout = ImageLayout.Zoom;
                                        board[0].status = status;
                                    }
                                    else if (id.Equals("1"))
                                    {
                                        grid1x2.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\" + status + @".png");
                                        grid1x2.BackgroundImageLayout = ImageLayout.Zoom;
                                        board[1].status = status;
                                    }
                                    else if (id.Equals("2"))
                                    {
                                        grid1x3.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\" + status + @".png");
                                        grid1x3.BackgroundImageLayout = ImageLayout.Zoom;
                                        board[2].status = status;
                                    }
                                    else if (id.Equals("3"))
                                    {
                                        grid2x1.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\" + status + @".png");
                                        grid2x1.BackgroundImageLayout = ImageLayout.Zoom;
                                        board[3].status = status;
                                    }
                                    else if (id.Equals("4"))
                                    {
                                        grid2x2.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\" + status + @".png");
                                        grid2x2.BackgroundImageLayout = ImageLayout.Zoom;
                                        board[4].status = status;
                                    }
                                    else if (id.Equals("5"))
                                    {
                                        grid2x3.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\" + status + @".png");
                                        grid2x3.BackgroundImageLayout = ImageLayout.Zoom;
                                        board[5].status = status;
                                    }
                                    else if (id.Equals("6"))
                                    {
                                        grid3x1.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\" + status + @".png");
                                        grid3x1.BackgroundImageLayout = ImageLayout.Zoom;
                                        board[7].status = status;
                                    }
                                    else if (id.Equals("7"))
                                    {
                                        grid3x2.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\" + status + @".png");
                                        grid3x2.BackgroundImageLayout = ImageLayout.Zoom;
                                        board[8].status = status;
                                    }
                                    else if (id.Equals("8"))
                                    {
                                        grid3x3.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\" + status + @".png");
                                        grid3x3.BackgroundImageLayout = ImageLayout.Zoom;
                                        board[8].status = status;
                                    }
                                }
                            }
                            catch { }

                        }
                        Console.WriteLine("Server Received: {0}", data);
                        //listBox1.Invoke((MethodInvoker)(() => listBox1.Items.Add(data)));
                    }

                    client.Close();
                }
                catch (Exception ex)
                {

                }
            }
            //server.Stop();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!client_connected)
            {
                client = new TcpClient();      
                client.Connect(textBox1.Text.ToString(), int.Parse(textBox2.Text));
                client_connected = true;
                client_thread = new Thread(Client);
                client_thread.Start();
            }
           
        }

        void Client()
        {
            try
            {
                label4.Invoke((MethodInvoker)(() => label4.Text = "Connected!"));
                while (client_connected)
                {
                    String data = null;
                    NetworkStream nwStream = client.GetStream();
                    byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                    int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                    data = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
                    if (data.ToString().Equals("serverReady"))
                    {
                        serverReady = true;
                        readyPlayer1.Invoke((MethodInvoker)(() => readyPlayer1.Text = "Ready"));
                    }
                    if(data.ToString().StartsWith("update_"))
                    {
                        if (player == 0)
                            player = 1;
                        else if (player == 1)
                            player = 0;
                        nextTurn = true;
                        string newData = data.Replace("update_","");
                        //listBox1.Invoke((MethodInvoker)(() => listBox1.Items.Add(newData)));

                        string count = newData.Substring(0, 1);
                        newData = newData.Remove(0, 1);
                        int cnt = 0;
                        try
                        {
                            cnt = int.Parse(count);
                            for(int i = 0;i<cnt;i++)
                            {
                                string id = newData.Substring(0, 1);
                                newData = newData.Remove(0, 1);
                                string status = newData.Substring(0, newData.IndexOf(" "));
                                newData = newData.Remove(0, newData.IndexOf(" ") + 1);

                                if(id.Equals("0"))
                                {
                                    grid1x1.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\" + status + @".png");
                                    grid1x1.BackgroundImageLayout = ImageLayout.Zoom;
                                    board[0].status = status;
                                }
                                else if (id.Equals("1"))
                                {
                                    grid1x2.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\" + status + @".png");
                                    grid1x2.BackgroundImageLayout = ImageLayout.Zoom;
                                    board[1].status = status;
                                }
                                else if (id.Equals("2"))
                                {
                                    grid1x3.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\" + status + @".png");
                                    grid1x3.BackgroundImageLayout = ImageLayout.Zoom;
                                    board[2].status = status;
                                }
                                else if (id.Equals("3"))
                                {
                                    grid2x1.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\" + status + @".png");
                                    grid2x1.BackgroundImageLayout = ImageLayout.Zoom;
                                    board[3].status = status;
                                }
                                else if (id.Equals("4"))
                                {
                                    grid2x2.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\" + status + @".png");
                                    grid2x2.BackgroundImageLayout = ImageLayout.Zoom;
                                    board[4].status = status;
                                }
                                else if (id.Equals("5"))
                                {
                                    grid2x3.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\" + status + @".png");
                                    grid2x3.BackgroundImageLayout = ImageLayout.Zoom;
                                    board[5].status = status;
                                }
                                else if (id.Equals("6"))
                                {
                                    grid3x1.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\" + status + @".png");
                                    grid3x1.BackgroundImageLayout = ImageLayout.Zoom;
                                    board[6].status = status;
                                }
                                else if (id.Equals("7"))
                                {
                                    grid3x2.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\" + status + @".png");
                                    grid3x2.BackgroundImageLayout = ImageLayout.Zoom;
                                    board[7].status = status;
                                }
                                else if (id.Equals("8"))
                                {
                                    grid3x3.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\" + status + @".png");
                                    grid3x3.BackgroundImageLayout = ImageLayout.Zoom;
                                    board[8].status = status;
                                }
                            }
                        }
                        catch { }
                        
                    }
                    //listBox1.Invoke((MethodInvoker)(() => listBox1.Items.Add(data)));
                }
                
                client.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }

        private void stopServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(server_started)
            {
                server.Stop();
                server_started = false;
                server_thread.Join();
                this.Text = "TicTacToe";
                label2.Text = "Offline";     
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(client_connected)
            {
                client_connected = false;
                client.Close();
                client_thread.Join();
                this.Text = "TicTacToe";
                label4.Text = "Disconnected";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateBoardInfo();
            player = 0;
            nextTurn = true;
        }

        private void ready_Click(object sender, EventArgs e)
        {
            if(client_connected_to_server)
            {
                try
                {
                    user = "server";
                    string textToSend = "serverReady";
                    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);
                    stream.Write(bytesToSend, 0, bytesToSend.Length);
                    serverReady = true;
                    readyPlayer1.Text = "Ready";
                }
                catch (Exception ex) { }
            }

            if (client_connected)
            {
                try
                {
                    user = "client";
                    string textToSend = "clientReady";
                    NetworkStream nwStream = client.GetStream();
                    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);
                    nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                    clientReady = true;
                    readyPlayer2.Text = "Ready";
                }
                catch (Exception ex) { }
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
            if (client_connected)
            {
                client_connected = false;
                client.Close();
                client_thread.Join();
            }
            inGame = false;
            game_thread.Join();
        }

        private void grid1x1_Click(object sender, EventArgs e)
        {
            if(player == 0 && user.Equals("server"))
            {
                if(board[0].status.Length == 0)
                {
                    grid1x1.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\cross.png");
                    grid1x1.BackgroundImageLayout = ImageLayout.Zoom;
                    board[0].status = "cross";
                    CrossCount++;
                    player = 1;
                    nextTurn = true;
                    updateBoardInfo();
                } 
            }
            else if(player == 1 && user.Equals("client"))
            {
                if(board[0].status.Length == 0)
                {
                    grid1x1.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\zero.png");
                    grid1x1.BackgroundImageLayout = ImageLayout.Zoom;
                    board[0].status = "zero";
                    ZeroCount++;
                    player = 0;
                    nextTurn = true;
                    updateBoardInfo();
                }
            }
        }

        private void grid1x2_Click(object sender, EventArgs e)
        {
            if (player == 0 && user.Equals("server"))
            {
                if(board[1].status.Length == 0)
                {
                    grid1x2.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\cross.png");
                    grid1x2.BackgroundImageLayout = ImageLayout.Zoom;
                    board[1].status = "cross";
                    CrossCount++;
                    player = 1;
                    nextTurn = true;
                    updateBoardInfo();
                }
            }
            else if(player == 1 && user.Equals("client"))
            {
                if (board[1].status.Length == 0)
                {
                    grid1x2.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\zero.png");
                    grid1x2.BackgroundImageLayout = ImageLayout.Zoom;
                    board[1].status = "zero";
                    ZeroCount++;
                    player = 0;
                    nextTurn = true;
                    updateBoardInfo();
                }
            }
        }

        private void grid1x3_Click(object sender, EventArgs e)
        {
            if (player == 0 && user.Equals("server"))
            {
                if (board[2].status.Length == 0)
                {
                    grid1x3.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\cross.png");
                    grid1x3.BackgroundImageLayout = ImageLayout.Zoom;
                    board[2].status = "cross";
                    CrossCount++;
                    player = 1;
                    nextTurn = true;
                    updateBoardInfo();
                }
            }
            else if(player == 1 && user.Equals("client"))
            {
                if (board[2].status.Length == 0)
                {
                    grid1x3.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\zero.png");
                    grid1x3.BackgroundImageLayout = ImageLayout.Zoom;
                    board[2].status = "zero";
                    ZeroCount++;
                    player = 0;
                    nextTurn = true;
                    updateBoardInfo();
                }  
            }
        }

        private void grid2x1_Click(object sender, EventArgs e)
        {
            if (player == 0 && user.Equals("server"))
            {
                if (board[3].status.Length == 0)
                {
                    grid2x1.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\cross.png");
                    grid2x1.BackgroundImageLayout = ImageLayout.Zoom;
                    board[3].status = "cross";
                    CrossCount++;
                    player = 1;
                    nextTurn = true;
                    updateBoardInfo();
                }       
            }
            else if(player == 1 && user.Equals("client"))
            {
                if (board[3].status.Length == 0)
                {
                    grid2x1.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\zero.png");
                    grid2x1.BackgroundImageLayout = ImageLayout.Zoom;
                    board[3].status = "zero";
                    ZeroCount++;
                    player = 0;
                    nextTurn = true;
                    updateBoardInfo();
                }   
            }
        }

        private void grid2x2_Click(object sender, EventArgs e)
        {
            if (player == 0 && user.Equals("server"))
            {
                if (board[4].status.Length == 0)
                {
                    grid2x2.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\cross.png");
                    grid2x2.BackgroundImageLayout = ImageLayout.Zoom;
                    board[4].status = "cross";
                    CrossCount++;
                    player = 1;
                    nextTurn = true;
                    updateBoardInfo();
                }      
            }
            else if(player == 1 && user.Equals("client"))
            {
                if (board[4].status.Length == 0)
                {
                    grid2x2.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\zero.png");
                    grid2x2.BackgroundImageLayout = ImageLayout.Zoom;
                    board[4].status = "zero";
                    ZeroCount++;
                    player = 0;
                    nextTurn = true;
                    updateBoardInfo();
                }     
            }
        }

        private void grid2x3_Click(object sender, EventArgs e)
        {
            if (player == 0 && user.Equals("server"))
            {
                if (board[5].status.Length == 0)
                {
                    grid2x3.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\cross.png");
                    grid2x3.BackgroundImageLayout = ImageLayout.Zoom;
                    board[5].status = "cross";
                    CrossCount++;
                    player = 1;
                    nextTurn = true;
                    updateBoardInfo();
                }      
            }
            else if(player == 1 && user.Equals("client"))
            {
                if (board[5].status.Length == 0)
                {
                    grid2x3.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\zero.png");
                    grid2x3.BackgroundImageLayout = ImageLayout.Zoom;
                    board[5].status = "zero";
                    ZeroCount++;
                    player = 0;
                    nextTurn = true;
                    updateBoardInfo();
                }
            }
        }

        private void grid3x1_Click(object sender, EventArgs e)
        {
            if (player == 0 && user.Equals("server"))
            {
                if (board[6].status.Length == 0)
                {
                    grid3x1.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\cross.png");
                    grid3x1.BackgroundImageLayout = ImageLayout.Zoom;
                    board[6].status = "cross";
                    CrossCount++;
                    player = 1;
                    nextTurn = true;
                    updateBoardInfo();
                }
            }
            else if(player == 1 && user.Equals("client"))
            {
                if (board[6].status.Length == 0)
                {
                    grid3x1.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\zero.png");
                    grid3x1.BackgroundImageLayout = ImageLayout.Zoom;
                    board[6].status = "zero";
                    ZeroCount++;
                    player = 0;
                    nextTurn = true;
                    updateBoardInfo();
                }
            }
        }

        private void grid3x2_Click(object sender, EventArgs e)
        {
            if (player == 0 && user.Equals("server"))
            {
                if (board[7].status.Length == 0)
                {
                    grid3x2.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\cross.png");
                    grid3x2.BackgroundImageLayout = ImageLayout.Zoom;
                    board[7].status = "cross";
                    CrossCount++;
                    player = 1;
                    nextTurn = true;
                    updateBoardInfo();
                }
            }
            else if(player == 1 && user.Equals("client"))
            {
                if (board[7].status.Length == 0)
                {
                    grid3x2.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\zero.png");
                    grid3x2.BackgroundImageLayout = ImageLayout.Zoom;
                    board[7].status = "zero";
                    ZeroCount++;
                    player = 0;
                    nextTurn = true;
                    updateBoardInfo();
                }
            }
        }

        private void grid3x3_Click(object sender, EventArgs e)
        {
            if (player == 0 && user.Equals("server"))
            {
                if (board[8].status.Length == 0)
                {
                    grid3x3.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\cross.png");
                    grid3x3.BackgroundImageLayout = ImageLayout.Zoom;
                    board[8].status = "cross";
                    CrossCount++;
                    player = 1;
                    nextTurn = true;
                    updateBoardInfo();
                }
            }
            else if (player == 1 && user.Equals("client"))
            {
                if (board[8].status.Length == 0)
                {
                    grid3x3.BackgroundImage = Image.FromFile(@"D:\3.RT\Programiranje\TicTacToe\images\zero.png");
                    grid3x3.BackgroundImageLayout = ImageLayout.Zoom;
                    board[8].status = "zero";
                    ZeroCount++;
                    player = 0;
                    nextTurn = true;
                    updateBoardInfo();
                }
            }
        }
    }
}
