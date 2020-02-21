using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Library
{
        public enum ClaimType { Car=1, Home, Theft }
    public class Claim
    {
        public Claim() { }
        public Claim(int claimID, ClaimType typeOfClaim, string description, string claimAmount, DateTime dateOfIncident, DateTime dateOfClaim /*bool isValid*/)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            
        }

        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public string ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }

        public bool IsValid
        {
            get
            {
                TimeSpan daysBetween = DateOfClaim - DateOfIncident;
                double span = daysBetween.TotalDays;
                if (span <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
/*    Queue<Claim> claim = new Queue<Claim>();
        claim.Enqueue(Claim(1, typeofclaim))*/
    }


}
