using System;
using System.Collections.Generic;

class Program
{
    // Структура для хранения данных
    struct Record
    {
        public int ID;
        public string Name;
        public double Value;
    }

    // Структура для хранения логов
    struct LogEntry
    {
        public DateTime Timestamp;
        public string Operation;
        public string RecordInfo;
    }

    // Лог действий пользователя
    static List<LogEntry> log = new List<LogEntry>();
    static DateTime lastActionTime = DateTime.Now;

    static void Main()
    {
        // Массив для хранения записей
        List<Record> records = new List<Record>();

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1 – Просмотр таблицы");
            Console.WriteLine("2 – Добавить запись");
            Console.WriteLine("3 – Удалить запись");
            Console.WriteLine("4 – Обновить запись");
            Console.WriteLine("5 – Поиск записей");
            Console.WriteLine("6 – Просмотреть лог");
            Console.WriteLine("7 – Выход");
            Console.Write("Выберите действие: ");
            int choice = int.Parse(Console.ReadLine());

            DateTime actionTime = DateTime.Now;
            TimeSpan idleTime = actionTime - lastActionTime;
            lastActionTime = actionTime;

            switch (choice)
            {
                case 1:
                    ViewTable(records);
                    break;
                case 2:
                    AddRecord(records);
                    break;
                case 3:
                    DeleteRecord(records);
                    break;
                case 4:
                    UpdateRecord(records);
                    break;
                case 5:
                    SearchRecords(records);
                    break;
                case 6:
                    ViewLog();
                    break;
                case 7:
                    Console.WriteLine("Выход из программы.");
                    return;
                default:
                    Console.WriteLine("Неверный выбор, попробуйте снова.");
                    break;
            }

            // Логирование времени простоя
            if (idleTime > TimeSpan.Zero)
            {
                LogIdleTime(idleTime);
            }
        }
    }

    // Просмотр таблицы
    static void ViewTable(List<Record> records)
    {
        Console.WriteLine("\nТаблица данных");
        Console.WriteLine("=====================================");
        Console.WriteLine("|  ID  |   Name   |   Value   |");
        Console.WriteLine("=====================================");
        foreach (var record in records)
        {
            Console.WriteLine($"| {record.ID,-4} | {record.Name,-8} | {record.Value,-9:F2} |");
        }
        Console.WriteLine("=====================================");
        LogAction("Просмотр таблицы", "");
    }

    // Добавление записи
    static void AddRecord(List<Record> records)
    {
        Console.WriteLine("\nДобавить запись:");

        Record newRecord = new Record();
        Console.Write("ID (целое число): ");
        newRecord.ID = int.Parse(Console.ReadLine());

        Console.Write("Name (строка): ");
        newRecord.Name = Console.ReadLine();

        Console.Write("Value (вещественное число): ");
        newRecord.Value = double.Parse(Console.ReadLine());

        records.Add(newRecord);
        LogAction("Добавлена запись", $"ID: {newRecord.ID}, Name: {newRecord.Name}");
    }

    // Удаление записи
    static void DeleteRecord(List<Record> records)
    {
        Console.Write("\nВведите номер записи для удаления (ID): ");
        int idToDelete = int.Parse(Console.ReadLine());

        var recordToDelete = records.Find(r => r.ID == idToDelete);
        if (recordToDelete.ID != 0)
        {
            records.Remove(recordToDelete);
            LogAction("Удалена запись", $"ID: {idToDelete}, Name: {recordToDelete.Name}");
        }
        else
        {
            Console.WriteLine("Запись с таким ID не найдена.");
        }
    }

    // Обновление записи
    static void UpdateRecord(List<Record> records)
    {
        Console.Write("\nВведите номер записи для обновления (ID): ");
        int idToUpdate = int.Parse(Console.ReadLine());

        var recordToUpdate = records.Find(r => r.ID == idToUpdate);
        if (recordToUpdate.ID != 0)
        {
            Console.WriteLine("Обновление записи:");

            Console.Write("New Name: ");
            recordToUpdate.Name = Console.ReadLine();

            Console.Write("New Value: ");
            recordToUpdate.Value = double.Parse(Console.ReadLine());

            int index = records.IndexOf(recordToUpdate);
            records[index] = recordToUpdate;

            LogAction("Обновлена запись", $"ID: {idToUpdate}, New Name: {recordToUpdate.Name}");
        }
        else
        {
            Console.WriteLine("Запись с таким ID не найдена.");
        }
    }

    // Поиск записей
    static void SearchRecords(List<Record> records)
    {
        Console.Write("\nВведите фильтр для поиска (например, имя или диапазон значений): ");
        string filter = Console.ReadLine();

        var filteredRecords = records.FindAll(r => r.Name.Contains(filter) || r.Value.ToString().Contains(filter));

        if (filteredRecords.Count > 0)
        {
            Console.WriteLine("\nРезультаты поиска:");
            Console.WriteLine("=====================================");
            Console.WriteLine("|  ID  |   Name   |   Value   |");
            Console.WriteLine("=====================================");
            foreach (var record in filteredRecords)
            {
                Console.WriteLine($"| {record.ID,-4} | {record.Name,-8} | {record.Value,-9:F2} |");
            }
            Console.WriteLine("=====================================");
        }
        else
        {
            Console.WriteLine("Записи, соответствующие фильтру, не найдены.");
        }

        LogAction("Поиск с фильтром", filter);
    }

    // Просмотр лога действий
    static void ViewLog()
    {
        Console.WriteLine("\nЛог действий:");
        foreach (var logEntry in log)
        {
            Console.WriteLine($"{logEntry.Timestamp:HH:mm:ss} – {logEntry.Operation} \"{logEntry.RecordInfo}\"");
        }

        LogIdleTimeReport();
    }

    // Логирование действия
    static void LogAction(string operation, string recordInfo)
    {
        if (log.Count >= 50)
        {
            log.RemoveAt(0); // Удалить самую старую запись
        }

        log.Add(new LogEntry
        {
            Timestamp = DateTime.Now,
            Operation = operation,
            RecordInfo = recordInfo
        });
    }

    // Логирование времени простоя
    static void LogIdleTime(TimeSpan idleTime)
    {
        // Форматируем время простоя в виде строки
        string idleTimeStr = idleTime.ToString(@"hh\:mm\:ss");
        Console.WriteLine($"\nВремя простоя: {idleTimeStr}");
    }

    // Отчет о времени самого долгого простоя
    static void LogIdleTimeReport()
    {
        TimeSpan maxIdleTime = TimeSpan.Zero;

        for (int i = 1; i < log.Count; i++)
        {
            TimeSpan idleTime = log[i].Timestamp - log[i - 1].Timestamp;
            if (idleTime > maxIdleTime)
            {
                maxIdleTime = idleTime;
            }
        }

        Console.WriteLine($"\n{maxIdleTime:hh\\:mm\\:ss} – Самый долгий период бездействия пользователя");
    }
}

