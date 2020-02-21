using Insurance_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance
{
    class InsuranceUI
    {
        private readonly ClaimRepo _claimRepo = new ClaimRepo();

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
                Console.WriteLine("Hello! Welcome to the claims Queue.\n" +
                    "\n" +
                    "Please choose an option below:\n" +
                    "1. See all claims\n" +
                    "2. Peek at next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();
                userInput = userInput.Trim();
                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        //show all claims
                        break;
                    case "2":
                        PeekAtNext();
                        //Peek at next claim
                        break;
                    case "3":
                        AddThemClaims();
                        //Add a claim to the queue
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void AddThemClaims()
        {
            Claim item = new Claim();
            Console.WriteLine("Let's start with a # for the new claim: ");
            item.ClaimID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What Type of claim is this? (Please choose an numerical choice from below)\n" +
                "1)Car\n" +
                "2)Home\n" +
                "3)Theft");
            string typeInput = Console.ReadLine();
            int typeID = int.Parse(typeInput);
            item.TypeOfClaim = (ClaimType)typeID;

            Console.WriteLine("Please add a description to the claim.");
            item.Description = Console.ReadLine();

            Console.WriteLine("What value did the estimate return for this claim");
            item.ClaimAmount = Console.ReadLine();

            Console.WriteLine("What date did the incident happen?\n" +
                "(Please enter in '(MM/DD/YY)' format)");
            string incidentInput= Console.ReadLine();
            item.DateOfIncident = Convert.ToDateTime(incidentInput);

            Console.WriteLine("Please also enter the date the claim was made.\n" +
                "(Again, please enter in '(MM/DD/YY)' format)");
            item.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            _claimRepo.AddContentToQueue(item);
            Console.WriteLine("The claim has been entered.  Please hit any key to return to the main menu.");
            Console.ReadLine();

        }
        public void SeeAllClaims()
        {
            Console.Clear();
            /*Queue<Claim> queues = _claimRepo.GetClaims();*/
            _claimRepo.WriteItOut();
        }
        public void PeekAtNext()
        {
            Console.Clear();
            var claim=_claimRepo.PeekAtNextQue();
            Console.WriteLine($"{claim.ClaimID,-20}{claim.TypeOfClaim,-20}{claim.Description,-20}{claim.ClaimAmount,-20}{claim.DateOfIncident.ToString("MM/dd/yy"),-20}{claim.DateOfClaim.ToString("MM/dd/yy"),-20}{claim.IsValid,-20}");
            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            string peekInput=Console.ReadLine();
            peekInput = peekInput.ToLower();
            switch(peekInput)
            {
                case"y":
                    _claimRepo.SayYesToThePeek();
                    Console.WriteLine("You have taken the next claim.\n" +
                        "Please hit any key to return to the main menu.");
                    Console.ReadLine();
                break;
                case "n":
                    Console.WriteLine("This claim will stay in the queue.\n" +
                        "Please hit any key to return to the main menu.");
                    Console.ReadLine();
                    break;
                default:
                    break;
            }
        }





        public void SeedContent()
        {
            Claim one = new Claim(1, ClaimType.Car, "Accident on 464", "$400.00", Convert.ToDateTime("04 / 25 / 18"), Convert.ToDateTime("04 / 27 / 18"));
            Claim two = new Claim(2, ClaimType.Home, "House fire in kitchen.", "$4000.00", Convert.ToDateTime("04/11/18"), Convert.ToDateTime("04 / 12 / 18"));
            Claim three = new Claim(3, ClaimType.Theft, "Stolen Pancakes.", "$4.00", Convert.ToDateTime("04 / 27 / 18"), Convert.ToDateTime("06 / 01 / 18"));
            _claimRepo.AddContentToQueue(one);
            _claimRepo.AddContentToQueue(two);
            _claimRepo.AddContentToQueue(three);
        }


    }
}
