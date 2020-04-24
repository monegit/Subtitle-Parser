using System;
using System.Text.RegularExpressions;
using Subtitle.Read;
using Subtitle.Parse;

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

            // //readFile.SetPath("/Users/bagjong-won/Desktop/1.smi");
            // //Console.WriteLine(readFile.getContent);

            // string i = "";

            // Regex regex = new Regex(@"[^<sync start=]+\d[^>]",
            //     RegexOptions.Multiline |
            //     RegexOptions.IgnoreCase);

            // i = @"
            //     <SYNC Start=-10131><P Class=KRCC>﻿sub by kairan 
            //     <Sync Start=-387><P Class=KRCC>&nbsp; 
            //     <SYNC Start=25117><P Class=KRCC><font color = 969696>어째서... 
            //     <Sync Start=26272><P Class=KRCC>&nbsp; 
            //     <SYNC Start=29752><P Class=KRCC><font color = 969696>어쩌다 이렇게 된 거지...? 
            //     <Sync Start=32720><P Class=KRCC>&nbsp; 
            //     <SYNC Start=34488><P Class=KRCC>네즈코, 죽지 마! 
            // ";

            // MatchCollection mc = regex.Matches(i);

            // foreach (Match match in mc)
            // {
            //     //Match gc = match.NextMatch;
            //     Console.WriteLine("{0}",match.Value);
            // }