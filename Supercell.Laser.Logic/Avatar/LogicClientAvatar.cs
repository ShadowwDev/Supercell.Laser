namespace Supercell.Laser.Logic.Avatar
{
    using Supercell.Laser.Titan.Math;
    using Supercell.Laser.Titan.DataStream;
    using Supercell.Laser.Logic.Helper;

    class LogicClientAvatar
    {
        private LogicLong m_homeId;

        public LogicClientAvatar()
        {
            this.Init();
        }

        public void Init()
        {
            this.m_homeId = new LogicLong();
        }

        public virtual void Encode(ChecksumEncoder encoder)
        {
            encoder.WriteLogicLong(m_homeId);
            encoder.WriteLogicLong(m_homeId);
            encoder.WriteLogicLong(m_homeId);

            encoder.WriteString("Name");
            encoder.WriteByte(1); //name set by user

            encoder.WriteInt(0);

            encoder.WriteVInt(8);

            encoder.WriteVInt(0);

            encoder.WriteVInt(0);

            encoder.WriteVInt(0);

            encoder.WriteVInt(0);

            encoder.WriteVInt(0);

            encoder.WriteVInt(0);

            encoder.WriteVInt(0);

            encoder.WriteVInt(0);

            encoder.WriteVInt(999999);
            encoder.WriteVInt(999999);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteVInt(2);
        }

        public void Decode(ByteStream stream)
        {
            
        }
    }
}
