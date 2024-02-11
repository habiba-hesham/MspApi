using System.ComponentModel.DataAnnotations;

namespace MspApi.Models
{
    public class Session
    {
        public int Id { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }
        [Url]
        public string SessionPDF { get; set; }

        [Url]
        public string Video { get; set; }

        public Committee Committee { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}
