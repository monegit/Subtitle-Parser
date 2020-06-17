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
            IParse smi = new SAMI();
            smi.SetPath("/Users/bagjong-won/Downloads/귀멸의 칼날 skip ver/[HorribleSubs] Kimetsu no Yaiba - 02 [1080p].smi");

            for (int i = 0; i<=smi.GetScriptList.Count - 1; i++)
            {
                Console.WriteLine(
                    string.Format("{0}, {1}",
                    smi.GetScriptList[i].GetSync(),
                    smi.GetScriptList[i].GetContent()));
            }
        }
        
    }
}