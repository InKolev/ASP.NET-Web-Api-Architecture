namespace Sample.Server.DataTransferModels.Sample
{
    using System.ComponentModel.DataAnnotations;
    using Data.Common.Constants;
    using Common.Mappings.Contracts;
    using Data.Models.Models;

    public class SampleDataTransferModel : IMapFrom<SampleModel>
    {
        [Required]
        [MaxLength(ValidationConstants.SampleDescriptionMaxLength, ErrorMessage = ValidationConstants.SampleDescriptionLengthErrorMessage)]
        [MinLength(ValidationConstants.SampleDescriptionMinLength, ErrorMessage = ValidationConstants.SampleDescriptionLengthErrorMessage)]
        public string Description { get; set; }
    }
}