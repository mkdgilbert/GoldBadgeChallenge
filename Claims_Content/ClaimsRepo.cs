using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Content
{
    public class ClaimsRepo
    {

        private readonly Queue<ClaimsProp> _queueOfclaims = new Queue<ClaimsProp>();


        //create
        public void AddToClaimsQueue(ClaimsProp newClaim)
        {
            _queueOfclaims.Enqueue(newClaim);
        }
        //read
        public Queue<ClaimsProp> ViewAllClaims()
        {
            return _queueOfclaims;
        }

        //update
        public bool UpdateExistingClaim(int existingClaim, ClaimsProp updatedMeal)
        {
            ClaimsProp num = GetClaimById(existingClaim);

            if (num != null)
            {
                num.ClaimAmount = updatedMeal.ClaimAmount;
                num.ClaimID = updatedMeal.ClaimID;
                num.DateOfClaim = updatedMeal.DateOfClaim;
                num.DateOfIncident = updatedMeal.DateOfIncident;
                num.Description = updatedMeal.Description;
                num.IsValid = updatedMeal.IsValid;
                num.TypeOfClaim = updatedMeal.TypeOfClaim;
                return true;
            }
            else
            {
                return false;
            }
        }

        //helper
        public ClaimsProp GetClaimById(int claimNum)
        {
            foreach (ClaimsProp claim in _queueOfclaims)
            {
                if (claim.ClaimID == claimNum)
                {
                    return claim;
                }
            }
            return null;
        }
    }
}
