int programm;
Boolean begin = true;

while (begin)
{
    Console.WriteLine("------");
    Console.WriteLine("Введите число для соответствующей задачи или иное для выхода:");
    Console.WriteLine("1. Вариант 1");
    Console.WriteLine("2. Вариант 2");

    programm = Convert.ToInt32(Console.ReadLine());

    switch (programm)
    {
        case 1:
            Method1();
            break;

        case 2:
            Method2();
            break;

        default:
            begin = false;
            break;
    }
}



void Method1()
{
    // Программа 1

    int[] array = { };
    string inputString;
    string tempString = String.Empty;
    int inputNumber = 0;
    int tempParseNum;
    bool checkDounleChar = true;

    Console.WriteLine("Введите последовательность чисел разделёных любыми знаками (кроме пустых пробелов):");
    inputString = Console.ReadLine();

    foreach (char charOfInputString in inputString) // одна проблема, если заканчивает работу на цифре, то ArrayExtension не срабатывает
    {
        tempString = tempString + charOfInputString;
        if (int.TryParse(tempString, out tempParseNum)) //проверяем временную строку на числа
        {
            inputNumber = tempParseNum;
            checkDounleChar = false;
        }
        else
        {
            if (checkDounleChar) tempString = String.Empty; // проверяем не был ли предыдущий знак не числом, иначе вызовется повторно метод
            else
            {
                array = ArrayExtension(array, inputNumber);
                checkDounleChar = true;
                tempString = String.Empty;
            }
        }
    }

    Console.WriteLine($"[{String.Join("; ", array)}]");
}

void Method2()
{
    string[] tempStringArr = { };
    int[] array = { };
    string inputString;
    int tempParseNum;
    bool checkDounleChar = true;

    Console.WriteLine("Введите последовательность чисел разделёных любыми знаками:");
    inputString = Console.ReadLine();

    for (int i = 0; i < inputString.Length; i++) // На выходе должны получить строку где все НЕ цифры заменены пробелами
    {
        //simbolInIndex = inputString[i];

        if (int.TryParse(Convert.ToString(inputString[i]), out tempParseNum)) //проверяем временную строку на числа
        {
            checkDounleChar = false;
        }
        else //Заменяем символы пробелом. 
             //Можно попробовать Replace, но я побоялся что она будет сканировать всю строку для каждого уникального символа
        {
            if (checkDounleChar) // удаляем двойные символы
            {
                inputString = inputString.Remove(i, 1);
                checkDounleChar = true;
                i--;
            }
            else
            {
                inputString = inputString.Remove(i, 1);
                inputString = inputString.Insert(i, " ");
                checkDounleChar = true;
            }

        }
    }

    if (checkDounleChar) inputString = inputString.Remove(inputString.Length - 1, 1); // удаляем последний символ если не цифра

    Console.WriteLine(inputString);
    tempStringArr = inputString.Split(' '); // разбиваем строку на массив

    array = new int[tempStringArr.Length];

    for (int i = 0; i < tempStringArr.Length; i++) // преобразуем масив string в int
    {
        array[i] = Convert.ToInt32(tempStringArr[i]);
    }
    Console.WriteLine($"[{String.Join("; ", array)}]");

    // array = Array.ConvertAll<string, Int32>(tempString, new Converter<string, Int32> converter ); // не получилось с convertAll



    // foreach (string obj in tempString)
    // {
    //     Console.WriteLine(obj);
    // }

    // foreach (string obj in tempString)
    // {
    //     Console.WriteLine(obj);
    // }


    // 
}



int[] ArrayExtension(int[] innerArray, int newNumber) // расширение массива, так как просто дописать в C# не знаю как
{
    int[] tempArray = new int[innerArray.Length + 1];
    Array.Copy(innerArray, tempArray, innerArray.Length);
    tempArray[tempArray.Length - 1] = newNumber;
    return tempArray;
}
