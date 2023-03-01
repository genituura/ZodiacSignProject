using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ZodiacSignLibrary.Models.Entities
{
    public class Client
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? SurnameClient { get; set; }
        public string? NameClient { get; set; }
        public string? EmailClient { get; set; }
        public string LoginClient { get; set; }
        public string PasswordClient { get; set; }
    }
}
