using System;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>(); 
            this.Name = name;
        }

        public void AddLetterGrade(char letter)
        {
            /*if(letter == 'A')
            {
                AddGrade(90);
            }
            else if(letter == 'B')
            { }*/

            // if-else or switch

            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(90);
                    break;
                default:
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if (0 <= grade && grade <= 100)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            /* 
            // FOR
            for(var index=0; index<grades.Count; index++)
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.Low = Math.Max(grades[index], result.High);
                result.Average += grades[index];
                index++;
            }

            
            
            
            // WHILE 
            while (index < grades.Count)
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.Low = Math.Max(grades[index], result.High);
                result.Average += grades[index];
                index++;
            } 

            // DO-WHILE 
            var index = 0;
            do
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.Low = Math.Max(grades[index], result.High);
                result.Average += grades[index];
                index++;
            } while (index < grades.Count);
            */

            // FOREACH
            foreach (var grade in grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.Low = Math.Max(grade, result.High);
                result.Average += grade;
            }


            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }

        public List<double> grades;
        public string Name;
    }
}