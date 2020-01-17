using ChessGame.Network;
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

namespace ChessGame
{
    public partial class frmLanGame : Form
    {
        NetworkManager networkManager = NetworkManager.GetInstance();
        NetworkInfo broadCast = new NetworkInfo("BroadCast", "255.255.255.255", 0);

        bool ActiveListener = false;
        Thread tRec;

        bool isReady = false;
        bool isGuestReady = false;

        public frmLanGame()
        {
            InitializeComponent();
        }


        private void frmLanGame_Load(object sender, EventArgs e)
        {
            btnDraw.Enabled = false;
            btnLose.Enabled = false;

            CheckForIllegalCrossThreadCalls = false;
            networkManager.Disconnect();

            if (networkManager.role == NetworkManager.Role.Server)
            {
                MessageBox.Show("Đang tìm kiếm đối thủ...", "Waitting");
            }
            else
            {
                MessageBox.Show("Đang tiến hành kết nối máy chủ...", "Waitting");
                btnReady.Enabled = true;
            }

            this.ActiveListener = true;
            tRec = new Thread(new ThreadStart(ListenForRequest));
            tRec.IsBackground = true;
            tRec.Start();
        }

        void ListenForRequest()
        {
            while (ActiveListener)
            {
                try
                {
                    Packet packet;
                    Dictionary<string, string> receivedString;
                    string message = networkManager.ReceivePacket();
                    networkManager.AnalysisReceiveString(message);
                    message = networkManager.ReceivePacket();
                    receivedString =
                    networkManager.AnalysisReceiveString(message);



                    if (receivedString["ReceiverIP"] != networkManager.senderInfo.IPAddress ||
                        int.Parse(receivedString["ReceiverPort"]) != networkManager.senderInfo.port)
                    {
                        switch (receivedString["Type"].ToUpper())
                        {
                            case "FINDHOST":
                                packet = new Packet("HOST", "");
                                networkManager.receiverInfo = new NetworkInfo(receivedString["ReceiverName"], receivedString["ReceiverIP"], int.Parse(receivedString["ReceiverPort"]));
                                networkManager.SendPacket(packet);
                                break;
                            case "JOIN":

                                networkManager.receiverInfo = new NetworkInfo(receivedString["ReceiverName"], receivedString["ReceiverIP"], int.Parse(receivedString["ReceiverPort"]));
                                btnReady.Enabled = true;

                                MessageBox.Show("Người chơi " + receivedString["ReceiverName"] + " đã kết nối");
                                this.ActiveListener = true;
                                tRec = new Thread(new ThreadStart(ListenForRequest));
                                tRec.IsBackground = true;
                                tRec.Start();
                                break;
                            case "CHAT":
                                lstChatBox.Items.Add(receivedString["ReceiverName"] + " :" + receivedString["Message"]);
                                lstChatBox.TopIndex = lstChatBox.Items.Count - 1;
                                break;
                            case "READY":
                                MessageBox.Show(receivedString["ReceiverName"] + " đã sẵn sàng chơi.");
                                this.isGuestReady = true;
                                if ((this.isReady) && (networkManager.role == NetworkManager.Role.Server))
                                {
                                    StartGame();
                                }
                                break;
                            case "OUT":
                                MessageBox.Show("Máy bạn mất kết nối với " + receivedString["ReceiverName"], "Mất kết nối");
                                networkManager.Disconnect();
                                networkManager.Disconnect();

                                this.ActiveListener = false;
                                tRec = new Thread(new ThreadStart(ListenForRequest));
                                tRec.IsBackground = true;
                                tRec.Start();
                                break;
                            case "SENDED":

                                break;
                            case "MOVE":
                                //Thêm nước đi
                                break;
                            case "LOSE":
                                MessageBox.Show("Chúc mừng bạn đã thắng " + networkManager.receiverInfo.hostName);
                                panel1.Enabled = false;
                                break;
                            case "DRAW":

                                DialogResult drdraw = MessageBox.Show(networkManager.receiverInfo.hostName + " xin Hòa. Bạn đồng ý không ?", "XIN HÒA", MessageBoxButtons.OKCancel);
                                if (drdraw == DialogResult.OK)
                                {
                                    packet = new Packet("DRAWOK", "");
                                    networkManager.SendPacket(packet);
                                    MessageBox.Show("Bạn đã Hòa với " + networkManager.receiverInfo.hostName + ". Cố gắng thêm nhé.");
                                    panel1.Enabled = false;
                                }
                                else
                                {
                                    packet = new Packet("DRAWCANCEL", "");
                                    networkManager.SendPacket(packet);
                                }
                                break;
                            case "DRAWOK":
                                MessageBox.Show("Bạn đã Hòa với " + networkManager.receiverInfo.hostName + ". Cố gắng thêm nhé.");
                                panel1.Enabled = false;
                                break;
                            case "DRAWCANCEL":
                                MessageBox.Show(networkManager.receiverInfo.hostName + " không đồng ý HÒA.");
                                break;
                        }



                    }

                }
                catch
                {
                    if (networkManager.receiverInfo != null)
                    {
                        MessageBox.Show("Máy bạn đã mất kết nối với " + networkManager.receiverInfo.hostName, "Mất kết nối");
                    }
                    else
                    {

                    }
                }
            }
        }

        private void StartGame()
        {
            throw new NotImplementedException();
        }

        private void frmLanGame_FormClosing(object sender, FormClosingEventArgs e)
        {

            Packet packet = new Packet("OUT", "");
            networkManager.SendPacket(packet);

            tRec.Abort();
            networkManager.Disconnect();
            networkManager.Disconnect();

        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            if (txtchat.Text != "")
            {
                lstChatBox.Items.Add(networkManager.senderInfo.hostName + ": " + txtchat.Text);
                lstChatBox.TopIndex = lstChatBox.Items.Count - 1;
                Packet packet = new Packet("CHAT", txtchat.Text);
                switch (networkManager.connectionState)
                {
                    case NetworkManager.ConnectionState.Connected:
                        networkManager.SendPacket(packet);
                        break;
                    default:
                        networkManager.SendPacket(packet);
                        break;
                }
                txtchat.Clear();
            }
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            if (networkManager.receiverInfo != null)
            {
                btnReady.Enabled = false;
                isReady = true;
                Packet packet = new Packet("READY", "");
                networkManager.SendPacket(packet);
                if ((isGuestReady) && (networkManager.role == NetworkManager.Role.Server))
                {
                    StartGame();
                }
            }else
            {
                MessageBox.Show("Chưa có người chơi kết nối ");

            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            btnPlay.Enabled = false;
            btnChat.Enabled = true;
        }

        
        private void btnDraw_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet("DRAW", "");
            networkManager.SendPacket(packet);
        }

        private void btnLose_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet("LOSE", "");
            networkManager.SendPacket(packet);
            MessageBox.Show("Bạn đã Thua " + networkManager.receiverInfo.hostName + ". Cố gắng thêm nhé.");
            panel1.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void txtChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnChat_Click(sender, e);
            }
        }
    }
}
