// =========================================[ PROJECT ]=========================================
// MAWS: MyAvatar Web Service
// A custom web service for Netsmart's myAvatar™ EHR.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================================

// -----------------------------------------[ CLASS ]-------------------------------------------
// MAWS.asmx.cs
// Entry point for MAWS.
// b220706.075759
// https://github.com/https://github.com/spectrum-health-systems/MAWS/tree/main/Documentation/Sourcecode/MAWS.asmx.cs.md
// ---------------------------------------------------------------------------------------------

// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-[ ABOUT MAWS ]-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// https://github.com/spectrum-health-systems/MAWS
// Version 1.99.0.0
// Build: 220706.075938+devbuild
//
// The MyAvatool Web Service (MAWS) is a custom web service which includes various tools and
// utilities for myAvatar™ that aren't included in the official release, and provides a solid
// foundation for building additional functionality quickly and efficiently.
//
// DOCUMENTATION
// -------------
// Manual: https://github.com/spectrum-health-systems/MAWS/blob/main/Documents/Manual/MAWS-manual.md
// Sourcecode: https://github.com/spectrum-health-systems/MAWS/blob/main/Documents/Sourcecode/MAWS-sourcecode.md
// README: https://github.com/spectrum-health-systems/MAWS#readme
// Changelog: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documents/Changelog.md
// Roadmap: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documents/Roadmap.md
// Known issues: https://github.com/spectrum-health-systems/MAWSC/blob/Documents/Known%20issues.md
//
// For more myAvatar™ related development, please visit the myAvatar™ Development Community:
// https://github.com/myAvatar-Development-Community
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

using NTST.ScriptLinkService.Objects;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Services;

namespace MAWS
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class MAWS : System.Web.Services.WebService
    {
        /// <summary>Returns the version of MAWS.</summary>
        /// <returns>MAWS version.</returns>
        [WebMethod]
        public string GetVersion()
        {
            LogEvent.DataDump();
            return "VERSION 2.0";
        }

        /// <summary>Executes a MAWS Request.</summary>
        /// <param name="sentOptObj">The OptionObject2015 sent from myAvatar.</param
        /// <param name="mawsRequest">The MAWS request to be executed.</param>
        /// <returns>OptionObject2015 with updated data.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptObj, string sentMawsRequest)
        {
            // ! Uncomment the following line to enable troubleshooting logs - DO NOT USE IN PRODUCTION.
            //LogEvent.DataDump("maws-initialization");
            // TODO Should prob make this C:\AppData\Devlogs\"
            // TODO Maybe gracefully exit after logging?

            Dictionary<string, string> mawsSession = Configuration.MawsSession.BuildSessionSettings(sentOptObj, sentMawsRequest);

            var assemblyName   = Assembly.GetExecutingAssembly().GetName().Name.ToLower();
            var avatarUserName = sentOptObj.OptionUserId;
            LogEvent.Trace(assemblyName, avatarUserName);

            var workOptObj = new OptionObject2015();
            LogEvent.OptObj(assemblyName, avatarUserName, workOptObj, "Initial workOptObj:");

            var mawsMode = Properties.Settings.Default.MawsMode.ToLower();

            switch (mawsMode)
            {
                case "enabled":
                    LogEvent.Trace(assemblyName, avatarUserName);
                    // Point to Roundhouse.cs
                    break;

                case "disabled":
                    LogEvent.Trace(assemblyName, avatarUserName);
                    // Don't do anything, just return the data from sentOptObj.
                    break;

                case "passthrough":
                    LogEvent.Trace(assemblyName, avatarUserName);
                    // Just log things, don't make any changes to the data.
                    break;

                default:
                    break;
            }

            LogEvent.Trace(assemblyName, avatarUserName);

            OptionObject2015 returnOptObj = global::MAWS.Finalize.FinalizeIt(sentOptObj, workOptObj);

            return returnOptObj;
        }

        //
        // DEPRECIATED
        //
        /// <summary>
        ///
        /// </summary>
        ////private static void Troubleshooter(string logWhat)
        ////{
        ////    var logMessage = "";
        ////    logWhat = logWhat.ToLower();

        ////    if(logWhat == "initial-settings")
        ////    {
        ////        logMessage += $"Settings.settings values:{Environment.NewLine}" +
        ////                      $"    MAWS mode: {Properties.Settings.Default.MawsMode}{Environment.NewLine}" +
        ////                      $"     Log mode: {Properties.Settings.Default.LogMode}{Environment.NewLine}" +
        ////                      $"    MAWS root: {Properties.Settings.Default.MawsRootDir}{Environment.NewLine}" +
        ////                      $"Fallback name: {Properties.Settings.Default.FallbackAvatarUserName}";
        ////    }

        ////    if(logWhat == "tbd")
        ////    {
        ////        logMessage += $"TBD values:{Environment.NewLine}" +
        ////                      $"   TBD1: {Properties.Settings.Default.MawsMode}{Environment.NewLine}" +
        ////                      $"   TBD2: {Properties.Settings.Default.LogMode}{Environment.NewLine}";
        ////    }

        ////    File.WriteAllText($@"C:\MAWS\Staging\Development\Devlogs\{logWhat}.log", logMessage);
        ////}
    }
}