using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MspApi.Models
{
    public class Admin
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required]
        [MaxLength(11), RegularExpression("^[0-9]{11}$", ErrorMessage = "StudentId number must be 11 digits")]
        public string StudentId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Please enter characters like (a~z , A~Z ) not more")]
        public string Name { get; set; }

        [Required]
        [MaxLength(150), EmailAddress, RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Gmail { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Please enter characters like (a~z , A~Z ) not more")]
        public string Role { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9@-._]*$", ErrorMessage = "Please enter characters like (a~z , A~Z , 0~9 , @ , _ , -) not more")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }

        [Required]
        [Phone, RegularExpression("^[0-9]{11}$", ErrorMessage = "Phone number must be 11 digits")]
        public string Moblie { get; set; }

        [Required]
        [RegularExpression("^[1-4]{1}$", ErrorMessage = "level is int must be 1 digits  between  1~>4")]
        public int Level { get; set; }

        //[ForeignKey("Committee")]
        //public string CommName { get; set; }
        //public virtual Committee Committee { get; set; }

        [Url]
        public string URLPhoto { get; set; }
    }
}