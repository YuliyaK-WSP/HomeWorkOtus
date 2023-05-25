using System.Diagnostics;
using System.Collections;
class Program
{

    private static void Main(string[] args)
    {
        PrintList();
        PrintListArray();
        PrintLinkedList();
    }
    public static void PrintList()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        List<int> list = new List<int>(1000000);

        for (int i = 0; i < 1000000; i++)
        {
            list.Add(i);
            //Console.WriteLine($"{list[i]}");     
        }
        SearchPrint(list);
        stopwatch.Stop();
        Console.WriteLine($"Выполнение операции List: {stopwatch.ElapsedMilliseconds} m/s");
    }
    public static void PrintListArray()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        ArrayList arrayList = new ArrayList();
        for (int i = 0; i < 1000000; i++)
        {
            arrayList.Add(i);
            //Console.WriteLine($"{arrayList[i]}");     
        }
        SearchPrint(arrayList);
        stopwatch.Stop();
        Console.WriteLine($"Выполнение операции ArrayList: {stopwatch.ElapsedMilliseconds} m/s");
    }
    public static void PrintLinkedList()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        var linkedList = new LinkedList<int>();
        for (int i = 0; i < 1000000; i++)
        {
            linkedList.AddLast(i);
            //Console.WriteLine($"{linkedList[i]}");     
        }
        SearchPrint(linkedList);
        stopwatch.Stop();
        Console.WriteLine($"Выполнение операции LinkedList: {stopwatch.ElapsedMilliseconds} m/s");
    }
    public static void SearchPrint(Object obj)
    {
        int search = 496753;
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        switch (obj)
        {
            case List<int>:

                for (int i = 0; i < ((List<int>)obj).Count; i++)
                {
                    if (i == search)
                    {
                        Console.WriteLine("Элемент 496753  найден");
                        break;
                    }
                }
                break;
            case ArrayList:
                for (int i = 0; i < ((ArrayList)obj).Count; i++)
                {
                    if (i == search)
                    {
                        Console.WriteLine("Элемент 496753  найден");
                        break;
                    }
                }
                break;
            case LinkedList<int>:
                for (int i = 0; i < ((LinkedList<int>)obj).Count; i++)
                {
                    if (i == search)
                    {
                        Console.WriteLine("Элемент 496753  найден");
                        break;
                    }
                }
                break;
        }
        stopwatch.Stop();
        Console.WriteLine($"Выполнение операции {obj.GetType().Name} Search: {stopwatch.ElapsedMilliseconds} m/s");


        /*if (obj.GetType() == typeof (List<int>))
        {
         Console.WriteLine($"Выполнение операции не возможно");
        }
        */
    }
}
