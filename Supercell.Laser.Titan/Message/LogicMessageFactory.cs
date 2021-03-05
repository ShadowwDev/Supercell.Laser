namespace Supercell.Laser.Titan.Message
{
    using Supercell.Laser.Titan.DataStream;

    public class LogicMessageFactory
    {
        public virtual PiranhaMessage CreateMessageByType(int type, ByteStream stream)
        {
            return null;
        }
    }
}
