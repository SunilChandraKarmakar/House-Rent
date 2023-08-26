using HouseRentWebApi.ApplicationLogic.AccountLogic.Model;
using HouseRentWebApi.ApplicationLogic.JwtExtensionsLogic;
using HouseRentWebApi.Common.Contracts;
using HouseRentWebApi.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HouseRentWebApi.ApplicationLogic.AccountLogic.Command
{
    public class LoginCommand : LoginModel, IRequest<UserModel>
    {
        public class Handler : IRequestHandler<LoginCommand, UserModel>
        {
            private readonly ICoreService _service;
            private readonly UserManager<User> _userManager;
            private readonly SignInManager<User> _signInManager;

            public Handler(ICoreService coreService, UserManager<User> userManager, SignInManager<User> signInManager)
            {
                _service = coreService;
                _userManager = userManager;
                _signInManager = signInManager;
            }

            public async Task<UserModel> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);

                if (result.Succeeded)
                {
                    var existUser = _service.Mapper.Map<UserModel>(await _userManager.FindByEmailAsync(request.Email));
                    existUser.Token = JwtExtensions.CreateJwt(existUser);

                    return existUser;
                }

                throw new Exception("User email and password cannot matched! Please, try again.");
            }
        }
    }
}