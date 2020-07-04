using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortourgalAPI.Models;
using PortourgalAPI.Services;

namespace PortourgalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoteirosController : ControllerBase
    {
        private readonly RoteiroService _roteiroService;

        public RoteirosController(RoteiroService roteiroService)
        {
            _roteiroService = roteiroService;
        }

        // GET: api/Roteiros
        [HttpGet]
        public ActionResult<List<Roteiro>> Get()
        {
            return _roteiroService.Get();
        }

        // GET: api/Roteiros/5
        [HttpGet("{id}", Name = "GetRoteiro")]
        public ActionResult<Roteiro> Get(string id)
        {
            var rot = _roteiroService.Get(id);

            if (rot == null)
            {
                return NotFound();
            }

            return rot;
        }

        // GET: api/Roteiros/nome/VianaCastelo
        [HttpGet("nome/{nome}")]
        public ActionResult<Roteiro> GetByNome(string nome)
        {
            var rot = _roteiroService.GetByNome(nome);

            if (rot == null)
            {
                return NotFound();
            }

            return rot;
        }


        // POST: api/Roteiros
        [HttpPost]
        public ActionResult<Roteiro> Post(Roteiro rot)
        {
            _roteiroService.Create(rot);
            return CreatedAtRoute("GetRoteiro", new { id = rot.Id }, rot);
        }

        // PUT: api/Roteiros/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, Roteiro rotIn)
        {
            var rot = _roteiroService.Get(id);

            if (rot == null)
            {
                return NotFound();
            }

            _roteiroService.Update(id, rotIn);

            return NoContent();
        }

        // PUT: api/Roteiros/nome/VianaCastelo
        [HttpPut("nome/{nome}")]
        public IActionResult PutByNome(string nome, Roteiro rotIn)
        {
            var rot = _roteiroService.GetByNome(nome);

            if (rot == null)
            {
                return NotFound();
            }

            rotIn.Id = rot.Id;

            _roteiroService.UpdateByNome(nome, rotIn);

            return NoContent();
        }


        // DELETE: api/Roteiros/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var rot = _roteiroService.Get(id);

            if (rot == null)
            {
                return NotFound();
            }

            _roteiroService.Remove(rot.Id);

            return NoContent();
        }


        // DELETE: api/Roteiros/nome/VianaCastelo
        [HttpDelete("nome/{nome}")]
        public IActionResult DeleteByEmail(string nome)
        {
            var rot = _roteiroService.GetByNome(nome);

            if (rot == null)
            {
                return NotFound();
            }

            _roteiroService.RemoveByNome(rot.Nome);

            return NoContent();
        }
    }
}
