using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MspApi.Models
{
    public class Committee
    {

        [Key]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(5000)]
        public string Description { get; set; }

        

       // public virtual List<Crew> Crew { get; set; }
       // public virtual List<Admin> Admin { get; set; }
        //[JsonIgnore]

       // [ForeignKey("SuperAdmin")]
       // public int SuperAdminID { get; set; }
       // public virtual SuperAdmin SuperAdmin { get; set; }



    }
}
/*
 
 crew.commm => hr

selet Committees where  crew.commm => hr
 
 */