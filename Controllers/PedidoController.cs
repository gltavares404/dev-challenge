using API_FullTrack.Context;
using API_FullTrack.DTO;
using API_FullTrack.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API_FullTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PedidoController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public PedidoController()
        {
            _dataContext = new DataContext();
        }

        // GET: api/<PedidoController>
       
        [HttpGet]
        public ActionResult<List<Pedido>> Get()
        {
            var pedido = _dataContext.Pedido.ToList();
            return pedido;
        }

        // POST api/<PedidoController>
        [HttpPost]
        public ActionResult<Pedido> Post([FromBody] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                var pedido1 = pedido;
                _dataContext.Pedido.Add(pedido1);
                _dataContext.SaveChanges();
                return pedido1;
            }
            return BadRequest(ModelState);
        }

        // PUT api/<PedidoController>/5

        [HttpPut]
        public ActionResult<Pedido> Put([FromBody] Pedido pedido)
        {
            var itemExistente = _dataContext.Pedido.Any(i => i.Id == pedido.Id);
            if (!itemExistente)
                ModelState.AddModelError("PedidosId", "Id de pedidos não encontrado!");

            if (ModelState.IsValid)
            {
                _dataContext.Pedido.Update(pedido);
                _dataContext.SaveChanges();
                return pedido;
            }
            return BadRequest(ModelState);
        }

        // DELETE api/PedidoController>/5
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var item = _dataContext.Pedido.Find(id);
            if (item == null)
                ModelState.AddModelError("PedidoId", "Id de Pedido não encontrado!");

            if (ModelState.IsValid)
            {
                _dataContext.Pedido.Remove(item);
                _dataContext.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
