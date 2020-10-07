using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace W2DApi.FW
{
    public enum ConfigurationTypes
    {
        ConnectionString,
        AppSetting
    }

    public class SettingsHelper
    {
        public T GetConfigurationValue<T>(string Key, ConfigurationTypes configType)
        {
            if (configType == ConfigurationTypes.ConnectionString)
            {
                return (T)(object)ConfigurationManager.ConnectionStrings[Key].ConnectionString;
            }
            else if (configType == ConfigurationTypes.AppSetting)
            {
                return (T)(object)ConfigurationManager.AppSettings[Key];
            }
            return (T)(object)string.Empty;
        }
    }
}
