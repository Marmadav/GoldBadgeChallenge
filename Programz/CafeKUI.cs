using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge
{
    class CafeKUI
    {
        private readonly MenuRepo _menuRepo = new MenuRepo();

        public void Run()
        {
            SeedContent();
            RunMenu();
            //add delete see all menu items
        }

        private void RunMenu()
        {
            bool continuetoRun = true;
            while(continuetoRun)
            {
                Console.Clear();
                Console.WriteLine("Select an option for your menu: \n" +
                    "1:Display all menu items\n" +
                    "2.Create a new menu item\n" +
                    "3.Delete existing menu item\n" +
                    "4.Exit");

                string userInput = Console.ReadLine();
                userInput = userInput.Trim();
                switch(userInput)
                {
                    case "1":
                        DisplayAllMenuItems();
                        //display all content
                        break;
                    case "2":
                        AddNewMenuItem();
                        //create menu item
                        break;
                    case "3":
                        DeleteItem();
                        //delete menu item
                        break;
                    case "4":
                        continuetoRun = false;
                        //exit
                        break;
                    default:
                        Console.WriteLine("Please choose an appropriate numerical choice.");
                        break;
                }

                 void DisplayAllMenuItems()
                {
                    Console.Clear();
                    List<MenuItem> directory = _menuRepo.GetAllItems();
                    foreach (MenuItem item in directory)
                    {
                        Console.WriteLine($"\n" +
                            $"Meal Number: {item.Number}\n" +
                            $"Meal Name: {item.Name}\n" +
                            $"Description: {item.Description}"); 
                        foreach(string ingredient in item.Ingredients)
                        { Console.WriteLine($"Ingredients: {ingredient}"); }
                        Console.WriteLine($"Item Price: {item.Price}");
            }
                    Console.WriteLine("Press any key to continue..");
                    Console.ReadKey();
                 }
                void AddNewMenuItem()
                {
                    MenuItem item = new MenuItem();
                    Console.WriteLine("Let's start with a # for the new meal: ");
                    item.Number = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("What name would you like to give this meal? ");
                    item.Name = Console.ReadLine();

                    Console.WriteLine("Please add a description for the new meal. ");
                    item.Description = Console.ReadLine();

                    Console.WriteLine("Please add the ingredients for this meal.");
                    item.Ingredients.Add(Console.ReadLine());

                    Console.WriteLine("What price would you like to charge for this meal?");
                    item.Price = Convert.ToDouble(Console.ReadLine());

                    _menuRepo.AddItemToMenu(item);
                    Console.WriteLine("Your meal has been added. Please return to the main menu by pressing any key.");
                    Console.ReadKey();
                }
                void DeleteItem()
                {
                    DisplayAllMenuItems();
                    Console.WriteLine("which?");
                    string name = Console.ReadLine();

                    bool success = _menuRepo.DeleteExistingItem(name);
                    if (success==true)
                    {
                        Console.WriteLine("thanks");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine($"{name} was unable to be removed.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }

            }
        }

        private void SeedContent()
        {
            List<string> tuesdaySlice = new List<string>() { "dough, parm, mozz, red sauce, cheddar, bacon" };
            MenuItem tuesdayDaily = new MenuItem(2, "TuesdayDailySlice", "Slice of Cheddar and Bacon", tuesdaySlice, 3.5);
            List<string> wednesdaySlice=new List<string>  (){ "dough, mozz, red sauce, tomato, gouda"};
            MenuItem wednesdayDaily = new MenuItem(3, "Wednesday Daily Slice", "Slice of Tomato and Gouda", wednesdaySlice, 3.5);
            _menuRepo.AddItemToMenu(tuesdayDaily);
            _menuRepo.AddItemToMenu(wednesdayDaily);
        }

    }
}
