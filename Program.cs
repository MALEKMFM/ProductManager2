using ProductManager;

namespace ProductManager_2
{
    static class Program
    {
    
        public static Dictionary<string, ProductInfo> ProductInformation = new Dictionary<string, ProductInfo>();
        
        public static List<Categories> categories = new List<Categories>();
        public static void Main()
        {
            Menu();
        }

        public static void Menu()
        {
    
            var pInfo = new ProductInfo();
            var catClass = new Categories();

            Console.CursorVisible = false;
            bool applicationRunning = true;

            do
            {
                Console.WriteLine("Välkommen till FreakyFashion \nvälj ett alternativ nedan!" + "\n");
                Console.WriteLine("(1) Ny produkt");
                Console.WriteLine("(2) Sök produkt");
                Console.WriteLine("(3) Skapa Kategori");
                Console.WriteLine("(4) Lista Kategorier");
                Console.WriteLine("(5) Avsluta");

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
                        userInput.Key == ConsoleKey.NumPad5
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
                        else if (!pInfo.Equals(pInfo.name) && key.Equals(ConsoleKey.J))
                        {


                            ProductInformation.Add(articleId, new ProductInfo()
                            {
                                name = name,
                                articleNumber = articleId,
                                description = description,
                                price = price
                            });
                            ProductInformation.Add(name, new ProductInfo()
                            {
                                articleNumber = articleId,
                                name = name,
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

                        string catName;


                        Console.Write("Namn: ");
                        catName = (Console.ReadLine());


                        Console.Clear();

                        Console.WriteLine("Namn: " + catName + "\n Stämmer detta? (J)a (N)ej");

                         key = Console.ReadKey(true).Key;

                        //var catToCheck = categories.FirstOrDefault(category => category.Equals(categories.Contains(catName)));

                        if (key.Equals(ConsoleKey.J) && categories.Equals(catName))
                        {
                            Console.Clear();
                            Console.WriteLine("En Kategori med samma namn är redan registerad!");
                            Thread.Sleep(2000);
                            break;
                        }
                        else if (key.Equals(ConsoleKey.N))
                        {
                            Console.Clear();
                            Thread.Sleep(2000);
                            break;
                        }
                        else if (!categories.Equals(catName) && key.Equals(ConsoleKey.J))
                        {


                            categories.Add(catClass);



                            Console.Clear();
                            Console.WriteLine("Produkten Registerat!");
                            Thread.Sleep(2000);
                            Console.Clear(); 
                        }

                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:

                        applicationRunning = false;

                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:

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

                var searched = ProductInformation.Where(product => product.Key.Equals(article));

                if (searched.Any())
                {
                    ProductInfo productInformation = ProductInformation[article];

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

    }

}