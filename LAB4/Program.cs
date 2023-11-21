using LAB4;

static void Main(string[] args) {
    DataFunc dataFunc = new DataFunc();

    Console.WriteLine("Выберите метод:");
    Console.WriteLine("1.) Получить запись по ID");
    Console.WriteLine("2.) Получить запись по названию");
    Console.WriteLine("3.) Добавить новую запись");
    Console.WriteLine("4.) Изменить сообщение в записи");
    Console.WriteLine("5.) Удалить запись");

    int input = Convert.ToInt32(Console.ReadLine());

    switch (input)
    {
        case 1:
            Console.Write("Введите ID записи: ");
            int id = Convert.ToInt32(Console.ReadLine());
            dataFunc.GetByID(id);
            break;
        case 2:
            Console.Write("Введите название в записи: ");
            string name = Console.ReadLine();
            dataFunc.GetByName(name);
            break;
        case 3:
            Console.WriteLine("Введите данные для новой записи:");
            Console.Write("ID: ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.Write("name: ");
            name = Console.ReadLine();
            Console.Write("message: ");
            string message = Console.ReadLine();
            dataFunc.Add(id, name, message);
            break;
        case 4:
            Console.WriteLine("Введите сообщение и ID для перезаписи:");
            Console.Write("ID: ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.Write("message: ");
            message = Console.ReadLine();
            dataFunc.Update(id, message);
            break;
        case 5:
            Console.WriteLine("Введите ID для удаления:");
            Console.Write("ID: ");
            id = Convert.ToInt32(Console.ReadLine());
            dataFunc.Delete(id);
            break;
        default:
            Console.WriteLine("Нет такого метода");
            break;
    }
}

