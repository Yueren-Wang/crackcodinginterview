using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //LinkedList<int> l1 = new LinkedList<int>();
            //l1.AddLast(7);
            //l1.AddLast(1);
            //l1.AddLast(6);
            //LinkedList<int> l2= new LinkedList<int>();

            //l2.AddLast(5);
            //l2.AddLast(9);
            //l2.AddLast(3);

            //LinkedList<int> res = calculate(l1, l2);

            //LinkedList<int> l3 = new LinkedList<int>();
            //l3.AddLast(0);
            //l3.AddLast(1);
            //l3.AddLast(2);
            //l3.AddLast(3);
            //l3.AddLast(2);
            //l3.AddLast(1);
            //l3.AddLast(0);

            //results results = isPalindrome(l3.First, 7);

            string exp = "2-6-7*8/2+5";
            double res = arithmeticcalculator(exp);
        }

        //2.5
        static LinkedList<int> calculate(LinkedList<int> c, LinkedList<int> d)
        {
            if(c==null)
            {
                return d;
            }

            if (d == null)
            {
                return c;
            }

            LinkedList <int> res = new LinkedList<int>();
            LinkedListNode<int> itera = c.First;
            LinkedListNode<int> iterb = d.First;
            int digit = 0;
            int value = 0;
            int a = 0;
            int b = 0;
            while(!(itera==null&&iterb==null))
            {
                a = itera == null ? 0 : itera.Value;
                b = iterb == null ? 0 : iterb.Value;
                value = (a + b + digit) % 10;
                digit = (a + b + digit) / 10;
                res.AddLast(value);
                if (itera != null)
                {
                    itera = itera.Next;
                }
                if (iterb != null)
                {
                    iterb = iterb.Next;
                }
            }
            if(digit != 0)
            {
                res.AddLast(1);
            }
            return res;
        }

        //recursion solution 2.5

        //2.6 recursion
        struct results
        {
            public LinkedListNode<int> node { get; set; }
            public bool res { get; set; }
        }
        static results isPalindrome(LinkedListNode<int> head, int length)
        {
            if(length==1)
            {
                return new results()
                {
                    node = head.Next,
                    res=true
                };
            }
            if (length == 0)
            {
                return new results()
                {
                    node = head,
                    res = true
                };

            }
            results result = isPalindrome(head.Next, length - 2);
            result.res =  result.res && result.node.Value == head.Value;
            result.node = result.node.Next;
            return result;
        }

        private static double arithmeticcalculator(string expression)
        {
            Stack<double> numbers = new Stack<double>();
            Stack<char> operators = new Stack<char>();
            int stringiterator = 0;
            char i;
            double val = 0;
            while(stringiterator < expression.Length)
            {
                i = expression[stringiterator];
                if (i == '+'||i=='-'||i=='*'||i=='/')
                {
                    if(operators.Count == 0 )
                    {
                        operators.Push(i);
                        stringiterator++;
                        continue;
                    }

                    while (collapseStack(i, operators.Peek()))
                    {
                        double a = numbers.Pop();
                        double b = numbers.Pop();
                        char o = operators.Pop();
                        switch(o.ToString())
                        {
                            case "+":
                                val = b + a;
                                numbers.Push(val);
                                stringiterator++;
                                operators.Push(i);
                                continue;
                            case "-":
                                val = b - a;
                                numbers.Push(val);
                                stringiterator++;
                                operators.Push(i);
                                continue;
                            case "*":
                                val = b * a;
                                numbers.Push(val);
                                stringiterator++;
                                operators.Push(i);
                                continue;
                            case "/":
                                val = b / a;
                                numbers.Push(val);
                                stringiterator++;
                                operators.Push(i);
                                continue;
                        }

                    }
                    operators.Push(i);
                }
                else
                {
                    numbers.Push(double.Parse(i.ToString()));
                }
                stringiterator++;
             }

            if(numbers.Count != 0)
            {
                return numbers.Pop();
            }

            return 0.0;
        }

        private static bool collapseStack(char a, char b)
        {
            if ((a == '*' || a == '/' )&&(b== '+' || b == '-'))
            {
                return false;
            }

            return true;
        }

    }
}