using NTST.ScriptLinkService.Objects;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace MAWS.Session.Settings
{
    public class Build
    {
        /// <summary>Build the settings for this MAWS session.</summary>
        /// <param name="sentOptObj">The OptionObject2015 sent from myAvatar.</param>
        /// <param name="sentMawsRequest">The MAWS request to be executed.</param>
        /// <returns>MAWS session configuration settings.</returns>
        public static Dictionary<string, string> All(OptionObject2015 sentOptObj, string sentMawsRequest, NameValueCollection mawsExternalSettings)
        {
            Dictionary<string, string> externalSettings = ExternalSettings.Load(mawsExternalSettings);
            Dictionary<string, string> runtimeSettings  = RuntimeSettings.Load(sentOptObj, sentMawsRequest);

            return new Dictionary<string, string>();
        }

    }
}
