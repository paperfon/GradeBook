using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var grades = new List<double>() { 12.8, 14.6, 12.5 };
            grades.Add(56.78);
            var result = 0.0;
            var total = grades.Count;
            foreach (double number in grades)
            {
                result += number;
            }

            var book = new Book();

            double average = result / total;
            Console.WriteLine(result);
            Console.WriteLine($"Your average grade is {average:N1}");
        }
    }
}
