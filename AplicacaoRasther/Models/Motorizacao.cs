using System.Collections.Generic;

namespace AplicacaoRasther.Models
{
    public class Motorizacao
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public List<Motorizacao> MotorizacaoList { get; set; } = new List<Motorizacao>();
    }
}
