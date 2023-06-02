using System;
using System.Collections.Generic;
using System.Text;

namespace Kursowa_rabota_SAA
{
    public class Rpn//the main rpn calculator class
    {
        private List<Operator> operators;
        MyDictionary<string, Operator> dictionary = new MyDictionary<string, Operator>();
        MyStack<Operand> stack = new MyStack<Operand>(); 
        private string funcToken;
        public List<string> tokens = new List<string>();
        public Rpn()
        {
            operators = new List<Operator>();
        }
        public void RegisterOperator(Operator opr)
        {
            operators.Add(opr);
        }
        public bool Evaluate(string expression)
        {
             tokens = MySplit(expression);//string.Split()
            funcToken = tokens[0];
            tokens.RemoveAt(0);//leaving just the expression
            //dictionary.Add(tokens[0], stack.Pop());
            //for (int i = 0; i < tokens.Count; i++)
            //{
            //    if (tokens[i] == "&")
            //        root.Name = tokens[i];
            //}
            foreach (var str in tokens)
            {
                var token = CreateToken(str);
                token.ProcessWith(stack);
            }
            var result = stack.Pop();
            return result.Value;
        }

        private Token CreateToken(string str)
        {
            //Tokenizing
            if (str != "&" && str != "|" && str != "!")
                return new Operand(str);
            //root.Left = new Node { Name = str };
            //if (bool.TryParse(str, out bool value))
            //{
            //    return new Operand(value);//if operand==true
            //}
            //root.Right = new Node { Name = str };
            //else
            foreach (var op in operators)
                if (op.Symbol == str)
                {
                    if (!dictionary.ContainsKey(funcToken))
                    {
                        dictionary.Add(funcToken, op);
                        List<int> table = new List<int>();
                        List<int> numbers = new List<int>();
                        string format = null;
                        do
                        {
                            Console.WriteLine("Type 'end' if you want to end the cycle");
                            format = Console.ReadLine();
                            switch (format)
                            {
                                case "All":
                                    Console.Write("The name of the function: ");
                                    format = Console.ReadLine();
                                    if (format == funcToken)
                                        table = FillTruthTable(stack, op.Symbol);

                                    break;
                                    //TODO: improving the find function
                                //case "Find":
                                //    Console.Write("The name of the function: ");    
                                //    string expression = Console.ReadLine();
                                //    numbers = Find(expression);
                                //    int counter = 0;
                                //    for (int i = 0; i < numbers.Count; i++)
                                //    {
                                //        for (int j = 0; j < table.Count; j++)
                                //        {
                                //            if (numbers[i] == table[j])
                                //                counter++;

                                //            if (counter > 2)
                                //                goto Message;
                                //        }
                                //    }
                                //    Message:
                                //    Console.WriteLine($"The name of the function is {funcToken}");
                                //    break;
                                case "Solve":
                                    Console.Write("The name of the function: ");
                                    string func = Console.ReadLine();
                                    for (int i = 0; i < stack.Count; i++)
                                    {
                                        if (dictionary.ContainsKey(func))
                                        {
                                            if (stack.stack[i] != null)
                                            {
                                                Console.Write($"{stack.ElementAt(i, stack.stack).Name}= ");
                                                string exp = Console.ReadLine();
                                                stack.ElementAt(i, stack.stack).Value = bool.TryParse(exp, out bool value);
                                                if (exp == "false")
                                                    stack.ElementAt(i, stack.stack).Value = false;
                                            }
                                            else
                                                break;
                                        }
                                    }
                                    break;
                            }

                        } while (format != "end");
                    }
                    return op;
                }

            throw new ArgumentException("Invalid operator or operand!");
        }

        public static List<string> MySplit(string str)
        {
            List<string> values = new List<string>(str.Length);
            string format = "";
            bool flag = true;
            while (flag)
            {
                foreach (var ch in str)
                {
                    if (ch != ' ')
                        format += ch;
                    if (ch == ' ')
                    {
                        values.Add(format);
                        format = "";
                    }
                }
                values.Add(format);
                flag = false;
            }
            return values;
        }
        public static List<int> FillTruthTable(MyStack<Operand> stack, string symbol)
        {
            int n = 0;
            foreach (var ch in stack.stack)
            {
                if (ch != null)
                    n++;
                else
                    break;
            }
            List<int> variables = new List<int>();
            List<int> table = new List<int>();
            List<int> valueTable = new List<int>();
            int prinCounter = 0;
            int value = 0;
            for (ulong sortOfAnArray = 0; sortOfAnArray < Math.Pow(2, n); sortOfAnArray++)
            {
                List<int> bits = new List<int>();
                for (int i = n - 1; i >= 0; i--)
                {
                    ulong bit = (sortOfAnArray >> i) & 1;
                    bits.Add((int)bit);
                    table.Add((int)bit);
                }
                for (int j = 0; j < bits.Count - 1; j++)
                {
                    if (symbol == "&")
                    {
                        value = bits[j] & bits[j + 1];
                        valueTable.Add(value);
                    }
                    else
                    {
                        value = bits[j] | bits[j + 1];
                        valueTable.Add(value);
                    }
                    if (valueTable.Count == (n - 1))
                    {
                        for (int k = 0; k <= valueTable.Count - 1; k++)
                        {
                            if (valueTable.Count >= 2)
                            {
                                if(symbol == "&")
                                {
                                    table.Add(valueTable[k] & valueTable[k + 1]);
                                    valueTable.Clear();
                                }
                                else if(symbol == "|")
                                {
                                    table.Add(valueTable[k] | valueTable[k + 1]);
                                    valueTable.Clear();
                                }
                            }
                            else
                            {
                                table.Add(valueTable[k]);
                                valueTable.Clear();
                            }
                        }
                    }
                }
            }
            foreach (var ch in table)
            {
                Console.Write($"{ch} ");
                prinCounter++;
                if (prinCounter == n + 1)
                {
                    Console.WriteLine();
                    prinCounter = 0;
                }
            }
            return table;
        }
        //public static List<int> Find(string format)
        //{
        //    List<string> array = MySplit(format);
        //    List<int> numbers = new List<int>();
        //    for (int i = 0; i < array.Count; i++)
        //        numbers.Add(Convert.ToInt32(array[i]));

        //    return numbers;
        //}
    }
}
