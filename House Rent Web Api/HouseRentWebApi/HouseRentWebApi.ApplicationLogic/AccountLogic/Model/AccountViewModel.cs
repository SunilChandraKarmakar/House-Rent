using AutoMapper;
using HouseRentWebApi.Domain;
using HouseRentWebApi.Shared.Contracts;

namespace HouseRentWebApi.ApplicationLogic.AccountLogic.Model
{
    public class AccountViewModel
    {
        public UserModel UserModel { get; set; }
        public RegisterModel RegisterModel { get; set; }
        public LoginModel LoginModel { get; set; }
    }

    public class RegisterModel : IMapFrom<User>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, RegisterModel>();
            profile.CreateMap<RegisterModel, User>();
        }
    }

    public class LoginModel : IMapFrom<User>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, LoginModel>();
            profile.CreateMap<LoginModel, User>();
        }
    }

    public class UserModel : IMapFrom<User>
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        //public DateTime CreatedTime { get; set; }
        //public DateTime LastModifiedTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserModel>();
        }
    }
}