using AutoMapper;
using CarPooling.Models;
using CarpoolingDB;
using CarPoolingServices.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CarPooling.Services
{
    public class UserServices: IUserServices
    {
        private readonly CarpoolingContext _context;
        private readonly IMapper _mapper;
        public UserServices(CarpoolingContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<UserViewModel> GetUsers()
        {
            return _context.Users.Select(u => _mapper.Map<UserViewModel>(u)).ToList<UserViewModel>();
        }
       public bool IsUserExits(string userId)
        {
            return (_context.Users.FirstOrDefault(x => x.UserID == userId) != null);
        }
        public UserViewModel UserData(string userId, string password)
        {
            var user= _context.Users.FirstOrDefault(x => x.UserID == userId && x.Password == password);
            return _mapper.Map<UserViewModel>(user);
        }
        public bool AddUser(UserViewModel User)
        {
            try
            {
                _context.Users.Add(_mapper.Map<User>(User));
                    _context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public UserViewModel GetUserById(string userId)
        {
            return _mapper.Map<UserViewModel>(_context.Users.FirstOrDefault(x => x.UserID == userId));
        }
        public UserViewModel GetUserName(string Id)
        {
            var user = _mapper.Map<UserViewModel>(_context.Users.FirstOrDefault(x => x.UserID == Id));
            user.Password = null;
            return user;
        }
        public bool UpdateUser(UserViewModel user)
        {
            try
            {
                    var existingUser = _context.Users.Where(u => u.UserID == user.ID)
                                                        .FirstOrDefault<User>();
                    if (existingUser != null)
                    {
                        existingUser.FirstName = user.FirstName;
                        existingUser.LastName = user.LastName;
                        _context.SaveChanges();
                    }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
