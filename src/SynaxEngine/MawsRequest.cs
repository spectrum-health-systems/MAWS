// MAWS - The myAvatool Web Service
// https://github.com/aprettycoolprogram/MAWS
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//
// v0.70.0.0-b220201.123035
//
// Code description goes here.
// b220201.123035

using System.Collections.Generic;
using System.Reflection;

namespace MAWS.SyntaxEngine
{
    public class MawsRequest
    {
        public static Dictionary<string, string> GetDic(string avatarUserName, string mawsRequest)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name.ToLower();
            LogEvent.Trace(avatarUserName, assemblyName);

            var mawsRequestComponent = mawsRequest.Split('-');

            return new Dictionary<string, string>()
            {
                { "MawsCommand", mawsRequestComponent[0].ToLower() },
                { "MawsAction",  mawsRequestComponent[1].ToLower() },
                { "MawsOptions", mawsRequestComponent[2].ToLower() }
            };
        }
    }
}