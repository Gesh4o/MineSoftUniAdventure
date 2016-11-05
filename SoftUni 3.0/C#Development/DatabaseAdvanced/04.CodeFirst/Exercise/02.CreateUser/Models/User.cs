namespace _02.CreateUser.Models
{
    using Attributes;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Users")]
    public class User 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        [PasswordValidation]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^(?:[a-zA-Z0-9](?:\.|\-|_)?)+[a-zA-Z0-9]+@\w+.\w+$")]
        public string Email { get; set; }

        [MaxLength(1024)]
        public byte[] ProfilePicture { get; set; }

        public DateTime? RegisteredOn { get; set; }

        public DateTime? LastTimeLoggedIn { get; set; }

        [Range(1,120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }
    }
}
