using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZodiacSignLibrary.Models.Entities
{
    public class Admin
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? SurnameAdmin { get; set; }
        public string? NameAdmin { get; set; }
        public string? EmailAdmin { get; set; }
        public string LoginAdmin { get; set; }
        public string PasswordAdmin { get; set; }

    }
}
