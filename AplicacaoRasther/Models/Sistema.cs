using System.Collections.Generic;

namespace AplicacaoRasther.Models
{
    public class Sistema
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public List<Sistema> SistemasList { get; set; } = new List<Sistema>();
    }
}
