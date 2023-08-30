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
    private int capacity; // емкость

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

        if (FindIndex(key) != -1)
            throw new ArgumentException("Элемент с таким ключом уже существует.");

        keys[count] = key;
        values[count] = value;
        count++;
    }

    public string Get(int key)
    {
        int index = FindIndex(key);
        if (index != -1)
            return values[index];

        return null;
    }

    private void ResizeArray()
    {
        int newCapacity = capacity * 2;
        int[] newKeys = new int[newCapacity];
        string[] newValues = new string[newCapacity];

        for (int i = 0; i < count; i++)
        {
            newKeys[i] = keys[i];
            newValues[i] = values[i];
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

    private int FindIndex(int key)
    {
        for (int i = 0; i < count; i++)
        {
            if (keys[i] == key)
                return i;
        }

        return -1;
    }
}
