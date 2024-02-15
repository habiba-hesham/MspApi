using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MspApi.Models
{
    public class User
    {

         
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

         
        [MaxLength(11), RegularExpression("^[0-9]{11}$", ErrorMessage = "StudentId number must be 11 digits")]
        public string StudentId { get; set; }

         

        [MaxLength(50), MinLength(3)]
        [RegularExpression(@"^[a-zA-Z0-9@,._\s]+$", ErrorMessage = "in Name Please enter characters like (a~z, A~Z, 0~9, @, _, ., ,, space) not more")]
        public string Name { get; set; }

         
        [MaxLength(150), EmailAddress, RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Gmail { get; set; }


        
        [RegularExpression(@"^(User|Admin|Superadmin)$", ErrorMessage = "Invalid role. Please enter either 'User', 'Admin', or 'Superadmin'.")]
        public string Role { get; set; }


        [MaxLength(50), MinLength(3)]
        [RegularExpression(@"^[a-zA-Z0-9@,._\s]+$", ErrorMessage = " Please enter characters like (a~z, A~Z, 0~9, @, _, ., ,, space) not more")]
        public string Position { get; set; }

         
        [RegularExpression(@"^[a-zA-Z0-9@-._]*$", ErrorMessage = "Please enter characters like (a~z , A~Z , 0~9 , @ , _ , -) not more")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }


         
        [Phone, RegularExpression("^[0-9]{11}$", ErrorMessage = "Phone number must be 11 digits")]
        public string Moblie { get; set; }

         
        [RegularExpression("^[1-4]{1}$", ErrorMessage = "level is int must be 1 digits  between  1~>4")]
        public int Level { get; set; }

        [RegularExpression("^[0-9]{3}$", ErrorMessage = "rank is int must be 3 digits  between  0~>999")]
        public int Rank { get; set; }

        [Url]
        public string URL_QR { get; set; }


        [RegularExpression(@"^(Yes|No)$", ErrorMessage = "Invalid waiting. Please enter either 'Yes', or 'No'.")]
        public string Waiting { get;set; }  

        [Url]
        public string URLPhoto { get; set; }

        [ForeignKey("Committee")]
        public byte CommitteeId { get; set; }
        public virtual Committee Committee { get; set; }

    }
}
