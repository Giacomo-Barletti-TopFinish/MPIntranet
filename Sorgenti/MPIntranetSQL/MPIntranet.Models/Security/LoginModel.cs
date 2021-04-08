using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Security
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Account { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
