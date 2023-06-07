using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,AuthNAuthZContext>,IUserDal
    {
        public List<UserWithCompleteInfoDto> GetAllUserWithCompleteInfo()
        {
            using(var context = new AuthNAuthZContext())
            {
                var result= from user in context.Users
                            select new UserWithCompleteInfoDto 
                            { 
                                ID = user.ID, 
                                UserName = user.UserName, 
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                Email = user.Email,
                                Status = user.Status,
                                Roles=GetClaims(user)
                            };
                return result.ToList();
            }
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new AuthNAuthZContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.ID equals userOperationClaim.OperationClaimID
                             where userOperationClaim.UserID == user.ID
                             select new OperationClaim { ID = operationClaim.ID, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public UserWithCompleteInfoDto GetUserWithCompleteInfoById(Guid userId)
        {
            using (var context = new AuthNAuthZContext())
            {
                var result = from user in context.Users
                             where user.ID== userId
                             select new UserWithCompleteInfoDto
                             {
                                 ID = user.ID,
                                 UserName = user.UserName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 Status = user.Status,
                                 Roles = GetClaims(user)
                             };
                return result.FirstOrDefault();
            }
        }
    }
}
