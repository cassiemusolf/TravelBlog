using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBlog.Models
{
    [Table("Places")]
    public class Place
    {
        public Place()
        {
            this.Experiences = new HashSet<Experience>();
        }

        public override bool Equals(System.Object otherPlace)
        {
            if (!(otherPlace is Place))
            {
                return false;
            }
            else
            {
                Place newPlace = (Place)otherPlace;
                return this.PlaceId.Equals(newPlace.PlaceId);
            }
        }

        public override int GetHashCode()
        {
            return this.PlaceId.GetHashCode();
        }

        [Key]
        public int PlaceId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }

    }
}
