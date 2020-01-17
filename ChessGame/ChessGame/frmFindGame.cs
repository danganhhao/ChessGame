using ChessGame.Network;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class frmFindGame : Form
    {
        Thread tListenForRequest;
        bool ActiveListener = true;
        ArrayList AlHost = new ArrayList();
        NetworkManager networkManager = NetworkManager.GetInstance();
        NetworkInfo broadCast = new NetworkInfo("BroadCast", IPAddress.Broadcast.MapToIPv4().ToString(), 0);

        public frmFindGame()
        {
            InitializeComponent();
        }

        private void frmFindGame_Load(object sender, EventArgs e)
        {
            networkManager.UDP.Disconnect();
            CheckForIllegalCrossThreadCalls = false;

            tListenForRequest = new Thread(new ThreadStart(ListenForRequest));
            tListenForRequest.IsBackground = true;
            tListenForRequest.Start();
        }

        void ListenForRequest()
        {
            while (ActiveListener)
            {
                string message = networkManager.UDP.ReceivePacket(broadCast);
                if (message != "")
                {
                   
                    Dictionary<string, string> receivedString =
                    networkManager.UDP.AnalysisReceiveString(message);

                    if (receivedString["ReceiverIP"] != networkManager.senderInfo.IPAddress ||
                        int.Parse(receivedString["ReceiverPort"]) != networkManager.senderInfo.port)
                    {   

                        switch (receivedString["Type"].ToUpper())
                        {
                            case "HOST":
                                if (this.AlHost.IndexOf(receivedString["ReceiverName"]) != 1)
                                {
                                    this.AlHost.Add(receivedString["ReceiverName"] + ":" + receivedString["ReceiverIP"] + ":" + receivedString["ReceiverPort"]);
                                }
                                break;
                            case "CHAT":
                                this.lstChat.Items.Insert(0, receivedString["ReceiverName"] + ": " + receivedString["Message"]);
                                this.lstChat.SelectedIndex = 0;
                                break;
                        }
                    }
                }
            }
        }

        private void timerSendBroadcast_Tick(object sender, EventArgs e)
        {
            this.AlHost = new ArrayList();

            Packet packet = new Packet("FINDHOST","");
            networkManager.UDP.SendPacket(broadCast,packet);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtChat.Text != "")
            {
                Packet packet = new Packet("CHAT", txtChat.Text);
                networkManager.UDP.SendPacket(broadCast, packet);
                this.lstChat.Items.Add(networkManager.senderInfo.IPAddress+":"+ networkManager.senderInfo.port + ": " + txtChat.Text);
                this.lstChat.TopIndex = lstChat.Items.Count - 1;
                txtChat.Clear();
            }
        }

        private void btnHostGame_Click(object sender, EventArgs e)
        {
            this.ActiveListener = false;
            this.tListenForRequest.Abort();
            timerSendBroadcast.Stop();
            timerUpdateHost.Stop();

            networkManager.UDP.Disconnect();
            this.Hide();
            this.AlHost = new ArrayList();
            lstHost.Items.Clear();


            ///Join Game
            networkManager.role = NetworkManager.Role.Server;
            frmLanGame frmLanGame = new frmLanGame();
            frmLanGame.ShowDialog();
            ///Escape Game

            this.Show();
            timerSendBroadcast.Start();
            timerUpdateHost.Start();
            this.ActiveListener = true;
            tListenForRequest = new Thread(new ThreadStart(ListenForRequest));
            tListenForRequest.IsBackground = true;
            tListenForRequest.Start();
        }

        private void btnJoinGame_Click(object sender, EventArgs e)
        {
            if (lstHost.SelectedItems.Count > 0)
            {
                tListenForRequest.Abort();
                this.ActiveListener = false;
                timerSendBroadcast.Stop();
                timerUpdateHost.Stop();
                networkManager.UDP.Disconnect();

                ListViewItem li = lstHost.SelectedItems[0];
                string strHost = li.Text;
                string[] arrHostEntry = strHost.Split(':');
                networkManager.receiverInfo = new NetworkInfo(arrHostEntry[0], arrHostEntry[1], int.Parse(arrHostEntry[2]));

                Packet packet = new Packet("JOIN", "");
                networkManager.UDP.SendPacket(networkManager.receiverInfo, packet);
                this.Hide();
                this.AlHost = new ArrayList();
                lstHost.Items.Clear();


                ///Join Game
                networkManager.role = NetworkManager.Role.Client;
                Form1 frmlangame = new Form1();
                frmlangame.ShowDialog();


                ///Escape Game
                this.Show();
                this.ActiveListener = true;
                timerSendBroadcast.Start();
                timerUpdateHost.Start();
                tListenForRequest = new Thread(new ThreadStart(ListenForRequest));
                tListenForRequest.IsBackground = true;
                tListenForRequest.Start();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn máy ...", "Join Game");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.tListenForRequest.Abort();
            networkManager.UDP.Disconnect();
            this.Close();
        }

        private void timerUpdateHost_Tick(object sender, EventArgs e)
        {
            //Remove Host
            for (int i = 0; i < lstHost.Items.Count; i++)
            {
                if (this.AlHost.IndexOf(lstHost.Items[i].Text) == -1)
                {
                    lstHost.Items[i].Remove();
                }
            }
            ///Add New Host
            for (int i = 0; i < this.AlHost.Count; i++)
            {
                ListViewItem li = this.lstHost.Items[this.AlHost[i].ToString()];
                if (li == null)
                {
                    li = new ListViewItem(this.AlHost[i].ToString(), 0);
                    li.Name = this.AlHost[i].ToString();
                    this.lstHost.Items.Add(li);
                }
            }
        }

        private void frmFindGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            networkManager.UDP.Disconnect(); ;
        }

        private void txtChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(sender, e);
            }
        }
    }
}
