using System.Xml.Linq;

namespace Categories
{

    public class Category
    {
        public static List<Category> categories = new List<Category>();
        public Category(string name)
        {

            Name = name;

        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                // Guard Clause
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Namnet kan inte vara tomt");

                name = value;
            }
        }

        public static void CategoryCheck()
        {


            string catName;

            Console.WriteLine("Ny Kategori\n");
            Console.Write("Namn: ");
            catName = (Console.ReadLine());


            Console.Clear();

            Console.WriteLine("Namn: " + catName + "\n Stämmer detta? (J)a (N)ej");
            ConsoleKey key = Console.ReadKey(true).Key;

            //key = Console.ReadKey(true).Key;


            Category category = new Category(catName);

            // Any()  eller FirstOrDefault()
            if (!categories.Any() && key.Equals(ConsoleKey.J))
            {
                categories.Add(category);

                Console.Clear();
                Console.WriteLine("Kategorien Registerat!");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else if (key.Equals(ConsoleKey.N))
            {
                Console.Clear();
                Thread.Sleep(2000);

            }
            else if (key.Equals(ConsoleKey.J) && categories.Any())
            {
                Console.Clear();
                Console.WriteLine("En Kategori med samma namn är redan registerad!");
                Thread.Sleep(2000);

            }
        }

        private string name;
    }
}