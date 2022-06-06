using System;


namespace HelloFunction
{
    public class BaseMessage : IBaseMessage
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
