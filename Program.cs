using System;
using System.Collections.Generic;
using Subtitle.Parse;
using Subtitle.Parse.SRT;

namespace Subtitle_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            IParse subtitle = new SRT("sample/srt.srt");

            for (int i = 0; i<=10; i++)
            {
                Console.WriteLine(
                    string.Format("{0}~{1}, {2}",
                    subtitle.GetCommentList[i].GetSyncStart(),
                    subtitle.GetCommentList[i].GetSyncEnd(),
                    subtitle.GetCommentList[i].GetComment()));
            }
        }
        
    }
}