using AutoMapper;
using HouseRentWebApi.Domain;
using HouseRentWebApi.Shared.Contracts;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Please, provied full name.")]
        [StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please, provied user name.")]
        [StringLength(20, MinimumLength = 2)]
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please, provied valid email address.")]
        [RegularExpression("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please, provied valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, provied valid password.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please, provied valid password.")]
        [Compare("Password", ErrorMessage = "Password cannot matched! Try again.")]
        public string ConfirmPassword { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, RegisterModel>();
            profile.CreateMap<RegisterModel, User>();
        }
    }

    public class LoginModel : IMapFrom<User>
    {
        [Required(ErrorMessage = "Please, provied valid email address.")]
        [RegularExpression("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please, provied valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, provied valid password.")]
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