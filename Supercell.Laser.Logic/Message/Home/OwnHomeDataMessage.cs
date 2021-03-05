namespace Supercell.Laser.Logic.Message.Home
{
    using Supercell.Laser.Logic.Home;
    using Supercell.Laser.Logic.Avatar;
    using Supercell.Laser.Titan.Message;
    using Supercell.Laser.Titan.DataStream;

    public class OwnHomeDataMessage : PiranhaMessage
    {
        public const int MESSAGE_TYPE = 24101;

        private LogicClientAvatar m_logicClientAvatar;
        private LogicClientHome m_logicClientHome;

        public OwnHomeDataMessage(short version) : base(version)
        {
            // OwnHomeDataMessage.
        }

        public override void Encode()
        {
            base.Encode();

            this.m_logicClientHome = new LogicClientHome();
            this.m_logicClientHome.Encode(this.m_stream);
            this.m_logicClientAvatar = new LogicClientAvatar();
            this.m_logicClientAvatar.Encode(this.m_stream);

            this.m_stream.WriteVInt(5);
        }

        public override void Decode()
        {
            base.Decode();
        }

        public override short GetMessageType()
        {
            return OwnHomeDataMessage.MESSAGE_TYPE;
        }

        public override int GetServiceNodeType()
        {
            return 9;
        }
    }
}
