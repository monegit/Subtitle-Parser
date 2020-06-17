using System.Collections.Generic;

namespace Subtitle.Parse
{
    public interface IParse
    {
        /// <summary>
        /// <para>get subtitle file content</para>
        /// </summary>
        string GetSubtitle(); // 자막의 파일 내용을 가져옴.
        void SetPath(string path); // 파일의 위치를 설정함.
        string GetScript(int time); // time에 맞는 자막을 가져옴.
        List<string> GetScriptList { get; } // 스크립트의 리스트를 가져옴.
    }
}