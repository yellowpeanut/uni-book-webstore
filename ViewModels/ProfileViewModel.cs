using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class ProfileViewModel
    {
        [Required(ErrorMessage = "Данное поле обязательно для заполнения")]
        [StringLength(64)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Данное поле обязательно для заполнения")]
        [StringLength(32)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Данное поле обязательно для заполнения")]
        [StringLength(64)]
        public string Email { get; set; }
    }
}
