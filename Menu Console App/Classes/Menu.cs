using System.Diagnostics;

namespace Menu_Console_App.Classes
{
    public class Menu
    {
        public List<MenuItem> menuItems = new List<MenuItem>()
        {
            new            (
                "Spaghetti",
                11.99m,
                "A big ol' plate of spaghetti",
                "main course",
                false
            ),
            new            (
                "Baguette",
                7.99m,
                "A long baguette",
                "appetizer",
                false
            ),
            new            (
                "Tiramisu",
                10.99m,
                "A tiramisu",
                "dessert",
                false
            )
        };
        public long LastUpdated { get; set; }

        private static readonly Stopwatch updateTime = new();

        public Menu()
        {
            LastUpdated = 0;
        }

        public void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine(this);
        }

        public void AddItem(MenuItem item)
        {
            foreach (MenuItem menuItem in this.menuItems)
            {
                menuItem.IsNew = false;
            }
            menuItems.Add(item);
            updateTime.Restart();
            Thread.Sleep(1);
        }
        public void RemoveItem(MenuItem item)
        {
            menuItems.Remove(item);
            updateTime.Restart();
            Thread.Sleep(1);
        }

        public long GetLastUpdated()
        {
            LastUpdated = updateTime.ElapsedMilliseconds;
            if (LastUpdated / 1000 < 60)
            {
                LastUpdated /= 1000;
            }
            else
            {
                LastUpdated /= (1000 * 60);
            }
            return LastUpdated;
        }
        public override string ToString()
        {
            Console.WriteLine("------------------------------------------\n------------------ Menu ------------------\n------------------------------------------");
            if (menuItems.Count != 0)
            {
                var menuString = string.Empty;
                foreach (MenuItem item in menuItems)
                {
                    menuString += $"-- {item.Name}: {item.Price:F2}\n";
                }
                return menuString;
            }
            else
            {
                return "The menu is empty";
            }

        }
    }
}
