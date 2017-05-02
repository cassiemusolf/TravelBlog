using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBlog.Models
{
    public interface IPlaceRepository
    {
        IQueryable<Place> Places { get; }
        Place Create(Place place);
        Place Details(Place place);
        Place Edit(Place place);
        void DeleteConfirmed(Place place);

    }
}
