using System;
using System.Collections.Generic;

namespace PolishNotation
{
    internal class Program
    {
        private static void Main()
        {
            IParser parser = new Parser();

            var commands =
              new[] { "+ 1 2", "- 3 4", "+ - 5 6 7", "+ 8 - 9 1", "+ - + - - 2 3 4 + - -5 6 + -7 8 9 0" };

            foreach (var command in commands)
            {
                var expression = parser.Parse(command);
                Console.WriteLine("{0} = {1}", expression, expression.Evaluate());
            }

            // Results:
            // (1 + 2) = 3
            // (3 - 4) = -1
            // ((5 - 6) + 7) = 6
            // (8 + (9 - 1)) = 16
            // (((((2 - 3) - 4) + ((-5 - 6) + (-7 + 8))) - 9) + 0) = -24

            Console.ReadKey();
        }
    }

    public interface IExpression
    {
        int Evaluate();
    }

    public class IntegerTerminalExpression : IExpression
    {
        private readonly int _value;

        public IntegerTerminalExpression(int value)
        {
            _value = value;
        }

        public int Evaluate()
        {
            return _value;
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }

    public class AdditionNonterminalExpression : IExpression
    {
        private readonly IExpression _expr1;
        private readonly IExpression _expr2;

        public AdditionNonterminalExpression(
          IExpression expr1,
          IExpression expr2)
        {
            _expr1 = expr1;
            _expr2 = expr2;
        }

        public int Evaluate()
        {
            var value1 = _expr1.Evaluate();
            var value2 = _expr2.Evaluate();
            return value1 + value2;
        }

        public override string ToString()
        {
            return $"({_expr1} + {_expr2})";
        }
    }

    public class SubtractionNonterminalExpression : IExpression
    {
        private readonly IExpression _expr1;
        private readonly IExpression _expr2;

        public SubtractionNonterminalExpression(
          IExpression expr1,
          IExpression expr2)
        {
            _expr1 = expr1;
            _expr2 = expr2;
        }

        public int Evaluate()
        {
            var value1 = _expr1.Evaluate();
            var value2 = _expr2.Evaluate();
            return value1 - value2;
        }

        public override string ToString()
        {
            return $"({_expr1} - {_expr2})";
        }
    }

    public interface IParser
    {
        IExpression Parse(string polish);
    }

    public class Parser : IParser
    {
        public IExpression Parse(string polish)
        {
            var symbols = new List<string>(polish.Split(' '));
            return ParseNextExpression(symbols);
        }

        private IExpression ParseNextExpression(List<string> symbols)
        {
            int value;
            if (int.TryParse(symbols[0], out value))
            {
                symbols.RemoveAt(0);
                return new IntegerTerminalExpression(value);
            }
            return ParseNonTerminalExpression(symbols);
        }

        private IExpression ParseNonTerminalExpression(List<string> symbols)
        {
            var symbol = symbols[0];
            symbols.RemoveAt(0);

            var expr1 = ParseNextExpression(symbols);
            var expr2 = ParseNextExpression(symbols);

            switch (symbol)
            {
                case "+":
                    return new AdditionNonterminalExpression(expr1, expr2);

                case "-":
                    return new SubtractionNonterminalExpression(expr1, expr2);

                default:
                    {
                        var message = $"Invalid Symbol ({symbol})";
                        throw new InvalidOperationException(message);
                    }
            }
        }
    }
}