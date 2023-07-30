class BinaryTree 
{
	private Employee root;

	public void Insert(string name, int salary)
	{
		Employee newNode = new Employee { Name = name, Salary = salary };

        if (root == null)
        {
            root = newNode;
            return;
        }

        Employee current = root;
        Employee parent = null;

        while (current != null)
        {
            parent = current;

            if (salary < current.Salary)
            {
                current = current.Left;
            }
            else
            {
                current = current.Right;
            }
        }

        if (salary < parent.Salary)
        {
            parent.Left = newNode;
        }
        else
        {
            parent.Right = newNode;
        }

	}
	public Employee GetRoot()
    {
        return root;
    }
	public void Search(int salary, Employee node)
	{
		if(node == null)
		{
			Console.WriteLine("Сотрудник с такой зарплатой не найден");
		}
		else if(salary == node.Salary)
		{
			Console.WriteLine($"Имя: {node.Name}, Зарплата: {node.Salary}");
		}
		else if(salary < node.Salary)
		{
			Search(salary, node.Left);
		}
		else if(salary > node.Salary)
		{
			Search(salary, node.Right);
		}
	}

}