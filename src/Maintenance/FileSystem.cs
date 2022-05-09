﻿// PROJECT: MAWS (https://github.com/spectrum-health-systems/MAWS)
//    FILE: MAWS.Maintenance.FileSystem.cs
// UPDATED: 5-09-2022
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

// File system logic.
// v0.99.0.0-b220509.083011

using System.IO;

namespace MAWS
{
    public class FileSystem
    {
        /// <summary>
        /// 
        /// </summary>
        public static void VerifyDirectoryExists(string directoryPath)
        {
            if(!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}