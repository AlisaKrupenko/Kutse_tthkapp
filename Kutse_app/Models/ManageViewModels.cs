﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Kutse_app.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} peab olema vähemalt {2} tähemärki pikk.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Uus salasõna")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Kinnita Uus salasõna")]
        [Compare("NewPassword", ErrorMessage = "Uus parool ja kinnitusparool ei ühti.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Praegune salasõna")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} peab olema vähemalt {2} tähemärki pikk.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Uus salasõna")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Kinnita Uus salasõna")]
        [Compare("NewPassword", ErrorMessage = "Uus parool ja kinnitusparool ei ühti.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Telefoninumber")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Kood")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Telefoninumber")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}