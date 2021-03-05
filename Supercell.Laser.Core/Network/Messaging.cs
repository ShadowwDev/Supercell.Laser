namespace Supercell.Laser.Core.Network
{
    using Supercell.Laser.Logic.Message;
    using Supercell.Laser.Titan.Message;
    using Supercell.Laser.Titan.DataStream;
    using System.Collections.Generic;
    using System;

    public class Messaging
    {
        private Connection m_connection;
        private MessageManager m_messageManager;
        public Messaging(Connection connection)
        {
            this.m_connection = connection;
            this.m_messageManager = new MessageManager(this.m_connection);
        }

        public void OnReceive(int type, int length, int version, ByteStream stream)
        {
            PiranhaMessage message = LogicLaserMessageFactory.Instance.CreateMessageByType(type, stream);
            if (message != null)
            {
                message.Decode();
                this.m_messageManager.ReceiveMessage(message);
            }
        }

        public void SendMessage(PiranhaMessage message)
        {
            message.Encode();
            byte[] stream = new byte[7];
            WriteHeader(stream, message);
            List<byte> packet = new List<byte>();
            packet.AddRange(stream);
            packet.AddRange(CheckByteArrayCapacity(message));
            packet.AddRange(new byte[] { 0xFF, 0xFF, 0x0, 0x0, 0x0, 0x0, 0x0 });
            this.m_connection.Send(packet.ToArray());
        }

        private void WriteHeader(byte[] stream, PiranhaMessage message)
        {
            stream[0] = (byte)(message.GetMessageType() >> 8);
            stream[1] = (byte)(message.GetMessageType());
            stream[2] = (byte)(message.GetEncodingLength() >> 16);
            stream[3] = (byte)(message.GetEncodingLength() >> 8);
            stream[4] = (byte)(message.GetEncodingLength());
            stream[5] = (byte)(message.GetMessageVersion() >> 8);
            stream[6] = (byte)(message.GetMessageVersion());
        }

        public byte[] CheckByteArrayCapacity(PiranhaMessage message)
        {
            if (message.GetEncodingLength() != message.GetMessageBytes().Length)
            {
                byte[] newBytes = new byte[message.GetEncodingLength()];

                Buffer.BlockCopy(message.GetMessageBytes(), 0, newBytes, 0, message.GetEncodingLength());

                return newBytes;
            }

            return message.GetMessageBytes();
        }
    }
}
