namespace CompanySystem.Data.Models.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using Common.Constants;

    public class City
    {
        private ICollection<User> users;

        public City()
        {
            this.users = new HashSet<User>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CityNameMaxLength, ErrorMessage = ValidationConstants.CityNameMaxLengthErrorMessage)]
        [MinLength(ValidationConstants.CityNameMinLength, ErrorMessage = ValidationConstants.CityNameMinLengthErrorMessage)]
        public string Name { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<User> Users
        {
            get
            {
                return this.users;
            }
            set
            {
                this.users = value;
            }
        }
    }
}