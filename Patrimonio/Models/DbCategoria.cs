



using Patrimonio.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patrimonio.Models
{
    [Table("categoria", Schema="public")]
    public class DbCategoria
    {
        [Key]   
        public int id { get; set; }
        public string? descricaoCategoria  { get; set; }

    }
}
