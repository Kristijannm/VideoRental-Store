using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.DataAccess;
using VideoRental.Domain.Models;
using VideoRental.Services.Interfaces;
using VideoRental.ViewModels;
using VideoRental.Mappers;

namespace VideoRental.Services.Implementations
{
    public class CastService : ICastService
    {
        private IRepository<Cast> _castRepository;
        public CastService(IRepository<Cast> castRepository)
        {
            _castRepository = castRepository;
        }

        public List<CastViewModel> GetAllCasts()
        {
            List<CastViewModel> cvm = new List<CastViewModel>();

            foreach(var item in _castRepository.GetAll())
            {
                cvm.Add(CastMapper.ToCastViewModel(item));
            }

            return cvm;
        }
    }
}
