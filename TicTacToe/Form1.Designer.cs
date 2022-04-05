namespace TicTacToe
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grid3x3 = new System.Windows.Forms.Button();
            this.grid3x2 = new System.Windows.Forms.Button();
            this.grid3x1 = new System.Windows.Forms.Button();
            this.grid2x3 = new System.Windows.Forms.Button();
            this.grid2x2 = new System.Windows.Forms.Button();
            this.grid2x1 = new System.Windows.Forms.Button();
            this.grid1x3 = new System.Windows.Forms.Button();
            this.grid1x2 = new System.Windows.Forms.Button();
            this.grid1x1 = new System.Windows.Forms.Button();
            this.ready = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.readyPlayer1 = new System.Windows.Forms.Label();
            this.readyPlayer2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startServerToolStripMenuItem,
            this.stopServerToolStripMenuItem,
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // startServerToolStripMenuItem
            // 
            this.startServerToolStripMenuItem.Name = "startServerToolStripMenuItem";
            this.startServerToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.startServerToolStripMenuItem.Text = "Start Server";
            this.startServerToolStripMenuItem.Click += new System.EventHandler(this.startServerToolStripMenuItem_Click);
            // 
            // stopServerToolStripMenuItem
            // 
            this.stopServerToolStripMenuItem.Name = "stopServerToolStripMenuItem";
            this.stopServerToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.stopServerToolStripMenuItem.Text = "Stop Server";
            this.stopServerToolStripMenuItem.Click += new System.EventHandler(this.stopServerToolStripMenuItem_Click);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server status:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 428);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Offline";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(676, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 37);
            this.button1.TabIndex = 3;
            this.button1.Text = "Test connection";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 428);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Client status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(298, 428);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Disconnected";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grid3x3);
            this.panel1.Controls.Add(this.grid3x2);
            this.panel1.Controls.Add(this.grid3x1);
            this.panel1.Controls.Add(this.grid2x3);
            this.panel1.Controls.Add(this.grid2x2);
            this.panel1.Controls.Add(this.grid2x1);
            this.panel1.Controls.Add(this.grid1x3);
            this.panel1.Controls.Add(this.grid1x2);
            this.panel1.Controls.Add(this.grid1x1);
            this.panel1.Location = new System.Drawing.Point(15, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 320);
            this.panel1.TabIndex = 6;
            // 
            // grid3x3
            // 
            this.grid3x3.Location = new System.Drawing.Point(215, 215);
            this.grid3x3.Name = "grid3x3";
            this.grid3x3.Size = new System.Drawing.Size(100, 100);
            this.grid3x3.TabIndex = 8;
            this.grid3x3.UseVisualStyleBackColor = true;
            this.grid3x3.Click += new System.EventHandler(this.grid3x3_Click);
            // 
            // grid3x2
            // 
            this.grid3x2.Location = new System.Drawing.Point(109, 215);
            this.grid3x2.Name = "grid3x2";
            this.grid3x2.Size = new System.Drawing.Size(100, 102);
            this.grid3x2.TabIndex = 7;
            this.grid3x2.UseVisualStyleBackColor = true;
            this.grid3x2.Click += new System.EventHandler(this.grid3x2_Click);
            // 
            // grid3x1
            // 
            this.grid3x1.Location = new System.Drawing.Point(3, 215);
            this.grid3x1.Name = "grid3x1";
            this.grid3x1.Size = new System.Drawing.Size(100, 100);
            this.grid3x1.TabIndex = 6;
            this.grid3x1.UseVisualStyleBackColor = true;
            this.grid3x1.Click += new System.EventHandler(this.grid3x1_Click);
            // 
            // grid2x3
            // 
            this.grid2x3.Location = new System.Drawing.Point(215, 109);
            this.grid2x3.Name = "grid2x3";
            this.grid2x3.Size = new System.Drawing.Size(100, 100);
            this.grid2x3.TabIndex = 5;
            this.grid2x3.UseVisualStyleBackColor = true;
            this.grid2x3.Click += new System.EventHandler(this.grid2x3_Click);
            // 
            // grid2x2
            // 
            this.grid2x2.Location = new System.Drawing.Point(109, 109);
            this.grid2x2.Name = "grid2x2";
            this.grid2x2.Size = new System.Drawing.Size(100, 100);
            this.grid2x2.TabIndex = 4;
            this.grid2x2.UseVisualStyleBackColor = true;
            this.grid2x2.Click += new System.EventHandler(this.grid2x2_Click);
            // 
            // grid2x1
            // 
            this.grid2x1.Location = new System.Drawing.Point(3, 109);
            this.grid2x1.Name = "grid2x1";
            this.grid2x1.Size = new System.Drawing.Size(100, 100);
            this.grid2x1.TabIndex = 3;
            this.grid2x1.UseVisualStyleBackColor = true;
            this.grid2x1.Click += new System.EventHandler(this.grid2x1_Click);
            // 
            // grid1x3
            // 
            this.grid1x3.Location = new System.Drawing.Point(215, 3);
            this.grid1x3.Name = "grid1x3";
            this.grid1x3.Size = new System.Drawing.Size(100, 100);
            this.grid1x3.TabIndex = 2;
            this.grid1x3.UseVisualStyleBackColor = true;
            this.grid1x3.Click += new System.EventHandler(this.grid1x3_Click);
            // 
            // grid1x2
            // 
            this.grid1x2.Location = new System.Drawing.Point(109, 3);
            this.grid1x2.Name = "grid1x2";
            this.grid1x2.Size = new System.Drawing.Size(100, 100);
            this.grid1x2.TabIndex = 1;
            this.grid1x2.UseVisualStyleBackColor = true;
            this.grid1x2.Click += new System.EventHandler(this.grid1x2_Click);
            // 
            // grid1x1
            // 
            this.grid1x1.Location = new System.Drawing.Point(3, 3);
            this.grid1x1.Name = "grid1x1";
            this.grid1x1.Size = new System.Drawing.Size(100, 100);
            this.grid1x1.TabIndex = 0;
            this.grid1x1.UseVisualStyleBackColor = true;
            this.grid1x1.Click += new System.EventHandler(this.grid1x1_Click);
            // 
            // ready
            // 
            this.ready.Location = new System.Drawing.Point(558, 404);
            this.ready.Name = "ready";
            this.ready.Size = new System.Drawing.Size(112, 37);
            this.ready.TabIndex = 7;
            this.ready.Text = "Ready";
            this.ready.UseVisualStyleBackColor = true;
            this.ready.Click += new System.EventHandler(this.ready_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(558, 77);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(430, 428);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Game status:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(505, 428);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Stopped";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Turn:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "player X";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(547, 378);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(521, 381);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "IP:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(653, 381);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Port:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(688, 378);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(555, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Player 1:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(673, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Player 2:";
            // 
            // readyPlayer1
            // 
            this.readyPlayer1.AutoSize = true;
            this.readyPlayer1.Location = new System.Drawing.Point(606, 34);
            this.readyPlayer1.Name = "readyPlayer1";
            this.readyPlayer1.Size = new System.Drawing.Size(58, 13);
            this.readyPlayer1.TabIndex = 19;
            this.readyPlayer1.Text = "Not Ready";
            // 
            // readyPlayer2
            // 
            this.readyPlayer2.AutoSize = true;
            this.readyPlayer2.Location = new System.Drawing.Point(727, 34);
            this.readyPlayer2.Name = "readyPlayer2";
            this.readyPlayer2.Size = new System.Drawing.Size(58, 13);
            this.readyPlayer2.TabIndex = 20;
            this.readyPlayer2.Text = "Not Ready";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.readyPlayer2);
            this.Controls.Add(this.readyPlayer1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.ready);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "TicTacToe";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startServerToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button grid1x1;
        private System.Windows.Forms.Button grid3x3;
        private System.Windows.Forms.Button grid3x2;
        private System.Windows.Forms.Button grid3x1;
        private System.Windows.Forms.Button grid2x3;
        private System.Windows.Forms.Button grid2x2;
        private System.Windows.Forms.Button grid2x1;
        private System.Windows.Forms.Button grid1x3;
        private System.Windows.Forms.Button grid1x2;
        private System.Windows.Forms.Button ready;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label readyPlayer1;
        private System.Windows.Forms.Label readyPlayer2;
    }
}

