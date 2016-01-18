namespace CompanySystem.Server.DataTransferModels.Users
{
    using Common.Mappings.Contracts;
    using Data.Common.Constants;
    using Data.Models.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserDetailedDataTransferModel : IMapFrom<User>
    {
        [MaxLength(ValidationConstants.FirstNameMaxLength, ErrorMessage = ValidationConstants.FirstNameMaxLengthErrorMessage)]
        [MinLength(ValidationConstants.FirstNameMinLength, ErrorMessage = ValidationConstants.FirstNameMinLengthErrorMessage)]
        public string FirstName { get; set; }

        [MaxLength(ValidationConstants.LastNameMaxLength, ErrorMessage = ValidationConstants.LastNameMaxLengthErrorMessage)]
        [MinLength(ValidationConstants.LastNameMinLength, ErrorMessage = ValidationConstants.LastNameMinLengthErrorMessage)]
        public string LastName { get; set; }

        [MaxLength(ValidationConstants.UsernameMaxLength, ErrorMessage = ValidationConstants.UsernameMaxLengthErrorMessage)]
        [MinLength(ValidationConstants.UsernameMinLength, ErrorMessage = ValidationConstants.UsernameMinLengthErrorMessage)]
        public string UserName { get; set; }

        [MinLength(ValidationConstants.EmailMinLength, ErrorMessage = ValidationConstants.EmailMinLengthErrorMessage)]
        public string Email { get; set; }
    }
}
