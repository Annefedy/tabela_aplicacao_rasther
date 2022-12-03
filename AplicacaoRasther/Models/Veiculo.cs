using System.Collections.Generic;

namespace AplicacaoRasther.Models
{
    public class Veiculo
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public List<Veiculo> VeiculoList { get; set; } = new List<Veiculo>();
    }
}
