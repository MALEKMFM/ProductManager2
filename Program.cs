using Categories;
using ProductManager;
using System.Net.WebSockets;
using System.Xml.Linq;

namespace ProductManager_2
{
   public class Program
    {
        public static Dictionary<string, Product> ProductInformation = new Dictionary<string, Product>();
        public static List<Category> categories = new List<Category>();

        public static void Main()
        {
            Program menu = new Program();
            menu.Menu();
        }

        public void Menu()
        {
            Console.CursorVisible = false;
            bool applicationRunning = true;
   
            do
            {
                Console.WriteLine("Välkommen till FreakyFashion \nvälj ett alternativ nedan!" + "\n");
                Console.WriteLine("(1) Ny produkt");
                Console.WriteLine("(2) Sök produkt");
                Console.WriteLine("(3) Skapa Kategori");
                Console.WriteLine("(4) Lägg till product I kategori");
                Console.WriteLine("(5) Lista Kategorier");
                Console.WriteLine("(6) Avsluta");

                ConsoleKeyInfo userInput;

                bool invalidSelection = true;

                do
                {
                    userInput = Console.ReadKey(true);

                    invalidSelection = !(
                        userInput.Key == ConsoleKey.D1 ||
                        userInput.Key == ConsoleKey.NumPad1 ||
                        userInput.Key == ConsoleKey.D2 ||
                        userInput.Key == ConsoleKey.NumPad2 ||
                        userInput.Key == ConsoleKey.D3 ||
                        userInput.Key == ConsoleKey.NumPad3 ||
                        userInput.Key == ConsoleKey.D4 ||
                        userInput.Key == ConsoleKey.NumPad4 ||
                        userInput.Key == ConsoleKey.D5 ||
                        userInput.Key == ConsoleKey.NumPad5 ||
                        userInput.Key == ConsoleKey.D6 ||
                        userInput.Key == ConsoleKey.NumPad6
                        );

                } while (invalidSelection);

                Console.Clear();
                Console.CursorVisible = true;

                switch (userInput.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        string articleId;
                        string name;
                        string description;
                        int price;

                        Console.Write("Artikelnummer: ");
                        articleId = (Console.ReadLine());

                        Console.Write("Namn: ");
                        name = (Console.ReadLine());

                        Console.Write("Beskrivning: ");
                        description = (Console.ReadLine());

                        Console.Write("Pris: ");
                        price = int.Parse(Console.ReadLine());

                        var pInfo = new Product();

                        Console.Clear();

                        Console.WriteLine("Namn: " + name + "\n" + "Artikelnummer: " + articleId + "\n" + "Beskrivning: " + description + "\n" + "Pris: " + price + "\n Stämmer detta? (J)a (N)ej");

                        ConsoleKey key = Console.ReadKey(true).Key;

                        if (key.Equals(ConsoleKey.J) && ProductInformation.ContainsKey(articleId))
                        {
                            Console.Clear();
                            Console.WriteLine("En produkt med samma artikelnummer är redan registerad!");
                            Thread.Sleep(2000);
                            break;
                        }
                        else if (key.Equals(ConsoleKey.N))
                        {
                            Console.Clear();
                            Thread.Sleep(2000);
                            break;
                        }
                        else if (!pInfo.Equals(pInfo.Name) && key.Equals(ConsoleKey.J))
                        {
                            ProductInformation.Add(articleId, new Product()
                            {
                                Name = name,
                                ArticleNumber = articleId,
                                Description = description,
                                Price = price
                            });

                            Console.Clear();
                            Console.WriteLine("Produkten Registerat!");
                            Thread.Sleep(2000);
                            Console.Clear();

                        }

                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:

                        SearchForProduct();

                        Console.ReadKey(true);

                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:

                        //Category.CategoryCheck();
                        string catName;

                        Console.WriteLine("Ny Kategori\n");
                        Console.Write("Namn: ");
                        catName = (Console.ReadLine());

                        Console.Clear();

                        Console.WriteLine("Namn: " + catName + "\n Stämmer detta? (J)a (N)ej");
                        key = Console.ReadKey(true).Key;

                        //key = Console.ReadKey(true).Key;

                        var categorieExist = categories.FirstOrDefault(x => x.Name == catName);
                        Category category = new Category(catName);

                        // Any()  eller FirstOrDefault()
                        if (key.Equals(ConsoleKey.J) && categorieExist != null)
                        {
                            Console.Clear();
                            Console.WriteLine("En Kategori med samma namn är redan registerad!");
                            Thread.Sleep(2000);

                        }
                        else if (key.Equals(ConsoleKey.N))
                        {
                            Console.Clear();
                            Thread.Sleep(2000);

                        }

                        else
                        {
                            categories.Add(category);
                            //AddCategoryToProductDictionary(category, new ProductInfo());
                            Console.Clear();
                            Console.WriteLine("Kategorien Registerat!");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }

                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                       
                        AddProductToCategory();

                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        static Category? FindCategory(string category)
=>                      categories.FirstOrDefault(x => x.Name == category);
                        string categoryy;
                        categoryy = (Console.ReadLine());

                        var categorys = FindCategory(categoryy);
                        categorys.ShowCategory();
                        break;

                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:

                        applicationRunning = false;
                        break;
                }

                Console.Clear();

            } while (applicationRunning);

            static void PrintProduct(Product ToPrint)
            {
                Console.Write($"Artikelnummer: {ToPrint.ArticleNumber}\n");
                Console.Write($"Namn: {ToPrint.Name}\n");
                Console.Write($"Beskrivning: {ToPrint.Description}\n");
                Console.Write($"Pris: {ToPrint.Price}\n");
            }

            static void SearchForProduct()
            {
                Console.Write("Ange produktens artikelnummer eller namn: ");
                string article = Console.ReadLine();

                var searched = ProductInformation.Where(product => product.Key.Equals(article));

                if (searched.Any())
                {
                    Product productInformation = ProductInformation[article];

                    PrintProduct(productInformation);
                }
                else
                {
                    Console.WriteLine("Produkten hittades inte!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }

        static Product? FindProduct(string articleNumber)
            => ProductInformation.ContainsKey(articleNumber)
                ? ProductInformation[articleNumber]
                : null;

        public void AddProductToCategory()
        {
            string categoryName;

            Console.WriteLine("Artikelnummer på produkten: ");
            var productArticleNumber = Console.ReadLine();

            var productExist = ProductInformation.Any(x => x.Key.Contains(productArticleNumber));
            var productExistInCategory = categories.FirstOrDefault(x => x.Name == productArticleNumber);

            var product = FindProduct(productArticleNumber);

            static Category? FindCategory(string category)
             => categories.FirstOrDefault(x => x.Name == category);
          
            Console.WriteLine("Ange Kategorie: ");
            if (productExist)
            {
                categoryName = Console.ReadLine();
                var category1 = new List<Category>(categories);
                var categoryExist = FindCategory(categoryName);

                if (categoryExist != null)
                {
                    categoryExist.AddProduct(product, categoryExist);
                }
                else if (categoryExist == null)
                {
                    Console.WriteLine("Kategorien finns ej!");
                }
            }
            else if (!productExist)
            {
                Console.WriteLine("Produkten hittades ej!");
                Thread.Sleep(2000);
            }
        }
    }
}