using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelApp.Model
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public IList<Travel> Basket { get; set; }

    }
}
