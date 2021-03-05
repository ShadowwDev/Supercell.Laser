namespace Supercell.Laser.Logic
{
    using System;
    using System.IO;
    using Supercell.Laser.Titan.Json;
    using Supercell.Laser.Titan.Debug;
    using Supercell.Laser.Logic.Helper;

    public class LogicConfiguration
    {
        private static LogicJSONObject m_json;
        private static string m_environment;
        private static string m_fingerprintSHA;
        private static string m_mongodbURL;

        public static LogicJSONObject GetJson()
        {
            return m_json;
        }
        public static void Load()
        {
            try
            {
                LogicConfiguration.Load(File.ReadAllText("configuration.json"));
            }
            catch
            {
                Debugger.Error("Server configuration = NULL!");
                Console.ReadLine();
                Environment.Exit(-1);
            }
        }
        public static void Load(string jsonObject)
        {
            m_json = LogicJSONParser.ParseObject(jsonObject);

            if (jsonObject != null)
            {
                m_environment = LogicJSONHelper.GetString(m_json, "environment");
                m_fingerprintSHA = LogicJSONHelper.GetString(m_json, "fingerprintSHA");
                m_mongodbURL = LogicJSONHelper.GetString(m_json, "mongodbURL");
            }
            else
            {
                Debugger.Error("Server configuration = NULL!");
            }
        }
        public static string GetEnviroment()
        {
            return m_environment;
        }
        public static string GetFingetprintSHA()
        {
            return m_fingerprintSHA;
        }
        public static string GetMongodbURL()
        {
            return m_mongodbURL;
        }
    }
}
