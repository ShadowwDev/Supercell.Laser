namespace Supercell.Laser.Logic.Message
{
    using Supercell.Laser.Titan.Message;
    using Supercell.Laser.Titan.DataStream;
    using Supercell.Laser.Logic.Message.Account;
    using Supercell.Laser.Logic.Message.Security;

    public class LogicLaserMessageFactory : LogicMessageFactory
    {
        public static readonly LogicMessageFactory Instance;
        static LogicLaserMessageFactory()
        {
            LogicLaserMessageFactory.Instance = new LogicLaserMessageFactory();
        }
        public override PiranhaMessage CreateMessageByType(int type, ByteStream stream)
        {
            if (type < 20000)
            {
                switch (type)
                {
                    case ClientCryptoErrorMessage.MESSAGE_TYPE:
                        return null; 
                    case ClientHelloMessage.MESSAGE_TYPE:
                        return null; 
                    case LoginMessage.MESSAGE_TYPE:
                        return new LoginMessage(1, stream);
                }
            }
            return null;
        }
    }
}
