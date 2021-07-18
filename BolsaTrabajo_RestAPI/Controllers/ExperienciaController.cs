using BolsaTrabajo_Domain.Core.Entities;
using BolsaTrabajo_Domain.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolsaTrabajo_RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienciaController : ControllerBase
    {
        private readonly IExperienciaLaboralRepository _experienciaRepository;

        public ExperienciaController(IExperienciaLaboralRepository experienciaRepository)
        {
            _experienciaRepository = experienciaRepository;
        }

        [HttpGet]
        [Route("GetExperiencias")]
        public async Task<IActionResult> GetExperiencias()
        {
            var experiencias = await _experienciaRepository.GetExperienciasLaborales();
            return Ok(experiencias);
        }

        [HttpGet]
        [Route("GetExperienciaById/{id}")]
        public async Task<IActionResult> GetExperienciaById(int id)
        {
            var experiencia = await _experienciaRepository.GetExperienciaLaboralById(id);

            if (experiencia == null)
                return NotFound();

            return Ok(experiencia);
        }

        [HttpPost]
        [Route("InsertExperiencia")]
        public async Task<IActionResult> InsertExperiencia(ExperienciaLaboral experiencia)
        {
            await _experienciaRepository.InsertExperienciaLaboral(experiencia);

            return Ok(experiencia);
        }

        [HttpPut]
        [Route("UpdateExperiencia")]
        public async Task<IActionResult> UpdateExperiencia(ExperienciaLaboral experiencia)
        {
            var result = await _experienciaRepository.UpdateExperienciaLaboral(experiencia);
            if (!result)
                return BadRequest();

            return Ok(new { result = "Success" });
        }

        //Intentar no usar delete
        [HttpDelete]
        [Route("DeleteExperiencia/{id}")]
        public async Task<IActionResult> DeleteExperiencia(int id)
        {
            var result = await _experienciaRepository.DeleteExperienciaLaboral(id);
            if (!result)
                return BadRequest();

            return Ok(new { result = "Success" });
        }
    }
}
