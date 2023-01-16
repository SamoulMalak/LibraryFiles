using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Library.Web.Models.Account
{
    public class Register
    {
        // her type the prop that 
        // must the user enter by it 

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a valid User Name ")]
        [MinLength(3,ErrorMessage ="User Name Must be More than 2 character")]
        [MaxLength(30,ErrorMessage ="User Name Must not be more than 30 character")]
        [Display(Name ="User Name")]
        [Remote(action: "IsUserNameInUse", controller:"Account")]
        public string UserName { get; set; }


        [Required(AllowEmptyStrings =false,ErrorMessage ="Please enter a valid Email ")]
        [DataType (DataType.EmailAddress,ErrorMessage ="Please enter a valid email ")]
        [Remote(action: "IsEmailInUse",controller:"Account")]
        public string Email { get; set; }

        [Display(Name = "Remember Me")]
        [Required(ErrorMessage = "This field is required ,,,,Please")]

        public bool RememberMe { get; set; }


        [Required( ErrorMessage = "You must enter a password ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage = "The two passwords do not match!!!!")]
        public string ConfirmPassword { get; set; }
    }
}
