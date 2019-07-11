using System;

public class CircularBuffer<T>
{
    T[] buffer;

    int newItemPointer;

    int length;

    readonly int capacity;

    public CircularBuffer(int capacity)
    {
        this.capacity = capacity;
        buffer = new T[capacity];
    }

    public T Read()
    {
        if (length == 0)
            throw new InvalidOperationException();

        int oldestItemPointer = (newItemPointer - length + capacity) % capacity;
        length--;

        return buffer[oldestItemPointer];
    }

    public void Write(T value)
    {
        if(length == capacity)
            throw new InvalidOperationException();

        buffer[newItemPointer] = value;

        length++;
        newItemPointer = (newItemPointer + 1) % capacity;
    }

    public void Overwrite(T value)
    {
        buffer[newItemPointer] = value;
        newItemPointer = (newItemPointer + 1) % capacity;

        if (length < capacity)
            length++;
    }

    public void Clear()
    {
        length = 0;
    }
}