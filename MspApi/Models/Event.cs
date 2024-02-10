using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MspApi.Models
{
    public class Event
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


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
