// ============================================================================================
// MAWS: MyAvatar Web Service
// A custom web service for Netsmart's myAvatar™ EHR.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================

// MAWS.Configuration.MawsSession.cs
// MAWS configuration settings logic.
// b220621.131338
// https://github.com/https://github.com/spectrum-health-systems/MAWS/tree/main/Documentation/Sourcecode/MAWS.Configuration.md

using NTST.ScriptLinkService.Objects;
using System.Collections.Generic;
using System.Reflection;

namespace MAWS.Configuration
{
    public class MawsSession
    {
        /// <summary>Get the MAWS session information.</summary>
        /// <param name="sentOptObj">The OptionObject2015 sent from myAvatar.</param>
        /// <param name="sentMawsRequest">The MAWS request to be executed.</param>
        /// <returns>MAWS session configuration settings.</returns>
        public static Dictionary<string, string> Build(OptionObject2015 sentOptObj, string sentMawsRequest)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name.ToLower();
            MawsEvent.Trace(sentOptObj.OptionUserId, assemblyName);

            Dictionary<string, string> settingsFileContents = Configuration.SettingsFile.Build(sentOptObj.OptionUserId);
            Dictionary<string, string> mawsRequest = SyntaxEngine.MawsRequest.GetDic(sentOptObj.OptionUserId, sentMawsRequest);

            return new Dictionary<string, string>();
        }
    }
}