using CarRentalSystem.DAL.Models.Car;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DAL.Models.Pictures
{
    public class BodyPictures
    {
        [ForeignKey("Body")]
        public int Id { get; set; }
        public string Path { get; set; }
        public BodyPictures(string path, Body body)
        {
            this.Path = path;
            this.Body = body;
        }
        public BodyPictures()
        { }
        public int? BodyId { get; set; }
        public virtual Body Body { get; set; }

    }
}
