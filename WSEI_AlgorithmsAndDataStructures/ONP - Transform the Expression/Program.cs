using System;
using System.Collections.Generic;
using System.Text;

public class ONP
{
    public static void Main()
    {
        if (!int.TryParse(Console.ReadLine(), out int t))
            return;

        while(t > 0)
        {
            t--;
            var expression = Console.ReadLine();
            
            int iterator = 0;
            Stack<char> stack = new Stack<char>();
            var output = new StringBuilder();

            while(iterator < expression.Length - 1) 
            {
                iterator++;
                switch(expression[iterator])
                {
                    case '(':
                        break;
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '^':
                        stack.Push(expression[iterator]);
                        break;
                    case ')':
                        if(stack.Count > 0)
                            output.Append(stack.Pop());
                        break;
                    default:
                        output.Append(expression[iterator]);
                        break;
                }
            }
            Console.WriteLine(output);
        }
    }
}