using System.Collections.Generic;
using System.Collections.Specialized;

namespace MAWS.Session.Settings
{
    public class ExternalSettings
    {
        // These settings are static in the local configuration file.
        public string MawsMode { get; set; }
        public string LoggingMode { get; set; }
        public string MawsRootDir { get; set; }
        public string FallbackAvatarUserName { get; set; }


        /// <summary>
        /// Load the configuration settings from the local Web.config file.
        /// </summary>
        /// <returns>A dictionary with the configuration values.</returns>
        public static Dictionary<string, string> Load(NameValueCollection mawsExternalSettings)
        {
            var externalSettings = new Dictionary<string, string>();

            foreach (var key in mawsExternalSettings.AllKeys)
            {
                externalSettings.Add(key, mawsExternalSettings[key]);
            }

            return externalSettings;
        }
    }
}