using System;

namespace Subtitle
{
    public class Singleton
    {
        private static readonly Lazy<Singleton> instance
            = new Lazy<Singleton>(() => new Singleton());

        public static Singleton Instance
        {
            get
            {
                return instance.Value;
            }
        }

        private Singleton()
        {
            
        }
    }
}