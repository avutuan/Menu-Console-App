using Menu_Console_App.Classes;
using System.Diagnostics;

namespace Menu_Console_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new();
            bool quit = false;

            do
            {
                Console.WriteLine("\n------------------------------------------");
                Console.WriteLine("-- Hi! Welcome to the Menu Console App! --");
                Console.WriteLine("------------------------------------------\n");
                Console.WriteLine("1) \tDisplay the whole entire menu");
                Console.WriteLine("2) \tAdd a new item to the menu");
                Console.WriteLine("3) \tRemove an item from the menu");
                Console.WriteLine("4) \tDisplay details of menu item");
                Console.WriteLine("5) \tQuit the app only if you hate it");

                if (menu.LastUpdated == 0)
                {
                    Console.WriteLine("\nLast Updated: never\n");
                }
                else
                {
                    Console.WriteLine($"\nLast Updated: {menu.GetLastUpdated:F0} s ago\n");
                }

                Console.WriteLine("-- Enter a number: ");

                string? input;

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        menu.PrintMenu();
                        Thread.Sleep(1000);
                        break;

                    case "2":
                        string? name;
                        decimal price;
                        string? description;
                        string? category;
                        bool isNew = true;
                        bool valid;

                        do
                        {
                            Console.WriteLine("\n-- Enter the name: ");
                            name = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(name))
                            {
                                Console.WriteLine("\n-- Please enter a valid name");
                            }
                        } while (string.IsNullOrWhiteSpace(name));

                        do
                        {
                            Console.WriteLine("\n-- Enter the price: ");
                            string? priceInput = Console.ReadLine();
                            valid = decimal.TryParse(priceInput, out price);
                            valid = valid && price >= 0;
                            if (!valid)
                            {
                                Console.WriteLine("\n-- Please enter a valid price");
                            }
                        } while (!valid);

                        do
                        {
                            Console.WriteLine("\n-- Enter the description: ");
                            description = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(description))
                            {
                                Console.WriteLine("\n-- Please enter a valid description");
                            }
                        } while (string.IsNullOrWhiteSpace(description));

                        do
                        {
                            Console.WriteLine("\n-- Choose Category: \n1) main course\n2) appetizer\n3) dessert");
                            string? categoryChoice = Console.ReadLine();
                            valid = categoryChoice == "1" || categoryChoice == "2" || categoryChoice == "3";
                            switch (categoryChoice)
                            {
                                case "1":
                                    category = "main course";
                                    break;
                                case "2":
                                    category = "appetizer";
                                    break;
                                case "3":
                                    category = "dessert";
                                    break;
                                default:
                                    category = "";
                                    Console.WriteLine("\n-- Enter a valid choice of category");
                                    break;
                            }
                        } while (!valid);

                        menu.AddItem(new MenuItem(name, price, description, category, isNew));

                        break;

                    case "3":
                        do
                        {
                            Console.WriteLine();
                            if (menu.menuItems.Count == 0)
                            {
                                Console.WriteLine("\n-- The menu is empty try to add more items");
                                break;
                            }
                            Console.WriteLine("-- Which item would you like removed?: ");
                            for (int i = 0; i < menu.menuItems.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}) {menu.menuItems[i].Name}");
                            }
                            string? removeInput = Console.ReadLine();
                            valid = int.TryParse(removeInput, out int removeIndex) && removeIndex - 1 < menu.menuItems.Count;
                            if (!valid)
                            {
                                Console.WriteLine("\n-- Please enter a valid choice of item to remove");
                            }
                            else
                            {
                                menu.RemoveItem(menu.menuItems[removeIndex - 1]);
                            }
                        } while (!valid);

                        break;

                    case "4":
                        do
                        {
                            Console.WriteLine();
                            if (menu.menuItems.Count == 0)
                            {
                                Console.WriteLine("\n-- The menu is empty try to add more items");
                                break;
                            }
                            Console.WriteLine("-- Which item would you like display?: ");
                            for (int i = 0; i < menu.menuItems.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}) {menu.menuItems[i].Name}");
                            }
                            string? displayInput = Console.ReadLine();
                            valid = int.TryParse(displayInput, out int displayIndex) && displayIndex - 1 < menu.menuItems.Count;
                            if (!valid)
                            {
                                Console.WriteLine("\n-- Please enter a valid choice of item to display");
                            }
                            else
                            {
                                Console.WriteLine($"\n{menu.menuItems[displayIndex - 1]}");
                            }
                        } while (!valid);
                        break;

                    case "5":
                        quit = true;
                        break;

                    default:
                        Console.WriteLine("\n-- Please enter a valid menu option");
                        break;

                }
            } while (!quit);
        }
    }
}
