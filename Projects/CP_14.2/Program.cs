using System;
using System.Collections.Generic;
using System.Globalization;

namespace Task2
{
    class Program
    {
        // Словарь операторов и их приоритетов
        static readonly Dictionary<char, int> operatorPriority = new Dictionary<char, int>
        {
            { '+', 1 },
            { '-', 1 },
            { '*', 2 },
            { '/', 2 }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Введите арифметическое выражение:");
            string expression = Console.ReadLine();

            // Преобразование выражения в постфиксную форму
            List<string> postfix = InfixToPostfix(expression);
            // Вычисление значения выражения
            double result = EvaluatePostfix(postfix);

            Console.WriteLine("Результат: " + result);
            Console.ReadKey();
        }

        // Метод для преобразования инфиксного выражения в постфиксное (обратную польскую запись)
        static List<string> InfixToPostfix(string expr)
        {
            List<string> output = new List<string>();
            Stack<char> operators = new Stack<char>();

            int i = 0;
            while (i < expr.Length)
            {
                char token = expr[i];

                // Пропускаем пробелы
                if (char.IsWhiteSpace(token))
                {
                    i++;
                    continue;
                }

                // Если цифра, читаем всё число (в том числе дробную часть)
                if (char.IsDigit(token) || token == '.')
                {
                    string number = "";
                    while (i < expr.Length && (char.IsDigit(expr[i]) || expr[i] == '.'))
                    {
                        number += expr[i];
                        i++;
                    }
                    output.Add(number);
                    continue;
                }

                // Если открывающая скобка, помещаем в стек
                if (token == '(')
                {
                    operators.Push(token);
                }
                // Если закрывающая скобка, извлекаем операторы до открывающей
                else if (token == ')')
                {
                    while (operators.Count > 0 && operators.Peek() != '(')
                    {
                        output.Add(operators.Pop().ToString());
                    }
                    if (operators.Count > 0 && operators.Peek() == '(')
                        operators.Pop(); // удаляем '('
                }
                // Если оператор
                else if (operatorPriority.ContainsKey(token))
                {
                    while (operators.Count > 0 && operators.Peek() != '(' &&
                           operatorPriority[operators.Peek()] >= operatorPriority[token])
                    {
                        output.Add(operators.Pop().ToString());
                    }
                    operators.Push(token);
                }
                else
                {
                    Console.WriteLine("Неизвестный символ: " + token);
                }
                i++;
            }

            // Извлекаем оставшиеся операторы из стека
            while (operators.Count > 0)
            {
                output.Add(operators.Pop().ToString());
            }

            return output;
        }

        // Метод для вычисления выражения в постфиксной форме
        static double EvaluatePostfix(List<string> postfix)
        {
            Stack<double> stack = new Stack<double>();

            foreach (var token in postfix)
            {
                double number;
                // Если токен – число, то помещаем его в стек
                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out number))
                {
                    stack.Push(number);
                }
                // Иначе токен – оператор
                else if (token.Length == 1 && operatorPriority.ContainsKey(token[0]))
                {
                    if (stack.Count < 2)
                    {
                        Console.WriteLine("Неверное выражение.");
                        return 0;
                    }
                    double b = stack.Pop();
                    double a = stack.Pop();
                    double res = 0;
                    switch (token[0])
                    {
                        case '+': res = a + b; break;
                        case '-': res = a - b; break;
                        case '*': res = a * b; break;
                        case '/':
                            if (b == 0)
                            {
                                Console.WriteLine("Ошибка: деление на ноль.");
                                return 0;
                            }
                            res = a / b;
                            break;
                    }
                    stack.Push(res);
                }
            }

            return stack.Pop();
        }
    }
}
