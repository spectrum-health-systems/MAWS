// MAWS - The myAvatool Web Service
// https://github.com/aprettycoolprogram/MAWS
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//
// 
// b220201.110604

using System.Collections.Generic;
using System.Reflection;
using NTST.ScriptLinkService.Objects;

namespace MAWS.Configuration
{
    public class Session
    {
        public static Dictionary<string, string> Build(OptionObject2015 sentOptObj, string sentMawsRequest)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name.ToLower();
            LogEvent.Trace(sentOptObj.OptionUserId, assemblyName);

            Dictionary<string, string> settingsFileContents = Configuration.SettingsFile.Build(sentOptObj.OptionUserId);
            Dictionary<string, string> mawsRequest = SyntaxEngine.MawsRequest.GetDic(sentOptObj.OptionUserId, sentMawsRequest);



            return new Dictionary<string, string>();
        }
    }

}
