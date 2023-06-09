﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Features.Linq;


namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> square  = x => x * x;
            Func<int, int, int> add = (x, y) =>
            {
                int temp = x + y;
                return temp;
            };
            Action<int> write= x=>Console.WriteLine(x);

            write(square(add(3, 5)));
            //IEnumerable<Employee> 
            var developers = new Employee[]
            {
            new Employee {Id=1, Name="Ianc"},
            new Employee {Id=2, Name="Leo" }

            };
            /*List<Employee> sales = new List<Employee>()
            {
                new Employee { Id =3, Name="Alex"}
            };
            foreach (var person in sales)
            {
                Console.WriteLine(person.Name);
            }*/
            //IEnumerable<Employee>
            var sales = new List<Employee>()
                {
                    new Employee {Id=3, Name="Alex"}
                };
            var query = developers.Where(e => e.Name.Length == 5)
                                .OrderBy(e => e.Name)
                                .Select(e => e);

            var query2 = from developer in developers
                         where developer.Name.Length == 5
                         orderby developer.Name

                         select developer;
            /*
            Console.WriteLine(developers.Count());
            IEnumerator<Employee> enumerator = developers.GetEnumerator();
            while (enumerator.MoveNext()) 
            {
                Console.WriteLine(enumerator.Current.Name);
            }*/

            foreach (var employee in query2)
                //delegate(Employee employee)

                // {
                //   return employee.Name.StartsWith("L");
                // }))
                //lambda-foreach (var employee in developers.Where(
                //e => e.Name.StartsWith("L")))
            {
                Console.WriteLine(employee.Name);
            }
        }

        private static bool NameStartsWithS(Employee employee)
        {
            return employee.Name.StartsWith("L");
        }
    }
}