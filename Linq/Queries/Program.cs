using System.Collections.Generic;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers =MyLinq.Random().Where(n=>n>0.5).Take(10);
            foreach(var  number in numbers)
            {
                Console.WriteLine(number);
            }
            var movies = new List<Movie>
            {
                new Movie {Title="The Dark Knight",   Rating=8.9f, Year=2010},
                new Movie {Title="Fast and Furious",  Rating=9.0f, Year=2015},
                new Movie {Title="Star Wars",         Rating=8.5f, Year=1980},
                new Movie {Title="Intrusul",          Rating=8.7f, Year=2020}
            };
            /*
            var query = movies.Where(m => m.Year > 2000);
            foreach (var movie in query)
            {
            
                Console.WriteLine(movie.Title);
            }*/



            var query = from movie in movies
                        where movie.Year > 2000
                        orderby movie.Rating descending
                        select movie;



            //Console.WriteLine(query.Count()); 
            var enumerator=query.GetEnumerator();
            while(enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }
        }
    }
}