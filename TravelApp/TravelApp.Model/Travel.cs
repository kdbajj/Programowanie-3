using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using TravelApp.Model;
using System.ComponentModel.DataAnnotations;

namespace TravelApp.Model
{
    public class Travel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string User { get; set; }

        public string Food { get; set; }
        public float Price { get; set; }

        [StringLength(50)]
        public string Transport { get; set; }

        [StringLength(100)]
        public string HotelName { get; set; }
    }
}
//modelBuilder.Configurations.Add(new TravelConfiguration());
              
//        }
//    }
//    public class TravelConfiguration : EntityTypeConfiguration<Travel>
//{
//    public TravelConfiguration()
//    {
//              .Property(t => t.City)
//                .IsRequired()
//                .HasMaxLength(50);