using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Subtitle.Read;

namespace Subtitle.Parse
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
            return SyncBlock(GetContent());
        }

        public void SetPath(string path)
        {
            FilePath(path);
        }

        private List<string> SyncBlock(string content)
        {
            var script = new List<string>();

            Regex regex = new Regex(@"[^<sync start=]+\d[^>]",
                RegexOptions.Multiline |
                RegexOptions.IgnoreCase);

            MatchCollection matches = regex.Matches(content);

            foreach (Match match in matches)
            {
                script.Add(match.Value);
            }

            return script;
        }
    }
    // {
    //     public int GetSync(int count)
    //     {
    //         string content = string.Empty;
    //         return 0;
    //     }

    //     private List<string> SyncBlock(string content)
    //     {
    //         var script = new List<string>();
    //         Regex regex = new Regex(@"[^<sync start=]+\d[^>]",
    //             RegexOptions.Multiline |
    //             RegexOptions.IgnoreCase);

    //         MatchCollection matches = regex.Matches(content);

    //         foreach (Match match in matches)
    //         {
    //             script.Add(match.Value);
    //         }

    //         return script;
    //     }

    //     public string SetPath(string path)
    //     {
    //         return string.Empty;
    //     }
}