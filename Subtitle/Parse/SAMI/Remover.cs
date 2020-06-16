using System;
using System.Text.RegularExpressions;

namespace Subtitle_Parser.Subtitle.Parse.SAMI
{
    public static class Remover
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
    }
}