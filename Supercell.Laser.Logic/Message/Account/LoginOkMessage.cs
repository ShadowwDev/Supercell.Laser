namespace Supercell.Laser.Logic.Message.Account
{
    using Supercell.Laser.Logic;
    using Supercell.Laser.Titan.Message;
    using Supercell.Laser.Titan.Math;

    public class LoginOkMessage : PiranhaMessage
    {
        public const int MESSAGE_TYPE = 20104;

        private LogicLong m_accountId;
        private LogicLong m_homeId;

        private string m_passToken;
        private string m_facebookId;
        private string m_gamecenterId;
        private int m_majorVersion;
        private int m_buildVersion;
        private int m_contentVersion;
        private string m_serverEnvironment;
        private int m_sessionCount;
        private int m_playTimeSeconds;
        private int m_daysSinceStartedPlaying;
        private string m_facebookAppId;
        private string m_serverTime;
        private string m_accountCreatedDate;
        public LoginOkMessage(short version) : base(version)
        {

        }
        public override void Encode()
        {
            base.Encode();

            this.m_stream.WriteLong(this.m_accountId);
            this.m_stream.WriteLong(this.m_homeId);
            this.m_stream.WriteString(this.m_passToken);
            this.m_stream.WriteString(this.m_facebookId);
            this.m_stream.WriteString(this.m_gamecenterId);
            this.m_stream.WriteInt(LogicVersion.MAJOR_VERSION);
            this.m_stream.WriteInt(LogicVersion.BUILD_VERSION);
            this.m_stream.WriteInt(this.m_contentVersion);
            this.m_stream.WriteString(this.m_serverEnvironment);
            this.m_stream.WriteInt(this.m_sessionCount);
            this.m_stream.WriteInt(this.m_playTimeSeconds);
            this.m_stream.WriteInt(this.m_daysSinceStartedPlaying);
            this.m_stream.WriteString(this.m_facebookAppId);
            this.m_stream.WriteString(this.m_serverTime);
            this.m_stream.WriteString(this.m_accountCreatedDate);
        }
        public override void Decode()
        {
            base.Decode();

            this.m_accountId = this.m_stream.ReadLong();
            this.m_homeId = this.m_stream.ReadLong();
            this.m_passToken = this.m_stream.ReadString(900000);
            this.m_facebookId = this.m_stream.ReadString(900000);
            this.m_gamecenterId = this.m_stream.ReadString(900000);
            this.m_majorVersion = this.m_stream.ReadInt();
            this.m_buildVersion = this.m_stream.ReadInt();
            this.m_contentVersion = this.m_stream.ReadInt();
            this.m_serverEnvironment = this.m_stream.ReadString(900000);
            this.m_sessionCount = this.m_stream.ReadInt();
            this.m_playTimeSeconds = this.m_stream.ReadInt();
            this.m_daysSinceStartedPlaying = this.m_stream.ReadInt();
            this.m_facebookAppId = this.m_stream.ReadString(900000);
            this.m_serverTime = this.m_stream.ReadString(900000);
            this.m_accountCreatedDate = this.m_stream.ReadString(900000);
        }
        public override short GetMessageType()
        {
            return LoginOkMessage.MESSAGE_TYPE;
        }

        public override int GetServiceNodeType()
        {
            return 1;
        }

        public override void Destruct()
        {
            base.Destruct();

            this.m_passToken = null;
            this.m_facebookId = null;
            this.m_gamecenterId = null;
            this.m_serverEnvironment = null;
            this.m_facebookAppId = null;
            this.m_serverTime = null;
            this.m_accountCreatedDate = null;
        }
        public LogicLong GetAccountId()
        {
            return this.m_accountId;
        }

        public void SetAccountId(LogicLong value)
        {
            this.m_accountId = value;
        }

        public LogicLong GetHomeId()
        {
            return this.m_homeId;
        }

        public void SetHomeId(LogicLong value)
        {
            this.m_homeId = value;
        }

        public string GetPassToken()
        {
            return this.m_passToken;
        }

        public void SetPassToken(string value)
        {
            this.m_passToken = value;
        }

        public string GetFacebookId()
        {
            return this.m_facebookId;
        }

        public void SetFacebookId(string value)
        {
            this.m_facebookId = value;
        }

        public string GetGamecenterId()
        {
            return this.m_gamecenterId;
        }

        public void SetGamecenterId(string value)
        {
            this.m_gamecenterId = value;
        }

        public string GetServerEnvironment()
        {
            return this.m_serverEnvironment;
        }

        public void SetServerEnvironment(string value)
        {
            this.m_serverEnvironment = value;
        }

        public string GetFacebookAppId()
        {
            return this.m_facebookAppId;
        }

        public void SetFacebookAppId(string value)
        {
            this.m_facebookAppId = value;
        }

        public string GetServerTime()
        {
            return this.m_serverTime;
        }

        public void SetServerTime(string value)
        {
            this.m_serverTime = value;
        }

        public string GetAccountCreatedDate()
        {
            return this.m_accountCreatedDate;
        }

        public void SetAccountCreatedDate(string value)
        {
            this.m_accountCreatedDate = value;
        }

        public int GetContentVersion()
        {
            return this.m_contentVersion;
        }

        public void SetContentVersion(int value)
        {
            this.m_contentVersion = value;
        }

        public int GetSessionCount()
        {
            return this.m_sessionCount;
        }

        public void SetSessionCount(int value)
        {
            this.m_sessionCount = value;
        }

        public int GetPlayTimeSeconds()
        {
            return this.m_playTimeSeconds;
        }

        public void SetPlayTimeSeconds(int value)
        {
            this.m_playTimeSeconds = value;
        }

        public int GetDaysSinceStartedPlaying()
        {
            return this.m_daysSinceStartedPlaying;
        }

        public void SetDaysSinceStartedPlaying(int value)
        {
            this.m_daysSinceStartedPlaying = value;
        }
    }
}
