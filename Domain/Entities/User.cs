using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(20)")]
        public string Password { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string UserName { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserRole Role { get; set; }
    }

    public enum UserRole
    {
        Admin,
        Client,
        Professor,
    }
}
