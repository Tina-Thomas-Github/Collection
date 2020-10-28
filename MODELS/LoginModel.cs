using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MODELS
{
    public class LoginModel: ResponseMessageModel
    {
        [Required(ErrorMessage = "Username is required")] // make the field required
        [Display(Name = "Username")]  // Set the display name of the field
        public string username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        public string password { get; set; }
        //public string flag { get; set; }
        public string Role { get; set; }
        public DateTime ldLastLogin { get; set; }
        public DateTime ldLastPasswordUpdated { get; set; }

        public string oldPassword { get; set; }
    }
}
