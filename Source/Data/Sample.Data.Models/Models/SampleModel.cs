namespace Sample.Data.Models.Models
{
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SampleModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.SampleDescriptionMaxLength, ErrorMessage = ValidationConstants.SampleDescriptionLengthErrorMessage)]
        [MinLength(ValidationConstants.SampleDescriptionMinLength, ErrorMessage = ValidationConstants.SampleDescriptionLengthErrorMessage)]
        public string Description { get; set; }
    }
}