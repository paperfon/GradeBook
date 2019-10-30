using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            var book = new Book("Ruby's Grade Book");
            book.GradeAdded += OnGradeAdded;

            do
            {
                Console.WriteLine("Please insert your grades. Quit with Q:");
                var input = Console.ReadLine();
                if (input == "Q") { break; }


                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("***");
                }

            } while (true);

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"Your highest grade is {stats.High:N1}");
            Console.WriteLine($"Your lowest grade is {stats.Low:N1}");
            Console.WriteLine($"Your average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("OnGradedAdded, a grade was added");
        }
    }
}
