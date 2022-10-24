using ProductManager;
using ProductManager_2;

namespace Categories
{
    public class Category
    {
        public Dictionary<string, string> ProductDictionary { get; } = new Dictionary<string, string>();

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
                    throw new ArgumentException("Invalid Name");

                name = value;
            }
        }

        private string name;

        public void AddProduct(Product product1, Category category)
        {

            var addPToCat = new Program();
            var productExistInCategory = ProductDictionary.Any(x => x.Key == product1.ArticleNumber);

            if (productExistInCategory)
            {
                throw new ArgumentException();
            }

            else if (!productExistInCategory)
            {

                Console.WriteLine("Produkten tillagd i kategorien!");
                Thread.Sleep(2000);
                Console.Clear();
                ProductDictionary.Add(product1.ArticleNumber, category.Name);
            }
        }
        public void ShowCategory()
        {
            foreach (var c in Program.categories)
                Console.WriteLine(ProductDictionary[c.Name].Count());

            Console.ReadKey(true);
            ConsoleKey key = ConsoleKey.Escape;
        }
    }
}