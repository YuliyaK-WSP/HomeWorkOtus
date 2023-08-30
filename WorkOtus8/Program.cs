internal partial class Program
{
    private static void Main(string[] args)
    {
        BinaryTree binaryTree = new BinaryTree();

        while (true)
        {
            Console.WriteLine("Введите имя сотрудника (или пустую строку для завершения): ");
            string name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                break;
            }

            Console.WriteLine("Введите зарплату сотрудника: ");
            int salary = int.Parse(Console.ReadLine());

            binaryTree.Insert(name, salary);
        }
        Employee root = binaryTree.GetRoot();
        PrintEmployees(root);
        int restart;
        do
        {
            Console.WriteLine("Введите размер зарплаты сотрудника: ");
            int searchSalary = int.Parse(Console.ReadLine());

            binaryTree.Search(searchSalary, binaryTree.GetRoot());

            Console.WriteLine(
                "Введите цифру 0 для перехода к началу программы или 1 для нового поиска зарплаты"
            );
            restart = int.Parse(Console.ReadLine());
        } while (restart == 1);
    }

    static void PrintEmployees(Employee node)
    {
        if (node != null)
        {
            PrintEmployees(node.Left);
            Console.WriteLine($"Имя: {node.Name}, Зарплата: {node.Salary}");
            PrintEmployees(node.Right);
        }
    }
}
