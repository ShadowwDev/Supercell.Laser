namespace Supercell.Laser.Logic.Message.Security
{
    using Supercell.Laser.Titan.DataStream;
    using Supercell.Laser.Titan.Message;

    public class ClientCryptoErrorMessage : PiranhaMessage
    {
        public const int MESSAGE_TYPE = 10099;

        public ClientCryptoErrorMessage(short version, ByteStream stream) : base(version, stream)
        {
            // ClientCryptoErrorMessage.
        }

        public override void Encode()
        {
            base.Encode();
            this.m_stream.WriteInt(0);
        }

        public override void Decode()
        {
            base.Decode();
            this.m_stream.ReadInt();
        }

        public override short GetMessageType()
        {
            return ClientCryptoErrorMessage.MESSAGE_TYPE;
        }

        public override int GetServiceNodeType()
        {
            return 1;
        }

        public override void Destruct()
        {
            base.Destruct();
        }
    }
}
