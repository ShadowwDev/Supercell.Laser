namespace Supercell.Laser.Logic.Helper
{
    using Supercell.Laser.Titan.Debug;
    using Supercell.Laser.Titan.Json;
    using Supercell.Laser.Titan.Math;
    using Supercell.Laser.Titan.Util;

    public static class LogicJSONHelper
    {
        public static bool GetBool(LogicJSONObject jsonObject, string key)
        {
            LogicJSONBoolean jsonBoolean = jsonObject.GetJSONBoolean(key);

            if (jsonBoolean != null)
            {
                return jsonBoolean.IsTrue();
            }

            return false;
        }

        public static LogicLong GetLogicLong(LogicJSONObject jsonObject, string key)
        {
            return new LogicLong(LogicJSONHelper.GetInt(jsonObject, key + "_hi"), LogicJSONHelper.GetInt(jsonObject, key + "_lo"));
        }

        public static void SetInt(LogicJSONObject jsonObject, string key, int value)
        {
            jsonObject.Put(key, new LogicJSONNumber(value));
        }

        public static void SetString(LogicJSONObject jsonObject, string key, string value)
        {
            jsonObject.Put(key, new LogicJSONString(value));
        }

        public static void SetBool(LogicJSONObject jsonObject, string key, bool value)
        {
            jsonObject.Put(key, new LogicJSONBoolean(value));
        }

        public static void SetLogicLong(LogicJSONObject jsonObject, string key, LogicLong value)
        {
            if (value != null)
            {
                LogicJSONHelper.SetInt(jsonObject, key + "_hi", value.GetHigherInt());
                LogicJSONHelper.SetInt(jsonObject, key + "_lo", value.GetLowerInt());
            }
        }

        public static int GetInt(LogicJSONObject jsonObject, string key)
        {
            return LogicJSONHelper.GetInt(jsonObject, key, -1, true);
        }

        public static int GetInt(LogicJSONObject jsonObject, string key, int defaultValue)
        {
            return LogicJSONHelper.GetInt(jsonObject, key, defaultValue, false);
        }

        public static int GetInt(LogicJSONObject jsonObject, string key, int defaultValue, bool throwIfNotExist)
        {
            if (jsonObject != null)
            {
                if (key.Length != 0)
                {
                    LogicJSONNumber number = jsonObject.GetJSONNumber(key);

                    if (number != null)
                    {
                        return number.GetIntValue();
                    }

                    if (!throwIfNotExist)
                    {
                        return defaultValue;
                    }

                    Debugger.Error(string.Format("Json number with key='{0}' not found!", key));
                }
            }

            return -1;
        }

        public static string GetString(LogicJSONObject jsonObject, string key)
        {
            return LogicJSONHelper.GetString(jsonObject, key, string.Empty, true);
        }

        public static string GetString(LogicJSONObject jsonObject, string key, string defaultValue, bool throwIfNotExist)
        {
            if (jsonObject != null)
            {
                if (key.Length != 0)
                {
                    LogicJSONString stringValue = jsonObject.GetJSONString(key);

                    if (stringValue != null)
                    {
                        return stringValue.GetStringValue();
                    }

                    if (!throwIfNotExist)
                    {
                        return defaultValue;
                    }

                    Debugger.Error(string.Format("Json string with key='{0}' not found!", key));
                }
            }

            return null;
        }
    }
}
