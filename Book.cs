using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
    }

    public class InMemoryBook : Book
    {
        private List<double> grades;

        public InMemoryBook(string name) :base(name)
        {
            grades = new List<double>();
            Name = name;
        }
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                //if (GradeAdded != null)
                //{
                //    GradeAdded(this, new EventArgs());
                //}
                // The previous code can be simplified in this way in the latest version of C#
                GradeAdded?.Invoke(this, new EventArgs());
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            foreach (var grade in grades)
            {
                result.Add(grade);
            }

            return result;
        }

    }
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            // Using replaces something like: outputToFile.Dispose();
            using (var outputToFile = File.AppendText($"{Name}.txt"))
            {
                outputToFile.WriteLine(grade);
            }

            if (GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var readingResultsFromDisk = File.OpenText($"{Name}.txt"))
            {
                var line = readingResultsFromDisk.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = readingResultsFromDisk.ReadLine();
                }
            }

            return result;
        }
    }
}