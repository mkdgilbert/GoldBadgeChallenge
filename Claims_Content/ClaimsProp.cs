using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Content
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
    public class ClaimsProp
    {
        public int ClaimID { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public ClaimsProp() { }
        public ClaimsProp(int claimId, string description, decimal claimAmount
            , DateTime dateOfIncident, DateTime dateOfClaim, bool isValid, ClaimType typeOfClaim)
        {
            ClaimID = claimId;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
            TypeOfClaim = typeOfClaim;
        }
    }
}
