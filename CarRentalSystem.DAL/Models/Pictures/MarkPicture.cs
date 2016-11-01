using CarRentalSystem.DAL.Models.Car;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DAL.Models.Pictures
{
    public class MarkPicture
    {
        [ForeignKey("Mark")]
        public int Id { get; set; }
        public string Path { get; set; }
        public MarkPicture(string path, Mark mark)
        {
            this.Path = path;
            this.Mark = mark;

        }
        public int? MarkId { get; set; }
        public virtual Mark Mark { get; set; }

        public MarkPicture() { }
    }
}
