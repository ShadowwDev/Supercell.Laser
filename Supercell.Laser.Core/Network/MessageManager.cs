namespace Supercell.Laser.Core.Network
{
    using System;
    using Supercell.Laser.Logic;
    using Supercell.Laser.Titan.Math;
    using Supercell.Laser.Titan.Message;
    using Supercell.Laser.Logic.Message.Account;
    using Supercell.Laser.Logic.Message.Security;
    using Supercell.Laser.Logic.Message.Home;

    class MessageManager
    {
        private readonly Connection m_connection;
        private DateTime m_keepAliveTime;
        private State state;
        private LogicLong m_accountId;
        private LogicLong m_homeId;
        private string m_token;

        public MessageManager(Connection connection)
        {
            this.m_connection = connection;
            this.m_keepAliveTime = DateTime.UtcNow;
            this.state = State.Login;
        }

        public void ReceiveMessage(PiranhaMessage message)
        {
            int messageType = message.GetMessageType();

            if (state == State.Disconnected)
                return;

            if (state != State.Logged)
            {
                switch (messageType)
                {
                    case ClientCryptoErrorMessage.MESSAGE_TYPE:
                        break;
                    case ClientHelloMessage.MESSAGE_TYPE:
                        this.ClientHelloReceived(message);
                        break;
                    case LoginMessage.MESSAGE_TYPE:
                        this.LoginMessageReceived((LoginMessage)message);
                        break;
                }
            }

        }

        private void LoginMessageReceived(LoginMessage message)
        {
            if (message.GetClientMajorVersion() == LogicVersion.MAJOR_VERSION && message.GetClientBuildVersion() == LogicVersion.BUILD_VERSION)
            {
                LoginOkMessage loginOk = new LoginOkMessage(1);
                OwnHomeDataMessage OHD = new OwnHomeDataMessage(0);
                this.m_accountId = new LogicLong(0, 1);
                this.m_homeId = new LogicLong(0, 1);
                loginOk.SetAccountId(this.m_accountId);
                loginOk.SetHomeId(this.m_homeId);
                loginOk.SetPassToken("qPuWwRXPUvQF8Q2Mjm9kQAyccu96UtBYmabkt3dQ");
                loginOk.SetContentVersion(1);
                loginOk.SetServerEnvironment(LogicConfiguration.GetEnviroment());
                this.m_connection.m_messaging.SendMessage(loginOk);
                this.m_connection.m_messaging.SendMessage(OHD);
                loginOk.Destruct();
            }
            else
            {
                LoginFailedMessage loginFailed = new LoginFailedMessage(0);
                loginFailed.SetErrorCode(LoginFailedMessage.ErrorCode.CLIENT_VERSION);
                this.m_connection.m_messaging.SendMessage(loginFailed);
                loginFailed.Destruct();
            }
        }

        private void ClientHelloReceived(PiranhaMessage message)
        {
            LoginFailedMessage loginFailed = new LoginFailedMessage(0);
            loginFailed.SetErrorCode(LoginFailedMessage.ErrorCode.CLIENT_VERSION);
            this.m_connection.m_messaging.SendMessage(loginFailed);
            loginFailed.Destruct();
        }

        private enum State
        {
            Disconnected,
            Login,
            Logged,
            Home,
            Matchmaking,
            Battle
        }
    }
}
