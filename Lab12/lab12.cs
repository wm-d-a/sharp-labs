using System;
using System.Linq;


namespace Laba12
{
    class Film
    {
        public string Name { get; set; }
        public string Filmmaker { get; set; }
        public int Year { get; set; }

        public Film()
        {
            this.Name = "Name";
            this.Filmmaker = "Filmmaker";
            this.Year = 2021;
        }
        public Film(string Name, string Filmmaker, int Year)
        {
            this.Name = Name;
            this.Filmmaker = Filmmaker;
            this.Year = Year;
        }
    }
    class laba12
    {
        static void Main(string[] args)
        {
            Film[] catFilms = {
                new Film("Экипаж", "Николай Лебедев", 2016),
                new Film("Месть", "Тони Скотт", 1990),
                new Film("Гринч - Похититель Рождества", "Рон Ховард", 2000),
                new Film("12 стульев", "Леонид Гайдай", 1971),
                new Film("Гордость и предубеждение", "Джо Райт", 2006),
                new Film("Тихий Дон", "Сергей Бондарчук", 1992),
                new Film("Дюна", "Дени Вильнёв", 2021),
                new Film("Борис Годунов", "Сергей Бондарчук", 1986),
                new Film("Елки 3", "Антон Мегердичев", 2013),
                new Film("Аквамарин", "Элизабет Аллен", 2006),
                new Film("Бриллиантовая рука", "Леонид Гайдай", 1968),
                new Film("Операция Ы и другие приключения Шурика", "Леонид Гайдай", 1965),
                new Film("Легенда №17", "Николай Лебедев", 2012),
                new Film("О чем говорят мужчины", "Дмитрий Дьяченко", 2010),
                new Film("Метро", "Антон Мегердичев", 2012),
                new Film("Главный герой", "Шон Леви", 2021),
                new Film("После.Глава 3", "Кастиль Лэндон", 2021),
                new Film("Судьба человека", "Сергей Бондарчук", 1959),
                new Film("Война и мир:1812 год", "Сергей Бондарчук", 1967),
                new Film("Верю в любовь", "Джон Дебни", 2020)
            };
            // Фильтрация
            {
                Console.WriteLine("\n\n1.Фильмы Леонида Гайдая или Сергея Бондарчука\n");

                var selectedFilms = catFilms.Where(u => u.Filmmaker == "Леонид Гайдай" && u.Filmmaker == "Сергей Бондарчук");

                foreach (Film u in selectedFilms)
                    Console.WriteLine(u.Name, u.Year);
            }
            // Проекция
            {
                Console.WriteLine("\n\n2.Наименование и Сколько лет в прокате\n");
                var items = from Film in catFilms
                            select new
                            {
                                FName = Film.Name,
                                HM = DateTime.Now.Year - Film.Year
                            };

                foreach (var n in items)
                    Console.WriteLine("{0} - {1}", n.FName, n.HM);
            }
            //Сортировка
            {
                Console.WriteLine("\n\n3.1.Сортировка по наименованию\n");

                var items1 = from Film in catFilms
                             orderby Film.Name, Film.Year
                             select Film;
                foreach (Film u in items1)
                    Console.WriteLine("{0} - {1}", u.Name, u.Year);
            }
            {
                Console.WriteLine("\n3.2.Сортировка по году выпуска\n");

                var items1 = from Film in catFilms
                             orderby Film.Year
                             select Film;
                foreach (Film u in items1)
                    Console.WriteLine("{0} - {1}", u.Name, u.Year);
            }
            //Группировка
            {
                Console.WriteLine("\n\n4.Группировка по режиссеру\n");
                var Fmg = catFilms.GroupBy(p => p.Filmmaker);
                foreach (IGrouping<string, Film> g in Fmg)
                {
                    Console.WriteLine(g.Key);
                    foreach (var t in g)
                        Console.WriteLine(t.Filmmaker, t.Name);
                    Console.WriteLine();
                }
            }
            //Агрегатные функции
            {
                Console.WriteLine("\n\n5.Количество фильмов вышедших в прокат в текущем году\n");
                double Count = catFilms.Where(u => u.Year == 2021).Count();
                Console.WriteLine($"Количество фильмов вышедших в прокат в текущем году: {Count}");
            }
            //Skip, Take, SkipWhile, TakeWhile
            {
                Console.WriteLine("\n\n6.Извлечь из списка элементы начиная с 1990 года выпуска \n");
                var item2 = catFilms.OrderBy(x => x.Year);
                var item3 = item2.SkipWhile(x => x.Year != 1990);
                foreach (Film i in item3)
                    Console.WriteLine($"{i.Name}, {i.Filmmaker}, {i.Year}");
            }
            //All и Any
            {
                Console.WriteLine("\n\n7.Все ли фильмы вышли в прокат в текущем году\n");
                bool item3 = catFilms.All(u => u.Year == 2021);
                Console.WriteLine(item3);
            }

            Console.ReadKey();
        }
    }
}
