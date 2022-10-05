using Categories;
using ProductManager;

namespace ProductManager_2
{
    static class Program
    {


        //public static List<Category> categories = new List<Category>();
        public static void Main()
        {
            Menu();
        }

        public static void Menu()
        {

            var pInfo = new ProductInfo();
            //var catClass = new Category();

            Console.CursorVisible = false;
            bool applicationRunning = true;

            do
            {
                Console.WriteLine("Välkommen till FreakyFashion \nvälj ett alternativ nedan!" + "\n");
                Console.WriteLine("(1) Ny produkt");
                Console.WriteLine("(2) Sök produkt");
                Console.WriteLine("(3) Skapa Kategori");
                Console.WriteLine("(4) Lägg till product till kategori");
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
                        {
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
                                Category.ProductInformation.Add(name, new ProductInfo()
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
                        } 

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:

                        SearchForProduct();

                        Console.ReadKey(true);

                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:

                        Category.CategoryCheck();

                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        {
                            Console.WriteLine("Ange utbildning: ");

                            string name = Console.ReadLine();

                            Console.Clear();

                            //var category = categories.FirstOrDefault(category => category.Name == name);
                            if (Category.categories.Any())
                            {
                                Console.Write("Ange produktens artikelnummer eller namn: ");
                                string article = Console.ReadLine();

                                var searched = Category.ProductInformation.Where(product => product.Key.Equals(article));

                                if (searched.Any())
                                {
                                    ProductInfo productInformation = Category.ProductInformation[article];

                                    PrintProduct(productInformation);

                                    Console.WriteLine("Produkten tillagd i kategorien!");
                                    Thread.Sleep(2000);

                                }
                                else
                                {
                                    Console.WriteLine("Produkten hittades inte!");
                                    Thread.Sleep(2000);
                                    Console.Clear();

                                }
                                //ProductInfo product = new ProductInfo(article);
                                var category = new Category(name);
                                category.Name = name;
                                Category.categories.Add(category);
                                //Category.ProductInformation.Add(article, new ProductInfo()
                                //{
                                //    name = name
                                //});

                               
                            }
                            else
                            {
                                Console.WriteLine("Utbildningen finns ej");
                                Thread.Sleep(2000);
                            }


                            break;
                        }


                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:

                        applicationRunning = false;

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

    }

}