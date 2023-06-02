using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Kursowa_rabota_SAA
{
    public class MyStack<T>
    {
        private const int MAX_SIZE = 1000;
        public virtual int Count
        {
            get
            {
                return stack.Length;
            }
            set
            {

            }
        }
        int top;
        public Operand[] stack = new Operand[MAX_SIZE];
        bool isEmpty()
        {
            return (top < 0);
        }
        public MyStack()
        {
            top = -1;
        }
        public void Push(Operand data)
        {
            if (top >= MAX_SIZE)
                throw new Exception("Stack overflow!");
            else
            {
                stack[++top] = data;
            }
        }
        public Operand Pop()
        {
            if (top < 0)
                throw new Exception("Stack undeflow!");
            else
            {
                Operand value = stack[top--];
                stack[top + 1] = null;
                return value;
            }
        }
        public Operand ElementAt(int i, Operand[] array)
        {
            return array[i];
        }
        //    public IEnumerator<T> GetEnumerator()
        //    {
        //        return GetEnumerator();
        //    }
        //    IEnumerator IEnumerable.GetEnumerator()
        //    {
        //        return this.GetEnumerator();
        //    }
        //}
    }
}
