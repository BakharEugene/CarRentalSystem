using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DAL.Models.Order_History
{
    public class OrderHistory
    {
        [Key]
        public int Id { get; set; }
        public int? CarId { get; set; }
        public virtual Car.Car Car { get; set; }
        public int? UserId { get; set; }
        public virtual Users.User User { get; set; }
        public DateTime Date { get; set; }
        public Information.Enums.Status Status { get; set; }
    }
}
