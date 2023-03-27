using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            int correctCount = 0;
            int incorrectCount = 0;
            while (true)
            {
                // загрузка списка слов и переводов из файла
                List<string> words = new List<string>();
                List<string> translations = new List<string>();
                using (StreamReader sr = new StreamReader("words.txt", Encoding.GetEncoding(1251)))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        words.Add(parts[0]);
                        translations.Add(parts[1]);
                    }
                }

                // случайный выбор слова и его перевода
                Random rand = new Random();
                int index = rand.Next(words.Count);
                string word = words[index];
                string translation = translations[index];

                // предложение пользователю угадать перевод слова
                Console.WriteLine("Угадайте перевод слова: " + word);
                string answer = Console.ReadLine();

                // проверка ответа пользователя
                if (answer == translation)
                {
                    Console.WriteLine("Правильно!");
                    correctCount++;
                }
                else
                {
                    Console.WriteLine("Неправильно. Правильный ответ: " + translation);
                    incorrectCount++;
                }
                Console.WriteLine("Количество правильных ответов: " + correctCount);
                Console.WriteLine("Количество неправильных ответов: " + incorrectCount);
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
