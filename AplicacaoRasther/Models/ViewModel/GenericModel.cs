namespace AplicacaoRasther.Models.ViewModel
{
    public class GenericModel
    {
        public Categoria Categoria { get; set; } = new Categoria();
        public Montadora Montadora { get; set; } = new Montadora();
        public TipoDeSistema TipoDeSistema { get; set; } = new TipoDeSistema();
        public Motorizacao Motorizacao { get; set; } = new Motorizacao();
        public Sistema Sistema { get; set; } = new Sistema();
        public Veiculo Veiculo { get; set; } = new Veiculo();
    }
}
