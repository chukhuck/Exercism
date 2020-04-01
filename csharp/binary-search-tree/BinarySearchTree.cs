using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree : IEnumerable<int>
{
    private int _value;
    private BinarySearchTree _left;
    private BinarySearchTree _right;

    public BinarySearchTree(int value)
    {
        _value = value;
    }

    public BinarySearchTree(IEnumerable<int> values)
    {
        _value = values.FirstOrDefault();

        foreach (var item in values.Skip(1))
            Add(item);
    }

    public int Value
    {
        get
        {
            return _value;
        }
    }

    public BinarySearchTree Left
    {
        get
        {
            return _left;
        }
    }

    public BinarySearchTree Right
    {
        get
        {
            return _right;
        }
    }

    public BinarySearchTree Add(int value)
    {
        if (value > _value)
        {
            _right =  CreateOrAdd(_right, value);
            return _right;
        }
        else
        {
            _left =  CreateOrAdd(_left, value);
            return _left;
        }
    }

    private BinarySearchTree CreateOrAdd(BinarySearchTree tree, int value)
    {
        if (tree is null)
            tree = new BinarySearchTree(value);
        else
            tree.Add(value);

        return tree;
    }

    public IEnumerator<int> GetEnumerator()
    {
        if (_left != null)
            foreach (var item in _left)
                yield return item;

        yield return _value;

        if (_right != null)
            foreach (var item in _right)
                yield return item;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}