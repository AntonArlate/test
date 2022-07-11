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


int[] ArrayExtension(int[] innerArray, int newNumber) // расширение массива, так как просто дописать в C# не знаю как
{
    int[] tempArray = new int[innerArray.Length + 1];
    Array.Copy(innerArray, tempArray, innerArray.Length);
    tempArray[tempArray.Length - 1] = newNumber;
    return tempArray;
}
