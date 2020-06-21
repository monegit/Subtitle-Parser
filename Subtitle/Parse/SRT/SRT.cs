using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Subtitle.Read;

namespace Subtitle.Parse.SRT
{
    public class SRT : ReadFile, IParse
    {
        public SRT(string path)
        {
            string extension = SimpleExtension(Path.GetExtension(path));

            if (IsSRT(path))
                SetPath(path);
            else
                throw new FileLoadException(
                    $"The {extension.ToUpper()} extension does not match the SRT format."
                );

            bool IsSRT(string path)
            {
                if (Token.Extension.Contains(extension.ToLower()))
                    return true;
                else
                    return false;
            }

            string SimpleExtension(string path) => path.Replace(".", string.Empty);
        }

        public List<string> GetCommentList
        {
            get { return SyncBlock(GetSubtitle()); }
        }

        public string GetComment(int time)
        {
            throw new NotImplementedException();
        }

        public string GetSubtitle()
        {
            return subtitleContent;
        }

        public void SetPath(string path)
        {
            FilePath(path);
        }

        private List<string> SyncBlock(string content)
        {
            var script = new List<string>();
            var builder = new StringBuilder();
            string session = Token.Session;
            string start = Token.SyncStart;
            string end = Token.SyncEnd;
            string comment = Token.Comment;
            string splitter = Token.Splitter;

            var regex = new Regex(
                $@"(?<{session}>\d)\n?(?<{start}>\d*:\d*:\d*,\d*)\s*-->\s*(?<{end}>\d*:\d*:\d*,\d*)\n?(?<{comment}>.*)"
            );

            var matches = regex.Matches(content);

            foreach (Match match in matches)
            {
                var groups = match.Groups;

                builder.Append(TokenBuilder(session));
                builder.Append(TokenBuilder(start));
                builder.Append(TokenBuilder(end));
                builder.Append(TokenBuilder(comment));

                script.Add(builder.ToString());
                builder.Clear();

                string TokenBuilder(string token) => $"{token}:{groups[token]}{splitter}";
            }

            return script;
        }
    }
}