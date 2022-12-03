using System.Collections.Generic;

namespace AplicacaoRasther.Models
{
    public class Montadora
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string NomeSpa { get; set; }
        public string NomeEng { get; set; }

        public List<Montadora> MontadoraList { get; set; } = new List<Montadora>();
    }
}
