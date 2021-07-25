using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoMapper;
using Crumbs.Api.Interfaces;
using Crumbs.Api.Requests;
using Crumbs.Api.Responses;
using Crumbs.Data.Interfaces;
using Crumbs.Data.Models;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Crumbs.Api.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public UserManager(IUnitOfWork unitOfWork,
            IJwtUtils jwtUtils,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _unitOfWork.UserRepository.GetUser(model.Username);
            // validate
            if (user == null || !BCryptNet.Verify(model.Password, user.Result.PasswordHash))
                throw new Exception("Username or password is incorrect");

            // authentication successful
            var response = _mapper.Map<AuthenticateResponse>(user);
            response.JwtToken = _jwtUtils.GenerateToken(user.Result);
            return response;
        }

        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.UserRepository.GetUsers().Result;
        }

        public User GetById(long id)
        {
            var user = _unitOfWork.UserRepository.GetUser(id);
            return user.Result;
        }

        public void Register(RegisterRequest model)
        {
            // validate
            if (_unitOfWork.UserRepository
                .GetUsers()
                .Result
                .Any(x => x.Username == model.Username))
                throw new Exception("Username '" + model.Username + "' is already taken");

            // map model to new user object
            var user = _mapper.Map<User>(model);

            // hash password
            user.PasswordHash = BCryptNet.HashPassword(model.Password);

            // save user
            _unitOfWork.UserRepository.AddUser(user);
            _unitOfWork.SaveChangesAsync(CancellationToken.None);
        }

        public void Update(long id, UpdateRequest model)
        {
            var user = _unitOfWork.UserRepository.GetUser(id);

            // validate
            if (model.Username != user.Result.Username && _unitOfWork.UserRepository
                .GetUsers()
                .Result
                .Any(x => x.Username == model.Username))
                throw new Exception("Username '" + model.Username + "' is already taken");

            // hash password if it was entered
            if (!string.IsNullOrEmpty(model.Password))
                user.Result.PasswordHash = BCryptNet.HashPassword(model.Password);

            // copy model to user and save
            _mapper.Map(model, user);
            
            _unitOfWork.UserRepository.UpdateUser(user.Result);
            _unitOfWork.SaveChangesAsync(CancellationToken.None);
        }

        public void Delete(long id)
        {
            var user = _unitOfWork.UserRepository.GetUser(id);
            
            _unitOfWork.UserRepository.RemoveUser(user.Result);
            _unitOfWork.SaveChangesAsync(CancellationToken.None);
        }
    }
}