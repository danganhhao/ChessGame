namespace ChessGame.Network
{
    partial class NetworkModule
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
