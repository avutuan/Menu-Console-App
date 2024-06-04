namespace Menu_Console_App.Classes
{
    public class MenuItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool IsNew { get; set; }

        public MenuItem(string name, decimal price, string description, string category, bool isNew)
        {
            Name = name;
            Price = Math.Round(price, 2);
            Description = description;
            Category = category;
            IsNew = isNew;
        }

        public override string ToString()
        {
            if (!IsNew)
            {
                return $"-- {Name} --\n-- ({Category})\n-- ${Price:F2}\n-- Description: {Description}\n-- Not New!!!!\n\n";
            }                      
            else                   
            {                      
                return $"-- {Name} --\n-- ({Category})\n-- ${Price:F2}\nDescription: {Description}\n-- New Item!!!\n\n";
            }
        }
    }
}
