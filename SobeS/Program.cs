using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
namespace SobeS
{
    #region [book]
    class Book
    {
        public Book(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }

    class Library
    {
        private Book[] books;

        public Library()
        {
            books = new Book[] { new Book("Отцы и дети"), new Book("Война и мир"),
                new Book("Евгений Онегин") };
        }

        public int Length
        {
            get { return books.Length; }
        }

        public IEnumerable GetBooks(int max)
        {
            for (int i = 0; i < max; i++)
            {
                if (i == books.Length)
                {
                    yield break;
                }
                else
                {
                    yield return books[i];
                }
            }
        }
    }
    #endregion
    #region [Adapter]
    public interface ITarget
    {
        string GetRequest();
    }

    // Адаптируемый класс содержит некоторое полезное поведение, но его
    // интерфейс несовместим  с существующим клиентским кодом. Адаптируемый
    // класс нуждается в некоторой доработке,  прежде чем клиентский код сможет
    // его использовать.
    class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific request.";
        }
    }

    // Адаптер делает интерфейс Адаптируемого класса совместимым с целевым
    // интерфейсом.
    class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            this._adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is '{this._adaptee.GetSpecificRequest()}'";
        }
    }
    #endregion
    #region [Icomparer]
    class Diary 
    {
        public string Name;
        public int Age { get; set; }
    }
    class Future : IComparer<Diary>
    {
        public int Compare(Diary d1, Diary d2)
        {
            if (d1.Age > d2.Age)
                return 1;
            if (d2.Age > d1.Age)
                return -1;
            else
                return 0;
        }
    }
    class Person : IComparable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int CompareTo(object o)
        {
            Person p = o as Person;
            if (p != null)
                return this.Name.CompareTo(p.Name);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }
    class PeopleComparer : IComparer<Person>
    {
        public int Compare(Person p1, Person p2)
        {
            if (p1.Age > p2.Age)
                return 1;
            else if (p1.Age < p2.Age)
                return -1;
            else
                return 0;
        }
        interface IBespoleznii
        {
            public int MyProperty { get; set; }
            const int qew = 10;
        }
    }
    #endregion
    class Program
    {
        public static List<string> GetSequence(string str, string time)
        {
            List<string> sequence = new List<string>();
            for (int i = 1; i < str.Length - 1; i++)
            {
                time += str[i];
                if (str[i] == '.' && str[i + 1] == 'e' && str[i - 1] == 'y')
                    continue;
                if (str[i] == '.' || str[i] == '!' || str[i] == '?')
                {
                    sequence.Add(time);
                    time = "";
                }
            }
            return sequence;
        }
        public static void YE()
        {
            string str = "yslovie s 1000y.e i bolle 200y.e! Ili zamenite na 2000y.e? A tut nichego net. ", time = str[0].ToString();
            List<string> sequence = GetSequence(str, time);
            var regex = new Regex(@"\d{4,}y\.e");
            for (int i = 0; i < sequence.Count; i++)
            {
                var match = regex.Matches(sequence[i]);
                if(match.Count > 0)
                    Console.WriteLine(sequence[i]);
            }
        }
        #region [lock and Task]
        static object locker = new object();
        static void Display()
        {
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Thread.Sleep(3000);
        }

        static void Factorial(int x, CancellationToken token)
        {
            lock (locker)
            {
                int result = 1;
                for (int i = 1; i <= x; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Операция прервана токеном");
                        return;
                    }

                    result *= i;
                    Console.WriteLine($"Факториал числа {x} равен {result}");
                    Thread.Sleep(5000);
                }
            }
        }
        public static void zxc()
        {
            Console.WriteLine($"Poshel na {Task.CurrentId}");
        }
        public static int MethodIsHead(int a)
        {
            Thread.CurrentThread.Name = "rofl";
            if (a > 5)
                Console.WriteLine($" a < 5 a potoc = {Thread.CurrentThread.Name}");
            else
                Console.WriteLine($" a > 5 a potoc= {Thread.CurrentThread.Name}");
            return a;
        }
        static void Factorial()
        {
            int result = 1;
            for (int i = 1; i <= 6; i++)
            {
                result *= i;
            }
            Thread.Sleep(8000);
            Console.WriteLine($"Факториал равен {result}");
        }
        static async void FactorialAsync()
        {
            Console.WriteLine("Начало метода FactorialAsync"); // выполняется синхронно
            await Task.Run(() => Factorial());                // выполняется асинхронно
            Console.WriteLine("Конец метода FactorialAsync");
        }
        #endregion

        public static int Rank(int key, int[] numbers)
        {
            int low = 0;
            int high = numbers.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (key < numbers[mid]) high = mid - 1;
                else if (key > numbers[mid]) low = mid + 1;
                else return mid;
            }

            return -1;
        }

        public static int Binary(int key, int[] numbers)
        {
            int low = 0;
            int high = numbers.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (key < numbers[mid]) high = mid - 1;
                else if (key > numbers[mid]) low = mid + 1;
                else return mid;
            }

            return -1;
        }
        
        static void Main(string[] args)
        {
            //YE();
            #region [Linq]
            var list = new List<string>
                {  "vk.com",
                   "fb.com",
                   "twitter.com",
                   "instagram.com",
                   "vkontakte",
                   "vfeicbuke"
                };

            //Enumerable.Range(0, list.Count).AsParallel().ForAll(x => Console.WriteLine(list[x]));
            Ping ping = new Ping();
            //list.AsParallel().ForAll(x => Console.WriteLine(ping.Send(x).RoundtripTime.ToString()));
            var newlist = list.Where(x => new Ping().Send(x).RoundtripTime > 30);
            //Console.WriteLine(string.Join(Environment.NewLine, newlist));
            var seclist = list.Aggregate("Люда", (x, y) => y.Length > x.Length ? y : x);
            //Console.WriteLine(string.Join(Environment.NewLine, seclist));
            #endregion
            #region [Main Diary]
            //Diary Second = new Diary { Name = "Yuno", Age = 18 };
            //Diary First = new Diary { Name = "Yukki", Age = 14 };
            //Diary Nine = new Diary { Name = "Minene", Age = 23 };
            //Diary[] All = { Second, First, Nine };
            //Array.Sort(All, new Future());
            //foreach (Diary item in All)
            //{
            //    Console.WriteLine($"{item.Name} - {item.Age}");
            //}
            #endregion
            #region [Main Adapter]
            //Adaptee adaptee = new Adaptee();
            //ITarget target = new Adapter(adaptee);
            //Console.WriteLine("Adaptee interface is incompatible with the client.");
            //Console.WriteLine("But with adapter client can call it's method.");
            //Console.WriteLine(target.GetRequest());
            #endregion
            #region [TPL]
            //Parallel.Invoke(Display,() => {Console.WriteLine($"Выполняется задача {Task.CurrentId}"); Thread.Sleep(3000);},() => Factorial(5));
            //Parallel.Invoke(zxc, () => { Console.WriteLine("Liambda"); }, () => MethodIsHead(2));
            //Parallel.For(1, 10, Factorial);
            //ParallelLoopResult result = Parallel.ForEach(new List<int>() { 1, 2, 3, 8 }, Factorial);
            //CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            //CancellationToken token = cancelTokenSource.Token;

            //Task task1 = new Task(() => Factorial(5, token));
            //task1.Start();

            //Console.WriteLine("Введите Y для отмены операции или любой другой символ для ее продолжения:");
            //string s = Console.ReadLine();
            //if (s == "Y")
            //    cancelTokenSource.Cancel();
            //FactorialAsync();   // вызов асинхронного метода
            #endregion
            #region [Linq]
            string[] teams = { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };
            var sel = from t in teams
                      where t.ToUpper().StartsWith("Б")
                      orderby t
                      select t;
            //foreach (string s in sel)
            //    Console.WriteLine(s);
            #endregion

            var tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(1);
            tree.Add(2);
            tree.Add(8);
            tree.Add(6);
            tree.Add(9);
            foreach (var item in tree.InOrder())
            {
                Console.Write(item + ", ");
            }
        }
    }
}
