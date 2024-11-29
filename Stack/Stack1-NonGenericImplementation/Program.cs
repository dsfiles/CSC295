/***********************************************************
 * Stack implementation using array - Non-generic version
 * 11/2024
 ***********************************************************/

using System;

public class Stack
{
    int[] values; //data stored in an array
    int top = -1, capacity = 1024;
    public Stack()
    {
        values = new int[capacity];
        top = -1;
    }
    public bool IsEmpty()
    {
        return (top < 0);
    }
    public bool Push(int data)
    {
        if (top >= capacity - 1)
        {
            throw new Exception("Stack overflow!");
        }
        else
        {
            values[++top] = data;
            return true;
        }
    }
    public int Pop()
    {
        if (top < 0)
        {
            throw new Exception("Can't pop an empty stack");
        }
        else
            return values[top--];
    }
    public int Peek()
    {
        if (top < 0)
        {
            Console.WriteLine("No item in an empty stack");
            return -1;
        }
        else
            return values[top];
    }
    public void Clear()
    {
        top = -1;
    }
    public void Display()
    {
        if (top < 0)
        {
            Console.WriteLine("Empty stack");
            return;
        }
        else
        {
            Console.Write("Stack content: \ntop ->");
            for (int i = top; i >= 0; i--)
            {
                Console.Write(" " + values[i]);
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Stack myStack = new Stack();
        myStack.Push(2);
        myStack.Push(3);
        myStack.Push(5);
        myStack.Push(8);
        myStack.Display();
        myStack.Peek();
        Console.WriteLine($"Pop the top item from Stack : {myStack.Pop()}");
        myStack.Display();
    }
}

