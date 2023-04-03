using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSupport.Core.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "User Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "User Name is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,15}$", ErrorMessage = "Password Must contain Minimum eight and maximum 15 characters, at least one uppercase letter, one lowercase letter, one number and one special character")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Select Gender")]
        public string Gender { get; set; }

        //[DataType(DataType.PhoneNumber, ErrorMessage = "Not a number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please Add valid mobile Number")]
        public string MobileNumber { get; set; }

        public Guid? Id { get; set; }
        [Required(ErrorMessage = "Please Select Role")]
        [Display(Name = "Role")]
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        [Required(ErrorMessage = "Please Select Role")]
        public List<DropDown> dropDowns { get; set; }
    }

    public class DropDown
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
