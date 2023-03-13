using Microsoft.AspNetCore.Identity;
using MyClinic.DAL.Models;

namespace MyClinic.Interfaces
{
    public interface IIdentityProvider
    {
        public Task<Dictionary<IdentityResult, User>> CreateUserAsync(string Email, string FirstName, string SecondName, string LastName, string password, string phone = "123", string specialty = "test");
    }
}
