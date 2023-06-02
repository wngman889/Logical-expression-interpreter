using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Kursowa_rabota_SAA
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        public class Node
        {
            public Node next;
            public T value;
        }
        private Node head;

        public void PrintAllNodes()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.value);
                current = current.next;
            }
        }

        public void AddFirst(T data)
        {
            Node toAdd = new Node();

            toAdd.value = data;
            toAdd.next = head;

            head = toAdd;
        }

        public void AddLast(T data)
        {
            if (head == null)
            {
                head = new Node();

                head.value = data;
                head.next = null;
            }
            else
            {
                Node toAdd = new Node();
                toAdd.value = data;

                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = toAdd;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.value;
                current = current.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
