using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Subtitle.Read;
using Subtitle.Parse.SAMI;
using System.IO;
using Subtitle_Parser.Subtitle.Parse.SAMI;
using System.Linq;

namespace Subtitle.Parse.SAMI
{
    public class SAMI : ReadFile, IParse
    {
        public SAMI(string path)
        {
            string extension = SimpleExtension(Path.GetExtension(path));

            if (IsSAMI(path))
                SetPath(path);
            else
                throw new FileLoadException(
                    $"The {extension.ToUpper()} extension does not match the SAMI format."
                );

            bool IsSAMI(string path)
            {
                if (Token.extension.Contains(extension.ToLower()))
                    return true;
                else
                    return false;
            }

            string SimpleExtension(string path) => path.Replace(".", string.Empty);
        }

        public string GetSubtitle()
        {
            return subtitleContent;
        }

        public string GetComment(int time)
        {
            throw new NotImplementedException();
        }

        public List<string> GetCommentList
        {
            get{
                return SyncBlock(GetSubtitle());
            }
        }

        public void SetPath(string path)
        {
            FilePath(path);
        }

        private List<string> SyncBlock(string content)
        {
            List<string> script = new List<string>();

            Regex regex = new Regex(
                @"<sync start=(?<sync>\d*)>\n*<p class=\w*>\n*(?<comment>.*)",
                RegexOptions.Multiline |
                RegexOptions.IgnoreCase);

            MatchCollection matches = regex.Matches(content);

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                string sync = Token.sync;
                string comment = Token.comment;

                script.Add(
                    $"{ sync }:{ groups[sync] },{ comment }:{ groups[comment] }");
            }

            return script;
        }
    }
}
