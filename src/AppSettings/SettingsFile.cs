// ============================================================================================
// MAWS: MyAvatar Web Service
// A custom web service for Netsmart's myAvatar™ EHR.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================

// MAWS.Configuration.SettingsFile.cs
// Logic for MAWS configuration files.
// b220714.092123
// https://github.com/spectrum-health-systems/MAWS/blob/main/Documentation/Sourcecode/MAWS-Sourcecode.md

using System.Collections.Generic;

namespace MAWS.AppSettings
{
    public class LocalFile
    {
        /// <summary>Load the configuration settings from the local configuration file.</summary>
        /// <returns></returns>
        public static Dictionary<string, string> LoadLocalSettings()
        {
            return new Dictionary<string, string>()
            {
                { "MawsMode", Properties.Settings.Default.MawsMode },
                { "LogMode",  Properties.Settings.Default.LoggingMode},
                { "MawsRootDir", Properties.Settings.Default.MawsRootDir },
                { "FallbackAvatarUserName", Properties.Settings.Default.FallbackAvatarUserName }
            };
        }
    }
}