using System.Collections.Generic;

namespace AplicacaoRasther.Models
{
    public class TipoDeSistema
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public List<TipoDeSistema> TiposDeSistemaList { get; set; } = new List<TipoDeSistema>();
    }
}

