using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NABILHACKER___Hack_the_Password
{
    internal static class NabilHacker
    {
        internal static void Main()
        {
            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                var password = NabilHacker.Keylogger(Console.ReadLine());
                Console.WriteLine(password);
            }
        }

        internal static bool StackIsEmpty<T>(Stack<T> stack)
        {
            if (stack.Count > 0)
                return true;
            return false;
        }

        internal static char[] Keylogger(string password)
        {
            var temporaryStack = new Stack<char>();
            var outputStack = new Stack<char>();

            for (int i = 0; i < password.Length; i++)
            {
                switch (password[i])
                {
                    case '<':
                        if (StackIsEmpty(outputStack))
                            temporaryStack.Push(outputStack.Pop());
                        break;
                    case '>':
                        if (StackIsEmpty(temporaryStack))
                            outputStack.Push(temporaryStack.Pop());
                        break;
                    case '-':
                        if (StackIsEmpty(outputStack))
                            outputStack.Pop();
                        break;
                    default:
                        outputStack.Push(password[i]);
                        break;
                }
            }

            while (StackIsEmpty(temporaryStack))
                outputStack.Push(temporaryStack.Pop());

            return outputStack.Reverse().ToArray();
        }
    }
}
