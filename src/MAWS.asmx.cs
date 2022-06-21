// ============================================================================== [ v1.99.0.0 ]
// MAWS: MyAvatar Web Service
// A custom web service for Netsmart's myAvatar™ EHR.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ================================================================= [ 220621.131252-devbuild ]

// MAWS.asmx.cs
// Entry point for MAWS.
// b220621.131246
// https://github.com/https://github.com/spectrum-health-systems/MAWS/tree/main/Documentation/Sourcecode/MAWS.asmx.cs.md

/* ABOUT MAWS
 * --------------------------------------------------------------------------------------------
 * The MyAvatool Web Service (MAWS) is a custom web service which includes various tools and
 * utilities for myAvatar™ that aren't included in the official release, and provides a solid
 * foundation for building additional functionality quickly and efficiently.
 *
 * To learn more about MAWS, and how you can use it at your organization, read the MAWS Manual!
 * 
 *      https://github.com/spectrum-health-systems/MAWS/blob/main/Documents/Manual/MAWS-manual.md
 *
 * For detailed information about this sourcecode, please see:
 * 
 *      https://github.com/spectrum-health-systems/MAWS/blob/main/Documents/Sourcecode/MAWS-sourcecode.md
 *
 *
 * README: https://github.com/spectrum-health-systems/MAWS#readme
 * Changelog: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documents/Changelog.md
 * Roadmap: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documents/Roadmap.md
 * Known issues: https://github.com/spectrum-health-systems/MAWSC/blob/Documents/Known%20issues.md
 *
 * For more myAvatar™ related development, please visit the myAvatar™ Development Community:
 *  https://github.com/myAvatar-Development-Community
 */

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
            return "VERSION 2.0";
        }

        /// <summary>Exectutes a MAWS Request.</summary>
        /// <param name="sentOptObj"> An OptionObject2015 sent from myAvatar.</param>
        /// <param name="mawsRequest">The MAWS request to be executed.</param>
        /// <returns>OptionObject2015 with updated data.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptObj, string sentMawsRequest)
        {
            /* Enable this line to write a troubleshooting log to "C:\MAWS\Staging\Development\Devlogs\"
             */
            //LogEvent.Troubleshoot("maws-initialization"); // TODO Should prob make this C:\MAWS\Devlogs\"

            // WTF is this?
            Dictionary<string, string> mawsSession = Configuration.MawsSession.Build(sentOptObj, sentMawsRequest);

            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name.ToLower();
            var avatarUserName = sentOptObj.OptionUserId;
            MawsEvent.Trace(assemblyName, avatarUserName);

            var workOptObj = new OptionObject2015();
            MawsEvent.OptObj(assemblyName, avatarUserName, workOptObj, "Initial workOptObj:");

            var mawsMode = Properties.Settings.Default.MawsMode.ToLower();

            switch (mawsMode)
            {
                case "enabled":
                    MawsEvent.Trace(assemblyName, avatarUserName);
                    // Point to Roundhouse.cs
                    break;

                case "disabled":
                    MawsEvent.Trace(assemblyName, avatarUserName);
                    // Don't do anything, just return the data from sentOptObj.
                    break;

                case "passthrough":
                    MawsEvent.Trace(assemblyName, avatarUserName);
                    // Just log things, don't make any changes to the data.
                    break;

                default:
                    break;
            }

            MawsEvent.Trace(assemblyName, avatarUserName);

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