using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Library.Web.Models.Account
{
    public class LogIn
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a valid User Name ")]
        [MinLength(3, ErrorMessage = "User Name Must be More than 2 character")]
        [MaxLength(30, ErrorMessage = "User Name Must not be more than 30 character")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }



        [Required(ErrorMessage = "You must enter a password ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Remember Me")]
        [Required(ErrorMessage = "This field is required ,,,,Please")]

        public bool RememberMe { get; set; }
    }
}
