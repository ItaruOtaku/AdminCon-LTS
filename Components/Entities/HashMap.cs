using System;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - HashMap.cs
 * Intro: HashMap on C#.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace System.Collections.Generic
{
    public class HashMap<TKey, TValue> : IDictionary<TKey, TValue>, IEnumerable
{
    Dictionary<TKey, TValue> HashMapData = new Dictionary<TKey, TValue>();
    public TValue this[TKey key]
    {
        get
        {
            return HashMapData[key];
        }

        set
        {
            if (HashMapData.ContainsKey(key))
            {
                HashMapData[key] = value;
            }
            else
            {
                HashMapData.Add(key, value);
            }
        }
    }

    public Int32 Count
    {
        get
        {
            return HashMapData.Count;
        }
    }

    public Boolean IsReadOnly
    {
        get
        {
            return false;
        }
    }

    public ICollection<TKey> Keys
    {
        get
        {
            return HashMapData.Keys;
        }
    }

    public ICollection<TValue> Values
    {
        get
        {
            return HashMapData.Values;
        }
    }

    public void Add(KeyValuePair<TKey, TValue> item)
    {
        if (item.Key == null)
        {
            throw new ArgumentNullException("key can't be null.");
        }
        if (HashMapData.ContainsKey(item.Key))
        {
            HashMapData[item.Key] = item.Value;
        }
        else
        {
            HashMapData.Add(item.Key, item.Value);
        }
    }

    public void Add(TKey key, TValue value)
    {
        if (key == null)
        {
            throw new ArgumentNullException("key can't be null.");
        }
        if (HashMapData.ContainsKey(key))
        {
            HashMapData[key] = value;
        }
        else
        {
            HashMapData.Add(key, value);
        }
    }

    public void Clear()
    {
        HashMapData.Clear();
    }

    public Boolean Contains(KeyValuePair<TKey, TValue> item)
    {
        return HashMapData.ContainsKey(item.Key) && HashMapData.ContainsValue(item.Value);
    }

    public Boolean ContainsKey(TKey key)
    {
        return HashMapData.ContainsKey(key);
    }

    public void CopyTo(KeyValuePair<TKey, TValue>[] array, Int32 arrayIndex)
    {
        if (array == null)
        {
            return;
        }
        if (array.Length <= arrayIndex)
        {
            return;
        }
        Int32 count = array.Length;
        for (Int32 i = 0; i < count; i++)
        {
            if (HashMapData.ContainsKey(array[i].Key))
            {
                HashMapData[array[i].Key] = array[i].Value;
            }
            else
            {
                HashMapData.Add(array[i].Key, array[i].Value);
            }
        }
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        return HashMapData.GetEnumerator();
    }

    public Boolean Remove(KeyValuePair<TKey, TValue> item)
    {
        if (HashMapData.ContainsKey(item.Key) && HashMapData.ContainsValue(item.Value))
        {
            return HashMapData.Remove(item.Key);
        }
        return false;
    }

    public Boolean Remove(TKey key)
    {
        return HashMapData.Remove(key);
    }

    public Boolean TryGetValue(TKey key, out TValue value)
    {
        try
        {
            if (HashMapData.ContainsKey(key))
            {
                value = HashMapData[key];
                return true;
            }
            else
            {
                value = default(TValue);
                return false;
            }
        }
        catch
        {
            value = default(TValue);
            return false;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return HashMapData.GetEnumerator();
    }
}

}
//Program Entry @ Program.cs