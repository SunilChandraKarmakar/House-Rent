using HouseRentWebApi.ApplicationLogic.AccountLogic.Model;
using HouseRentWebApi.ApplicationLogic.JwtExtensionsLogic;
using HouseRentWebApi.ApplicationLogic.JwtExtensionsLogic.Model;
using HouseRentWebApi.Common.Contracts;
using HouseRentWebApi.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace HouseRentWebApi.ApplicationLogic.AccountLogic.Command
{
    public class LoginCommand : LoginModel, IRequest<UserModel>
    {
        public class Handler : IRequestHandler<LoginCommand, UserModel>
        {
            private readonly ICoreService _service;
            private readonly JwtConfig _jwtConfig;
            private readonly UserManager<User> _userManager;
            private readonly SignInManager<User> _signInManager;

            public Handler(ICoreService coreService, UserManager<User> userManager, SignInManager<User> signInManager, IOptions<JwtConfig> jwtConfig)
            {
                _service = coreService;
                _userManager = userManager;
                _signInManager = signInManager;
                _jwtConfig = jwtConfig.Value;
            }

            public async Task<UserModel> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);

                if (result.Succeeded)
                {
                    var existUser = _service.Mapper.Map<UserModel>(await _userManager.FindByNameAsync(request.UserName));
                    existUser.Token = JwtExtensions.CreateJwt(existUser, _jwtConfig);

                    return existUser;
                }

                throw new Exception("Email and password cannot matched! Please, try again.");
            }
        }
    }
}