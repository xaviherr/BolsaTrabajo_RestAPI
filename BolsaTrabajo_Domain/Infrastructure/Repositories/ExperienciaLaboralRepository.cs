using BolsaTrabajo_Domain.Core.Entities;
using BolsaTrabajo_Domain.Core.Interfaces;
using BolsaTrabajo_Domain.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaTrabajo_Domain.Infrastructure.Repositories
{
    public class ExperienciaLaboralRepository : IExperienciaLaboralRepository
    {
        private readonly PostulacionesDBContext _context;

        public ExperienciaLaboralRepository(PostulacionesDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExperienciaLaboral>> GetExperienciasLaborales()
        {
            return await _context.ExperienciaLaboral.ToListAsync();
        }

        public async Task<ExperienciaLaboral> GetExperienciaLaboralById(int id)
        {
            return await _context.ExperienciaLaboral.Where(x => x.IdExperiencia == id).FirstOrDefaultAsync();
        }

        public async Task InsertExperienciaLaboral(ExperienciaLaboral experiencia)
        {
            _context.ExperienciaLaboral.Add(experiencia);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateExperienciaLaboral(ExperienciaLaboral experiencia)
        {
            var experienciaNow = await _context.ExperienciaLaboral.Where(x => x.IdExperiencia == experiencia.IdExperiencia).FirstOrDefaultAsync();

            if (experienciaNow == null)
                return false;

            experienciaNow.Organizacion = experiencia.Organizacion;
            experienciaNow.Puesto = experiencia.Puesto;
            experienciaNow.Descripcion = experiencia.Descripcion;
            experienciaNow.FechaFin = experiencia.FechaFin;
            experienciaNow.FechaInicio = experiencia.FechaInicio;

            int countRows = await _context.SaveChangesAsync();

            return (countRows > 0);
        }

        public async Task<bool> DeleteExperienciaLaboral(int id)
        {
            var experienciaNow = await _context.ExperienciaLaboral.Where(x => x.IdExperiencia == id).FirstOrDefaultAsync();

            if (experienciaNow == null)
                return false;

            _context.ExperienciaLaboral.Remove(experienciaNow);

            int countRows = await _context.SaveChangesAsync();

            return (countRows > 0);
        }
    }
}
