using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Subtitle.Read;
using Subtitle.Parse.SAMI;
using System.IO;

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
                switch (extension)
                {
                    case "sami":
                    case "smi":
                        return true;
                    default:
                        return false;
                }
            }

            string SimpleExtension(string path) => path.Replace(".", string.Empty);
        }

        public string GetSubtitle()
        {
            return subtitleContent;
        }

        public string GetScript(int time)
        {
            throw new NotImplementedException();
        }

        public List<string> GetScriptList
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
                @"<sync start=(?<sync>\d*)>\n*<p class=\w*>\n*(?<content>.*)",
                RegexOptions.Multiline |
                RegexOptions.IgnoreCase);

            MatchCollection matches = regex.Matches(content);

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                script.Add(string.Format("sync:{0}, content:{1}", groups["sync"], groups["content"]));
            }

            return script;
        }
    }
}