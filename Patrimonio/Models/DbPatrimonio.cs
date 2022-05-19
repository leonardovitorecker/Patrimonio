using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patrimonio.Models
{
    [Table("patrimonio",Schema="public")]
    public class DbPatrimonio
    {
        [Key]
        public int Id { get; set; }
        public string? numeEtiqueta { get; set; }
        public string? nomePatrimonio { get; set; }
        public string? descricaoPatrimonio { get; set; }
        public decimal valorPatrimonio { get; set; }
        public int idCategoria { get; set; }
        public int idLocal { get; set; }
        public string? marcaModelo { get; set; }
        public DateTime dataAquisicao { get; set; }
        public DateTime dataBaixa { get; set; }
        public int numF { get; set; }
        public string? numSerie { get; set; }
        public string? situacao { get; set; }

        public int idFornecedor { get; set; }
        public DateTime dataGarantia { get; set; }
    }
}
