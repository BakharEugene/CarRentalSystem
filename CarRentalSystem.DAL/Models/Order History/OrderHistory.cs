using CarRentalSystem.DAL.Models.Car;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DAL.Models.Order_History
{
    public class OrderHistory
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Car")]
        public int? CarId { get; set; }
        public virtual Car.Car Car { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual Users.User User { get; set; }
        [ForeignKey("Status")]
        public int? IdStatus { get; set; }
        public virtual Status Status { get; set; }
        public DateTime Date { get; set; }
    }
}
