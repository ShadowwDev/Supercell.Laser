namespace Supercell.Laser.Logic.Message.Account
{
    using Supercell.Laser.Titan.Message;

    public class LoginFailedMessage : PiranhaMessage
    {
        public const int MESSAGE_TYPE = 20103;

        private ErrorCode m_errorCode;
        private string m_resourceFingerprintContent;
        private string m_redirectDomain;
        private string m_contentUrl;
        private string m_updateUrl;
        private string m_reason;
        private int m_endMaintenanceTime;
        public LoginFailedMessage(short version) : base(version)
        {
        }

        public override void Encode()
        {
            base.Encode();

            this.m_stream.WriteInt((int) this.m_errorCode);
            this.m_stream.WriteString(this.m_resourceFingerprintContent); //Fingerprint
            this.m_stream.WriteString(this.m_redirectDomain);
            this.m_stream.WriteString(this.m_contentUrl);
            this.m_stream.WriteString(this.m_updateUrl);
            this.m_stream.WriteString(this.m_reason);
            this.m_stream.WriteInt(this.m_endMaintenanceTime);
            this.m_stream.WriteBoolean(false);
            this.m_stream.WriteInt(0);
            this.m_stream.WriteBytes(null, 0);
            this.m_stream.WriteInt(0);
        }

        public override void Decode()
        {
            base.Decode();

            this.m_errorCode = (ErrorCode) this.m_stream.ReadInt();
            this.m_resourceFingerprintContent = this.m_stream.ReadString(900000);
            this.m_redirectDomain = this.m_stream.ReadString(900000);
            this.m_contentUrl = this.m_stream.ReadString(900000);
            this.m_updateUrl = this.m_stream.ReadString(900000);
            this.m_reason = this.m_stream.ReadString(900000);
            this.m_endMaintenanceTime = this.m_stream.ReadInt();
        }

        public override short GetMessageType()
        {
            return LoginFailedMessage.MESSAGE_TYPE;
        }

        public override int GetServiceNodeType()
        {
            return 1;
        }

        public override void Destruct()
        {
            base.Destruct();

            this.m_resourceFingerprintContent = null;
            this.m_redirectDomain = null;
            this.m_reason = null;
            this.m_updateUrl = null;
            this.m_contentUrl = null;
        }

        public ErrorCode GetErrorCode()
        {
            return this.m_errorCode;
        }

        public void SetErrorCode(ErrorCode value)
        {
            this.m_errorCode = value;
        }

        public int GetEndMaintenanceTime()
        {
            return this.m_endMaintenanceTime;
        }

        public void SetEndMaintenanceTime(int value)
        {
            this.m_endMaintenanceTime = value;
        }

        public string GetResourceFingerprintContent()
        {
            return this.m_resourceFingerprintContent;
        }

        public void SetResourceFingerprintContent(string value)
        {
            this.m_resourceFingerprintContent = value;
        }

        public string GetRedirectDomain()
        {
            return this.m_redirectDomain;
        }

        public void SetRedirectDomain(string value)
        {
            this.m_redirectDomain = value;
        }

        public string GetReason()
        {
            return this.m_reason;
        }

        public void SetReason(string value)
        {
            this.m_reason = value;
        }

        public string GetUpdateUrl()
        {
            return this.m_updateUrl;
        }

        public void SetUpdateUrl(string value)
        {
            this.m_updateUrl = value;
        }

        public string GetContentUrl()
        {
            return this.m_contentUrl;
        }

        public void SetContentUrl(string value)
        {
            this.m_contentUrl = value;
        }

        public enum ErrorCode
        {
            ACCOUNT_NOT_EXISTS = 1,
            DATA_VERSION = 7,
            CLIENT_VERSION = 8,
            REDIRECTION = 9,
            SERVER_MAINTENANCE = 10,
            BANNED = 11,
            PERSONAL_BREAK = 12,
            ACCOUNT_LOCKED = 13,
            WRONG_STORE = 15,
            VERSION_NOT_UP_TO_DATE_STORE_NOT_READY = 16,
            CHINESE_APP_STORE_CONFLICT_MESSAGE = 18,
        }
    }
}
