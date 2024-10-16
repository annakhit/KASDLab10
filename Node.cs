using System;

public class Node<T> where T : IComparable<T>
{
    public Node(T value) { Value = value; }
    public T Value { get; set; }

    private Node<T> right = default;
    public ref Node<T> Right => ref right;

    private Node<T> left = default;
    public ref Node<T> Left => ref left;

    public int Size => (left?.Size ?? 0) + (right?.Size ?? 0) + 1;

    public ref Node<T> GetLowerChild()
    {
        if (Left == null) return ref Left;
        if (Right == null) return ref Right;
        if (right.Size >= left.Size) return ref Left;
        return ref Right;
    }

    public void Heapify()
    {
        if (Left != null && Left.Value.CompareTo(Value) > 0) SwapValueWith(Left);
        if (Right != null && Right.Value.CompareTo(Value) > 0) SwapValueWith(Right);
    }

    public void SwapValueWith(Node<T> other) => (other.Value, Value) = (Value, other.Value);
}
