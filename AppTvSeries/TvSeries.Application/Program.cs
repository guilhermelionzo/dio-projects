using System;
using TvSeries.Domain.Entities;
using TvSeries.Domain.Enums;
using TvSeries.Domain.Infra.Repositories;
using TvSeries.Domain.Repositories;

namespace TvSeries.Application
{
    class Program
    {
        static IRepository<Series> repository = new SeriesRepository();

        static void Main(string[] args)
        {
            string usersoption = GetUserOption();

            while (usersoption.ToUpper() != "X")
            {
                switch (usersoption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        RemoveSeries();
                        break;
                    case "5":
                        VisualizeSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                usersoption = GetUserOption();
            }

            Console.WriteLine("Thank you for using our services.");
            Console.ReadLine();
        }

        private static void RemoveSeries()
        {
            Console.Write("Insert the id: ");

            Guid input;
            if (Guid.TryParse(Console.ReadLine(), out input))
                repository.Delete(repository.GetById(input));
        }

        private static void VisualizeSeries()
        {
            Console.Write("Insert the Id: ");
            Guid input;
            if (Guid.TryParse(Console.ReadLine(), out input))
                Console.WriteLine(repository.GetById(input));
        }

        private static void UpdateSeries()
        {
            Console.Write("Insert the Id: ");
            Guid id;

            if (Guid.TryParse(Console.ReadLine(), out id))
            {
                var seriesToBeUpdated = repository.GetById(id);

                foreach (int i in Enum.GetValues(typeof(EGender)))
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(EGender), i));

                Console.Write("Digit the new gender: ");
                int.TryParse(Console.ReadLine(), out int gender);
                seriesToBeUpdated.SetGender((EGender)gender);

                Console.Write("Digit the new title: ");
                seriesToBeUpdated.SetTitle(Console.ReadLine());

                Console.Write("Digit the new year: ");
                int.TryParse(Console.ReadLine(), out int year);
                seriesToBeUpdated.SetYear(year);

                Console.Write("Digit the new description: ");
                seriesToBeUpdated.SetDescription(Console.ReadLine());

                repository.Update(seriesToBeUpdated);
            }
        }
        private static void ListSeries()
        {
            Console.WriteLine("List series");

            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("There is any series registered.");
                return;
            }

            foreach (var s in list)
            {
                Console.WriteLine("#Id {0}: - {1}", s.Id, s.Title);
            }
        }

        private static void InsertSeries()
        {
            Console.WriteLine("Insert new Series.");

            foreach (int i in Enum.GetValues(typeof(EGender)))
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(EGender), i));

            Console.Write("Enter the gender between the options above: ");
            int.TryParse(Console.ReadLine(), out int gender);

            Console.Write("Enter the Series Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter the Series Start Year: ");
            int.TryParse(Console.ReadLine(), out int year);

            Console.Write("Enter the Series Description: ");
            string description = Console.ReadLine();

            Series novaSerie = new Series((EGender)gender, title, description, year);

            repository.Insert(novaSerie);
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Choose the one of the options below:");

            Console.WriteLine("1- List series");
            Console.WriteLine("2- Insert new serie");
            Console.WriteLine("3- Update series");
            Console.WriteLine("4- Delete series");
            Console.WriteLine("5- Visualize series");
            Console.WriteLine("C- Clean screen");
            Console.WriteLine("X- Close application");
            Console.WriteLine();

            string usersoption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return usersoption;
        }
    }
}