using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace sa3_c3a_groupE
{
    class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
        }
    }
}
