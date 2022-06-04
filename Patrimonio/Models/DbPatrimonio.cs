using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patrimonio.Models
{
    [Table("patrimonio",Schema="public")]
    public class DbPatrimonio
    {
        [Key]
        public int id { get; set; }
        public string? numeetiqueta { get; set; }
        public string? nomepatrimonio { get; set; }
        public string? descricaopatrimonio { get; set; }
        public decimal valorpatrimonio { get; set; }
        public int idcategoria { get; set; }
        public int idlocal { get; set; }
        public string? marcamodelo { get; set; }
        public DateTime dataqquisicao { get; set; }
        public DateTime databaixa { get; set; }
        public int numf { get; set; }
        public string? numserie { get; set; }
        public string? situacao { get; set; }

        public int idfornecedor { get; set; }
        public DateTime datagarantia { get; set; } 
    }
}
