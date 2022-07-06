// ============================================================================================
// MAWS: MyAvatar Web Service
// A custom web service for Netsmart's myAvatar™ EHR.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================

// MAWS.Configuration.SettingsFile.cs
// Logic for MAWS configuration files.
// b220624.115605
// https://github.com/spectrum-health-systems/MAWS/blob/main/Documentation/Sourcecode/MAWS-Sourcecode.md

using MAWS.Logging;
using System.Collections.Generic;
using System.Reflection;

namespace MAWS.Configuration
{
    public class SettingsFile
    {
        /// <summary></summary>
        /// <param name="avatarUserName"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Build(string avatarUserName)
        {
            // TODO These are in Settings.settings, but we need to confirm that making changes to the local config file
            // override these.
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name.ToLower();
            LogEvent.Trace(avatarUserName, assemblyName);

            return new Dictionary<string, string>()
            {
                { "MawsMode", Properties.Settings.Default.MawsMode },
                { "LogMode",  Properties.Settings.Default.LogMode},
                { "MawsRootDir", Properties.Settings.Default.MawsRootDir },
                { "FallbackAvatarUserName", Properties.Settings.Default.FallbackAvatarUserName }
            };
        }
    }
}

// TODO Rename Build(), since it's too generic.
// Also, it is "settings" or "configuration"?