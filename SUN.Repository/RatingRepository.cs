


using cbt.Interface.CBT;
using SUN.Business.Entity.Model;
using SUN.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.repository.CBT
{
    public class RatingRepository : IRatingRepository
    {
        private DataContext _context;
        public RatingRepository(DataContext context)
        {
            _context = context;

        }

        public bool AddRating(RatingVM model)
        {
            if (model == null) throw new Exception("There is no Entry!");

            var data = new Rating
            {
                RatingId = model.RatingId,
                Rating1 = model.Ratings,

            };

            _context.Rating.Add(data);

            return _context.SaveChanges() > 0;

        }

        public IEnumerable<RatingVM> GetRatings()
        {

            var data = (from q in _context.Rating
                        select new RatingVM
                        {
                            RatingId = q.RatingId,
                            Ratings = q.Rating1,

                        }).ToList();


            return data;

        }

        public bool UpdateRating(RatingVM model)
        {
            var data = (from x in _context.Rating
                        where x.RatingId == model.RatingId
                        select x).FirstOrDefault();

            if (data == null) throw new Exception("Record not found");

            data.RatingId = model.RatingId;
            data.Rating1 = model.Ratings;

            return _context.SaveChanges() > 0;

        }

        public bool DeleteRating(int RatingId)
        {

            if (RatingId == 0) throw new Exception("There is nothing to delete!");

            var data = _context.Rating.Find(RatingId);

            if (data == null) throw new Exception("Record not found");

            _context.Rating.Remove(data);

            return _context.SaveChanges() > 0;
        }



        public RatingVM GetRating(int RatingId)
        {
            return (from x in _context.Rating
                    where x.RatingId == RatingId
                    select new RatingVM
                    {
                        RatingId = x.RatingId,
                        Ratings = x.Rating1,


                    }).FirstOrDefault();

        }

    }
}






