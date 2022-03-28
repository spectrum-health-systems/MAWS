// MAWS - The myAvatool Web Service
// https://github.com/aprettycoolprogram/MAWS
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//
// 
// b220201.110604

using System.Collections.Generic;
using System.Reflection;

namespace MAWS.Configuration
{
    public class SettingsFile
    {
        public static Dictionary<string, string> Build(string avatarUserName)
        {
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