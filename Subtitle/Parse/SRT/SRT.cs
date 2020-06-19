using System;
using System.Collections.Generic;

namespace Subtitle.Parse.SRT
{
    public class SRT : IParse
    {
        public SRT()
        {
        }

        public List<string> GetCommentList => throw new NotImplementedException();

        public string GetScript(int time)
        {
            throw new NotImplementedException();
        }

        public string GetSubtitle()
        {
            throw new NotImplementedException();
        }

        public void SetPath(string path)
        {
            throw new NotImplementedException();
        }
    }
}