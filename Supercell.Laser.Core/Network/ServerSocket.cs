namespace Supercell.Laser.Core.Network
{
    using System.Net;
    using System.Threading;
    using System.Net.Sockets;

    class ServerSocket
    {
        private static TcpListener m_listener;
        private static Thread m_receiveThread;

        private static bool m_started;

        public static void Init()
        {
            ServerSocket.m_started = true;
            ServerSocket.m_listener = new TcpListener(IPAddress.Any, 9339);
            ServerSocket.m_receiveThread = new Thread(ServerSocket.Receive);
            ServerSocket.m_receiveThread.Start();
        }

        public static void DeInit()
        {
            ServerSocket.m_started = false;
        }

        private static void Receive()
        {
            ServerSocket.m_listener.Start();
            while (ServerSocket.m_started)
            {
                Socket client = ServerSocket.m_listener.AcceptSocket();

                Connection connection = new Connection(client);
            }
            ServerSocket.m_listener.Stop();
        }
    }
}
