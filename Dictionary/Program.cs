using System;
using System.Collections.Generic;
using System.Collections;
namespace Dictionary
{
    public class Program
    {
        public static void Main()
        {
            // Создаем коллекцию из пар ключ/значение – оба типа string.
            Dictionary<string, string> FileAssos =
                new Dictionary<string, string>();
            // Добавляем элементы в коллекцию.
            FileAssos.Add("txt", "notepad.exe");
            FileAssos.Add("rar", "winrar.exe");
            FileAssos.Add("jpg", "photoshop.exe");
            FileAssos.Add("docx", "winword.exe");

            // Следующая строка кода вызовет исключение. Поскольку с ключом rar ассоциировано значение winrar.

            try
            {
                FileAssos.Add("rar", "winzip.exe");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Элемент с ключом = \"rar\" уже присутствует в коллекции.");
            }

            // Получаем доступ через индексатор.
            Console.WriteLine("Для ключа = \"jpg\", значение = {0}.",
                FileAssos["jpg"]);

            // Используем индексатор для изменения значения в ассоциированной с ключом.
            FileAssos["jpg"] = "Paint.exe";
            Console.WriteLine("Для ключа= \"jpg\", значение = {0}.",
                FileAssos["jpg"]);

            // используем индексатор для добавления нового значения элемента коллекции, в виде структуры KeyValuePair.
            FileAssos["cfg"] = "cfgreader.exe";

            // С помощью индексатора обращаемся к коллекции по несуществующему ключу. Будет сгенерировано исключение.
            try
            {
                Console.WriteLine("Для ключа = \"xls\", значение = {0}.",
                    FileAssos["xls"]);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Ключ = \"xls\" не был найден в коллекции.");
            }

            // Получаем значение из структуры KeyValuePair по ключу с помощью метода TryGetValue.
            string value = "";
            if (FileAssos.TryGetValue("xls", out value))
            {
                Console.WriteLine("Для ключа = \"xls\", значение = {0}.", value);
            }
            else
            {
                Console.WriteLine("Ключ = \"xls\" не найден.");
            }

            // Чтобы проверить вхождение ключа в коллекцию перед добавлением, следует использовать метод ContainsKey.
            if (!FileAssos.ContainsKey("ht"))
            {
                FileAssos.Add("mp3", "aimp.exe");
                Console.WriteLine("Значение добавлено по ключу = \"mp3\": {0}",
                    FileAssos["mp3"]);
            }

            // При использовании конструкции foreach для перебора элементов словаря в качестве обьектов используется структура KeyValuePair.
            Console.WriteLine();
            foreach (KeyValuePair<string, string> element in FileAssos)
            {
                Console.WriteLine("Ключ = {0}, Значение = {1}",
                    element.Key, element.Value);
            }

            // Чтобы получить список всех значений коллекции нужно использовать свойство Values.
            Dictionary<string, string>.ValueCollection TempvaluesColl =
                FileAssos.Values;

            Console.WriteLine();
            foreach (string str in TempvaluesColl)
            {
                Console.WriteLine("Все значения из словаря: {0}", str);
            }

            // Чтобы получить список всех ключей коллекции нужно использовать свойство Keys. 
            Dictionary<string, string>.KeyCollection TempkeysColl =
                 FileAssos.Keys;

            Console.WriteLine();
            foreach (string str in TempkeysColl)
            {
                Console.WriteLine("Ключ = {0}", str);
            }

            // Используем метод Remove для удаления элемента по ключу.
            Console.WriteLine("\nУдаляем(\"rar\")");
            FileAssos.Remove("rar");

            if (!FileAssos.ContainsKey("rar"))
            {
                Console.WriteLine("Ключ \"rar\" не найден.");
            }
            Console.ReadLine();
        }
    }
}

