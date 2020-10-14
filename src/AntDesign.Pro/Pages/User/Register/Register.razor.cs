using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Template.Pages.User
{
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Captcha { get; set; }
    }

    public partial class Register
    {
        private readonly RegisterModel _user = new RegisterModel();

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        public void HandleSubmit()
        {
            NavigationManager.NavigateTo("/user/register-result");
        }
    }
}