namespace Problem04.BalancedParentheses
{
    using System.Collections.Generic;
    using System.Linq;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            Stack<char> symbols = new Stack<char>();

            for (int i = 0; i < parentheses.Length; i++)
            {
                if (parentheses[i] == '{')
                {
                    symbols.Push(parentheses[i]);
                }
                else if (parentheses[i] =='[')
                {
                    symbols.Push(parentheses[i]);
                }
                else if (parentheses[i] == '(')
                {
                    symbols.Push(parentheses[i]);
                }
                else if (parentheses[i] == '}')
                {
                    if (!symbols.Any() || symbols.Pop() != '{')
                    {
                        return false;
                    }
                }
                else if (parentheses[i] == ']')
                {
                    if (!symbols.Any() || symbols.Pop() != '[')
                    {
                        return false;
                    }
                }
                else if (parentheses[i] == ')')
                {
                    if (!symbols.Any() || symbols.Pop() != '(')
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
