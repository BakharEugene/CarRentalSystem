using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DAL.Models.Car
{
    public class Status
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<Car> Car { get; set; }
        public string Name { get; set; }
    }
}
