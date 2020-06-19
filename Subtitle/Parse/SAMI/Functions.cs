using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Subtitle.Parse.SAMI
{
    public static class Functions
    {

        public static string CommentRemove(this string content)
        {
            Regex regex = new Regex(@"<(!?)--(\n?)(.*?)(\n?)-->");

            return regex.Replace(content, "");
        }

        public static string LineRemove(this string content)
        {
            return content.Replace(Environment.NewLine, string.Empty);
        }

        internal static int GetSync(this string block)
        {
            return int.Parse(block.Split("sync:")[1].Split(",")[0]);
        }

        public static string GetContent(this string block)
        {
            return block.Split("content:")[1].Split(",")[0];
        }
    }
}