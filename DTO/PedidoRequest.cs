using API_FullTrack.Model;
using System.ComponentModel.DataAnnotations;

namespace API_FullTrack.DTO
{
    public class PedidoRequest
    {
        public int Id { get; set; }

        public string Titulo { get; set; }
        public string Endereco { get; set; }
        public string Horario { get; set; }

        public string Data { get; set; }

        public Pedido toModel()
            => new Pedido(Titulo, Endereco, Horario, Data);
    }
}
