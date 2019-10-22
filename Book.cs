using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void Showstatistics()
        {
            var result = 0.0;
            var highestGrade = double.MinValue;
            var lowestGrade = double.MaxValue;
            var total = grades.Count;
            foreach (double number in grades)
            {
                //if(number > highGrade)
                //{
                //    highGrade = number;
                //}
                highestGrade = Math.Max(number, highestGrade);
                lowestGrade = Math.Min(number, lowestGrade);
                result += number;
            }

            double average = result / total;
            Console.WriteLine(result);
            Console.WriteLine($"Your average grade is {average:N1}");
            Console.WriteLine($"Your highest grade is {highestGrade:N1}");
            Console.WriteLine($"Your lowest grade is {lowestGrade:N1}");
        }

        private List<double> grades;
        private string name;
    }
}   