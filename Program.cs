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
            book.Showstatistics();

        }
    }
}
