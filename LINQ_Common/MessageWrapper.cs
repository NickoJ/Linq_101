using System;
using System.Reflection;

namespace Common
{
    
    public static class MessageWrapper
    {

        public static void ShowMessage(Type type)
        {
            var attr = (MessageAttribute) type.GetCustomAttribute(typeof(MessageAttribute));
            Console.WriteLine(attr?.Text ?? "No message.");
            Console.Write('\n');
        }
        
        public static void WrappedInvoke(Action del)
        {
            Console.WriteLine($"{del.Method.Name} executed:");
            
            var attr = (MessageAttribute)del.Method.GetCustomAttribute(typeof(MessageAttribute));
            Console.WriteLine(attr?.Text ?? "No message.");
            del.DynamicInvoke();
            Console.Write('\n');
        }
        
    }
    
}