using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TravelBlog.Models
{
    [Table("Peoples")]
    public class People
    {
        [Key]
        public int PeopleId { get; set; }
        public string Name { get; set; }

        public ICollection<ExperiencePeople> ExperiencesPeoples { get; set; }

        public override bool Equals(System.Object otherPeople)
        {
            if (!(otherPeople is People))
            {
                return false;
            }
            else
            {
                People newPeople = (People)otherPeople;
                bool peopleIdEquality = PeopleId.Equals(newPeople.PeopleId);
                bool peopleNameEquality = Name.Equals(newPeople.Name);
                return (peopleIdEquality && peopleNameEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.PeopleId.GetHashCode();
        }
    }
}
