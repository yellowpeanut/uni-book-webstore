using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Данное поле обязательно для заполнения")]
        [StringLength(32)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Данное поле обязательно для заполнения")]
        [StringLength(64)]
        public string Email { get; set; }
    }
}