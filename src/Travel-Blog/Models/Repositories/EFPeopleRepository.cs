using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TravelBlog.Models
{
    public class EFPeopleRepository : IPeopleRepository
    {
        TravelDbContext db = new TravelDbContext();

        public EFPeopleRepository(TravelDbContext connection = null)
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

        public IQueryable<People> Peoples
        {
            get { return db.Peoples; }
        }

        public People Create(People people)
        {
            db.Peoples.Add(people);
            db.SaveChanges();
            return people;
        }

        public People Details(People people)
        {
            return people;
        }

        public People Edit(People people)
        {
            db.Entry(people).State = EntityState.Modified;
            db.SaveChanges();
            return people;
        }

        public void DeleteConfirmed(People people)
        {
            db.Remove(people);
            db.SaveChanges();   
        }

        public void DeleteAll()
        {
            db.Database.ExecuteSqlCommand("DELETE FROM Peoples");
        }
    }
}
