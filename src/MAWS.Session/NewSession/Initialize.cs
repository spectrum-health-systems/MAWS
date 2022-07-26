using NTST.ScriptLinkService.Objects;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;

namespace MAWS.Session.NewSession
{
    public class Initialize
    {
        public static Dictionary<string, string> GetSettings(OptionObject2015 sentOptObj, string sentMawsRequest, NameValueCollection mawsExternalSettings)
        {
            //? This should return "MAWS"
            var assemblyName         = Assembly.GetEntryAssembly().GetName().Name.ToLower();
            var avatarUserName       = sentOptObj.OptionUserId;

            Dictionary<string, string> mawsSettings = MAWS.Session.Settings.Build.All(sentOptObj, sentMawsRequest, mawsExternalSettings);

            //todo LogEvent.Trace(assemblyName, avatarUserName);

            return mawsSettings;

        }



    }
}

