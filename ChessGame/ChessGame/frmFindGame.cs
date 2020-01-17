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
            CheckForIllegalCrossThreadCalls = false;

            txtHostVal.Text = networkManager.senderInfo.IPAddress+ ":" + networkManager.senderInfo.port;
            tListenForRequest = new Thread(new ThreadStart(ListenForRequest));
            tListenForRequest.IsBackground = true;
            tListenForRequest.Start();
        }

        void ListenForRequest()
        {
            while (ActiveListener)
            {
                string message = networkManager.ReceivePacket();
                if (message != "")
                {
                   
                    Dictionary<string, string> receivedString =
                    networkManager.AnalysisReceiveString(message);

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
                        }
                    }
                }
            }
        } 

        private void btnHostGame_Click(object sender, EventArgs e)
        {
            this.ActiveListener = false;
            this.tListenForRequest.Abort();

            this.AlHost = new ArrayList();


            ///Join Game
            networkManager.ChangeRole(NetworkManager.Role.Server);
            MessageBox.Show("Đang tìm kiếm đối thủ...", "Waitting");
            networkManager.Connect(broadCast);
            this.Hide();
            frmLanGame LanGame = new frmLanGame();
            LanGame.ShowDialog();

            ///Escape Game
            this.Show();
            this.ActiveListener = true;
            tListenForRequest = new Thread(new ThreadStart(ListenForRequest));
            tListenForRequest.IsBackground = true;
            tListenForRequest.Start();
        }

        private void btnJoinGame_Click(object sender, EventArgs e)
        {
            networkManager.ChangeRole(NetworkManager.Role.Client);

            if (txtIP.Text == "" || txtPort.Text == "")
            {
                MessageBox.Show("Vui nhập IP/Port ...", "Join Game");
            }
            else
            {
                NetworkInfo server = new NetworkInfo(txtIP.Text, int.Parse(txtPort.Text));
                networkManager.Connect(server);
                networkManager.receiverInfo = server;
                networkManager.SendPacket(new Packet("JOIN",""));
                frmLanGame frmLanGame = new frmLanGame();
                frmLanGame.ShowDialog();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.tListenForRequest.Abort();
            this.Close();
        }

        private void frmFindGame_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

    }
}
