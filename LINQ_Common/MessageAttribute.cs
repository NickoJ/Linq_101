using System;

namespace Common
{
    
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class MessageAttribute : Attribute
    {
        public readonly string Text;

        public MessageAttribute(string text)
        {
            Text = text;
        }
    }
}