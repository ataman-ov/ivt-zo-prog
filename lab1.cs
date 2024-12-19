using System;

class Program
{
    static void Main()
    {
        // Пример положительного вещественного числа
        double x = 21.3198;

        // Преобразуем число в строку
        string xString = x.ToString();

        // Находим позицию запятой или точки
        int decimalPointIndex = xString.IndexOf(',');

        // Проверяем, что дробная часть существует
        if (decimalPointIndex != -1 && decimalPointIndex < xString.Length - 1)
        {
            // Извлекаем первую цифру дробной части
            char firstDecimalDigit = xString[decimalPointIndex + 1];

            // Преобразуем символ в целое число
            int d = (int)char.GetNumericValue(firstDecimalDigit);

            // Выводим результат
            Console.WriteLine($"Первая цифра дробной части: {d}");
        }
        else
        {
            Console.WriteLine($"Дробная часть отсутствует. ");
        } 
    }
}
