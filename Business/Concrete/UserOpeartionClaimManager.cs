using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserOpeartionClaimManager:IUserOpeartionClaimService
    {
        IUserOperationClaimDal _userOperationClaimDal;
        public UserOpeartionClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IResult Add(UserOperationClaim claim)
        {
            var userOperationClaim=_userOperationClaimDal.Get(c=>c.UserID==claim.UserID && c.OperationClaimID==claim.OperationClaimID);
            if(userOperationClaim==null) 
            {
                _userOperationClaimDal.Add(claim);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult Delete(UserOperationClaim claim)
        {
            var userOperationClaim= _userOperationClaimDal.Get(c => c.UserID == claim.UserID && c.OperationClaimID == claim.OperationClaimID);
            if (userOperationClaim != null)
            {
                _userOperationClaimDal.Delete(userOperationClaim);
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
