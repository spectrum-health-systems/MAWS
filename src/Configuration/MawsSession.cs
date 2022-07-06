// =========================================[ PROJECT ]=========================================
// MAWS: MyAvatar Web Service
// A custom web service for Netsmart's myAvatar™ EHR.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================================

// -----------------------------------------[ CLASS ]-------------------------------------------
// MAWS.Configuration.MawsSession.cs
// Logic for current MAWS session variables.
// b220706.085509
// https://github.com/spectrum-health-systems/MAWS/blob/main/Documentation/Sourcecode/MAWS-Sourcecode.md
// ---------------------------------------------------------------------------------------------


using MAWS.Logging;
using NTST.ScriptLinkService.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace MAWS.Configuration
{
    public class MawsSession
    {
        /// <summary>Build the settings for this MAWS session.</summary>
        /// <param name="sentOptObj">The OptionObject2015 sent from myAvatar.</param>
        /// <param name="sentMawsRequest">The MAWS request to be executed.</param>
        /// <returns>MAWS session configuration settings.</returns>
        public static Dictionary<string, string> BuildSessionSettings(OptionObject2015 sentOptObj, string sentMawsRequest)
        {
            var dateStamp = DateTime.Now.ToString("yyMMdd");
            var timeStamp = DateTime.Now.ToString($"HHmmss.fffffff");
            var userName = sentOptObj.OptionUserId;
            File.WriteAllText($@"C:\MAWS\temp_prod\{dateStamp}-{timeStamp}_p.{userName}", "temp_prod");

            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name.ToLower();
            LogEvent.Trace(sentOptObj.OptionUserId, assemblyName);

            Dictionary<string, string> settingsFileContents = Configuration.SettingsFile.Build(sentOptObj.OptionUserId);
            Dictionary<string, string> mawsRequest = SyntaxEngine.MawsRequest.GetDic(sentOptObj.OptionUserId, sentMawsRequest);

            return new Dictionary<string, string>();
        }
    }




}

// TODO Rename Build(), since it's too generic.
// Also, it is "settings" or "configuration"?