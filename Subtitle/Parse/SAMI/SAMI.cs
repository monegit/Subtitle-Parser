using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Subtitle.Read;
using Subtitle_Parser.Subtitle.Parse.SAMI;

namespace Subtitle.Parse.SAMI
{
    public class SAMI : ReadFile, IParse
    {
        public string GetContent()
        {
            return subtitleContent;
        }

        public string GetScript(int time)
        {
            throw new NotImplementedException();
        }

        public List<string> GetScriptList()
        {
            return SyncBlock(
                GetContent()
            );
        }

        public void SetPath(string path)
        {
            FilePath(path);
        }

        private List<string> SyncBlock(string content)
        {
            var script = new List<string>();

            Regex regex = new Regex(@"<sync start=(?<sync>\d*)>\n*<p class=\w*>\n*(?<content>.*)",//@"[^<sync start=]+\d[^>]",
                RegexOptions.Multiline |
                RegexOptions.IgnoreCase);

            MatchCollection matches = regex.Matches(content);

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                script.Add(string.Format("sync: {0}, content: {1}", groups["sync"], groups["content"]));
            }

            return script;
        }
    }
}