using System.ComponentModel.DataAnnotations;

namespace QEApp.Web.Models
{
    public class OtpViewModel
    {
        [Required(ErrorMessage = "شماره موبایل الزامی است.")]
        [Display(Name = "شماره موبایل")]
        public string Mobile { get; set; }
    }
}
