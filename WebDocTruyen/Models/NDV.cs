using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDocTruyen.Models
{
    public class NDV
    {
        public static string InlineFile(string path)
        {
            return System.IO.File.ReadAllText(path);
        }
    }
}