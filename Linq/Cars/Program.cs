using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarDb>());
            InsertData();
            QueryData();

            /*Func<int, int> square = x => x * x;
            Expression<Func<int, int, int>> add = (x, y) => x + y;
            Func<int, int, int> addI = add.Compile();

            var result = addI(3, 5);
            Console.WriteLine(result);
            Console.WriteLine(add);*/
            /*foreach(var record in records)
            {
                var car = new XElement("Car");
                var name = new XElement("Name", record.Name);
                var combined = new XElement("Combined", record.Combined);

                car.Add(name);
                car.Add(combined);
                cars.Add(car);
            }
            document.Add(cars);
            document.Save("fuel.xml");*/
        }

        private static void QueryData()
        {
            var db = new CarDb();

            db.Database.Log = Console.WriteLine;
            var query =
                        from car in db.Cars
                        group car by car.Manufacturer into manufacturer
                        select new
                        {
                            Name = manufacturer.Key,
                            Cars = (from car in manufacturer
                                    orderby car.Combined descending
                                    select car).Take(2)
                        };

                        //orderby car.Combined descending, car.Name ascending
                        //select car;
                   /* db.Cars.GroupBy(c => c.Manufacturer)//== "BMW")
                           .Select(g => new
                           {
                               Name = g.Key,
                               Cars = g.OrderByDescending(c => c.Combined).Take(2)
                           }); */

                           //.OrderByDescending(c => c.Combined)
                           //.ThenBy(c => c.Name)
                           //.Take(10)
                           //.Select(c => new {Name=c.Name.ToUpper()})
                           //.ToList();

            //Console.WriteLine(query.Count());
            foreach (var group  in query)
            {
                Console.WriteLine(group.Name);

                foreach (var car in group.Cars)
                {
                    Console.WriteLine($"\t{car.Name}:{car.Combined}");
                }
            }
        }

        private static void InsertData()
        {
            var cars = ProcessCars("fuel.csv");
            var db = new CarDb();
            

            if (!db.Cars.Any())
            {
                foreach(var car in cars)
                {
                    db.Cars.Add(car);
                }
                db.SaveChanges();
            }

        }

        private static void QueryXml()
        {
            var ns = (XNamespace)"http://pluralsight.com/cars/2022";
            var ex = (XNamespace)"http://pluralsight.com/cars/2022/ex";
            var document = XDocument.Load("fuel.xml");
            var query =
                from element in document.Element(ns+"Cars")?.Elements(ex + "Car") 
                                                      ?? Enumerable.Empty<XElement>()
                where element.Attribute("Manufacturer")?.Value == "BMW"
                select element.Attribute("Name").Value;

            foreach(var name in query)
            {
                Console.WriteLine(name);
                
            }
        }

        private static void CreateXml()
        {
            var records = ProcessCars("fuel.csv");

            var ns = (XNamespace)"http://pluralsight.com/cars/2022";
            var ex = (XNamespace)"http://pluralsight.com/cars/2022/ex";
            var document = new XDocument();
            var cars = new XElement(ns+ "Cars",


                from record in records
                select new XElement(ex+"Car",
                new XAttribute("Name", record.Name),
                new XAttribute("Combined", record.Combined),
                new XAttribute("Manufacturer", record.Manufacturer))
            );

            cars.Add(new XAttribute(XNamespace.Xmlns + "ex", ex));
            document.Add(cars);
            document.Save("fuel.xml");
        }


        private static List<Car> ProcessCars(string path)
        {
            //Operatorul va lua un sir individual care reprezinta o linie din fisier
            /*return
                    File.ReadAllLines(path)
                    .Skip(1)
                    .Where(line => line.Length > 1) //expresie lambda pentru a decide daca pastrez sau nu ultimul rand din fisierul csv care este  gol
                    .Select(Car.ParseFromCsv)
                    .ToList();*/

            //metoda extensiei
            var query =
              /*from line in File.ReadAllLines(path).Skip(1)
              where line.Length > 1
              select Car.ParseFromCsv(line);*/
              File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1)
                    .ToCar();

              return query.ToList();
        }
        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            var query =
        
                File.ReadAllLines(path)
                    .Where(l => l.Length > 1)
                    .Select(l =>
                    {
                        var columns = l.Split(',');
                        return new Manufacturer
                        {
                            Name = columns[0],         //numele este coloana 1
                            Headquarters = columns[1],  //sediu coloana 2
                            Year = int.Parse(columns[2]) //anul coloana 3
                        };
                    });
            return query.ToList();
        }
    }
    
    public class CarStatistics
    {
        public CarStatistics()
        {
            Max = Int32.MinValue;
            Min = Int32.MaxValue;


        }

        internal CarStatistics Accumulate(Car car)
        {
            Count += 1;
            Total += car.Combined;
            Max = Math.Max(Max, car.Combined);
            Min = Math.Min(Min, car.Combined);
            return this;
        }

        public CarStatistics  Compute()
        {
            Average = Total / Count;
            return this;
        }

        public int Max { get; set; }
        public int Min { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }
        public double Average { get; set; }
    }
    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach(var line in source)
            {
                var columns = line.Split(',');
                yield return new Car
                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3]),
                    Cylinders = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7])


                };
            }
            
        }
    }
}
/*var manufacturers = ProcessManufacturers("manufacturers.csv");
            var query =
                from car in cars
                    /*group car by car.Manufacturer.ToUpper() into manufacturer
                    orderby manufacturer.Key
                    select manufacturer;*/
// join car in cars on manufacturer.Name equals car.Manufacturer
//into carGroup
/* group car by car.Manufacturer into carGroup
 select new
 {
     Name = carGroup.Key,
     Max = carGroup.Max(carGroup => carGroup.Combined),
     Min = carGroup.Min(carGroup => carGroup.Combined),
     Avg = carGroup.Average(carGroup => carGroup.Combined),
 } into result
 orderby result.Max descending
 select result;


var query2 =
 /*manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer,
     (m, g) =>
 new
 {
     Manufacturer = m,
     Cars = g
 })
  .GroupBy(m => m.Manufacturer.Headquarters);*/
/*cars.GroupBy(c => c.Manufacturer)
    .Select(g =>
    {
        var results = g.Aggregate(new CarStatistics(),
                            (acc, c) => acc.Accumulate(c),
                            acc => acc.Compute());

        return new
        {
            Name = g.Key,
            Avg=results.Average,
            Min=results.Min,
            Max=results.Max
        };
    })
    .OrderByDescending(r => r.Max);            

foreach (var result  in query2)
{
Console.WriteLine($" { result.Name}");
Console.WriteLine($"\t Max:{result.Max}");
Console.WriteLine($"\t Min:{result.Min}");
/*foreach(var car in group.Se(c=>c.Combined).Take(2))
{
    Console.WriteLine($"/t{car.Name}:{car.Combined}");
}
}*/

/* metode de extensie
var query = cars.OrderByDescending(c => c.Combiend)
            .ThenBy(c => c.Name);*/
//var query =
//from car in cars
//join manufacturer in manufacturers 
/*on new { car.Manufacturer, car.Year } 
equals 
new { Manufacturer = manufacturer.Name, manufacturer.Year }
//where car.Manufacturer == "BMW" && car.Year == 2016
orderby car.Combined descending, car.Name ascending
select new
{
manufacturer.Headquarters,
car.Name,
car.Combined
};
var query2 =
cars.Join(manufacturers, //imbinare impotriva a doua surse date 
c => new { c.Manufacturer, c.Year },//ceea ce cauta
m => new { Manufacturer = m.Name, m.Year }, 
(c, m) => new //ce a pus c si m la un loc 
{
    m.Headquarters,
    c.Name,
    c.Combined
})
.OrderByDescending(c => c.Combined)
.ThenBy(c => c.Name);






foreach (var car in query.Take(10))
{
Console.WriteLine($"{car.Headquarters} {car.Name}:{car.Combined}");
}*/

/*var result = cars.SelectMany(c => c.Name)//verifica de cate ori apare fiecare element in colectie
                 .OrderBy(c => c);
foreach(var character in result)
{
    Console.WriteLine(character);

}
//new { c.Manufacturer, c.Name, c.Combined });



var top =
        cars
        //.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
            .OrderByDescending(c => c.Combined)
            .ThenBy(c => c.Name)
            .Select(c => c)
            .FirstOrDefault(c=>c.Manufacturer=="BMW"&&c.Year==2016);
Console.WriteLine(top.Name);


/*foreach(var car in query.Take(10))
{
    Console.WriteLine($"{car.Manufacturer}:{car.Name}:{car.Combined})");
}*/
