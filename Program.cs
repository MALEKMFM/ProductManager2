using Categories;
using ProductManager;

namespace ProductManager_2
{
    static class Program
    {

        public static void Main()
        {
            Menu();
        }

        public static void Menu()
        {

            var pInfo = new ProductInfo();


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

                        Console.Clear();

                        Console.WriteLine("Namn: " + name + "\n" + "Artikelnummer: " + articleId + "\n" + "Beskrivning: " + description + "\n" + "Pris: " + price + "\n Stämmer detta? (J)a (N)ej");

                        ConsoleKey key = Console.ReadKey(true).Key;

                        if (key.Equals(ConsoleKey.J) && Category.ProductInformation.ContainsKey(articleId))
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
                        else if (!pInfo.Equals(pInfo.name) && key.Equals(ConsoleKey.J))
                        {


                            Category.ProductInformation.Add(articleId, new ProductInfo()
                            {
                                name = name,
                                articleNumber = articleId,
                                description = description,
                                price = price
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

                        var categoriee = Category.categories.FirstOrDefault(x => x.Name == catName);
                        Category category = new Category(catName);

                        // Any()  eller FirstOrDefault()
                        if (key.Equals(ConsoleKey.J) && categoriee != null)
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
                            Category.categories.Add(category);

                            Console.Clear();
                            Console.WriteLine("Kategorien Registerat!");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }

                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:

                        // Console.WriteLine("Ange Kategorie: ");

                        // var findCatName = Console.ReadLine();

                        // Console.Clear();

                        //var categorieExist = Category.categories.FirstOrDefault(x => x.Name == findCatName);

                        // if (categorieExist != null)
                        // {
                        //     Console.WriteLine("Namn på produkten: ");
                        //     var productName = Console.ReadLine();

                        //     var catt = new Category(productName);

                        //     var productExist = Category.categories.FirstOrDefault(x => x.Name == productName);

                        //     if (productExist != null)
                        //     {


                        //         Console.WriteLine("Produkten finns redan i kategorien");
                        //         Thread.Sleep(2000);

                        //     }
                        //     else if (productExist == null)
                        //     {
                        //         Category.categories.Add(catt);
                        //         Console.WriteLine("Produkten tillagd i kategorien!");
                        //         Thread.Sleep(2000);

                        //     }
                        //     else
                        //     {
                        //         Console.WriteLine("Produkten hittades inte!");
                        //         Thread.Sleep(2000);
                        //     }

                        // }
                        // else if(categorieExist == null)
                        // {
                        //     Console.WriteLine("Kategorien hittades ej!");
                        //     Thread.Sleep(2000);
                        // }
                        string categoryName;

                        Console.WriteLine("Artikelnummer på produkten: ");
                        var productArticleNumber = Console.ReadLine();
                        var productExist = Category.ProductInformation.Any(x => x.Key.Equals(productArticleNumber));
                        var productExistInCategory = Category.categories.FirstOrDefault(x => x.Name == productArticleNumber);
                        var product = FindProduct(productArticleNumber);

                        if (productExist != null)
                        {
                            Console.WriteLine("Ange Kategorie: ");

                            categoryName = Console.ReadLine();
                            var newCategory = Category.FindCategory(categoryName);



                            if (newCategory != null)
                            {
                                AddProduct(product);
                                Console.WriteLine("Produkten tillagd i kategorien!");
                                Thread.Sleep(2000);
                            }
                            else if (productExistInCategory != null)
                            {
                                Console.WriteLine("Produkten finns redan i kategorien");
                                Thread.Sleep(2000);

                            }
                            else
                            {
                                Console.WriteLine("Kategorien finns ej!");
                            }



                        }
                        else
                        {
                            Console.WriteLine("Produkten hittades ej!");
                            Thread.Sleep(2000);
                        }
                        break;



                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:



                        var categorieList = from s in Category.categories select s;
                        foreach (var c in categorieList)
                            Console.Write("\n" + $"Namn: " + c.Name + " ");
                        Console.Write(Category.categories.Count + "\n");
                        Console.ReadKey(true);
                        key = ConsoleKey.Escape;



                        break;

                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:

                        applicationRunning = false;
                        break;
                }

                Console.Clear();

            } while (applicationRunning);

            static void PrintProduct(ProductInfo ToPrint)
            {
                Console.Write($"Artikelnummer: {ToPrint.articleNumber}\n");
                Console.Write($"Namn: {ToPrint.name}\n");
                Console.Write($"Beskrivning: {ToPrint.description}\n");
                Console.Write($"Pris: {ToPrint.price}\n");
            }

            static void SearchForProduct()
            {
                Console.Write("Ange produktens artikelnummer eller namn: ");
                string article = Console.ReadLine();

                var searched = Category.ProductInformation.Where(product => product.Key.Equals(article));

                if (searched.Any())
                {
                    ProductInfo productInformation = Category.ProductInformation[article];

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

        static ProductInfo? FindProduct(string articleNumber)
            => Category.ProductInformation.ContainsKey(articleNumber)
                ? Category.ProductInformation[articleNumber]
                : null;
        public static Dictionary<string, ProductInfo> ProductDictionary { get; } = new Dictionary<string, ProductInfo>();
        static void AddProduct(ProductInfo product)
        {
            ProductDictionary.Add(product.articleNumber, product);
        }
    }

}