using System;
using System.Collections.Generic;
using Subtitle.Parse;
using Subtitle.Parse.SAMI;

namespace Subtitle_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            IParse subtitle = new SAMI("sample/smi.smi");

            for (int i = 0; i<=10; i++)
            {
                Console.WriteLine(
                    string.Format("{0}, {1}",
                    subtitle.GetCommentList[i].GetSync(),
                    subtitle.GetCommentList[i].GetComment()));
            }
        }
        
    }
}