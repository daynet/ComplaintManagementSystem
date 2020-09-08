


using SUN.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.Interface.CBT
{
    public interface IRatingRepository
    {
        bool AddRating(RatingVM model);

        RatingVM GetRating(int RatingId);

        IEnumerable<RatingVM> GetRatings();

        bool UpdateRating(RatingVM model);

        bool DeleteRating(int RatingId);
    }
}



     
