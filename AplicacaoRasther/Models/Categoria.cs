using System.Collections.Generic;

namespace AplicacaoRasther.Models
{
    public class Categoria
    {
        public string Nome { get; set; }
        public List<string> CategoriasList { get; set; } = new List<string>();
    }
}
