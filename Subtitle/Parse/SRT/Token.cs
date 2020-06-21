namespace Subtitle.Parse.SRT
{
    internal class Token
    {
        internal const string Session = "session";
        internal const string Comment = "comment";
        internal const string SyncStart = "start_time";
        internal const string SyncEnd = "end_time";
        internal static string[] Extension = { "srt" };
        internal const string Splitter = "||";
    }
}
