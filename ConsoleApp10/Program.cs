using System.Text;

namespace ConsoleApp10
{

    class Person : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int Heigth { get; set; }
        public string City { get; set; }

        public int CompareTo(object? obj)
        {
            Person person = obj as Person;
            if (Age > person.Age || Salary > person.Salary || Heigth > person.Heigth)
            {
                return 1;
            }
            if (Age < person.Age || Salary < person.Salary || Heigth < person.Heigth)
            {
                return -1;
            }
            else
            {
                return 0;
            }
            //if((Age > p.Age) || (Age ==p.Age && Salary < p.Salary) || ((Age == p.Age) && (Salary == p.Salary) && (Height < p.Height)))
            //{
                   //return1;
            //}
            // return -1;
        }
    }
    internal class Program
    {
        static List<Person> personList = new();

        static String[] cities = new[] { "Ankara", "İstanbul", "Bursa", "Eskişehir", "Antalya", "Trabzon" };

        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                Random r = new();
                personList.Add(new Person { Name = "Özge", Age = r.Next(18, 90), City = cities[r.Next(0, 6)], Salary = r.Next(5500, 60000), Heigth = r.Next(170, 190) });
            }
            personList.Sort();
            IEnumerable<Person> people = personList.Where(x => x.Salary > 50000); //x her bir kaydı temsil eder.
            List<Person> people2 = people.ToList(); //Sort özelliği listede vardır.
            people = personList.Where(x => x.City == "Ankara" && x.Age < 30);
            bool found = personList.Exists(x => x.City == "Berlin");
            personList.ForEach(x => x.Age = x.Age * 2);
            Person p1 = personList.Find(x => x.City == "İstanbul"); //ilk bulduğunu getirir.
            Person p2 = personList.SingleOrDefault(x => x.City == "İstanbul"); //Birden çok istanbul varsa patlar yoksa null döner
            Person p3 = personList.Single(x => x.City == "İstanbul"); //Birden çok istanbul varsa yada hiç yoksa patlar
            Person p4 = personList.SingleOrDefault(x => x.City == "İstanbul", new Person { City = "İstanbul" }); //Birden çok istanbul varsa patlar yoksa istanbul döner. LinQ denir.


            foreach (var p in personList)
            {
                StringBuilder sb = new();
                sb.AppendFormat("id:{0}, ", p.Id);
                sb.AppendFormat("Age:{0}, Salary{1}, ", p.Age, p.Salary);
                sb.AppendLine("Heigth:" + p.Heigth);
                Console.WriteLine(sb.ToString());
            }

            foreach (var p in people)
            {
                StringBuilder sb = new();
                sb.AppendFormat("id:{0}, ", p.Id);
                sb.AppendFormat("Age:{0}, Salary{1}, ", p.Age, p.Salary);
                sb.AppendLine("Heigth:" + p.Heigth);
                Console.WriteLine(sb.ToString());
            }
        }
    }
}