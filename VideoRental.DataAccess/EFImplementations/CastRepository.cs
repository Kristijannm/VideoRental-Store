using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Domain.Models;

namespace VideoRental.DataAccess.EFImplementations
{
    public class CastRepository : IRepository<Cast>
    {
        private VideoRentalDbContext _videoRentalDbContext;

        public CastRepository(VideoRentalDbContext videoRentalDbContext)
        {
            _videoRentalDbContext = videoRentalDbContext;
        }

        public void DeleteById(int id)
        {
            Cast cast = _videoRentalDbContext.Casts.FirstOrDefault(c => c.Id == id)!;
            if (cast == null)
            {
                throw new Exception($"Cast with id {id} was not found.");
            }

            _videoRentalDbContext.Casts.Remove(cast);
            _videoRentalDbContext.SaveChanges();
        }

        public List<Cast> GetAll()
        {
            return _videoRentalDbContext.Casts.ToList();
        }

        public Cast GetById(int id)
        {
            return _videoRentalDbContext.Casts.FirstOrDefault(c => c.Id == id);
        }

        public int Insert(Cast entity)
        {
            _videoRentalDbContext.Casts.Add(entity);
            _videoRentalDbContext.SaveChanges();

            return entity.Id;
        }

        public void Update(Cast entity)
        {
            _videoRentalDbContext.Casts.Update(entity);
            _videoRentalDbContext.SaveChanges();
        }
    }
}
