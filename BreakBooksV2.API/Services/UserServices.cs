
using BreakBooks.Data.Dtos.UserDtos;
using BreakBooks.Models;
using Microsoft.AspNetCore.Identity;

namespace BreakBooks.Services
{
    public class UserServices
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenServices _tokenServices;
        public UserServices(SignInManager<User> signInManager, 
            UserManager<User> userManager, TokenServices tokenServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenServices = tokenServices;
        }
        internal async Task Register(User user, CreateUserDto dto)
        {
            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                throw new ApplicationException("Falha ao cadastrar");

        }

        internal async Task<string> SignIn(LoginUserDto dto)
        {
            var result = await _signInManager
                .PasswordSignInAsync(dto.UserName, dto.Password, false, false);

            if (!result.Succeeded)
                throw new ApplicationException("Erro ao fazer login");

            var user = _signInManager.UserManager.Users
                .FirstOrDefault(user => user.UserName == dto.UserName)!;
      
            var token = _tokenServices.Generate(user!);
            return token;
        }
    }
}