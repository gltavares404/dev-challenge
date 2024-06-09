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

    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public UsuarioController()
        {
            _dataContext = new DataContext();
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            var usuarios = _dataContext.Usuario.ToList();
            return usuarios;
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<Usuario> Post([FromBody] UsuarioRequest usuarioRequest)
        {
            if (ModelState.IsValid)
            {
                var usuario = usuarioRequest.toModel();
                _dataContext.Usuario.Add(usuario);
                _dataContext.SaveChanges();
                return usuario;
            }
            return BadRequest(ModelState);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut]
        public ActionResult<Usuario> Put([FromBody] Usuario usuario)
        {
            var usuarioENulo = _dataContext.Usuario.FirstOrDefault(usuario) == null;
            if (usuarioENulo)
                ModelState.AddModelError("UsuarioId", "Id do Usuario não encontrado!");

            if (ModelState.IsValid)
            {
                _dataContext.Usuario.Update(usuario);
                _dataContext.SaveChanges();
                return usuario;
            }
            return BadRequest(ModelState);

        }

        // DELETE api/UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var usuario = _dataContext.Usuario.Find(id);
            if (usuario == null)
                ModelState.AddModelError("UsuarioId", "Id do Usuario não encontrado!");

            if (ModelState.IsValid)
            {
                _dataContext.Usuario.Remove(usuario);
                _dataContext.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
