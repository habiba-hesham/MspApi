using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MspApi.Models
{
    public class Event
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Please enter characters like (a~z , A~Z ) and spaces, not more")]
        public string Name { get; set; }

        [Required]
        [StringLength(5000)]
        public string Description { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{dd.MM.yyyy}"), DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{dd.MM.yyyy}"), DataType(DataType.DateTime)]
        public DateTime DeadTime { get; set; }

        [Required]
        [Url]
        public string FormLink { get; set; }

        [Url]
        [Required]
        public string Videos { get; set; }

        public string URLPhoto { get; set; }

        ///////////////////////////////////////////////////////////////////
        // public List<String> URLALLPhoto { get; set; }
    }
}