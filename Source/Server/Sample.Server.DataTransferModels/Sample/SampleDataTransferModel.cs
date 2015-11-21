namespace Sample.Server.DataTransferModels.Sample
{
    using System.ComponentModel.DataAnnotations;
    using Data.Common.Constants;

    public class SampleDataTransferModel
    {
        [Required]
        [MaxLength(ValidationConstants.SampleDescriptionMaxLength, ErrorMessage = ValidationConstants.SampleDescriptionLengthErrorMessage)]
        [MinLength(ValidationConstants.SampleDescriptionMinLength, ErrorMessage = ValidationConstants.SampleDescriptionLengthErrorMessage)]
        public string Description { get; set; }
    }
}