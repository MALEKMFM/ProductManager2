using ProductManager;

namespace Categories
{

    public class Category
    {
        public static List<Category> categories = new List<Category>();
        public static Dictionary<string, ProductInfo> ProductInformation = new Dictionary<string, ProductInfo>();

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

        public void AddProductToCategory(ProductInfo product)
        {
            Console.WriteLine("Namen på produkten: ");
            var productName = Console.ReadLine();
            var productExist = Category.ProductInformation.Any(x => x.Key.Equals(productName));

            if (productExist != null)
            {
                Console.WriteLine("Ange Kategorie: ");

                var catName = Console.ReadLine();

                var category = FindCategory(catName);


                if (category != null)
                {
                    //var addProduct = new Category(productName);
                    //Category.categories.Add(addProduct);

                    AddProduct(product);
                    Console.WriteLine("Produkten tillagd i kategorien!");
                    Thread.Sleep(2000);
                }
                else if (productExist != null)
                {


                    Console.WriteLine("Produkten finns redan i kategorien");
                    Thread.Sleep(2000);

                }
                else if ((category == null))
                {

                    Console.WriteLine("Kategorien finns ej! ");
                }
                else
                {
                    Console.WriteLine("Produkten hittades inte!");
                }

            }
        }
         public static Category? FindCategory(string category)
           => Category.categories.FirstOrDefault(x => x.Name == category);

        public Dictionary<string, ProductInfo> ProductDictionary { get; } = new Dictionary<string, ProductInfo>();
        public void AddProduct(ProductInfo product)
        {
            ProductDictionary.Add(product.articleNumber, product);
        }

    }




}