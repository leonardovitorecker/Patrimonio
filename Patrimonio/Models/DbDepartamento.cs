using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patrimonio.Models
{
    [Table("departamento" , Schema="public")]
    public class DbDepartamento
    {
        [Key]
        public int Id { get; set; }
        public string? nomeDepartamento { get; set; }
        public string? descricaoDepartamento { get; set; }
        public int idLocal { get; set; }

    }
}
