using ChessGame.Network;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        NetworkInfo broadCast = new NetworkInfo("BroadCast", "255.255.255.255", 0);

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
                string message = networkManager.UDP.ReceiveDataBroadCast();
                if (message != "")
                {
                    Dictionary<string, string> receivedString =
                    networkManager.UDP.AnalysisReceiveString(message);

                    if (receivedString["ReceiverIP"] != networkManager.senderInfo.broadcastAddress)
                    {
                        switch (receivedString["Type"].ToUpper())
                        {
                            case "HOST":
                                if (this.AlHost.IndexOf(receivedString["ReceiverName"]) != 1)
                                {
                                    this.AlHost.Add(receivedString["ReceiverName"] + ":" + receivedString["ReceiverIP"]);
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

        private void btnsend_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet("CHAT", "txtchat.Text");
            networkManager.UDP.SendPacket(broadCast, packet);
            this.lstChat.Items.Add(networkManager.senderInfo.hostName + ": " + txtchat.Text);
            this.lstChat.TopIndex = lstChat.Items.Count - 1;
            txtchat.Clear();
        }

        private void btnHostGame_Click(object sender, EventArgs e)
        {
            this.ActiveListener = false;
            this.tListenForRequest.Abort();
            timerSendBroadcast.Stop();
            timerUpdateHost.Stop();

            networkManager.UDP.Disconnect();
            networkManager.Function = 1;
            this.Hide();
            this.AlHost = new ArrayList();
            lstHost.Items.Clear();
            ///Join Game
            Form1 frmlangame = new Form1();
            frmlangame.ShowDialog();
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
                networkManager.connectionState = 1;
                networkManager.Function = 2;

                ListViewItem li = lstHost.SelectedItems[0];
                string strHost = li.Text;
                string[] arrHostEntry = strHost.Split(':');
                networkManager.receiverInfo = new NetworkInfo(arrHostEntry[0], arrHostEntry[1], int.Parse(arrHostEntry[2]));

                //clsProfile profile = new clsProfile(networkManager.Profile);
                //string a = profile.TotalWin.ToString();
                //string b = profile.TotalDraw.ToString();
                //string c = profile.TotalLose.ToString();
                //string d = profile.Rating.ToString();

                Packet packet = new Packet("JOIN", "");
                networkManager.UDP.SendPacket(networkManager.receiverInfo, packet);
                this.Hide();
                this.AlHost = new ArrayList();
                lstHost.Items.Clear();
                ///Join Game
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
    }
}
