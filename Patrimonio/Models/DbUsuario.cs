using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patrimonio.Models
{
    [Table("usuario", Schema="public")]
    public class DbUsuario
    {
        [Key]
        public int Id { get; set; }
        public string? nome { get; set; }
        public string? login { get; set; }
        public string? senha { get; set; }
    }
}
