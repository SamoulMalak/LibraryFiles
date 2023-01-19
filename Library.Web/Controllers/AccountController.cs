using Library.Web.Models.Account;
using Library.Web.Models.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager
                                 ,SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid) 
            {
                var User= new IdentityUser { UserName=model.UserName, Email=model.Email };
                var result = await userManager.CreateAsync(User,model.Password);
                if (result.Succeeded) 
                {
                   await  signInManager.SignInAsync(User, model.RememberMe);
                    return RedirectToAction("index", "home");
                }
                else return View(model);
            }
           else return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {

            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogIn model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
            var user=  await  signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe,false);
                if (user.Succeeded)
                {
                    if (!(string.IsNullOrEmpty(returnUrl)))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    var errorModel = new ErrorModel
                    {
                        ErrorName = "Log In Error",
                        ErrorDescription = "An error occur while Loging in ,, pleace Check Your internet" +
                        "and Try againe to Log In",
                        ActionRedirect="LogIn",
                        ControllerRedirect="Account",
                        ButtonName="Log In Again"
                        
                    };
                    return View("/Views/Shared/Error.cshtml",errorModel);
                }
               
            }
            return RedirectToPage("Error");
        }


        //this two methods for identification user name and email are in use or not 


        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsUserNameInUse(string username)
        {
            var result = await userManager.FindByNameAsync(username);
            if (result != null)
            {
                return Json($"This User Name \"{username}\" are in Use .... Please Change it  ");
            }
            else
            {
                return Json($"This User Name Is Good {username}");
            }
        }

       [AcceptVerbs("Get","Post")]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var result = await userManager.FindByEmailAsync(email);
            if (result !=null)
            {
                return Json($"This Email \"{email}\" is in Use ....Please Change it ");
            }
            else
            {
                return Json($"This User Email Is Good {email}");

            }

        }

        [AcceptVerbs("Get", "Post")]

        public async Task<IActionResult> IsExistUserName(string username )
        {
           var userResult = await userManager.FindByNameAsync(username);
            if (userResult != null)
            { 
                return Json(true);
            }
            else
            {
                return Json($"There is no User Name  with this name \"{username}\" ");
            }
        }
    }
}
