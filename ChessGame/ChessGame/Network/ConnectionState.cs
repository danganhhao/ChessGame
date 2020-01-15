namespace ChessGame.Network
{
    partial class NetworkManager
    {
        public enum ConnectionState
        {
            StandingBy,
            Connecting,
            Listening,
            Connected,
            Disconnected,

        }

        public enum PacketTranferState
        {
            None,
            Sending,
            Sended,
            Receiving,
            Received,
        }

    }
}
