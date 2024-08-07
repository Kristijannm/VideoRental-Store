using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Domain.Models;

namespace VideoRental.DataAccess.EFImplementations
{
    public class MovieRepository : IRepository<Movie>
    {
        private VideoRentalDbContext _videoRentalDbContext;

        public MovieRepository(VideoRentalDbContext vdb)
        {
            _videoRentalDbContext = vdb;
        }
        public void DeleteById(int id)
        {
            var movie = _videoRentalDbContext.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                throw new Exception($"Movie with id {id} was not found.");
            }

            _videoRentalDbContext.Movies.Remove(movie);
            _videoRentalDbContext.SaveChanges();
        }

        public List<Movie> GetAll()
        {
            return _videoRentalDbContext.Movies.Include(m => m.Rentals)
                                               .Include(m => m.Casts)
                                               .ToList();
        }

        public Movie GetById(int id)
        {
            return _videoRentalDbContext.Movies.Include(m => m.Rentals)
                                               .Include(m => m.Casts)
                                               .FirstOrDefault(m => m.Id == id);
        }

        public int Insert(Movie entity)
        {
            _videoRentalDbContext.Movies.Add(entity);
            _videoRentalDbContext.SaveChanges();

            return entity.Id;
        }

        public void Update(Movie entity)
        {
            _videoRentalDbContext.Movies.Update(entity);
            _videoRentalDbContext.SaveChanges();
        }
    }
}
