using System;
using System.Collections.Generic;

public class MyHeap<T> where T : IComparable<T>
{
    private Node<T> head = default;

    public MyHeap(T[] array) { foreach (T item in array) Insert(item); }

    public T Max() => head.Value;

    public T RemoveMax()
    {
        if (head == null) throw new InvalidOperationException();
        T temp = head.Value;
        HeapifyDownRecursive(ref head);
        return temp;
    }

    public void ReplaceValue(T oldValue, T newValue) => ReplaceValueRecursive(ref head, oldValue, newValue);

    public void Insert(T value) => InsertResursive(ref head, new Node<T>(value));

    public void Merge(MyHeap<T> heap)
    {
        T[] array = heap.ToArray();
        foreach (T element in array) Insert(element);
    }

    public void Print()
    {
        T[] array = ToArray();
        foreach (T element in array) Console.Write(element + " ");
        Console.WriteLine();
    }

    private void HeapifyDownRecursive(ref Node<T> current)
    {
        if (current.Left == null && current.Right == null) current = null;
        else if (current.Right == null)
        {
            current.SwapValueWith(current.Left);
            HeapifyDownRecursive(ref current.Left);
        }
        else if (current.Left == null)
        {
            current.SwapValueWith(current.Right);
            HeapifyDownRecursive(ref current.Right);
        }
        else if (current.Left.Value.CompareTo(current.Right.Value) > 0)
        {
            current.SwapValueWith(current.Left);
            HeapifyDownRecursive(ref current.Left);
        }
        else
        {
            current.SwapValueWith(current.Right);
            HeapifyDownRecursive(ref current.Right);
        }
    }

    private void InsertResursive(ref Node<T> current, Node<T> newNode)
    {
        if (current == null) current = newNode;
        else if (current.Left == null) current.Left = newNode;
        else if (current.Right == null) current.Right = newNode;
        else InsertResursive(ref current.GetLowerChild(), newNode);
        current.Heapify();
    }

    private bool ReplaceValueRecursive(ref Node<T> current, T oldValue, T newValue)
    {
        if (current == null) return false;

        if (current.Value.Equals(oldValue))
        {
            HeapifyDownRecursive(ref current);
            Insert(newValue);
            return true;
        }

        return ReplaceValueRecursive(ref current.Left, oldValue, newValue) || ReplaceValueRecursive(ref current.Right, oldValue, newValue);
    }

    private T[] ToArray()
    {
        List<T> list = new List<T>();
        ToArrayRecursive(ref list, head);
        return list.ToArray();
    }

    private void ToArrayRecursive(ref List<T> list, Node<T> current)
    {
        list.Add(current.Value);
        if (current.Left != null) ToArrayRecursive(ref list, current.Left);
        if (current.Right != null) ToArrayRecursive(ref list, current.Right);
    }
}
