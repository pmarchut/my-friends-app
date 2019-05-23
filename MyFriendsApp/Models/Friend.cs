using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFriendsApp.Models
{
    public class Friend
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(55, ErrorMessage = "First Name cannot be longer than 55 characters.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(1075, ErrorMessage = "Last Name cannot be longer than 1075 characters.")]
        public string LastName { get; set; }

        public string Pseudonym { get; set; }

        [Required]
        [RegularExpression(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$", ErrorMessage = "Invalid Telephone format.")]
        [StringLength(18, ErrorMessage = "Telephone cannot be longer than 18 characters.")]
        public string Telephone { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email format.")]
        [StringLength(345, ErrorMessage = "Email cannot be longer than 345 characters.")]
        public string Email { get; set; }

        [Required]
        [StringLength(105, ErrorMessage = "Address cannot be longer than 105 characters.")]
        public string Address { get; set; }

        [Required]
        [StringLength(180, ErrorMessage = "City's name cannot be longer than 180 characters.")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        [RegularExpression(@"^([0-9]|\-)*", ErrorMessage = "Invalid Postal Code format.")]
        [StringLength(80, ErrorMessage = "Postal cannot be longer than 80 characters.")]
        public string PostalCode { get; set; }

        public string Notes { get; set; }
    }
}
