using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class OtusDictionary
{
    private int[] keys;
    private string[] values;
    private int count; // кол-во значений
    private const int DefaultCapacity = 32;
    public int capacity; // емкость

    public OtusDictionary()
    {
        capacity = DefaultCapacity;
        keys = new int[capacity];
        values = new string[capacity];
        count = 0;
    }

    public void Add(int key, string value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value), "Значение не может быть null");
        }
        if (count == capacity)
            ResizeArray();

        int index = FindEmptyIndex(key);
        keys[index] = key;
        values[index] = value;
        count++;
    }

    public string Get(int key)
    {
        int index = FindKeyIndex(key);

        if (index != -1)
        {
            return values[index];
        }
        else
        {
            throw new KeyNotFoundException("Ключ не найден");
        }
    }

    private void ResizeArray()
    {
        int newCapacity = capacity * 2;
        int[] newKeys = new int[newCapacity];
        string[] newValues = new string[newCapacity];

        for (int i = 0; i < capacity; i++)
        {
            if (values[i] != null)
            {
                int newIndex = FindEmptyIndex(keys[i]);
                newKeys[newIndex] = keys[i];
                newValues[newIndex] = values[i];
            }
        }

        capacity = newCapacity;
        keys = newKeys;
        values = newValues;
    }

    public string this[int key]
    {
        get { return Get(key); }
        set { Add(key, value); }
    }

    private int FindEmptyIndex(int key)
    {
        int index = key % capacity;

        while (values[index] != null && keys[index] != key)
        {
            ResizeArray();
        }

        return index;
    }

    private int FindKeyIndex(int key)
    {
        int index = key % capacity;

        if (values[index] != null)
        {
            return index;
        }

        return -1;
    }
}
