// =========================================[ PROJECT ]=========================================
// MAWS: MyAvatar Web Service
// A custom web service for Netsmart's myAvatar™ EHR.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================================

// -----------------------------------------[ CLASS ]-------------------------------------------
// MAWS.Logging.Breadcrumb.cs
// Logic for creating breadcrumb/tracing logs.
// b220706.095050
// https://github.com/spectrum-health-systems/MAWS/blob/main/Documentation/Sourcecode/MAWS-Sourcecode.md
// -----------------------------------------[ CLASS ]-------------------------------------------

using System.Runtime.CompilerServices;

namespace MAWS.Logging
{
    public class Breadcrumb
    {
        /// <summary>Create a basic TRACE log.</summary>
        public static void WriteCrumb(string assemblyName, string avatarUserName, string logMessage = "No log message.", [CallerFilePath] string callerFilePath = "",
                                 [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLine = 0)
        {
            ToFile("trace", assemblyName, avatarUserName, logMessage, callerFilePath, callerMemberName, callerLine);
        }
    }
}