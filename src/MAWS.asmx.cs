// PROJECT: MAWS (https://github.com/spectrum-health-systems/MAWS)
//    FILE: MAWS.MAWS.asmx.cs
// UPDATED: 4-18-2022-12:22 PM
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2020 A Pretty Cool Program All rights reserved

// Entry point for MAWS.
// b220201.103342



/* ====================
 * ABOUT MAWS
 * ====================
 * 
 * The MyAvatool Web Service (MAWS) is a custom web service for Netsmart's myAvatar EHR.
 * 
 * --------------------
 * READ THE MANUAL
 * --------------------
 *
 * To learn more MAWS, and how you can use it at your organization, please read the MAWS Manual:
 * 
 *      https://github.com/spectrum-health-systems/MAWS/blob/main/doc/man/manual.md
 *      
 * ---------------------
 * NOTES ABOUT THIS CODE
 * ---------------------
 * I've tried to make this sourcecode as human-readable as possible, but since other organizations may use MAWS I've
 * decided to heavily comment everything as well (sometimes even in places where it is very clear as to what the code
 * does. I know this goes against best practice, however since Netsmart doesn't do the best job of making everything
 * they do transparent, I want to make sure that my code is as clear as possible as to what it does, and how it's done.
 * 
 * You will find three types of comments in this sourcecode:
 *
 *  - /// XML comments used by Visual Studio
 *  - // Short comments intended to give additional information about a block of code.
 *  - / *...* / Narrative comments when sourcecode concepts need to be explained in more detail.
 * 
 * Please do not remove any of the sourcecode comments.
 */

using System.Reflection;
using System.Web.Services;
using NTST.ScriptLinkService.Objects;

namespace MAWS
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class MAWS : System.Web.Services.WebService
    {
        /// <summary>
        /// Returns the version of MAWS.
        /// </summary>
        /// <returns>The version of MAWS.</returns>
        /// <remarks>This method is required by myAvatar.</remarks>
        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 1.0";
        }

        /// <summary>
        /// Exectutes a MAWS Request.
        /// </summary>
        /// <param name="sentOptObj"> An OptionObject2015 sent from myAvatar.</param>
        /// <param name="mawsRequest">The MAWS request to be executed.</param>
        /// <returns>An OptionObject2015 with updated data.</returns>
        /// <remarks>This method is required by myAvatar.</remarks>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptObj, string sentMawsRequest)
        {
            /* This can be used to write a troublshooting log to a local, non web server machine.
             */
            LogEvent.Troubleshoot("maws-initialization");

            var mawsSession = Configuration.Session.Build(sentOptObj, sentMawsRequest);


            /* Get nice looking names for the assembly name and myAvatar username.
             */
            var assemblyName   = Assembly.GetExecutingAssembly().GetName().Name.ToLower();
            var avatarUserName = sentOptObj.OptionUserId;
            LogEvent.Trace(assemblyName, avatarUserName);

            /* Initialize a new, empty OptionObject that we work on throughout MAWS.
             */
            OptionObject2015 workOptObj = new OptionObject2015();
            LogEvent.OptObj(assemblyName, avatarUserName, workOptObj, "Initial workOptObj:");

            /* Depending on what mode MAWS is using, we will:
             * 
             *  -     enabled: Use MAWS normally. This is the defauly setting.
             *  -    disabled: Skip all MAWS functionality. Essentially MAWS will recieve the sentOptObj, then skip
             *                 directly to finalizing and returning the retOptObj, so no changes are made. This should
             *                 be used when you don't want myAvatar to call MAWS, but you don't want to disable scripts
             *                 on every form you use ScriptLink on. This way MAWS will still be called, it just won't do
             *                 anything, including writing logs (aside from basic, informational logs).
             *  - passthrough: Use MAWS, but don't make changes, only write logs. This is like the "disabled" setting,
             *                 since no modifications to the OptionObject are make, and also like the "enabled" setting,
             *                 since MAWS will actually go through the motions and write logs normally.
             */
            var mawsMode = Properties.Settings.Default.MawsMode.ToLower();




            //var mawsRequest = new Dictionary<string, string>
            //{
            //    { "mawsCommand", "" },
            //    { "mawsAction",  "" },
            //    { "mawsOptions", "" }
            //};


            switch(mawsMode)
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

            /* Finalize the workOptObj, and return it to Avatar.
             */
            OptionObject2015 returnOptObj = OptObj.Finalize(sentOptObj, workOptObj);

            return returnOptObj;
        }

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
