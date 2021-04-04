using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        return input.Cast<object>()
                    .Where(item => !(item is null))
                    .SelectMany<object, object>(item => (item is IEnumerable<object>) ? 
                                                        Flatten((IEnumerable<object>)item).Cast<object>() : 
                                                        new object[]{item});
    }

    public static IEnumerable Flatten1(IEnumerable input)
    {
        return from object item in input
               where !(item is null)
               from object item2 in (item is IEnumerable) ? Flatten(item as IEnumerable) : new object[]{item}
               select item2;
    }
}