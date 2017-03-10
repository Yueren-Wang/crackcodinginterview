using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> l1 = new LinkedList<int>();
            l1.AddLast(7);
            l1.AddLast(1);
            l1.AddLast(6);
            LinkedList<int> l2= new LinkedList<int>();

            l2.AddLast(5);
            l2.AddLast(9);
            l2.AddLast(3);

            LinkedList<int> res = calculate(l1, l2);

            LinkedList<int> l3 = new LinkedList<int>();
            l3.AddLast(0);
            l3.AddLast(1);
            l3.AddLast(2);
            l3.AddLast(3);
            l3.AddLast(2);
            l3.AddLast(1);
            l3.AddLast(0);

            results results = isPalindrome(l3.First, 7);

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


    }
}