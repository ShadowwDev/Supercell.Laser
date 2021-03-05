namespace Supercell.Laser.Core.Network
{
    using System.IO;
    using System.Threading;
    using System.Net.Sockets;
    using Supercell.Laser.Titan.DataStream;

    public class Connection
    {
        public Socket m_socket;
        private bool m_established;
        private Thread m_receiveThread;
        public Messaging m_messaging;

        public Connection(Socket socket)
        {
            this.m_socket = socket;
            this.m_messaging = new Messaging(this);
            this.m_established = true;

            this.m_receiveThread = new Thread(() =>
            {
                while (this.m_established)
                {
                    this.Receive();
                }
            });

            this.m_receiveThread.Start();
        }

        public void Receive()
        {
            byte[] buffer = new byte[2048];
            try
            {
                this.m_socket.Receive(buffer);
            }
            catch(SocketException)
            {
                this.Close();
            }

            ByteStream stream = new ByteStream(buffer, 2048);

            int type = stream.ReadShort();
            int length = stream.ReadByte() << 16 | stream.ReadByte() << 8 | stream.ReadByte() << 0;
            int version = stream.ReadShort();

            if (type != 0)
            {
                this.m_messaging.OnReceive(type, length, version, stream);
            }
            else
            {
                this.Close();
            }
        }

        public void Send(byte[] buffer)
        {
            try
            {
                this.m_socket.Send(buffer);
            }
            catch (IOException)
            {
                this.Close();
            }
        }

        public void Close()
        {
            this.m_socket.Close();
            this.m_established = false;
            this.m_receiveThread.Interrupt();
        }
    }
}
