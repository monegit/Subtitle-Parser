using System.IO;

namespace Subtitle.Read
{
    public class ReadFile
    {
        protected string subtitleContent = string.Empty;
        protected string subtitlePath = string.Empty;

        protected void FilePath(string path) => subtitleContent = File.ReadAllText(path);
        protected string SplitContentBody(string content)
        {
            return string.Empty;
        }
    }
}