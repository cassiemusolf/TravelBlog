using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBlog.Models
{
    public interface IPeopleRepository
    {
        IQueryable<People> Peoples { get; }
        People Create(People people);
        People Details(People people);
        People Edit(People people);
        void DeleteConfirmed(People people);

    }
}
