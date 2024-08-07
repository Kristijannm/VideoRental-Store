using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Domain.Models;

namespace VideoRental.DataAccess.EFImplementations
{
    public class RentalRepository : IRepository<Rental>
    {
        private VideoRentalDbContext _videoRentalDbContext;

        public RentalRepository(VideoRentalDbContext vdb)
        {
            _videoRentalDbContext = vdb;
        }
        public void DeleteById(int id)
        {
            Rental rental = _videoRentalDbContext.Rentals.FirstOrDefault(r => r.Id == id);

            if (rental == null) {
                throw new Exception($"Rental with id {id} was not found.");
            }

            _videoRentalDbContext.Rentals.Remove(rental);
            _videoRentalDbContext.SaveChanges();
        }

        public List<Rental> GetAll()
        {
            return _videoRentalDbContext.Rentals.Include(r => r.User)
                                                .Include(r => r.Movie)
                                                .ToList();
        }

        public Rental GetById(int id)
        {
            
            return _videoRentalDbContext.Rentals.Include(r => r.User)
                                                .Include(r => r.Movie)
                                                .FirstOrDefault(r => r.Id == id);
        }

        public int Insert(Rental entity)
        {
            _videoRentalDbContext.Rentals.Add(entity);
            _videoRentalDbContext.SaveChanges();
            return entity.Id;
        }

        public void Update(Rental entity)
        {
            _videoRentalDbContext.Rentals.Update(entity);
            _videoRentalDbContext.SaveChanges();
        }
    }
}
