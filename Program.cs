using System;
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

            for (int i = 0; i<=10; i++)
            {
                Console.WriteLine(smi.GetScriptList()[i]);
            }
        }
        
    }
}