using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TravelBlog.Models
{
    public class EFPlaceRepository : IPlaceRepository
    {
        TravelDbContext db = new TravelDbContext();

        public EFPlaceRepository(TravelDbContext connection = null)
        {
            if (connection == null)
            {
                this.db = new TravelDbContext();
            }
            else
            {
                this.db = connection;
            }
        }
        public IQueryable<Place> Places
        { get { return db.Places} }

        public Place Create(Place place)
        {
            db.Places.Add(place);
            db.SaveChanges();
            return place;
        }

        public Place Edit(Place place)
        {
            db.Entry(place).State = EntityState.Modified;
            db.SaveChanges();
            return place;
        }

        public Place Details(Place place)
        {
            return place;
        }

        public void DeleteConfirmed(Place place)
        {
            db.Remove(place);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            db.Database.ExecuteSqlCommand("DELETE FROM Places");
        }
    }
}
