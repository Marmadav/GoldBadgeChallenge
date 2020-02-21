using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge
{
    public class MenuRepo
    {
        // methods
        protected readonly List<MenuItem> _menuItems = new List<MenuItem>();

        public bool AddItemToMenu(MenuItem item)
        {
            int menuLength = _menuItems.Count();
            _menuItems.Add(item);
            bool wasAdded = menuLength + 1 == _menuItems.Count();
            return wasAdded;
        }
        public List<MenuItem> GetAllItems()
        {
            return _menuItems;
        }
        public MenuItem GetItemByName(string name)
        {
            foreach(MenuItem item in _menuItems)
            {
                return item;
            }
            return null;
        }
        public bool DeleteExistingItem(string name)
        {
            MenuItem foundMeal = GetItemByName(name);
            bool deletedResults = _menuItems.Remove(foundMeal);
            return deletedResults;
        }

    }
}
