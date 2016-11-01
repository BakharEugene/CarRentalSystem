using CarRentalSystem.DAL.Models.Pictures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DAL.Models.Car
{
    public class Mark
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Car> Cars { get; set; }
        public string MarkType { get; set; }
        public virtual MarkPicture MarkPictrure { get; set; }


    }
}
