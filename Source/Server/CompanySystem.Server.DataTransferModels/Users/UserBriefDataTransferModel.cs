namespace CompanySystem.Server.DataTransferModels.Users
{
    using Common.Mappings.Contracts;
    using Data.Common.Constants;
    using Data.Models.Models;
    using System.ComponentModel.DataAnnotations;

    public class UserBriefDataTransferModel : IMapFrom<User>
    {
        [MaxLength(ValidationConstants.UsernameMaxLength, ErrorMessage = ValidationConstants.UsernameMaxLengthErrorMessage)]
        [MinLength(ValidationConstants.UsernameMinLength, ErrorMessage = ValidationConstants.UsernameMinLengthErrorMessage)]
        public string UserName { get; set; }

        [MinLength(ValidationConstants.EmailMinLength, ErrorMessage = ValidationConstants.EmailMinLengthErrorMessage)]
        public string Email { get; set; }
    }
}