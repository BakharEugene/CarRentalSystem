using CarRentalSystem.DAL.Models.Information;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DAL.Models.Users
{
    public class EditModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Input first name")]
        [MaxLength(130, ErrorMessage = "Max length is 13")]
        [MinLength(4, ErrorMessage = "Min length is 6")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Input last name")]
        [MaxLength(130, ErrorMessage = "Max length is 13")]
        [MinLength(4, ErrorMessage = "Min length is 6")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Input telephone number")]
        [MaxLength(13,ErrorMessage="Max length is 13")]
        [MinLength(6,ErrorMessage="Min length is 6")]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Input your skype")]
        public string Skype { get; set; }
        public Enums.Genders Gender { get; set; }
        public int? RoleId { get; set; }
        
        public virtual Role Role { get; set; }
        public virtual ICollection<Order_History.OrderHistory> Orders { get; set; }
    }
}
