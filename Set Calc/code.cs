using System;
using System.Collections.Immutable;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

class Program
{
    static int[] Universum = new int[201];
    static List<int> setA = new List<int>();
    static List<int> setB = new List<int>();
    static List<int> setC = new List<int>();

    static void Main()
    {
        // Заполнение Юниверсум множества
        for (int i = 0; i < Universum.Length; i++)
        {
            Universum[i] = i - 100;
        }
        Menu();
    }

    static void Menu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("1. Создать/изменить множества");
            Console.WriteLine("2. Вывести множества");
            Console.WriteLine("3. Рассчитать формулу");
            Console.WriteLine("4. Выход");


            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateSet();
                    break;
                case "2":
                    Console.Write("A = ");
                    PrintList(setA);
                    Console.Write("B = ");
                    PrintList(setB);
                    Console.Write("C = ");
                    PrintList(setC);
                    break;
                case "3":
                    CalculateExseption();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Некорректный ввод, попробуйте снова.");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
            }
        } 
    }


    // Пункт меню 1 - создание множества
    static void CreateSet()
    {
        bool back = false;

        while (!back)
        {
            Console.Clear();
            Console.WriteLine("1. Множество А");
            Console.WriteLine("2. Множество B");
            Console.WriteLine("3. Множество C");
            Console.WriteLine("4. Назад");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    WayToCreate("A", ref setA);
                    break;
                case "2":
                    WayToCreate("B", ref setB);
                    break;
                case "3":
                    WayToCreate("C", ref setC);
                    break;
                case "4":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Некорректный ввод, попробуйте снова.");
                    break;
            }
        }
    }

    // Подменю пункта 1
    static void WayToCreate(string setName, ref List<int> set)
    {
        bool back = false;

        while (!back)
        {
            Console.Clear();
            Console.WriteLine($"=== Заполнение множества {setName} ===");
            Console.WriteLine($"1. Заполнить множество {setName} самостоятельно");
            Console.WriteLine($"2. Заполнить множество {setName} рандомайзером");
            Console.WriteLine($"3. Заполнить множество {setName} с условием кратности");
            Console.WriteLine($"4. Заполнить множество {setName} с условием диапазона");
            Console.WriteLine($"5. Назад");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine($"Вы выбрали заполнение множества {setName} самостоятельно.");
                    set = CreateAndFillArray(setName);
                    break;
                case "2":
                    Console.WriteLine($"Вы выбрали заполнение множества {setName} рандомайзером.");
                    set = CreateRandomArray(setName);
                    break;
                case "3":
                    Console.WriteLine($"Вы выбрали заполнение множества {setName} с условием кратности.");
                    set = MultiplicityArray(setName);
                    break;
                case "4":
                    Console.WriteLine($"Вы выбрали заполнение множества {setName} с условием диапазона.");
                    set = RangeArray(setName);
                    break;
                case "5":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Неккоректный ввод. Попробуйте снова.");
                    break;

            }
            if (!back)
            {
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
            }
        }
    }



    // Ввод множества пользователем
    static List<int> CreateAndFillArray(string listName)
    {
        Console.Write($"Введите количество элементов множества {listName}: ");
        int size;
        while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
        {
            Console.Write($"Введите количество элементов множества {listName}: ");
        }

        List<int> list = new List<int>(); ;

        Console.WriteLine($"Введите элементы (по одному числу на строку):");
        int element;
        for (int i = 0; i < size; i++)
        {
            while (!int.TryParse(Console.ReadLine(), out element) || element < -100 || element > 100 || list.Contains(element))
            {
                Console.WriteLine("Неккоректный ввод. Введите заново: ");
            }
            list.Add(element);
        }

        return list;
    }


    // Создание множества рандомайзером
    static List<int> CreateRandomArray(string listName)
    {
        Random random = new Random();

        Console.Write($"Введите количество элементов множества {listName}: ");

        int size;
        while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
        {
            Console.Write($"Введите количество элементов множества {listName}: ");
        }

        List<int> list = new List<int>();

        for (int i = 0; i < size; i++)
        {
            int element = random.Next(-100, 101);
            if (!list.Contains(element))
            {
                list.Add(element);
            }

            else
            {
                i--;
            }
        }

        return list;
    }


    // Создание множества с  условием диапазона
    static List<int> RangeArray(string listName)
    {


        Console.Write($"Введите левую границу: ");
        int min;
        while (!int.TryParse(Console.ReadLine(), out min) || min < -100)
        {
            Console.Write($"Ошибка. Введите левую границу: ");
        }


        Console.Write($"Введите правую границу: ");
        int max;
        while (!int.TryParse(Console.ReadLine(), out max) || max > 100 || max < min)
        {
            Console.Write($"Ошибка. Введите правую границу: ");
        }

        int size = max - min + 1;
        List<int> list = new List<int>();

        for (int i = min; i <= max; i++)
        {
            list.Add(i);
        }

        return list;

    }


    // Создание множества с условием кратности
    static List<int> MultiplicityArray(string listName)
    {
        Console.Write($"Какому числу должны быть кратны элементы? ");
        int k;
        while (!int.TryParse(Console.ReadLine(), out k) || k == 0)
        {
            Console.Write($"Ошибка ввода. Введите заново: ");
        }

        List<int> resList = new List<int>();


        for (int element = -100; element < 100; element++)
        {
            if (element % k == 0)
            {
                resList.Add(element);
            }
        }

        return resList;

    }


    static void PrintList(List<int> list)
    {
        Console.WriteLine("{" + string.Join(", ", list) + "}");
    }


    static List<int> Union(List<int> setA, List<int> setB)
    {
        List<int> resList = new List<int>();

        foreach (int i in setA)
        {
            if (!resList.Contains(i))
            {
                resList.Add(i);
            }
        }

        foreach (int i in setB)
        {
            if (!resList.Contains(i))
            {
                resList.Add(i);
            }
        }

        return resList;
    }


    static List<int> Intersection(List<int> setA, List<int> setB)
    {
        List<int> resList = new List<int>();

        foreach (int i in setA)
        {
            if (setB.Contains(i))
            {
                resList.Add(i);
            }
        }

        return resList;
    }


    static List<int> Denial(List<int> setA)
    {
        List<int> resList = new List<int>();

        int n = -100;

        while (n < 101)
        {
            if (!setA.Contains(n))
            {
                resList.Add(n);
            }
            n++;
        }
        return resList;
    }


    static List<int> Difference(List<int> setA, List<int> setB)
    {
        List<int> resList = new List<int>();

        foreach (int i in setA)
        {
            if (!setB.Contains(i))
            {
                resList.Add(i);
            }
        }

        return resList;
    }


    static List<int> SymmetricDifference(List<int> setA, List<int> setB)
    {
        List<int> resList = new List<int>();

        foreach (int i in setA)
        {
            if (!setB.Contains(i))
            {
                resList.Add(i);
            }
        }

        foreach (int i in setB)
        {
            if (!setA.Contains(i))
            {
                resList.Add(i);
            }
        }

        return resList;
    }



    static List<int> EvaluateExpression(string expression, Dictionary<string, List<int>> sets)
    {
        Stack<List<int>> operands = new Stack<List<int>>(); // Стек для хранения операндов (множеств)
        Stack<char> operators = new Stack<char>();  // Стек для хранения операторов

        // Проходим по каждому символу в выражении
        for (int i = 0; i < expression.Length; i++)
        {
            char token = expression[i];

            // Игнорируем пробелы
            if (token == ' ')
                continue;

            // Если встречаем открывающую скобку, добавляем в стек операторов
            if (token == '(')
            {
                operators.Push(token);
            }
            // Если встречаем закрывающую скобку
            else if (token == ')')
            {
                // Выполняем операции до тех пор, пока не встретим открывающую скобку
                while (operators.Peek() != '(')
                {
                    char op = operators.Pop(); // Извлекаем оператор

                    // Проверяем, является ли оператор унарным
                    if (op == '!')
                    {
                        // Унарный оператор: получаем операнд и применяем оператор
                        List<int> setA = operands.Pop();
                        operands.Push(ApplyUnaryOperator(setA, op));
                    }
                    else
                    {
                        // Бинарный оператор: получаем два операнда и применяем оператор
                        List<int> setB = operands.Pop();
                        List<int> setA = operands.Pop();
                        operands.Push(ApplyOperator(setA, setB, op));
                    }
                }
                operators.Pop(); // Убираем '(' из стека
            }
            // Если встречаем оператор
            else if (IsOperator(token))
            {
                // Применяем операторы с более высоким приоритетом
                while (operators.Count > 0 && Priority(operators.Peek()) >= Priority(token))
                {
                    char op = operators.Pop(); // Извлекаем оператор

                    // Проверяем, является ли оператор унарным
                    if (op == '!')
                    {
                        // Унарный оператор: получаем операнд и применяем оператор
                        List<int> setA = operands.Pop();
                        operands.Push(ApplyUnaryOperator(setA, op));
                    }
                    else
                    {
                        // Бинарный оператор: получаем два операнда и применяем оператор
                        List<int> setB = operands.Pop();
                        List<int> setA = operands.Pop();
                        operands.Push(ApplyOperator(setA, setB, op));
                    }
                }
                // Добавляем текущий оператор в стек
                operators.Push(token);
            }
            // Если это переменная множества (например, A, B, C)
            else
            {
                string setName = token.ToString(); // Преобразуем символ в строку
                operands.Push(sets[setName]); // Получаем множество и добавляем его в стек операндов
            }
        }

        // Применение оставшихся операторов после завершения прохода по выражению
        while (operators.Count > 0)
        {
            char op = operators.Pop(); // Извлекаем оператор

            // Проверяем, является ли оператор унарным
            if (op == '!')
            {
                // Унарный оператор: получаем операнд и применяем оператор
                List<int> setA = operands.Pop();
                operands.Push(ApplyUnaryOperator(setA, op));
            }
            else
            {
                // Бинарный оператор: получаем два операнда и применяем оператор
                List<int> setB = operands.Pop();
                List<int> setA = operands.Pop();
                operands.Push(ApplyOperator(setA, setB, op));
            }
        }

        // Возвращаем окончательный результат (остается только одно множество в стеке)
        return operands.Pop();
    }

    // Метод для применения унарного оператора
    static List<int> ApplyUnaryOperator(List<int> setA, char op)
    {
        switch (op)
        {
            case '!':
                return Denial(setA); // Дополнение множества
            default:
                throw new ArgumentException("Unknown operator");
        }
    }

    // Метод для проверки, является ли символ оператором
    static bool IsOperator(char c)
    {
        return c == '&' || c == '|' || c == '-' || c == '!' || c == '^';
    }

    // Метод для определения приоритета оператора
    static int Priority(char c)
    {
        if (c == '!') return 3; // Унарный оператор имеет самый высокий приоритет
        if (c == '&') return 2; // Пересечение
        if (c == '|') return 1; // Объединение
        if (c == '-') return 1; // Разность
        if (c == '^') return 1; // Симметрическая разность
        return 0; // Если оператор не распознан, возвращаем 0
    }

    // Метод для применения бинарных операторов
    static List<int> ApplyOperator(List<int> setA, List<int> setB, char op)
    {
        switch (op)
        {
            case '&':
                return Intersection(setA, setB); // Пересечение
            case '|':
                return Union(setA, setB); // Объединение
            case '-':
                return Difference(setA, setB); // Разность
            /*case '!':
                return Denial(setA); // Унарный оператор*/
            case '^':
                return SymmetricDifference(setA, setB); // Симметрическая разность
            default:
                throw new ArgumentException("Unknown operator");
        }
    }

    static void CalculateExseption()
    {
        bool validInput = false;

        while (!validInput)
        {
            try
            {
                Console.WriteLine("Обозначения для ввода выражения: «&» - пересечение, " +
                               "«|» - объединение, «-» - разность,\n «^» - симметрическая разность, «!» - дополнение.");
                Console.WriteLine("Введите выражение: ");
                string expression = Console.ReadLine();

                if(!IsValidExpression(expression))
                {
                    Console.WriteLine("Ошибка при вводе выражения!");
                    continue;
                }
                var sets = new Dictionary<string, List<int>>
                        {
                            { "A", setA },
                            { "B", setB },
                            { "C", setC }
                        };

                List<int> result = EvaluateExpression(expression, sets);
                PrintList(result);
                validInput = true;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при вычислении выражения: {ex.Message}");
                Console.WriteLine("Попробуйте ввести выражение заново.");
            }
        }
    }

    static bool IsValidExpression(string expression)
    {
        char[] validOperands = { 'A', 'B', 'C' };
        char[] validOperations = { '&', '|', '-', '^' };
        char prev = '\0';

        for (int i = 0; i < expression.Length; i++)
        {
            char  current = expression[i];
            
            // Если встретился пробел, то пропускаем
            if (current == ' ') continue;

            // Если встретилось множество
            if (validOperands.Contains(current))
            {
                if ((char.IsLetter(prev) || prev == ')'))
                {
                    return false;
                }

                prev = current;
            }

            // Если встретился бинарный оператор
            else if(validOperations.Contains(current))
            {
                if (prev == '\0' && (validOperations.Contains(prev) || prev == '(' || prev == '!'))
                {
                    return false;
                }

                prev = current;
            }

            //Если встретился унарный оператор
            else if (current == '!')
            {
                if (prev == ')' || char.IsLetter(prev))
                {
                    return false;
                }

                prev = current;
            }

            // Если встретилась открывающаяa скобка
            else if (current == '(')
            {
                if (char.IsLetter(prev) || prev == ')')
                {
                    return false;
                }

                prev = current;
            }

            // Если встретилась закрывающая скобка
            else if (current == ')')
            {
                if (prev == '(' || prev == '!' || validOperations.Contains(prev))
                {
                    return false;
                }

                prev = current;
            }

            else
            {
                return false;
            }
        }
        return (!validOperations.Contains(prev) || prev == '!');
    }
}
