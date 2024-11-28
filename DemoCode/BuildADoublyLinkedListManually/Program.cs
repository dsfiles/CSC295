/*
 * In the class demo code that shows how to build a doubly linked manually
 * 11/26/2024
 */

using System;
public class Node
{
    public Node Next;
    public Node Prev;
    public int Value;
    // default constructor
    public Node(int value)
    {
        Value = value;
        Next = null;
        Prev = null;
    }
    // constructor for creating a new node and appending it to an existing code simultaneously
    public Node(int value, Node prev)
    {
        Value = value;
        Prev = prev;
        Next = null;
    }
} // END of class Node

public class Program
{
    public static void Main()
    {
    
        // let's construct three nodes
        Node node1 = new Node(5);
        Node node2 = new Node(2);
        Node node3 = new Node(3);

        // mark node1 as head node, node3 as tail node
        Node head = node1;
        Node tail = node3;

        // append node 2 to node 1
        node1.Next = node2;
        node2.Prev = node1;

        // append node 3 to node 2
        node2.Next = node3;
        node3.Prev = node2;

        Print(head, "Our first manually constructed linked lists with three nodes:");


        // create a new node called node4
        Node node4 = new Node(4);
        
        // insert node4 between node2 and node3
        // because we have 
        node4.Prev = node2;
        node4.Next = node3;
        node2.Next = node4;
        node3.Prev = node4;

        Print(head, "After insertin a new node: ");

        //// remove the second node (node 2 with value 3)
        //// your code here
        //head.Next = node4;
        //node4.Prev = head;

        //Print(head, "After linking out node2: ");

        //int[] arr = { 5, 2, 3, 0, 1 };
        //Node head = new Node(arr[0]);
        //Node iterator = head;
        //for (int i = 1; i < arr.Length; i++)
        //{
        //    iterator = new Node(arr[i], iterator);
        //    iterator.Prev.Next = iterator;
        //}


        //Node head = new Node(2);
        //Node iterator = head;
        //for (int i = 0; i < 50; i++)
        //{
        //    iterator = new Node(i, iterator);
        //    iterator.Prev.Next = iterator;
        //}
        //Print(head, "Original list: ");



    }

    // a utility method that prints the content of a list
    public static void Print(Node iterator, string msg)
    {
        Console.Write(msg);
        while (iterator != null)
        {
            Console.Write(iterator.Value + " ");
            iterator = iterator.Next;
        }
        Console.WriteLine();
    }
}
