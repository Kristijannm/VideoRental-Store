using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Domain.Models;

namespace VideoRental.DataAccess.EFImplementations
{
    public class UserRepository : IRepository<User>
    {
        private VideoRentalDbContext _videoRentalDbContext;

        public UserRepository(VideoRentalDbContext videoRentalDbContext)
        {
            _videoRentalDbContext = videoRentalDbContext;
        }

        public void DeleteById(int id)
        {
            User user = _videoRentalDbContext.Users.FirstOrDefault(u => u.Id == id);

            if(user == null) {
                throw new Exception($"User with id {id} does not exist.");
            }

            _videoRentalDbContext.Remove(user);
            _videoRentalDbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _videoRentalDbContext.Users.Include(u => u.Rentals).ToList();
        }

        public User GetById(int id)
        {
            return _videoRentalDbContext.Users.Include(u => u.Rentals).FirstOrDefault(u => u.Id == id);
        }

        public int Insert(User entity)
        {
            _videoRentalDbContext.Users.Add(entity);
            _videoRentalDbContext.SaveChanges();
            return entity.Id;
        }

        public void Update(User entity)
        {
            _videoRentalDbContext.Update(entity);
            _videoRentalDbContext.SaveChanges();
        }
    }
}
