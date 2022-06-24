// ============================================================================================
// MAWS: MyAvatar Web Service
// A custom web service for Netsmart's myAvatar™ EHR.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================

// MAWS.Data.Validate.cs
// Logic dealing with MAWS data.
// b220621.131338
// https://github.com/https://github.com/spectrum-health-systems/MAWS/tree/main/Documentation/Sourcecode/MAWS.Data.md

namespace MAWS
{
    public class Validate
    {
        /// <summary>Validate the Avatar username.</summary>
        /// <param name="avatarUserName">The value of sentOptObj.OptionUserId.</param>
        /// <returns>A valid username.</returns>
        public static string AvatarUserName(string avatarUserName)
        {
            return string.IsNullOrWhiteSpace(avatarUserName)
                ? Properties.Settings.Default.FallbackAvatarUserName
                : avatarUserName;
        }
    }
}