using Microsoft.AspNetCore.Identity;
using MyClinic.DAL.Models;
using MyClinic.Interfaces;

namespace MyClinic.Services
{
    public class IdentityProvider:IIdentityProvider
    {
        private readonly UserManager<User> _userManager;
        private readonly MyClinicContext db;
        public IdentityProvider(UserManager<User> userManager,MyClinicContext context)
        {
            _userManager = userManager;
            db= context;
        }
        public async Task<Dictionary<IdentityResult,User>> CreateUserAsync(string Email, string FirstName, string SecondName,string LastName,string password, string phone="123",string specialty="test")
        {
            User user = new User {UserName=Email, Email = Email, FirstName =FirstName,SecondName=SecondName,LastName=LastName,Phone=phone,Specialty=specialty };            
            var result = await _userManager.CreateAsync(user, password);
            Dictionary<IdentityResult, User> dictionary = new Dictionary<IdentityResult, User>();
            dictionary.Add(result, user);
            return dictionary;
        }
    }
}
