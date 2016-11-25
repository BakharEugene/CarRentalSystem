using CarRentalSystem.DAL.Models.Information;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DAL.Models.Users
{
    public class RegisterModel
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
        [MaxLength(13, ErrorMessage = "Max length is 13")]
        [MinLength(6, ErrorMessage = "Min length is 6")]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Input your skype")]
        public string Skype { get; set; }
        public Enums.Genders Gender { get; set; }
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Некорректный Email")]
        [Required(ErrorMessage = "Input your email")]
        public string Email { get; set; }

        [Required(ErrorMessage="Input password")]
        [MinLength(5,ErrorMessage="Min length 5 symbols")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Input password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
