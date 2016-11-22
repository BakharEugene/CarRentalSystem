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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Skype { get; set; }
        public Enums.Genders Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
