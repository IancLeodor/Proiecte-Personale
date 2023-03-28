using System;
using System.Collections.Generic; 

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            var book = new Book(" Grade Book");

            

            //book.AddGrade(89.1);
            //book.AddGrade(90.5);
            //book.AddGrade(73.9);
            // book.grades.Add(101);
            var stats = book.GetStatistics();

            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N2}");
            Console.WriteLine($"The letter grade is {stats.Letter}");



            // "Lectia1":
            /*

            // Ex1: 
            var x = 34.1;
            var y = 10.39;
            var result = x + y;
            // Console.WriteLine(result);


            // Ex2: 
            var numbers = new double[3];
            numbers[0] = 12.7;
            numbers[1] = 3.14;
            numbers[2] = 55;
            // another type of array declaration: 
            // var numbers = new[] { 12.7, 3.14, 55 };

            result = 0;
            result = numbers[0] + numbers[1] + numbers[2];
            // Console.WriteLine(result);


            // Ex3: 
            result = 0;
            foreach (var number in numbers)
            {
                result += number;
            }
            // Console.WriteLine(result);


            
            var grades = new List<double>() { 12.7, 21.8, 5.5, 91.2 };
            grades.Add(56.1);

            result = 0;
            foreach (double number in grades)
            {
                result = result + number;
            }
            result /= grades.Count;
            Console.WriteLine($"The average grade is {result:N2}");
            */
        }
    }
}