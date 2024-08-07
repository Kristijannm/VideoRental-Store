using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Domain.Models;
using VideoRental.ViewModels;

namespace VideoRental.Mappers
{
    public static class CastMapper
    {
        public static CastViewModel ToCastViewModel(Cast cast)
        {
            return new CastViewModel
            {
                Id = cast.Id,
                MovieId = cast.MovieId,
                Part = cast.Part,
                Name = cast.Name,
            };
        }

        public static List<CastViewModel> ToCastViewModelList(ICollection<Cast>? casts)
        {
            var castViewModelList = new List<CastViewModel>();
            if(casts != null)
            {
                foreach (var c in casts)
                {
                    castViewModelList.Add(new CastViewModel
                    {
                        Id = c.Id,
                        MovieId = c.MovieId,
                        Name = c.Name,
                        Part = c.Part,
                    });
                }
                return castViewModelList;
            }
            else
            {
                return new List<CastViewModel>();
            }
            
        }

    }
}