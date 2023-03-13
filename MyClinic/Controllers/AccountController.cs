using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyClinic.DAL.Models;
using MyClinic.Interfaces;

namespace MyClinic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController:ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IIdentityProvider _identityProvider;
        public AccountController(SignInManager<User> signInManager, IIdentityProvider identityprovider)
        {
            _signInManager = signInManager;
            _identityProvider = identityprovider;
        }
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register()
        {
            string firstname = Request.Headers["fn"];
            string secondname = Request.Headers["sn"];
            string lastname = Request.Headers["ln"];
            string phone = Request.Headers["ph"];
            string email = Request.Headers["email"];
            string password = Request.Headers["psw"];
            string specialty = Request.Headers["sp"];
            if (ModelState.IsValid)
            {
                var dictionary =await _identityProvider.CreateUserAsync( email, firstname, secondname, lastname, password,phone = "123", specialty = "test");

                if (dictionary.ElementAt(0).Key.Succeeded)
                {
                    await _signInManager.SignInAsync(dictionary.ElementAt(0).Value, false);
                    return Content("OK");
                }
                else
                {
                    foreach (var error in dictionary.ElementAt(0).Key.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return Content("Wrong");
        }
    }
}
