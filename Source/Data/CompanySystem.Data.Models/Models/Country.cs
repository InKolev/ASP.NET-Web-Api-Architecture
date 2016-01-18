namespace CompanySystem.Data.Models.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Constants;

    public class Country
    {
        private ICollection<City> cities;
        private ICollection<User> users;

        public Country()
        {
            this.cities = new HashSet<City>();
            this.users = new HashSet<User>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(ValidationConstants.CountryNameMaxLength, ErrorMessage = ValidationConstants.CountryNameMaxLengthErrorMessage)]
        [MinLength(ValidationConstants.CountryNameMinLength, ErrorMessage = ValidationConstants.CountryNameMinLengthErrorMessage)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities
        {
            get
            {
                return this.cities;
            }
            set
            {
                this.cities = value;
            }
        }

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