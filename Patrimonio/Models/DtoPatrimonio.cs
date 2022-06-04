


namespace Patrimonio.Models
{
    public class DtoPatrimonio
    {
        public int id { get; set; }
        public string nomepatrimonio { get; set; }
        public decimal valorpatrimonio { get; set; }
        public string descricaopatrimonio { get; set; }   
        public string? marcamodelo { get; set; }
        public string? numserie { get; set; }
        public string? situacao { get; set; }
        public string? numeetiqueta { get; set; }
        public int numf { get; set; }
        public DateTime dataaquisicao { get; set; }
        public DateTime databaixa { get; set; }
        public DateTime datagarantia { get; set; }
        public string nomelocal { get; set; }
        public string nomecategoria { get; set; }
        public string nomefornecedor { get; set; }
        public int idfornecedor { get; set; }
        public int idcategoria { get; set; }
        public int idlocal { get; set; }

    }
}
