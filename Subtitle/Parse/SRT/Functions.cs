using System;

namespace Subtitle.Parse.SRT
{
    public static class Functions
    {
        internal static int GetSyncStart(this string block)
        {
            return ToMilliSecond(block.Split($"{Token.SyncStart}:")[1].Split(Token.Splitter)[0]);
        }

        internal static int GetSyncEnd(this string block)
        {
            return ToMilliSecond(block.Split($"{Token.SyncEnd}:")[1].Split(Token.Splitter)[0]);
        }

        public static string GetComment(this string block)
        {
            return block.Split($"{Token.Comment}:")[1].Split(Token.Splitter)[0];
        }

        public static string GetSession(this string block)
        {
            return block.Split($"{Token.Session}:")[1].Split(Token.Splitter)[0];
        }

        private static int ToMilliSecond(string content)
        {
            return int.Parse(content.Replace(":", string.Empty)
                                    .Replace(",",string.Empty)
                                    .TrimStart('0'));
        }
    }
}