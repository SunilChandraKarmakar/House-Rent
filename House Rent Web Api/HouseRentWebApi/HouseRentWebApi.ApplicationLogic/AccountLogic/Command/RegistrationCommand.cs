using HouseRentWebApi.ApplicationLogic.AccountLogic.Model;
using HouseRentWebApi.Common.Contracts;
using HouseRentWebApi.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.AccountLogic.Command
{
    public class RegistrationCommand : RegisterModel, IRequest<UserModel>
    {
        public class Handler : IRequestHandler<RegistrationCommand, UserModel>
        {
            private readonly ICoreService _service;
            private readonly UserManager<User> _userManager;

            public Handler(ICoreService coreService, UserManager<User> userManager)
            {
                _service = coreService;
                _userManager = userManager;
            }

            public async Task<UserModel> Handle(RegistrationCommand request, CancellationToken cancellationToken)
            {
                var existUser = await _userManager.Users.Where(u => u.Email == request.Email).FirstOrDefaultAsync();

                if (existUser != null)
                    throw new Exception("Email allready exist! Try new one.");

                var registerUser = _service.Mapper.Map<User>(request);
                registerUser.UserName = request.UserName;
                registerUser.PhoneNumber = request.PhoneNumber;
                registerUser.CreatedTime = DateTime.UtcNow;
                registerUser.LastModifiedTime = DateTime.UtcNow;                

                var result = _userManager.CreateAsync(registerUser, request.Password);
                var registerCompleteUser = _service.Mapper.Map<UserModel>(registerUser);

                if (result.Result.Succeeded)
                    return registerCompleteUser;
                else
                    throw new Exception(result.Result.Errors.Select(s => s.Description).FirstOrDefault());
            }
        }
    }
}