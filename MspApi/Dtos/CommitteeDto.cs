using System.ComponentModel.DataAnnotations;

namespace MspApi.Dtos
{
    public class CommitteeDto
    {
        [Key]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(5000)]
        public string Description { get; set; }

    }
}
