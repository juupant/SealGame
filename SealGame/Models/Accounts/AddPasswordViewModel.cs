using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SealGame.Models.Accounts
{
    public class AddPassWordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Type new password here: ")]
        public string NewPassword { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Type it again to confirm: ")]
        [Compare("NewPassword", ErrorMessage = "The new password and its confirmation do not match. Please retry.")]

        public string ConfirmPassword { get; set; }
    }
}
