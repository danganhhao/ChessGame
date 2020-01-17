namespace ChessGame.Network
{
    partial class NetworkManager
    {
        public RoleStategy RoleStategy
        {
            get => default(RoleStategy);
            set
            {
            }
        }

        public NetworkInfo NetworkInfo
        {
            get => default(NetworkInfo);
            set
            {
            }
        }

        public enum ConnectionState
        {
            StandingBy,
            Connecting,
            Listening,
            Connected,
            Disconnected,

        }

        public enum Role
        {
            Client,
            Server,
        }

    }
}
