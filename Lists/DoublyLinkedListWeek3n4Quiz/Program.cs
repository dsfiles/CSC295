namespace DoublyLinkedListWeek3n4Quiz
{
    /*************************************************************
     * Doubly Linked List - Version 1.0 Non-Generic Implementation
     * November 2024
     * Week 3&4 Quiz
     *************************************************************/

    using System;

    public class Node
    {
        public Node Next;
        public Node Prev;
        public object Value;
        public Node(object obj)
        {
            Value = obj;
            Next = null;
            Prev = null;
        }
    }

    public class DoublyLinkedList
    {
        public Node head;
        public Node tail;
        public Node current; // This will have latest node
        public int Count;
        public DoublyLinkedList()
        {
            // Empty list does not have node, all pointers are set to null
            head = tail = current = null;
            Count = 0;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void AddStart(object data)
        {
            Node newNode = new Node(data);
            if (IsEmpty())
            {
                head = tail = current = newNode;
                newNode.Next = newNode.Prev = null;
            }
            else
            {
                newNode.Next = head;
                newNode.Prev = null;
                head.Prev = newNode;
                head = current = newNode;
            }
            Count++;
        }

        public void RemoveStart()
        {
            if (IsEmpty())
            {
                throw new Exception("Can't remove a node from an empty list!");
            }
            else if (head.Next == null) // Only one node in the list
            {
                head = tail = current = null;
            }
            else
            {
                head = current = head.Next;
                head.Prev = null;
            }
            Count--;
        }

        public void AddLast(object data)
        {
            Node newNode = new Node(data);
            if (IsEmpty())
            {
                head = tail = current = newNode;
                newNode.Next = newNode.Prev = null;
            }
            else
            {
                newNode.Next = null;
                newNode.Prev = tail;
                tail.Next = newNode;
                tail = current = newNode;
            }
            Count++;
        }

        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new Exception("Can't remove a node from an empty list!");
            }
            else if (head.Next == null) // Only one node in the list
            {
                head = tail = current = null;
            }
            else
            {
                tail = current = tail.Prev;
                tail.Next = null;
            }
            Count--;
        }


        // A new node is inserted after the 'current' node
        public void InsertNode(object data)
        {
            Node newNode = new Node(data);
            if (IsEmpty())
            {
                head = tail = current = newNode;
                newNode.Next = newNode.Prev = null;
                Count++;
            }
            else if (current == tail)
            { // If the 'current' node is the last one
                AddLast(data);
            }
            else
            {
                newNode.Next = current.Next;
                newNode.Prev = current;
                current.Next = current.Next.Prev = newNode;
                current = current.Next;
                Count++;
            }
        }

        public void PrintList()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Empty list!");
            }
            else
            {
                Console.Write("--- Head");
                Node curr = head;
                while (curr != null) // Advance the pointer
                {
                    if (curr == current)
                    { // Mark the 'current' node with <= =>
                        Console.Write(" <=");
                        Console.Write(curr.Value);
                        Console.Write("=> ");
                        curr = curr.Next;
                    }
                    else
                    {
                        Console.Write(" <-");
                        Console.Write(curr.Value);
                        Console.Write("-> ");
                        curr = curr.Next;
                    }
                }
                Console.WriteLine("Tail ---");
            }
        }

        /*
         * Week 3&4 Quiz
         * Complete 2 out 3 exercises below:
            1. Write a method Reverse() that reverses the order of elements in a doubly linked list.
            public void Reverse()
            {
                // your code is here
            }
            2. Delete all the nodes that contain 'data'. 
            public void DeleteNodes (T data)
            {
                // your code is here
            }
            3. Remove all the duplicate nodes that contain the same value (data).
            public void RemoveDuplicateNodes()
            {
                // your code is here
            }
         */

        public void Reverse()
        {
            Node tmp, saved, curr = head;
            while (curr != null) // advance the pointer
            { // swap the two pointers for each node
                saved = curr.Next; // save the next node's pointer
                tmp = curr.Next;
                curr.Next = curr.Prev;
                curr.Prev = tmp;
                curr = saved; // recover the next node's pointer
            }
            // swap head and tail
            tmp = head;
            head = tail;
            tail = tmp;
        }

        public void DeleteNodes(object value)
        {
            if (IsEmpty())
            {
                throw new Exception("Can't remove a node from an empty list!");
            }
            Node curr = head;
            while (curr.Value.Equals(value))
            {
                RemoveStart();
                if (IsEmpty()) return; // After deleting the only node, exit with an empty list
                curr = head; // set curr to the new head
            }
            while (curr.Next != null)
            {
                if (curr.Next.Value.Equals(value))
                {
                    if (curr.Next.Next == null) // The node to be deleted is the tail node
                    {
                        curr.Next = null;
                        this.current = curr;
                        Count--;
                        return;
                    }
                    else
                    {
                        Node deleted = curr.Next;
                        this.current = curr.Next = curr.Next.Next;
                        deleted.Next.Prev = curr;
                        Count--;
                    }
                }
                else
                {
                    curr = curr.Next;
                }
            }
        }

        public void RemoveDuplicateNodes()
        {
            if (this.Count <= 1)
            {
                return; // Exit if the size of list is <= 1
            }
            Node p1, p2;
            p1 = head;
            while (p1 != null)
            {
                if (p1.Next == null) return;
                p2 = p1.Next;
                while (p2 != null)
                {
                    if (p1.Value.Equals(p2.Value))
                    {
                        if (p2.Next == null)
                        {
                            p2.Prev.Next = null;
                            this.current = p2.Prev;
                            Count--;
                            break;
                        }
                        else // p2.Next != null
                        {
                            p2.Prev.Next = p2.Next;
                            p2.Next.Prev = p2.Prev;
                            this.current = p2.Next;
                            Count--;
                        }
                    }
                    p2 = p2.Next;
                }
                p1 = p1.Next;
            }
        }


    } // END of class DoublyLinkedList

    public class DoublyLinkedListTest
    {
        static void Main(string[] args)
        {
            DoublyLinkedList testList = new DoublyLinkedList();
            Console.WriteLine("Insert 3, 5, 7, 5 to the list:");
            testList.InsertNode(3);
            testList.InsertNode(5);
            testList.InsertNode(7);
            testList.InsertNode(5);
            testList.PrintList();
            testList.Reverse();
            testList.PrintList();
            testList.RemoveDuplicateNodes();
            testList.PrintList();
            testList.DeleteNodes(5);
            testList.PrintList();
        }
    } // END of class DoublyLinkedListTest
}