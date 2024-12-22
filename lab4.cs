//----------------------#1---------------------------
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите текст предложения, завершите точкой:");
        string input = Console.ReadLine();

        // Удаляем точку в конце, если она есть
        if (input.EndsWith("."))
        {
            input = input.Substring(0, input.Length - 1);
        }

        // Использование методов класса string
        Dictionary<char, int> charCount = new Dictionary<char, int>();

        // Подсчет символов
        foreach (char c in input)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount[c] = 1;
            }
        }

        Console.WriteLine("Символы, входящие в текст ровно один раз (метод 2):");
        foreach (var pair in charCount)
        {
            if (pair.Value == 1)
            {
                Console.Write(pair.Key + " ");
            }
        }

        Console.WriteLine();
    }
}

//----------------------#2---------------------------
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите текст предложения, завершите точкой:");
        string input = Console.ReadLine();

        // Удаляем точку в конце, если она есть
        if (input.EndsWith("."))
        {
            input = input.Substring(0, input.Length - 1);
        }

        // Использование методов класса string
        string[] words = input.Split(new char[] { ' ', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
        string result = "";

        for (int i = 0; i < words.Length; i++)
        {
            result += words[i] + $"({i + 1})"; // Добавляем слово и номер
            if (i < words.Length - 1)
            {
                result += " "; // Добавляем пробел между словами
            }
        }

        Console.WriteLine("Результат:");
        Console.WriteLine(result);
    }
}

//----------------------#3---------------------------
using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите текст из нескольких слов, завершите точкой:");
        string input = Console.ReadLine();

        // Удаляем точку в конце, если она есть
        if (input.EndsWith("."))
        {
            input = input.Substring(0, input.Length - 1);
        }

        // Использование методов класса string и StringBuilder
        string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder result = new StringBuilder();

        // Перестановка слов в обратном порядке
        for (int i = words.Length - 1; i >= 0; i--)
        {
            result.Append(words[i]);
            if (i > 0)
            {
                result.Append(" "); // Добавляем пробел между словами
            }
        }

        Console.WriteLine("Результат:");
        Console.WriteLine(result.ToString());
    }
}

//----------------------#4---------------------------

using System;

class Program
{
    static void Main()
    {
        string[] lines = new string[7];

        // Ввод 7 строк
        Console.WriteLine("Введите 7 строк:");
        for (int i = 0; i < 7; i++)
        {
            lines[i] = Console.ReadLine();
        }

        // Поиск строк с ".com" и минимальное количество пробелов
        int minSpaces = int.MaxValue;
        int minSpacesLineIndex = -1;

        Console.WriteLine("\nСтроки, содержащие слова, оканчивающиеся на '.com':");
        for (int i = 0; i < lines.Length; i++)
        {
            string[] words = lines[i].Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            int spaceCount = lines[i].Length - lines[i].Replace(" ", "").Length; // Подсчет пробелов

            foreach (string word in words)
            {
                if (word.EndsWith(".com", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(lines[i]);
                    break; // Если нашли слово с .com, выходим из цикла
                }
            }

            if (spaceCount < minSpaces)
            {
                minSpaces = spaceCount;
                minSpacesLineIndex = i;
            }
        }

        Console.WriteLine($"\nНомер строки с наименьшим количеством пробелов: {minSpacesLineIndex + 1} (строка: \"{lines[minSpacesLineIndex]}\")");
    }
}

//----------------------#5---------------------------
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите текст:");
        string input = Console.ReadLine();

        // Обработка строки как массива символов
        char[] characters = input.ToCharArray();
        string word = "";
        bool inWord = false;

        Console.WriteLine("Слова, начинающиеся с большой буквы и заканчивающиеся на две цифры:");
        for (int i = 0; i <= characters.Length; i++)
        {
            if (i == characters.Length || char.IsWhiteSpace(characters[i]) || characters[i] == ',' || characters[i] == '.' || characters[i] == ';')
            {
                if (inWord)
                {
                    // Проверяем, начинается ли слово с большой буквы и заканчивается ли на две цифры
                    if (word.Length >= 2 && char.IsUpper(word[0]) && char.IsDigit(word[word.Length - 1]) && char.IsDigit(word[word.Length - 2]))
                    {
                        Console.WriteLine(word);
                    }
                    word = ""; // Сбрасываем слово
                    inWord = false; // Выходим из слова
                }
            }
            else
            {
                word += characters[i]; // Собираем слово
                inWord = true; // Входим в слово
            }
        }
    }
}
//---------RegExp------------

using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите текст:");
        string input = Console.ReadLine();

        // Использование регулярных выражений
        string pattern = @"\b[A-Z][a-zA-Z0-9]*\d{2}\b";
        MatchCollection matches = Regex.Matches(input, pattern);

        Console.WriteLine("Слова, начинающиеся с большой буквы и заканчивающиеся на две цифры:");
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}

//----------------------#6---------------------------
using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку вида «15 + 36 = 51»: ");
        string input = Console.ReadLine();

        // Регулярное выражение для разбора строки
        string pattern = @"\s*(-?\d+)\s*([\+\-*/])\s*(-?\d+)\s*=\s*(-?\d+)\s*";
        Match match = Regex.Match(input, pattern);

        if (match.Success)
        {
            // Извлечение операндов и суммы
            int operand1 = int.Parse(match.Groups[1].Value);
            string operation = match.Groups[2].Value; // Операция (можно использовать, если нужно)
            int operand2 = int.Parse(match.Groups[3].Value);
            int sum = int.Parse(match.Groups[4].Value);

            // Вывод переменных на консоль
            Console.WriteLine($"Первый операнд: {operand1}");
            Console.WriteLine($"Второй операнд: {operand2}");
            Console.WriteLine($"Сумма: {sum}");
            Console.WriteLine($"Операция: {operation}");
        }
        else
        {
            Console.WriteLine("Строка не соответствует ожидаемому формату.");
        }
    }
}

//----------------------#7---------------------------
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Треклист
        string[] tracklist = new string[]
        {
            "Gentle Giant – Free Hand [6:15]",
            "Supertramp – Child Of Vision [07:27]",
            "Camel – Lawrence [10:46]",
            "Yes – Don’t Kill The Whale [3:55]",
            "10CC – Notell Hotel [04:58]",
            "Nektar – King Of Twilight [4:16]",
            "The Flower Kings – Monsters & Men [21:19]",
            "Focus – Le Clochard [1:59]",
            "Pendragon – Fallen Dream And Angel [5:23]",
            "Kaipa – Remains Of The Day (08:02)"
        };

        TimeSpan totalDuration = TimeSpan.Zero;
        TimeSpan minDuration = TimeSpan.MaxValue;
        TimeSpan maxDuration = TimeSpan.Zero;
        string shortestTrack = "";
        string longestTrack = "";
        List<(string track, TimeSpan duration)> durations = new List<(string, TimeSpan)>();

        // Обработка треклиста
        foreach (var track in tracklist)
        {
            // Извлечение названия трека и времени
            string[] parts = track.Split(new[] { ' ', '[', ']', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            string trackName = string.Join(" ", parts.Skip(1).Take(parts.Length - 2)); // Название трека
            string timePart = parts.Last(); // Время звучания

            // Преобразование времени в TimeSpan
            TimeSpan duration = TimeSpan.Parse(timePart);
            durations.Add((trackName, duration));

            // Суммирование времени
            totalDuration += duration;

            // Поиск самой короткой и самой длинной песни
            if (duration < minDuration)
            {
                minDuration = duration;
                shortestTrack = trackName;
            }
            if (duration > maxDuration)
            {
                maxDuration = duration;
                longestTrack = trackName;
            }
        }

        // Поиск пары песен с минимальной разницей во времени
        (string track1, string track2, TimeSpan minDifference) = FindMinDifference(durations);

        // Вывод результатов
        Console.WriteLine($"Общее время звучания: {totalDuration}");
        Console.WriteLine($"Самая короткая песня: {shortestTrack} ({minDuration})");
        Console.WriteLine($"Самая длинная песня: {longestTrack} ({maxDuration})");
        Console.WriteLine($"Пара песен с минимальной разницей во времени: {track1} и {track2} (разница: {minDifference})");
    }

    static (string, string, TimeSpan) FindMinDifference(List<(string track, TimeSpan duration)> durations)
    {
        TimeSpan minDifference = TimeSpan.MaxValue;
        string track1 = "";
        string track2 = "";

        for (int i = 0; i < durations.Count; i++)
        {
            for (int j = i + 1; j < durations.Count; j++)
            {
                TimeSpan difference = TimeSpan.Abs(durations[i].duration - durations[j].duration);
                if (difference < minDifference)
                {
                    minDifference = difference;
                    track1 = durations[i].track;
                    track2 = durations[j].track;
                }
            }
        }

        return (track1, track2, minDifference);
    }
}

//----------------------ИНДИВИДУАЛЬНОЕ ЗАДАНИЕ--------------------------
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку для шифрования:");
        string input = Console.ReadLine();

        // Шифрование и расшифрование с использованием различных ключей
        string encrypted7 = Encrypt(input, 7);
        string decrypted7 = Decrypt(encrypted7, 7);

        string encrypted8 = Encrypt(input, 8);
        string decrypted8 = Decrypt(encrypted8, 8);

        string encrypted9 = Encrypt(input, 9);
        string decrypted9 = Decrypt(encrypted9, 9);

        // Вывод результатов
        Console.WriteLine($"\nИсходная строка: {input}");
        Console.WriteLine($"Зашифрованная строка (ключ 7): {encrypted7}");
        Console.WriteLine($"Расшифрованная строка (ключ 7): {decrypted7}");
        Console.WriteLine($"Зашифрованная строка (ключ 8): {encrypted8}");
        Console.WriteLine($"Расшифрованная строка (ключ 8): {decrypted8}");
        Console.WriteLine($"Зашифрованная строка (ключ 9): {encrypted9}");
        Console.WriteLine($"Расшифрованная строка (ключ 9): {decrypted9}");
    }

    static string Encrypt(string input, int key)
    {
        char[] characters = input.ToCharArray();
        char[] result = new char[characters.Length];

        // Перестановка символов в зависимости от ключа
        for (int i = 0; i < characters.Length; i++)
        {
            int newIndex = (i + key) % characters.Length; // Новый индекс с учетом ключа
            result[newIndex] = characters[i];
        }

        return new string(result);
    }

    static string Decrypt(string input, int key)
    {
        char[] characters = input.ToCharArray();
        char[] result = new char[characters.Length];

        // Обратная перестановка символов в зависимости от ключа
        for (int i = 0; i < characters.Length; i++)
        {
            int originalIndex = (i - key + characters.Length) % characters.Length; // Исходный индекс
            result[originalIndex] = characters[i];
        }

        return new string(result);
    }
}

//------------#2---------------
//Подход 1: Обработка строки как массива символов
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите текст:");
        string input = Console.ReadLine();
        
        char[] delimiters = { ' ', ',', '.', '!', '?', ';', ':', '\n', '\r' };
        string[] words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        
        string result = "";
        
        foreach (string word in words)
        {
            if (ContainsPlusInMiddle(word))
            {
                result += "CONCAT ";
            }
            else
            {
                result += word + " ";
            }
        }
        
        Console.WriteLine("Результат: " + result.Trim());
    }

    static bool ContainsPlusInMiddle(string word)
    {
        // Проверяем, что символ '+' находится не на первом и не на последнем месте
        return word.Length > 2 && word.Contains('+');
    }
}

//Подход 2: Использование методов классов string и StringBuilder
using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите текст:");
        string input = Console.ReadLine();
        
        char[] delimiters = { ' ', ',', '.', '!', '?', ';', ':', '\n', '\r' };
        string[] words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        
        StringBuilder result = new StringBuilder();
        
        foreach (string word in words)
        {
            if (ContainsPlusInMiddle(word))
            {
                result.Append("CONCAT ");
            }
            else
            {
                result.Append(word + " ");
            }
        }
        
        Console.WriteLine("Результат: " + result.ToString().Trim());
    }

    static bool ContainsPlusInMiddle(string word)
    {
        // Проверяем, что символ '+' находится не на первом и не на последнем месте
        return word.Length > 2 && word.Contains('+');
    }
}

//--------------------#3--------------------------
using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = "IP-адресоа: 192.168.5.48, 10.0.0.1, 255.255.255.255 и 300.300.300.300.";
        
        // Регулярное выражение для поиска IPv4-адресов
        string pattern = @"\b(?:[0-9]{1,3}\.){3}[0-9]{1,3}\b";
        
        // Поиск всех совпадений
        MatchCollection matches = Regex.Matches(input, pattern);
        
        Console.WriteLine("Найденные IPv4-адреса:");
        foreach (Match match in matches)
        {
            // Дополнительная проверка на диапазон 0-255
            string[] parts = match.Value.Split('.');
            bool isValid = true;
            foreach (string part in parts)
            {
                if (int.TryParse(part, out int number))
                {
                    if (number < 0 || number > 255)
                    {
                        isValid = false;
                        break;
                    }
                }
                else
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
