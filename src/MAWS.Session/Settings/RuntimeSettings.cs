using NTST.ScriptLinkService.Objects;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MAWS.Session.Settings
{
    public class RuntimeSettings
    {

        public static Dictionary<string, string> Load(OptionObject2015 sentOptObj, string sentMawsRequest)
        {
            var runtimeSettings = new Dictionary<string, string>()
            {
                { "dateStamp", DateTime.Now.ToString("yyMMdd") },
                { "timeStamp", DateTime.Now.ToString($"HHmmss.fffffff") },
            };

            if (string.IsNullOrWhiteSpace)
            {

            }



            mawsSession["AvatarUserName"] = "";



            var userName = sentOptObj.OptionUserId;
            File.WriteAllText($@"C:\MAWS\temp_prod\{dateStamp}-{timeStamp}_p.{userName}", "temp_prod");

            var avatarUserName = sentOptObj.OptionUserId;

            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name.ToLower();
            LogEvent.Trace(sentOptObj.OptionUserId, assemblyName);

            Dictionary<string, string> settingsFileContents = Configuration.SettingsFile.Build(sentOptObj.OptionUserId);
            Dictionary<string, string> mawsRequest = SyntaxEngine.MawsRequest.GetDic(sentOptObj.OptionUserId, sentMawsRequest);
        }
    }
}
