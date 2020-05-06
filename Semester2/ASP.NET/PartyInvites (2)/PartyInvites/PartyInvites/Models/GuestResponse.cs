using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage ="please enter your name")]
        public string  Name { get; set; }
        [Required(ErrorMessage = "please enter your Email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "please enter your Phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please specify if you attend")]
        public bool? WillAttend { get; set; }
    }
}
