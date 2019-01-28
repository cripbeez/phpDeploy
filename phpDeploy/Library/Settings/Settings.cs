using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace phpDeploy.Library.Settings
{
    public class Settings
    {

        public Settings()
        {

        }

        public string this[string key]
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings[key] ?? null;
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                try
                {
                    Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    KeyValueConfigurationCollection settings = appConfig.AppSettings.Settings;

                    if (settings[key] == null)
                    {
                        settings.Add(key, value);
                    }
                    else
                    {
                        settings[key].Value = value;
                    }

                    appConfig.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(appConfig.AppSettings.SectionInformation.Name);
                }
                catch { }
            }
        }
        public bool Exists(string key)
        {
            return (this[key] == null);
        }

    }
}
