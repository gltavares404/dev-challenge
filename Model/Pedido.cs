namespace API_FullTrack.Model
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Endereco { get; set; }
        public string Horario { get; set; }
        public string Data { get; set; }

        public Pedido(string titulo, string endereco, string horario, string data)
        {
            Titulo = titulo;
            Endereco = endereco;
            Horario = horario;
            Data = data;

        }
    }
}
