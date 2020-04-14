using Microsoft.AspNetCore.Mvc;
using PortourgalAPI.Models;
using PortourgalAPI.Services;
using System.Collections.Generic;

namespace PortourgalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistritosController : ControllerBase
    {
        private readonly DistritoService _distritoService;

        public DistritosController(DistritoService distritoService)
        {
            _distritoService = distritoService;
        }

        // GET: api/Distritos
        [HttpGet]
        public ActionResult<List<Distrito>> Get()
        {
            return _distritoService.Get();
        }

        // GET: api/Distritos/Braga
        [HttpGet("{nome}", Name = "GetDistrito")]
        public ActionResult<Distrito> GetByNome(string nome)
        {
            var distrito = _distritoService.GetByNome(nome);

            if (distrito == null)
            {
                return NotFound();
            }

            return distrito;
        }

        // POST: api/Distritos
        [HttpPost]
        public ActionResult<Distrito> Post(Distrito distrito)
        {
            _distritoService.Create(distrito);
            return CreatedAtRoute("GetDistrito", new { nome = distrito.Nome }, distrito);
        }

        // PUT: api/Distritos/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, Distrito distritoIn)
        {
            var user = _distritoService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _distritoService.Update(id, distritoIn);

            return NoContent();
        }

        // DELETE: api/Distritos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var distrito = _distritoService.Get(id);

            if (distrito == null)
            {
                return NotFound();
            }

            _distritoService.Remove(distrito.Id);

            return NoContent();
        }
    }
}
