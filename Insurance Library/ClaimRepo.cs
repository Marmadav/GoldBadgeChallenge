using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Library
{

    public class  ClaimRepo
    {
   private readonly Queue<Claim> _claim = new Queue<Claim>();
      
        public void AddContentToQueue(Claim que)
        {
            _claim.Enqueue(que);
        }
        public Queue<Claim> GetClaims()
        {
            return _claim;
        }

        public Claim PeekAtNextQue()
        {
            return _claim.Peek();
        }
        public void SayYesToThePeek()
        {
            _claim.Dequeue();
        }

        public void WriteItOut()
        {
            Console.WriteLine($"{ "Claim ID",-20}{ "Type",-20}{"Description",-20}{"Amount",-20}{"DateOfAccident",-20}{"DateOfIncident",-20}{"IsValid",-20}");
            foreach (Claim claim in _claim)
            {
                Console.WriteLine($"{claim.ClaimID,-20}{claim.TypeOfClaim,-20}{claim.Description,-20}{claim.ClaimAmount,-20}{claim.DateOfIncident.ToString("MM/dd/yy"),-20}{claim.DateOfClaim.ToString("MM/dd/yy"),-20}{claim.IsValid,-20}");
            }
            Console.ReadKey();
        }

    }

}
