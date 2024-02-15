using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MspApi.Models
{
    public class Committee
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(50), MinLength(2)]
        [RegularExpression(@"^[a-zA-Z0-9@,._\s]+$", 
            ErrorMessage = "in Name Please enter characters like (a~z, A~Z, 0~9, @, _, ., ,, space) not more")]
        public string Name { get; set; }

        [Required]
        [StringLength(5000), RegularExpression(@"^[a-zA-Z0-9@,._\s]+$",
            ErrorMessage = "in Description Please enter characters like (a~z, A~Z, 0~9, @, _, ., ,, space) not more")]
        public string Description { get; set; }

        [Url]
        public string Image {  get; set; }
        

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