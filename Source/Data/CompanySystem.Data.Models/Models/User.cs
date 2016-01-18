namespace CompanySystem.Data.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Common.Constants;
    using System.Linq;

    public class User : IdentityUser
    {
        [Required]
        [MaxLength(ValidationConstants.FirstNameMaxLength, ErrorMessage = ValidationConstants.FirstNameMaxLengthErrorMessage)]
        [MinLength(ValidationConstants.FirstNameMinLength, ErrorMessage = ValidationConstants.FirstNameMinLengthErrorMessage)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(ValidationConstants.LastNameMaxLength, ErrorMessage = ValidationConstants.LastNameMaxLengthErrorMessage)]
        [MinLength(ValidationConstants.LastNameMinLength, ErrorMessage = ValidationConstants.LastNameMinLengthErrorMessage)]
        public string LastName { get; set; }

        public virtual Country Country { get; set; }

        public virtual City City { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            // Add custom user claims here
            return userIdentity;
        }

        //: IValidatableObject
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    var isModelValid = this.EGN.All(Char.IsDigit);

        //    if (!isModelValid)
        //    {
        //        yield return new ValidationResult("EGN must contain only digits from 0 to 9 inclusive.", new[] { nameof(this.EGN) });
        //    }
        //}
    }
}