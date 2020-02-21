using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge
{
    public class MenuItem
    {
        // prop construct fields
        public MenuItem(int number, string name, string description, List<string> ingredients, double price)
        {
            Number = number;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }//Use .Add to add to the ingredient list for new items.

        public MenuItem()
        {
        }

        //MenuItem menu = new MenuItem();
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public List<string> Ingredients { get; set; } = new List<string>();    /*{ get; set; }*/
        public double Price { get; set; }
    }
}
