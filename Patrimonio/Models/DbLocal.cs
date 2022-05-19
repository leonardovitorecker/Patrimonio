using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patrimonio.Models
{
    [Table("local", Schema="public")]
    public class DbLocal
    {
        [Key]
        public int Id { get; set; }
        public string? nomeLocal{ get; set; }
        public string? descricaoLocal { get; set; }
    }
   
}
