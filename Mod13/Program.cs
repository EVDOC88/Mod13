using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace Mod13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 13.6.1
            // Прочли из файла
            string text = File.ReadAllText("E:\\Загрузки\\Text1.txt");
            // Создали массив из строки, без знаков пунктуации
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            // Определиил массив разделителей
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            var text2 = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            // Создали коллекцию List
            var list = new List<string>();
            // Запустим таймер
            var watchOne = Stopwatch.StartNew();
            // Выполним вставку для каждого значения в массиве в коллекцию list
            foreach (var item in text2)
            { list.Add(item); }
            // Выведем результат
            Console.WriteLine($"Вставка через List: {watchOne.Elapsed.TotalMilliseconds}  мс");
            // Создали коллекцию LinkedList
            LinkedList<string> LinkedList = new LinkedList<string>();
            // Запустим таймер
            var watchTwo = Stopwatch.StartNew();
            // Выполним вставку для каждого значения в массиве в коллекцию LinkedList
            foreach (var item2 in text2)
            { LinkedList.AddFirst(item2); }
            // Выведем результат
            Console.WriteLine($"Вставка через  LinkedList: {watchTwo.Elapsed.TotalMilliseconds}  мс");

            // Задание 13.6.2
            // Создание коллекцию slova  с помощью словаря
            var slova = new Dictionary<string, int>();
            // Взяли каждое слово из коллекции list, так как она создается и обрабатывется быстрее
            foreach (string word in list)
            {    
                    // Проверка на повторение
                    if (!slova.ContainsKey(word))
                    {   //Если повтора нет, записали слово и присвоили значение 1
                        slova.Add(word, 1);
                    }
                    else
                    { //Если повтор есть, то по ключу, чем у насявляется слово, прибавлем счетчик, значение, тем самым считаем повторы
                        slova[word] += 1;
                    }
                
            }
            //Сортируем коллекцию и по убыванию и отбираем первые 10 слов
            var sort = slova.OrderByDescending(x => x.Value).Take(10);
            //Для каждого значения отсортированной коллекции выводим пару ключ-значение первых топ 10 повторяющихся слов
            foreach (KeyValuePair<string, int> p in sort)
                    Console.WriteLine($"{p.Key} = {p.Value}");
        }

     }
    
}