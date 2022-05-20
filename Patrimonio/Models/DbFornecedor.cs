using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patrimonio.Models
{
    [Table("fornecedor", Schema="public")]
    public class DbFornecedor
    {
       [Key]
       public int id { get; set; }
        public string? nomefornecedor { get; set; }
        public string? endereco { get; set; }
        public string? fone { get; set; }
    }
}
