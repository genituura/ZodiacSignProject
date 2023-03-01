using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZodiacSignLibrary.Models.Entities
{
    public class Services
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        private DateTime _dateOfBirth;
        public DateTime DateOfBirth { 
            get => _dateOfBirth; 
            set => _dateOfBirth = DateTime.Parse(value.ToShortDateString()); 
        }

        private TimeOnly _timeOfBirth;
        public TimeOnly TimeOfBirth
        {
            get => _timeOfBirth;
            set => _timeOfBirth = TimeOnly.Parse(value.ToShortTimeString());
        }

        public string CityOfBirth { get; set; }
        public string DeliveryEmail { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
