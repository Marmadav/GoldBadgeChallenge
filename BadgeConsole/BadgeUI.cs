using BadgeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeConsole
{
    class BadgeUI
    {
        private readonly BadgeMethods badgeMethods = new BadgeMethods();

        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Aloha! Make some badges for people.They need the access.\n" +
                    "Please choose an option below:\n" +
                    "1.Show all Badges and their door access\n" +
                    "2. Create a new Badge\n" +
                    "3. Update the door access for an existing Badge.\n" +
                    "4.Exit");

                string userInput = Console.ReadLine();
                userInput = userInput.Trim();
                switch (userInput)
                {
                    case "1":
                        ViewBadges();
                        //Show all Badges and values
                        break;
                    case "2":
                        MakeABadge();
                        //Make a new badge 
                        //give it access to doors
                        break;
                    case "3":
                        AlterBadges();
                        //find a badge and its list of doors
                        //update its values
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void ViewBadges()
        {
            Console.Clear();
            badgeMethods.ViewStuffLikeAString();
            /*Console.WriteLine("what badge are you looking for?");
            string userInput=Console.ReadLine();
            var name=badgeMethods.GetListByID(userInput);
            Console.WriteLine($" Badge{userInput} {string.Join(",",name)}");*/
            Console.ReadKey();

        }
        public void MakeABadge()
        {
            
            Badge userBadge = new Badge();
            userBadge.Doors = new List<string>();
            Console.WriteLine("You want to make a badge?\n" +
                "Great! Please assign the bagde a number.");
            userBadge.BadgeID=Console.ReadLine();
            Console.WriteLine("Got the number.\n" +
                "Now..what door would you like this badge to have access to?");
            userBadge.Doors.Add(Console.ReadLine());
            Console.WriteLine($"Great {userBadge.BadgeID} now has access to that door.\n" +
                $"Would you like to add access to a new door? (y/n)");
            string answer=Console.ReadLine();
            answer = answer.Trim();
            switch(answer)
            {
                case "y":
                    Console.WriteLine("What other door would you like to add access to?");
                    userBadge.Doors.Add(Console.ReadLine());
                    Console.WriteLine($"Great {userBadge.BadgeID} now has access to that door.");
                    Console.ReadLine();
                    break;
                case "n":
                    break;
            }
            badgeMethods.AddKeyValuePairToDictionary(userBadge);
        }
        public void AlterBadges()
        {
            Console.Clear();
            badgeMethods.ViewStuffLikeAString();
            Console.WriteLine("Here's the list of current badges.\n" +
                "\n" +
                "Which badge would you like to modify?");
            string userInput = Console.ReadLine();
            var name = badgeMethods.GetListByID(userInput);
            Console.WriteLine($" Badge{userInput} {string.Join(",", name)}");
          
            Console.WriteLine("Would you like to add access to doors or remove access?" +
                "1) Add\n" +
                "2) Remove");
       /*     bool stillAdding = true;*/
            string input=Console.ReadLine();
           input = input.Trim();
            switch (input)
            {
                case "1":
                    Console.WriteLine($"What door would you like to add access to for Badge{userInput}?");
                    name.Add(Console.ReadLine());
                    Console.WriteLine($"Thanks! Badge{userInput} has new access......");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine($"What door would you like to remove access to from Badge{userInput}?");
                    name.Remove(Console.ReadLine());
                    Console.WriteLine($"Got it. Badge{userInput} has less access....");
                    Console.ReadLine();
                    break;
            }
            /*while (stillAdding = true) ;*/


        }
        public void SeedContent()
        {
            List<string> list12345 = new List<string> { "A7" };
            List<string> list22345 = new List<string> { "A1", "A4", "B1", "B2" };
            List<string> list32345 = new List<string> { "A4", "A5" };
            Badge newName = new Badge("12345", list12345);
            badgeMethods.AddKeyValuePairToDictionary(newName);
            Badge otherName = new Badge("22345", list22345);
            Badge lastName = new Badge("32345", list32345);
            badgeMethods.AddKeyValuePairToDictionary(otherName);
            badgeMethods.AddKeyValuePairToDictionary(lastName);
        }
        
    }
}
