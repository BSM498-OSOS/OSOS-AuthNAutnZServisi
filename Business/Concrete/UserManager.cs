using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new Result(true);
        }

        public IResult Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll().Select(u=>new User {UserName=u.UserName,ID=u.ID,Email=u.Email,FirstName=u.FirstName,LastName=u.LastName}).ToList());
        }

        public IDataResult<List<UserWithCompleteInfoDto>> GetAllCompleteInfo()
        {
            var result = _userDal.GetAll()
                .Select(u=>new UserWithCompleteInfoDto 
                { 
                    ID= u.ID,
                    UserName=u.UserName,
                    Email  =u.Email,
                    FirstName=u.FirstName,
                    LastName=u.LastName,
                    Status=u.Status,
                    Roles =_userDal.GetClaims(u)
                }).ToList();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<UserWithCompleteInfoDto>>(result);
            }
            return new ErrorDataResult<List<UserWithCompleteInfoDto>>();

        }

        public IDataResult<User> GetById(Guid id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.ID == id));
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            if (result != null)
            {
                return new SuccessDataResult<User>(result);
            }
            return new ErrorDataResult<User>();
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            if (result != null)
            {
                return new SuccessDataResult<List<OperationClaim>>(result);
            }
            return new ErrorDataResult<List<OperationClaim>>();
        }

        public IDataResult<UserWithCompleteInfoDto> GetCompleteInfoById(Guid id)
        {
            var user = _userDal.Get(u => u.ID == id);
            if(user != null)
            {
                var result = new UserWithCompleteInfoDto
                {
                    ID = user.ID,
                    UserName = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Status = user.Status,
                    Roles = _userDal.GetClaims(user)
                };
                return new SuccessDataResult<UserWithCompleteInfoDto>(result);
            }
            return new ErrorDataResult<UserWithCompleteInfoDto>();
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
