namespace MyFirstCRUD.Entity
{
    public enum Frequencia
    {
        Nenhum,
        Diario,
        Semanal,
        Mensal
    }

    public class LembreteEntity
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Frequencia Frequencia { get; set; }
        public int Pessoa_Id { get; set; }
    }
}
