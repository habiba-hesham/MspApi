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

        public byte CommitteeId { get; set; }
        public Committee Committee { get; set; }
    }
}