using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            var book = new Book("ruby");
            book.AddGrade(89.7);
            book.AddGrade(77.7);
            book.AddGrade(77.7);
            var stats = book.GetStatistics();

            Console.WriteLine($"Your average grade is {stats.Low:N1}");
            Console.WriteLine($"Your highest grade is {stats.High:N1}");
            Console.WriteLine($"Your lowest grade is {stats.Average:N1}");

        }
    }
}
