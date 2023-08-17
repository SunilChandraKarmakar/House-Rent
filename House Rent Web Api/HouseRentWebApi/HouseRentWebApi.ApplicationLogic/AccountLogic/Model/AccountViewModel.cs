using AutoMapper;
using HouseRentWebApi.Domain;
using HouseRentWebApi.Shared.Contracts;

namespace HouseRentWebApi.ApplicationLogic.AccountLogic.Model
{
    public class AccountViewModel
    {
        public UserModel UserModel { get; set; }
        public UserRegisterModel UserRegisterModel { get; set; }
    }

    public class UserRegisterModel : IMapFrom<User>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserRegisterModel>();
            profile.CreateMap<UserRegisterModel, User>();
        }
    }

    public class UserModel : IMapFrom<User>
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        //public DateTime CreatedTime { get; set; }
        //public DateTime LastModifiedTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserModel>();
        }
    }
}