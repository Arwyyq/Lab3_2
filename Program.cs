using System.Collections;
using System.Collections.Generic;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

MyString[] myArray = new MyString[5]
{
    new MyString("Перший рядок"),
    new MyString("Другий рядок"),
    new MyString("Третій рядок"),
    new MyString("Четвертий рядок"),
    new MyString("П'ятий рядок")
};

// Створює динамічний список на основі нашого масиву
List<MyString> myList = new List<MyString>(myArray);

BinarySearchTree myTree = new BinarySearchTree();
foreach (var item in myList)
{
    myTree.Insert(item);
}


while (true)
{
    Console.WriteLine("1. Вивести всі елементи масиву");
    Console.WriteLine("2. Пошук підряка в масиві");
    Console.WriteLine("3. Заміна підрядка в масиві");
    Console.WriteLine("4. Додати новий рядок");
    Console.WriteLine("5. Видалити рядок за номером");
    Console.WriteLine("6. Вивести бінарне дерево (в алфавітному порядку)");
    Console.WriteLine("0. Вийти");
    Console.Write("Виберіть опцію: ");

    string choice = Console.ReadLine() ?? "";

    if (choice == "1")
    {
        Console.WriteLine("\n - = - Всі елементи масиву - = -"); //проходиться циклом foreach по MyArray і викликається Print()
        for (int i = 0; i < myList.Count; i++)
        {
            myList[i].Print(i + 1);
        }
        Console.WriteLine("-- -=- --- -=- -- -=- --- -=- --");
    }

    else if (choice == "2")
    {
        Console.Write("Введіть підрядок для пошуку: ");
        string sub = (Console.ReadLine() ?? "").Trim(); //зчитується текст від користувача

        Console.WriteLine("- = - Результат пошуку - = -");
        int index = 1;
        foreach (var item in myArray)
        {
            if (item.searchSub(sub))
            {
                item.Print(index);
            }
            index++;
        }
        Console.WriteLine("-- -=- --- -=- -- -=- --- -=- --");

    }

    else if (choice == "3")
    {
        Console.Write("Введіть текст, який треба замінити: ");
        string oldValue = (Console.ReadLine() ?? "").Trim();
        Console.Write("Введіть новий текст: ");
        string newValue = (Console.ReadLine() ?? "").Trim();

        foreach (var item in myArray)
        {
            item.replaceSub(oldValue, newValue);
        }
        Console.WriteLine("Заміну виконано успішно!");
    }

    else if (choice == "4")
    {
        Console.WriteLine("Введіть новий текст: ");
        string text = (Console.ReadLine() ?? "").Trim();

        myList.Add(new MyString(text));
        Console.WriteLine("Рядок успішно додано до списку!");
    }

    else if (choice == "5")
    {
        Console.WriteLine("Введіть номер рядка для видалення: ");
        if (int.TryParse(Console.ReadLine(), out int num) && num > 0 && num <= myList.Count)
        {
            myList.RemoveAt(num - 1);
            Console.WriteLine("Рядок успішно видалено");
        }
    }

    else if (choice == "6")
    {
        Console.WriteLine("\n- = - Графічна структура бінарного дерева - = -");

        // Перебудовує дерево на основі актуальних елементів з myList
        myTree = new BinarySearchTree();
        foreach (var item in myList)
        {
            myTree.Insert(item);
        }

        if (myTree.Root == null)
        {
            Console.WriteLine("Дерево порожнє!");
        }
        else
        {
            myTree.PrintTree(myTree.Root);
        }
    }

    else if (choice == "0")
    {
        Console.WriteLine("Вихід з програми");
        break;
    }

    else
    {
        Console.WriteLine("Невілома команда, спробуйте ще раз!");
    }
}