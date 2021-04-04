using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    T value;
    SimpleLinkedList<T> next;

    public SimpleLinkedList(T value)
    {
        this.value = value;
    }

    public SimpleLinkedList(IEnumerable<T> values)
    {
        this.value = values.First();

        var lastItem = this;
        foreach (var item in values.Skip(1))
            lastItem = lastItem.Add(item);
    }

    public T Value => value;

    public SimpleLinkedList<T> Next => next;

    public SimpleLinkedList<T> Add(T value)
    {
        var lastItem = this;

        while (lastItem.next != null)
        {
            lastItem = lastItem.next;
        }

        lastItem.next = new SimpleLinkedList<T>(value);

        return this;
    }

    public IEnumerator<T> GetEnumerator()
    {
        yield return value;

        SimpleLinkedList<T> temp = Next;
        while (temp != null)
        {
            yield return temp.Value;
            temp = temp.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}