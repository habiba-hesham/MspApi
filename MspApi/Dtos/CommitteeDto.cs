using System.ComponentModel.DataAnnotations;

namespace MspApi.Dtos
{
    public class CommitteeDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        
        [StringLength(5000)]
        public string Description { get; set; }

        [Url]
        public string Image { get; set; }

    }
}
