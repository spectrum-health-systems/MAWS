// ============================================================================================
// MAWS: MyAvatar Web Service
// A custom web service for Netsmart's myAvatar™ EHR.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================

// MAWS.Logging.MawsEvent.cs
// MAWS event logging
// b220621.131338
// https://github.com/https://github.com/spectrum-health-systems/MAWS/tree/main/Documentation/Sourcecode/MAWS.Logging.md

using NTST.ScriptLinkService.Objects;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace MAWS
{
    public class MawsEvent
    {
        public static void Startup()
        {

        }

        /// <summary>Only used for debugging.</summary>
        public static void Troubleshoot(string troubleshootTarget)
        {
            var logMessage = "";

            switch (troubleshootTarget)
            {
                case "maws-initialization":
                    logMessage = $"Settings.settings values:{Environment.NewLine}" +
                                 $"    MAWS mode: {Properties.Settings.Default.MawsMode}{Environment.NewLine}" +
                                 $"     Log mode: {Properties.Settings.Default.LogMode}{Environment.NewLine}" +
                                 $"    MAWS root: {Properties.Settings.Default.MawsRootDir}{Environment.NewLine}" +
                                 $"Fallback name: {Properties.Settings.Default.FallbackAvatarUserName}";
                    break;

                default:
                    break;
            }

            File.WriteAllText($@"C:\MAWS\Staging\Development\Devlogs\{troubleshootTarget}.troubleshoot", logMessage);
        }

        /// <summary>Create a basic TRACE log.</summary>
        public static void Trace(string assemblyName, string avatarUserName, string logMessage = "No log message.", [CallerFilePath] string callerFilePath = "",
                                 [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLine = 0)
        {
            ToFile("trace", assemblyName, avatarUserName, logMessage, callerFilePath, callerMemberName, callerLine);
        }

        /// <summary>Create a basic DEBUG log.</summary>
        public static void Debug(string assemblyName, string avatarUserName, string logMessage = "No log message.", [CallerFilePath] string callerFilePath = "",
                                 [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLine = 0)
        {
            ToFile("debug", assemblyName, avatarUserName, logMessage, callerFilePath, callerMemberName, callerLine);
        }

        /// <summary> Create a OPTOBJ log.</summary>
        public static void OptObj(string assemblyName, string avatarUserName, OptionObject2015 optObj, string logMessage = "No log message.",
                                  [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "",
                                  [CallerLineNumber] int callerLine = 0)
        {
            ToFile("optobj", assemblyName, avatarUserName, optObj, logMessage, callerFilePath, callerMemberName, callerLine);
        }

        /// <summary>Create a log for something that isn't for an OptionObject.</summary>
        public static void ToFile(string logType, string assemblyName, string avatarUserName, string logMessage, [CallerFilePath] string callerFilePath = "",
                                  [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLine = 0)
        {
            if (ConfirmShouldLogEvent(logType))
            {
                WriteToFile(logType, assemblyName, avatarUserName, logMessage, callerFilePath, callerMemberName, callerLine);
            }
        }

        /// <summary>Create a log for something for an OptionObject.</summary>
        public static void ToFile(string logType, string assemblyName, string avatarUserName, OptionObject2015 optObj, string logMessage,
                                  [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLine = 0)
        {
            if (ConfirmShouldLogEvent(logType))
            {
                WriteToFile(logType, assemblyName, avatarUserName, optObj, logMessage, callerFilePath, callerMemberName, callerLine);
            }
        }

        /// <summary>Confirm that a specific type of log should be written.</summary>
        private static bool ConfirmShouldLogEvent(string logType)
        {
            var logMode = Properties.Settings.Default.LogMode.ToLower();

            return logMode == "all" || logMode.Contains(logType);
        }

        /// <summary>Create and write a non-OptionObject.</summary>
        private static void WriteToFile(string logType, string assemblyName, string avatarUserName, string logMessage, string callerFilePath,
                                        string callerMemberName, int callerLine)
        {
            var logfilePath = Utilities.Build.LogfilePath(logType, assemblyName, avatarUserName, callerFilePath, callerLine);
            var logfileContent = Utilities.Build.LogfileContent(assemblyName, logMessage, callerFilePath, callerMemberName, callerLine);

            File.WriteAllText(logfilePath, logfileContent);
        }

        /// <summary>Create and write an OptionObject2015 logfile.</summary>
        private static void WriteToFile(string logType, string assemblyName, string avatarUserName, OptionObject2015 optObj, string logMessage,
                                        string callerfilePath, string callerMemberName, int callerLine)
        {
            var logfilePath = Utilities.Build.LogfileName(logType, assemblyName, avatarUserName, callerfilePath, callerLine);
            var logfileContent = Utilities.Build.LogfileContents(assemblyName, logMessage, optObj, callerfilePath, callerMemberName, callerLine);

            File.WriteAllText(logfilePath, logfileContent);
        }
    }
}